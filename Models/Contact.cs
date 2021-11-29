using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookMVC.Models
{
    public class Contact
    {
        // Create necessary public properties
        [Required]
        [Display(Name = "First Name")] // Changes label name
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [DataType(DataType.PostalCode)]
        public int Zip { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public DateTime Created { get; set; }

        [NotMapped] // Don't map this property to a DB
        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }
        // Digital bite array representation of the image 
        public byte[] ImageData { get; set; } 
        public string ImageType { get; set; }

        public int Id { get; set; }

        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }


    }
}
