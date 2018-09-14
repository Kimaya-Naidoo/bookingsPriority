using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace invoice.Models
{
    public class Truck
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TruckId { get; set; }

        [Required(ErrorMessage = "please select make of truck")]
        [Display(Name = "Truck make")]
        public string make { get; set; }

        [Required(ErrorMessage = "please enter model of truck")]
        [Display(Name = "Truck model")]
        public string model { get; set; }

        [Required(ErrorMessage = "please Vehicle Identification Number of truck")]
        [Display(Name = "Vehicle Identification Number")]
        [StringLength(17)]
        public string vin { get; set; }

        [Required(ErrorMessage = "please enter registration of truck")]
        [Display(Name = "Truck Registration")]
        public string reg { get; set; }


        [Required(ErrorMessage = "please enter initial cost of truck")]
        [Display(Name = "Price of Truck")]
        public double cost { get; set; }

        //[Display(Name = "Monthly Maintence and Repairs")]
        //public double maintence { get; set; }

        [Display(Name = "Monthly Insurance")]
        public double insurance { get; set; }


        [Display(Name = "Annual Licensing ")]
        public double license { get; set; }
    }
}