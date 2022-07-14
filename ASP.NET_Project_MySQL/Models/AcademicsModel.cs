using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET_Project_MySQL.Models
{
    public class AcademicsModel
    {
        public string id { get; set; }
        [Required(ErrorMessage = "namekh is required.")]
        public string namekh { get; set; }
        [Required(ErrorMessage = "nameen is required.")]
        public string nameen { get; set; }
    }
}