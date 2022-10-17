using FluentValidation;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class EmailTemplateDTO
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string EmailContent { get; set; }
        public string EmailSubject { get; set; }
    }
    public class EmailTemplateModelValidator : AbstractValidator<EmailTemplateDTO>
    {
        public EmailTemplateModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Please enter email name");
            RuleFor(p => p.EmailContent).NotEmpty().WithMessage("Please enter email content");
            RuleFor(p => p.EmailSubject).NotEmpty().WithMessage("Please enter email subject");
        }
    }
}