using MediatR;
using SunniNooriMasjidAPI.Data.Entities;
using SunniNooriMasjidAPI.Data.MasjidDbContext;
using SunniNooriMasjidAPI.Features.MasjidGullak.Commands;
using SunniNooriMasjidAPI.Features.Models.MasjidGullak.Response;
using SunniNooriMasjidAPI.Interfaces.IMasjidGullak;

namespace SunniNooriMasjidAPI.Features.MasjidGullak.Handlers;

public class AddGullakCommandHandler : IRequestHandler<AddGullakCommand, UpdateGullakResponseModel>
{
    private IMasjidGullakService _service;

    public AddGullakCommandHandler(IMasjidGullakService service)
    {
        _service = service;
    }

    public async Task<UpdateGullakResponseModel> Handle(AddGullakCommand request, CancellationToken cancellationToken)
    {
        return await _service.AddMasjidGullakDataAsync(request);
    }
}
