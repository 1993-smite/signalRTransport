using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    /// <summary>
    /// class for web task
    /// </summary>
    public class WebTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public WebTaskStatus Status { get; set; }
    }

    /// <summary>
    /// web task status
    /// </summary>
    public enum WebTaskStatus
    {
        Active = 1,
        Done = 5,
        Cansel = 9
    }

    /// <summary>
    /// validation for web task
    /// </summary>
    public class WebTaskValid: WebTask
    {
        public bool isNew => Id < 1;

        [Required(ErrorMessage = "'Название' должно быть заполнено")]
        public string NameValid => Name;

        [RegularExpression("(True|true)", ErrorMessage = "'Дата' должна быть будущей")]
        public bool DateValid => !isNew || Date > DateTime.Now.AddDays(-1);
    }

    public class WebTaskValidation: AbstractValidator<WebTask>
    {
        public WebTaskValidation()
        {
            When(t => t.Id < 1, () => {
                RuleFor(t => t.Date).GreaterThan(DateTime.Now.AddDays(-1));
            });
            RuleFor(t => t.Name).NotEmpty();
            //RuleFor(t => t.Date).GreaterThan(DateTime.Now.AddDays(-1));
        }
    }
}
