using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    /// <summary>
    /// model of address
    /// </summary>
    public class Place
    {
        public string Address { get; set; }
        public decimal Lon { get; set; }
        public decimal Lat { get; set; }
    }

    public class PlaceValid: Place
    {
        [Required(ErrorMessage = "'Адрес' должно быть заполнено")]
        public bool AddressValid => !string.IsNullOrEmpty(this.Address.Trim());
    }
}
