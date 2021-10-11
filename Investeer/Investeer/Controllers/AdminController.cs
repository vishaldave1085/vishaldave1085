using Investeer.Models.Models;
using Investeer.Models;
using Investeer.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Investeer.Utility;
using Investeer.DataAccess.Repository.IRepository;
using Investeer.DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Linq.Dynamic.Core;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Http.Headers;

namespace Investeer.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _userId;

        public AdminController(ILogger<AdminController> logger, ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FileUpload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FileUpload(FileUploadViewModel FileModel)
        {
            if (FileModel == null || FileModel.File == null || FileModel.File.Length == 0)
            {
                ViewBag.Toast = "toast('error','Please select file')";
                return View();
            }
            if (FileModel.File.FileName.Substring(FileModel.File.FileName.LastIndexOf(".") + 1) != "xlsx")
            {
                ViewBag.Toast = "toast('error','Please select .xlsx file')";
                return View();
            }
            var mypath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files");
            if (!Directory.Exists(mypath))
            {
                Directory.CreateDirectory(mypath);
            }
            var Images = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "PropertyImages");
            if (Directory.Exists(Images))
            {
                Directory.Delete(Images, true);
            }
            if (!Directory.Exists(Images))
            {
                Directory.CreateDirectory(Images);
            }

            var path = Path.Combine(mypath,
                        string.Format("{0:yyyyMMdd_HHmmssfff}", DateTime.Now) + "_" + FileModel.File.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await FileModel.File.CopyToAsync(stream);
            }
            var success = ProcessData(path);
            if (success)
            {
                ViewBag.Toast = "toast('success','File Uploaded successfully')";
                ViewBag.DynamicScripts = "GetData()";
            }

            else
            {
                ViewBag.Toast = "toast('error','Due to some technicle issue, file upload failed')";
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult GetDataTable()
        {
            var myprop = Enum.GetNames(typeof(MyEnum.DC)).ToList();

            var columns = _db.PropertyName.ToList()
                            .OrderBy(item => myprop.ToList().IndexOf(item.Column))
                            .Where(x => !string.IsNullOrEmpty(x.Name))
                            .Select(x => new { title = x.Name, data = x.Column }).ToList();
            var county = columns.FirstOrDefault(x => x.title.Equals("County"));
            columns.Remove(county);
            columns.Insert(0, county);
            //columns.Insert(0, new { title = "County", data = "SheetName" });
            var myfields = string.Join(",", myprop);
            var entries = _db.PropertyDetail.Select("new(" + myfields + ")").ToDynamicList();

            return Json(new { columns = columns, data = entries });
        }

        private bool ProcessData(string path)
        {
            var datas = path.ExcelToList<PropertyDetail>(_userId, 3).ToList();
            if (datas != null && datas.Count() > 0)
            {
                _db.PropertyName.RemoveRange(_db.PropertyName);
                _db.SaveChanges();


                var cols = Enum.GetNames(typeof(MyEnum.DC));

                _db.PropertyName.AddRange(
                    cols.Where(x => typeof(PropertyDetail).GetProperty(x) != null)
                    .Select(y => new PropertyName()
                    {
                        Column = y,
                        Name = Convert.ToString(typeof(PropertyDetail).GetProperty(y).GetValue(datas[0], null))
                    }));

                _db.SaveChanges();

                datas.RemoveAt(0);

                //_db.PropertyImage.RemoveRange(_db.PropertyImage);
                _db.PropertyDetail.RemoveRange(_db.PropertyDetail);

                _db.SaveChanges();

                _db.PropertyDetail.AddRange(datas.ToArray());
                _db.SaveChanges();

                var datalist = _db.PropertyDetail.Select(x => new { B = x.B, ID = x.ID }).ToList();

                //Task.Factory.StartNew(() =>
                //{
                //    Parallel.ForEach(datalist, x => ProcessImages(x.B, x.ID, _db));
                //});

                //foreach(var x in datalist)
                //{
                //    ProcessImages(x.B, x.ID, _db);
                //}
                //ProcessImages(_db.PropertyDetail.FirstOrDefault().B, _db.PropertyDetail.FirstOrDefault().ID);

                return true;
            }


            return false;
        }

        //private void ProcessImages(string url, int id,ApplicationDbContext db)
        //{
        //    try
        //    {
        //        using (HttpClient hc = new HttpClient())
        //        {
        //            string contentType = "text/html";
        //            hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
        //            var userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.63 Safari/537.36";
        //            hc.DefaultRequestHeaders.Add("User-Agent", userAgent);

        //            var strHtml = hc.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        //            var ulRegex = "<ul class=\"media-stream media-stream--initial\">[^>]*?>([\\s\\S]*?)</ul>";
        //            Regex rx = new Regex(ulRegex, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        //            MatchCollection matches = rx.Matches(strHtml);
        //            if (matches.Count > 0)
        //            {
        //                Regex rxi = new Regex("<img.*?src=\"(.*?)\" alt=\"\"/>", RegexOptions.Multiline | RegexOptions.IgnoreCase);
        //                var imges = rxi.Matches(matches[0].Value).ToList();
        //                foreach (var x in imges)
        //                {
        //                    if (x.Groups.Count > 1)
        //                    {
        //                        db.PropertyImage.Add(new PropertyImage() { PropertyDetailId = id,ImageUrl= x.Groups[1].Value });
        //                    }
        //                }

        //            }
        //        }
        //        db.SaveChanges();

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Image extraction failed for " + id.ToString());
        //    }
        //}

        //private void ProcessImages(string url, int id)
        //{
        //    try
        //    {
        //        var ImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "PropertyImages", id.ToString());
        //        if (!Directory.Exists(ImagePath))
        //        {
        //            Directory.CreateDirectory(ImagePath);
        //        }
        //        using (HttpClient hc = new HttpClient())
        //        {
        //            var strHtml = hc.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        //            var ulRegex = "<ul class=\"media-stream media-stream--initial\">[^>]*?>([\\s\\S]*?)</ul>";
        //            Regex rx = new Regex(ulRegex, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        //            MatchCollection matches = rx.Matches(strHtml);
        //            if (matches.Count > 0)
        //            {
        //                Regex rxi = new Regex("<img.*?src=\"(.*?)\" alt=\"\"/>", RegexOptions.Multiline | RegexOptions.IgnoreCase);
        //                var imges = rxi.Matches(matches[0].Value).ToList();
        //                foreach(var x in imges)
        //                {
        //                    DownloadImage(x, ImagePath, imges.IndexOf(x));
        //                }

        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Image extraction failed for " + id.ToString());
        //    }
        //}

        //private void DownloadImage(Match img, string path, int id)
        //{
        //    try
        //    {
        //        if (img.Groups.Count > 1)
        //        {
        //            using (WebClient wc = new WebClient())
        //            {
        //                wc.DownloadFile(img.Groups[1].Value, Path.Combine(path, id.ToString() + img.Groups[1].Value.Substring(img.Groups[1].Value.LastIndexOf('.'))));
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Image downloading failed for " + path.Substring(path.LastIndexOf("\\") + 1));
        //    }

        //}
    }
}
