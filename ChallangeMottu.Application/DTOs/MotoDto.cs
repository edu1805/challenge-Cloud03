namespace ChallangeMottu.Application;

/// <summary>
/// DTO para exibição de dados de uma moto.
/// </summary>
public class MotoDto
{
    /// <summary>
    /// Identificador da moto.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Placa da moto.
    /// </summary>
    public string Placa { get; set; } = string.Empty;
    
    /// <summary>
    /// Posição da moto no pátio (A1; B2...).
    /// </summary>
    public string Posicao { get; set; }

    /// <summary>
    /// Status atual da moto.
    /// </summary>
    public string Status { get; set; } = "desconhecido";

    /// <summary>
    /// Data e hora da última atualização da moto.
    /// </summary>
    public DateTime? UltimaAtualizacao { get; set; }
}