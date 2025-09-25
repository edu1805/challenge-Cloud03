namespace ChallangeMottu.Application;

/// <summary>
/// DTO para exibir a localização atual de uma moto.
/// </summary>
public class LocalizacaoAtualDto
{
    /// <summary>
    /// Identificador da localização.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ID da moto associada.
    /// </summary>
    public Guid MotoId { get; set; }

    /// <summary>
    /// Coordenada X da moto no pátio.
    /// </summary>
    public double CoordenadaX { get; set; }

    /// <summary>
    /// Coordenada Y da moto no pátio.
    /// </summary>
    public double CoordenadaY { get; set; }

    /// <summary>
    /// Data e hora da última atualização de localização.
    /// </summary>
    public DateTime DataHoraAtualizacao { get; set; }
}