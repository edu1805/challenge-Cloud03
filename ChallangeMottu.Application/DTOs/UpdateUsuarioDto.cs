namespace ChallangeMottu.Application;

public class UpdateUsuarioDto
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid? MotoId { get; set; }
}