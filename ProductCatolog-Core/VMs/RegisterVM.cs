using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatolog_Core.VMs
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "İsim girilmesi zorunludur!")]
        [DisplayName("İsim")]
        public string FirstName { get; set; }

        [DisplayName("Soyisim")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email alanı zorunludur!")]
        [DisplayName("Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur!")]
        [DisplayName("Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur!")]
        [DisplayName("Şifre Tekrar")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifrelere tutarsız.")]
        public string ConfirmPassword { get; set; }
    }
}
