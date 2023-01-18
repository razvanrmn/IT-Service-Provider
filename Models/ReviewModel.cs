using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Xml.Linq;

namespace ProiectFinal.Models
{
    public class ReviewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "User", ResourceType = typeof(MultiLanguage.Res.Resource))]
        public string User { get; set; }
        [Display(Name = "NumberOfStars", ResourceType = typeof(MultiLanguage.Res.Resource))]
        public int NumberOfStars { get; set; }
        [Display(Name = "Message", ResourceType = typeof(MultiLanguage.Res.Resource))]
        public string Message { get; set; }

    }
}