using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ILikeTheBartender.Models
{
    public class DrinkOrder
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool Completed { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public Alcohol Alcohol { get; set; }

        [Required]
        public Mixer Mixer { get; set; }
    }

    public enum Alcohol
    {
        Vodka,
        Rum, 
        Whiskey,
        Tequila
    }

    public enum Mixer
    {
        Water,
        OrangeJuice,
        MargaritaMix,
        MartiniMix,
        Coke
    }
}