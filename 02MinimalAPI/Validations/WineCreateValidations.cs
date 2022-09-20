using FluentValidation;

namespace _02MinimalAPI.Validations;

public class WineCreateValidations : AbstractValidator<DTO.WineCreateDTO>
{
	public WineCreateValidations()
	{
		RuleFor(model => model.name).NotEmpty();
		RuleFor(model => model.alcohol).GreaterThan(0);
	}
}
