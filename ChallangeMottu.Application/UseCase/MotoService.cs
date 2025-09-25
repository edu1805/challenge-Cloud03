using AutoMapper;
using ChallangeMottu.Application;
using ChallangeMottu.Domain;
using ChallangeMottu.Domain.Interfaces;

namespace ChallangeMottu.Application.UseCase;

public class MotoService : IMotoService
{
    private readonly IMotoRepository _motoRepository;
    private readonly IMapper _mapper;

    public MotoService(IMotoRepository motoRepository, IMapper mapper)
    {
        _motoRepository = motoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MotoDto>> ListarMotosAsync(string? status)
    {
        IEnumerable<Moto> motos;

        if (!string.IsNullOrWhiteSpace(status))
            motos = await _motoRepository.FindAsync(m => m.Status == status.ToLower());
        else
            motos = await _motoRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<MotoDto>>(motos);
    }

    public async Task<MotoDto?> BuscarPorIdAsync(Guid id)
    {
        var moto = await _motoRepository.GetByIdAsync(id);
        return moto == null ? null : _mapper.Map<MotoDto>(moto);
    }

    public async Task<MotoDto> CriarAsync(CreateMotoDto dto)
    {
        var novaMoto = new Moto(dto.Placa, dto.Posicao, dto.Status);

        await _motoRepository.AddAsync(novaMoto);
        await _motoRepository.SaveChangesAsync();

        return _mapper.Map<MotoDto>(novaMoto);
    }

    public async Task<bool> AtualizarAsync(Guid id, UpdateMotoDto dto)
    {
        var moto = await _motoRepository.GetByIdAsync(id);
        if (moto == null) return false;

        moto.AtualizarPosicao(dto.Posicao);
        moto.AtualizarStatus(dto.Status);

        _motoRepository.Update(moto);
        await _motoRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeletarAsync(Guid id)
    {
        var moto = await _motoRepository.GetByIdAsync(id);
        if (moto == null) return false;

        _motoRepository.Delete(moto);
        await _motoRepository.SaveChangesAsync();

        return true;
    }
}