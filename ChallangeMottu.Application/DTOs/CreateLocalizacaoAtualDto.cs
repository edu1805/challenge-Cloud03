namespace ChallangeMottu.Application;

/// <summary>
/// DTO para criação de uma nova localização atual.
/// </summary>
public class CriarLocalizacaoAtualDto
{
    /// <summary>
    /// ID da moto.
    /// </summary>
    public Guid MotoId { get; set; }

    /// <summary>
    /// Coordenada X.
    /// </summary>
    public double CoordenadaX { get; set; }

    /// <summary>
    /// Coordenada Y.
    /// </summary>
    public double CoordenadaY { get; set; }
}