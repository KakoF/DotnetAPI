using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.DTO.IsSimianDTO.Validators
{
    public class IsSimianValidator : AbstractValidator<IsSimianRequestDTO>
    {
        private ISimianRepository _repository;
        public IsSimianValidator(ISimianRepository repository)
        {
            _repository = repository;
            RuleFor(a => a.Dna)
                .NotEmpty().WithMessage("Dna não pode ser vazio")
                .MustAsync(async (value, c) => await UniqueRegister(string.Join(",", value))).WithMessage("Dna ja existe na base.")
                .ChildRules(x =>
                {
                    x.RuleForEach(x => x)
                    .MaximumLength(6).WithMessage("Cadeia de Dna's devem ter 6 elementos")
                    .MinimumLength(6).WithMessage("Cadeia de Dna's devem ter 6 elementos");
                });
        }

        public async Task<bool> UniqueRegister(string dna)
        {
            var entity = await _repository.GetAsync(dna);

            if (entity == null)
            {
                return true;
            }
            return false;
        }
    }
}
