using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using HR_System.helpers;
using Microsoft.AspNetCore.Http;

namespace HR_System.Data
{
    [Table("Employee")]
    public class Employee
    {
        public int Id { set; get; }
        [Required]
        public string Fname { set; get; }
        [Required]
        public string Lname { set; get; }
        public string Phone { set; get; }
        public int gender { set; get; }

        [ForeignKey("cnt")]
        public int countryId { set; get; }
        public Country cnt { set; get; }

        [ForeignKey("city")]
        public int cityId { set; get; }
        public City city { set; get; }
        

        public string address { set; get; }
        public string email { set; get; }
        public double salary { set; get; }
        public double ExpectedSalary { set; get; }

        [ForeignKey("DId")]
        public int depId { set; get; }
        public Department DId { set; get; }

        [HDateValidation]
        public DateTime hireDate { set; get; }

        public string path { set; get; }

        [NotMapped]
        public IFormFile Image { set; get; }






    }
}
