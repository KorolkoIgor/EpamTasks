using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class ManagerDTO
    {
        public int Id { get; set; }
        [StringLength(10, ErrorMessage = "Too many chars")]
        public string FirstName { get; set; }
        [StringLength(10, ErrorMessage = "Too many chars")]
        public string SecondName { get; set; }
    }
}
