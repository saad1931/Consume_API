using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class mvcCricketerModel
    {
        public int Jersey_Number { get; set; }
        [Required (ErrorMessage ="Player Name is required1")]
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public string Player_Role { get; set; }
        public string Contract_Category { get; set; }
    }
}