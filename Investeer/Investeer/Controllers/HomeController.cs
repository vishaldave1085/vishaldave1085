using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Investeer.Models.ViewModels;
using Investeer.DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Investeer.Utility;
using Investeer.DataAccess.Repository.IRepository;
using Investeer.Models.Models;
using static Investeer.Models.MyEnum;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Investeer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IEmailService _mailService;
        private readonly IMapper _mapper;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;

        public HomeController(ApplicationDbContext db, IEmailService mailService, IMapper mapper, SignInManager<ApplicationUser> signInManager, ILogger<HomeController> logger)
        {
            _db = db;
            _mailService = mailService;
            _mapper = mapper;
            _signInManager = signInManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.macomb = _mapper.Map<PropertyViewModel>(_db.PropertyDetail.FirstOrDefault(x => x.SheetName == "macomb"));
            ViewBag.oakland = _mapper.Map<PropertyViewModel>(_db.PropertyDetail.FirstOrDefault(x => x.SheetName == "oakland"));
            ViewBag.wayne = _mapper.Map<PropertyViewModel>(_db.PropertyDetail.FirstOrDefault(x => x.SheetName == "wayne"));
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult portfolio()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> QuickContact(int id, QuickContactViewModel model)
        {
            try
            {
                var prop = _db.PropertyDetail.Find(id);
                if (prop != null)
                {
                    var objProp = _mapper.Map<PropertyViewModel>(prop);

                    var email = new Email();
                    email.ToAdmin = true;
                    email.TemplateName = EmailTemplates.InvestAdmin;
                    await _mailService.SendEmailAsync<QuickContactViewModel, PropertyViewModel, Object>(email, model, objProp, null);

                    email = new Email();
                    email.ToEmails.Add(model.EmailId);
                    email.TemplateName = EmailTemplates.Invest;
                    await _mailService.SendEmailAsync<QuickContactViewModel, PropertyViewModel, Object>(email, model, objProp, null);

                    return Json(new { success = true });

                }
                return Json(new { success = false, msg = "Property not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return Json(new { success = false, msg = "Something went wrong!" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel model)
        {
            try
            {
                var email = new Email();
                email.ToAdmin = true;
                email.TemplateName = EmailTemplates.ContactAdmin;
                await _mailService.SendEmailAsync<ContactViewModel, Object, Object>(email, model, null, null);

                email = new Email();
                email.ToEmails.Add(model.Name+"<"+ model.EmailId+">");
                email.TemplateName = EmailTemplates.Contact;
                await _mailService.SendEmailAsync<ContactViewModel, Object, Object>(email, model, null, null);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return Json(new { success = false, msg = "Something went wrong!" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetProperty(string county = null, int pageIndex = 1, int pageSize = 9)
        {
            try
            {
                var lstProperty = new List<PropertyDetail>();
                decimal pageCount = 0;
                int dataCount = 0;
                county = Convert.ToString(county).ToLower();

                if (_signInManager.IsSignedIn(User))
                {
                    if (county == "all")
                    {
                        //dataCount = _db.PropertyDetail.Count();
                        //pageCount = Math.Floor(Convert.ToDecimal(dataCount / pageSize));
                        ////pageIndex = Convert.ToInt32(pageIndex < 1 ? (pageIndex > pageCount ? pageCount : pageIndex) : pageIndex);
                        //pageIndex = Convert.ToInt32(pageIndex > pageCount ? pageCount : pageIndex);
                        //lstProperty = _db.PropertyDetail.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();

                        pageCount = 3;
                        pageIndex = pageIndex < 1 ? 1 : pageIndex > 3 ? 3 : pageIndex;

                        var macomb = _db.PropertyDetail.Where(x => x.SheetName.ToLower() == "macomb").Skip(3 * (pageIndex - 1)).Take(pageSize).ToList();
                        var oakland = _db.PropertyDetail.Where(x => x.SheetName.ToLower() == "oakland").Skip(3 * (pageIndex - 1)).Take(pageSize).ToList();
                        var wayne = _db.PropertyDetail.Where(x => x.SheetName.ToLower() == "wayne").Skip(3 * (pageIndex - 1)).Take(pageSize).ToList();
                        for (int i = 0; i < 3; i++)
                        {
                            if (macomb != null)
                                lstProperty.Add(macomb[i]);
                            if (oakland != null)
                                lstProperty.Add(oakland[i]);
                            if (wayne != null)
                                lstProperty.Add(wayne[i]);
                        }
                    }
                    else
                    {
                        dataCount = _db.PropertyDetail.Where(x => x.SheetName.Equals(county)).Count();
                        pageCount = 1;
                        //pageCount = Math.Floor(Convert.ToDecimal(dataCount / pageSize));
                        //pageIndex = Convert.ToInt32(pageIndex < 1 ? (pageIndex > pageCount ? pageCount : pageIndex) : pageIndex);
                        pageIndex = Convert.ToInt32(pageIndex > pageCount ? pageCount : pageIndex);
                        lstProperty = _db.PropertyDetail.Where(x => x.SheetName.Equals(county)).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
                    }
                }
                else
                {
                    if (county == "all" || county == "macomb")
                    {
                        var macomb = _db.PropertyDetail.FirstOrDefault(x => x.SheetName.ToLower() == "macomb");
                        lstProperty.Add(macomb == null || String.IsNullOrEmpty(macomb.SheetName) ? new PropertyDetail() { SheetName = "Macomb" } : macomb);

                    }
                    if (county == "all" || county == "oakland")
                    {
                        var oakland = _db.PropertyDetail.FirstOrDefault(x => x.SheetName.ToLower() == "oakland");
                        lstProperty.Add(oakland == null || String.IsNullOrEmpty(oakland.SheetName) ? new PropertyDetail() { SheetName = "Oakland" } : oakland);
                    }
                    if (county == "all" || county == "wayne")
                    {
                        var wayne = _db.PropertyDetail.FirstOrDefault(x => x.SheetName.ToLower() == "wayne");
                        lstProperty.Add(wayne == null || String.IsNullOrEmpty(wayne.SheetName) ? new PropertyDetail() { SheetName = "Wayne" } : wayne);
                    }
                }

                return Json(new { properties = _mapper.Map<List<PropertyViewModel>>(lstProperty), pagecount = pageCount, pageindex = pageIndex });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return Json(new { msg = "Unable to fetch property" });
            }
        }

        public async Task<IActionResult> Property(string requestProp = null)
        {
            int ID = 0;
            if (string.IsNullOrEmpty(requestProp) || !int.TryParse(requestProp, out ID))
            {
                return RedirectToActionPermanent("portfolio", "Home");
            }
            return View(_mapper.Map<PropertyViewModel>(_db.PropertyDetail.Find(ID)));
        }
    }
}
