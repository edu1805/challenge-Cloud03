using ChallangeMottu.Application;
using ChallangeMottu.Domain.Interfaces;
using FluentValidation;

namespace ChallangeMottu.Application.Validators;

public class CreateMotoDtoValidator : AbstractValidator<CreateMotoDto>
{
    private readonly string[] _statusValidos = 
        { "pronta", "revisao", "reservada", "fora de serviço", "sem placa" };
    
    private readonly IMotoRepository _motoRepository;

    public CreateMotoDtoValidator(IMotoRepository motoRepository)
    {
        _motoRepository = motoRepository;
        
        RuleFor(x => x.Placa)
            .NotEmpty().WithMessage("A placa é obrigatória")
            .Matches("^[A-Z]{3}[0-9]{1}[A-Z]{1}[0-9]{2}$")
            .WithMessage("A placa deve estar no padrão Mercosul, ex: ABC1D23")
            .MustAsync(async (placa, cancellation) =>
            {
                var existente = await _motoRepository.FindAsync(m => m.Placa == placa);
                return !existente.Any(); // true = placa não existe, validação ok
            })
            .WithMessage("Já existe uma moto cadastrada com esta placa");

        RuleFor(x => x.Posicao)
            .NotEmpty().WithMessage("A posição é obrigatória")
            .Matches("^[A-Z][0-9]+$")
            .WithMessage("A posição deve estar no formato letra+número, ex: A1, B2");

        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("O status é obrigatório")
            .Must(status => _statusValidos.Contains(status.ToLower()))
            .WithMessage("Status inválido. Os valores permitidos são: pronta, revisao, reservada, fora de serviço, sem placa");
        
        When(x => x.UltimaAtualizacao.HasValue, () =>
        {
            RuleFor(x => x.UltimaAtualizacao)
                .Must(d => d == null || d <= DateTime.UtcNow)
                .WithMessage("A data da última atualização não pode estar no futuro");
        });
    }
}