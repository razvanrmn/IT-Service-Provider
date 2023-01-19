using ProiectFinal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static MultiLanguage.Models.ProductModel;

namespace MultiLanguage.Models
{
    public class AccountModel
    {
        [Key] 
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Username", ResourceType = typeof(MultiLanguage.Res.Resource))]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
       // [RegularExpression(@"[a-z0-9]{6,}", ErrorMessage = "Please enter min 6 characters password")]

        [Display(Name = "Password", ResourceType = typeof(MultiLanguage.Res.Resource))]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format")]
        [Display(Name = "Email", ResourceType = typeof(MultiLanguage.Res.Resource))]
        public string Email { get; set; }
        
    }
    public class MainDbContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<ReviewModel> Reviews { get; set; }
        public DbSet<ShoppingListModel> ShoppingList { get; set; }
    }
}