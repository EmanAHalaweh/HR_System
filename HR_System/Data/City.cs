using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System.Data
{ 
    [Table("City")]
    public class City
    {
        public int Id { set; get; }
        public int code { set; get; }
        [Required]
        public string name { set; get; }

        [ForeignKey("cnt")]
        public int countryId { set; get; }
        public Country cnt { set; get; }

        public List<Employee> empli { set; get; }



    }
}
