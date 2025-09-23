namespace ChallangeMottu.Application;

/// <summary>
/// DTO para atualizar coordenadas de uma localização atual.
/// </summary>
public class AtualizarLocalizacaoAtualDto
{
    /// <summary>
    /// Nova coordenada X.
    /// </summary>
    public double CoordenadaX { get; set; }

    /// <summary>
    /// Nova coordenada Y.
    /// </summary>
    public double CoordenadaY { get; set; }
}