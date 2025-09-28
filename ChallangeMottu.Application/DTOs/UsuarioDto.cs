namespace ChallangeMottu.Application;

public class UsuarioDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid? MotoId { get; set; }
    public string? StatusMoto { get; set; } 
}