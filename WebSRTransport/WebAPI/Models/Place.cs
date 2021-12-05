using Clasterization;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    /// <summary>
    /// geographic coordinates
    /// </summary>
    public class PlaceCoord
    {
        public decimal Lon { get; set; }
        public decimal Lat { get; set; }

        public PlaceCoord()
        {

        }

        public PlaceCoord(decimal lat, decimal lon)
        {
            Lon = lon;
            Lat = lat;
        }

        public GeographicPoint toGeographic()
        {
            return new GeographicPoint(0, decimal.ToDouble(Lat), decimal.ToDouble(Lon));
        }
    }

    /// <summary>
    /// model of address
    /// </summary>
    public class Place: PlaceCoord
    {
        public string Address { get; set; }
    }

    public class PlaceValid: Place
    {
        [Required(ErrorMessage = "'Адрес' должно быть заполнено")]
        public bool AddressValid => !string.IsNullOrEmpty(this.Address.Trim());
    }

    public class PlaceCoordValid : PlaceCoord
    {

    }

    public class PlaceValidation : AbstractValidator<Place>
    {
        public PlaceValidation()
        {
            RuleFor(p => p.Address).NotEmpty();
        }
    }
}
