using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBookApplication.Models
{
    public class Book 
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string BookName { get; set; }
       
        [Required]
        public string BookDescription { get; set; }
    }
}
