using mvcregister.CoustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcregister.Models
{
    public class Register
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public GenderType Gender { get; set; }
        [Display(Name = "Policies")]
        [Checkboxvalidation(ErrorMessage ="Please accept terms and conditions")]
        public bool Subscribe { get; set; }
        [Display(Name = "City")]
        public int CityId { get; set; }

        public City City { get; set; }
        [Display(Name = "Country")]
        [NotMapped]
        public int countryid { get; set; }
        [Display(Name = "State")]
        [NotMapped]
        public int StateId { get; set; }

    }
}