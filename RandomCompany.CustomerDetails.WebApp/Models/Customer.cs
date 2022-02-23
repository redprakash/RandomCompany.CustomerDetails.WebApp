using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RandomCompany.CustomerDetails.WebApp.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="First Name is required")]
        [MaxLength(100)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Last Name is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Email is required")]
        [EmailAddress]
        public string Email { get; set; }


    }
}
