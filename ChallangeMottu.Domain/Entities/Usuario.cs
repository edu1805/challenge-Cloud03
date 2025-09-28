namespace ChallangeMottu.Domain;

public class Usuario
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Nome { get; private set; }
    public string Email { get; private set; }
    
    public Guid? MotoId { get; private set; }
    public Moto? Moto { get; private set; }

    private Usuario() { }

    public Usuario(string nome, string email, Guid? motoId = null)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome é obrigatório.");
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email é obrigatório.");

        Nome = nome;
        Email = email;
        MotoId = motoId;
    }

    public void AtribuirMoto(Moto? moto)
    {
        if (moto != null && moto.Id == Guid.Empty)
            throw new ArgumentException("Moto inválida.");

        Moto = moto;
        MotoId = moto?.Id;
    }
    
    public void AtualizarDados(string nome, string email)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome é obrigatório.");
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email é obrigatório.");

        Nome = nome;
        Email = email;
    }
}
