namespace EatEasy.Application.ViewModels
{
    public class TokenViewModel
    {
        public Guid UserId { get; set;  }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public string? AccessToken { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
