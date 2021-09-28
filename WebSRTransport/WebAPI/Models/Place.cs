using FluentValidation;
using System.ComponentModel.DataAnnotations;

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

    public class PlaceValidation : AbstractValidator<Place>
    {
        public PlaceValidation()
        {
            RuleFor(p => p.Address).NotEmpty();
        }
    }
}
