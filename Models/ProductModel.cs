using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Xml.Linq;

namespace MultiLanguage.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(MultiLanguage.Res.Resource))]
        public string Name { get; set; }

        [Display(Name = "Price", ResourceType = typeof(MultiLanguage.Res.Resource))]

        public int Price { get; set; }

        [Display(Name = "Description", ResourceType = typeof(MultiLanguage.Res.Resource))]
        public string Description { get; set; }
    }
}