using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusWeb.Models
{
    /// <summary>
    /// The product view model.
    /// </summary>
    public class OrderViewModel
    {
        /// <summary>
        /// Gets or sets the address line one.
        /// </summary>
        [Required]
        [Display(Name = "Address - Line one")]
        public string AddressLineOne { get; set; }

        /// <summary>
        /// Gets or sets the address line two.
        /// </summary>
        [Required]
        [Display(Name = "Address - Line two")]
        public string AddressLineTwo { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }
    }
}
