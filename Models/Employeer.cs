using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApplication.Models
{
    public class Employeer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "FirstName is Reqired")]
        [MaxLength(50, ErrorMessage = "Firstname should contain less that 50 letters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is Reqired")]
        [MaxLength(50, ErrorMessage = "Lastname should contain less that 50 letters")]
        public string LasttName { get; set; }
        public string MobileNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }

    }
}
