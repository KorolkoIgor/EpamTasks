using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sales.Models
{
    public class PieChartModel
    {
        [StringLength(10, ErrorMessage = "Too many chars")]
        public string Manager { get; set; }
        public double TotalSales { get; set; }
    }
}