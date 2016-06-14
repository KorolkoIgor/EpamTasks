using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class GoodsDal
    {
        public int Id { get; set; }

        [StringLength(10, ErrorMessage = "Too many chars")]
        public string Name { get; set; }
    }
}
