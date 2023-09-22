using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter your email")]
        [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$",
            ErrorMessage = "Enter a valid email")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Password")]
        //[Required(ErrorMessage = "Please enter your password")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            ErrorMessage = "Password must be of 8 characters with atleast " +
            "one uppercase,atleast one lowercase, atleast one symbol, atleast number")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(10, ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter your address")]
        public string Address { get; set; } = string.Empty;
    }
}
