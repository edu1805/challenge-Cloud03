namespace ChallangeMottu.Domain;

public class LocalizacaoAtual
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid MotoId { get; private set; }
    
    public Moto Moto { get; private set; }
    public double CoordenadaX { get; private set; }
    public double CoordenadaY { get; private set; }

    public DateTime DataHoraAtualizacao { get; private set; }

    private LocalizacaoAtual() { }

    public LocalizacaoAtual(Guid motoId, double coordenadaX, double coordenadaY)
    {
        Validar(motoId, coordenadaX, coordenadaY);

        MotoId = motoId;
        CoordenadaX = coordenadaX;
        CoordenadaY = coordenadaY;
        DataHoraAtualizacao = DateTime.UtcNow;
    }

    public void AtualizarCoordenadas(double coordenadaX, double coordenadaY)
    {
        Validar(MotoId, coordenadaX, coordenadaY);

        CoordenadaX = coordenadaX;
        CoordenadaY = coordenadaY;
        DataHoraAtualizacao = DateTime.UtcNow;
    }

    private void Validar(Guid motoId, double coordenadaX, double coordenadaY)
    {
        if (motoId == Guid.Empty)
            throw new ArgumentException("MotoId inválido.");

        if (double.IsNaN(coordenadaX) || double.IsInfinity(coordenadaX))
            throw new ArgumentException("Coordenada X inválida.");

        if (double.IsNaN(coordenadaY) || double.IsInfinity(coordenadaY))
            throw new ArgumentException("Coordenada Y inválida.");
    }
}