using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace WebAPI.Models
{
    /// <summary>
    /// state of film task
    /// </summary>
    public enum FilmState
    {
        Active = 0,
        UnActive = 9
    }

    /// <summary>
    /// film classs
    /// </summary>
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FilmType Type { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public long Timing { get; set; }
        public long Budget { get; set; }
        public FilmState State { get; set; }
    }

    /// <summary>
    /// validation of films
    /// </summary>
    public class FilmValid: Film
    {
        public bool isNew => Id < 1;

        [Required(ErrorMessage = "'Название' должно быть заполнено")]
        public bool NameValid => !string.IsNullOrEmpty(Name);

        [RegularExpression("(True|true)", ErrorMessage = "'Год' должен быть в дипазоне от 1800 до 2030")]
        public bool YearValid => (Year > 1800 && Year < 2030);

        [RegularExpression("(True|true)", ErrorMessage = "'Тип' должен быть выбрано")]
        public bool TypeValid => !(Type == null || Type.Id < 1);
    }
}
