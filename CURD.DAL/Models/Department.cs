using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CURD.DAL.Models
{
    public class Department
    {
        public int Id { get; set; } // Pk identity (1,1)
        [Required(ErrorMessage = "Code Is Reqired!.")]  
        public string Code { get; set; } //Allow null we use .net (5) not suppot nullable Reference type
        [Required(ErrorMessage = "Name Is Required!.")] 
        public string Name { get; set; }

        [Display(Name = "Date Of Creation")] // in view model 
        public DateTime DateOfCreation { get; set; }
    }
}
