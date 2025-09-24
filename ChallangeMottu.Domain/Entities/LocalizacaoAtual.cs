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

        if (coordenadaX < 0 || coordenadaY < 0)
            throw new ArgumentException("Coordenadas não podem ser negativas.");

        if (coordenadaX > 1000 || coordenadaY > 1000)
            throw new ArgumentException("Coordenadas fora do limite permitido.");
    }
}