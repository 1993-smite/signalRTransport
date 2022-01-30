using FluentValidation;
using WebSRTransport.Params;

namespace WebSRTransport.Validators
{
    public class SendParamHubValidator: AbstractValidator<SendParamHub>
	{
		public SendParamHubValidator()
		{
			RuleFor(x => x.group)
				.NotNull()
				.NotEmpty()
				.Length(2, 100);
			RuleFor(x => x.message)
				.NotNull()
				.NotEmpty()
				.Length(0, 10);
		}
	}
}
