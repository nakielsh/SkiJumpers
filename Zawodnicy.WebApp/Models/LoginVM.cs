using System;
using System.ComponentModel.DataAnnotations;

namespace Zawodnicy.WebApp.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Nazwa uzytkownika jest wymagana ...")]
        [Display(Name = "Nazwa uzytkownika")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Haslo jest wymagane")]
        [Display(Name ="Haslo")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}
