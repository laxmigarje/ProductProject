using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductProject.Models
{
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "pid is required")]

        public int pid { get; set; }

        [Required(ErrorMessage = "pname is required")]
        public string pname { get; set; }

        [Required(ErrorMessage = "company is required")]
        public string company { get; set; }

        [Required(ErrorMessage = "price is required")]
        public int price { get; set; }

        [Required(ErrorMessage = "password is required")]
        public string password { get; set; }

    }
}
