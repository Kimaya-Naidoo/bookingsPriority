using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using invoice.Models;

namespace invoice.Models
{
   public class Booking
    {
        //*****************pick up *********************
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingIds { get; set; }
        //[Required]
        //[Display(Name = "Street Number")]
        //public string ColStreetNum { get; set; }
        //[Required]
        //[Display(Name = "Street Name")]
        //public string ColStreetName { get; set; }
        //[Required]
        //[Display(Name = "Area")]
        //public string ColArea { get; set; }
        //[Required]
        //[Display(Name = "City")]
        //public string ColCity { get; set; }
        //[Required]
        //[Display(Name = "Postal code")]
        //public string ColCode { get; set; }
        [Required]
        [Display(Name = "Pick up Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime pickupdate { get; set; }


        

        //******************Booking Details******************
        [Required]
        [Display(Name = "Client Name")]
        public string clientname { get; set; }
        [Required]
        [Display(Name = "Contact Number")]
        public string cellnum { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string email { get; set; }


        //*******************container details***********************
        [Required]
        [Display(Name = "Container Number ")]
        public string ConNum { get; set; }
        [Required]
        [Display(Name = "Container Type")]
        public string ConType { get; set; }

        [Required]
        [Display(Name = "Container Size")]
        public string Size { get; set; }

        [Display(Name = "Special Instructions")]
        public string specInstruct { get; set; }
        
        public string testtext { get; set; }
        public double two { get; set; }

        public string Distance { get; set; }

        [Display(Name = "Final")]
        public double final { get; set; }

        public string Collection { get; set; }
        public string Dropoff { get; set; }

        public string priorty { get; set; }

        //public double pcalc()
        //{
        //    if (two> 570)
        //    {
        //        priorty = "Medium";
        //    }
        //    else if (two > 1637)
        //    {
        //        priorty = "High";
        //    }
        //    else { priorty = "Low"; }

        //    return pcalc();
        //}



        //public double calcCost ()
        //{
        //    prices prices = new prices();
        //    double dcost = two * prices.rate ;
        //    return dcost;
        //}

        //public double sizecost()
        //{
        //    double scost = 0.00;
        //    prices prices = new prices();


        //    if (Size == "6m" && ConType == "Refrigderated ISO")
        //    {
        //        scost = prices.six+prices.refridge;
        //    }
        //    else if (Size == "6m" && ConType == "Tank")
        //    {
        //        scost = prices.six + prices.tank;
        //    }
        //    else if (Size == "6m" && ConType == "Dry Container")
        //    {
        //        scost = prices.six + prices.dry;
        //    }
        //    else if (Size == "12m" && ConType == "Refrigderated ISO")
        //    {
        //        scost = prices.twelve + prices.refridge;
        //    }
        //    else if (Size == "12m" && ConType == "Tank")
        //    {
        //        scost = prices.twelve + prices.tank;
        //    }
        //    else if (Size == "12m" && ConType == "Dry Container")
        //    {
        //        scost = prices.twelve + prices.dry;
        //    }

        //    return scost;

        //}



        //public double finalAmt()
        //{
        //    double fina = calcCost() + sizecost() ;

        //    return fina;
        //}



    }
}

