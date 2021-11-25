using System.ComponentModel.DataAnnotations;

namespace Validation.Models
{
    public class CreateUserModel
    {
        [Required(ErrorMessage = "O nome e obrigatorio")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "O nome do usuario deve conter entre 3 e 10 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "A senha e obrigatoria")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O salario e obrigatorio")]
        [Range(0,999.99, ErrorMessage = "Voce ganha muito")]
        public decimal Salary { get; set; }
        [EmailInUse]
        [BlockDomain("google.com")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        [Required(ErrorMessage = "O email e obrigatorio")]
        public string Email { get; set; }
    }

    public class EmailInUseAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return (string)value == "hello@fsociety.com"
                ? new ValidationResult("Esse e-mail ja esta em uso")
                : ValidationResult.Success;
        }
    }

    public class BlockDomainAttribute : ValidationAttribute
    {
        public string Domain { get; set; }
        public BlockDomainAttribute(string domain)
        {
            Domain = domain;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return ((string)value).Contains(Domain)
                ? new ValidationResult("Dominio invalido")
                : ValidationResult.Success;
        }
    }
}
