using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sales.Models
{
    public class SalesViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Maneger")]
        public ManagerDTO Manager { get; set; }

        [Display(Name = "Client")]
        public ClientDTO Client { get; set; }

        [Display(Name = "Goods")]
        public GoodsDTO Goods { get; set; }

        [Display(Name = "Total sum")]
        public double Cost { get; set; }
    }
}