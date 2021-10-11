using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using static Investeer.Models.MyEnum;

namespace Investeer.Models.Models
{
    public class Email
    {
        public Email()
        {
            ToEmails = new List<string>();
        }
        public List<string> ToEmails { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
        public EmailTemplates TemplateName { get; set; }
        public bool ToAdmin { get; set; }
    }
}
