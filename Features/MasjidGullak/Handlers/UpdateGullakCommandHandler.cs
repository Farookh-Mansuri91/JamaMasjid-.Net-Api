using MediatR;
using SunniNooriMasjidAPI.Features.MasjidGullak.Commands;
using SunniNooriMasjidAPI.Features.Models.MasjidGullak.Response;
using SunniNooriMasjidAPI.Interfaces.IMasjidGullak;

namespace SunniNooriMasjidAPI.Features.MasjidGullak.Handlers
{
    public class UpdateGullakCommandHandler : IRequestHandler<UpdateGullakCommand, UpdateGullakResponseModel>
    {
        private IMasjidGullakService _service;
        public UpdateGullakCommandHandler(IMasjidGullakService service)
        {
            _service = service;
        }
        public async Task<UpdateGullakResponseModel> Handle(UpdateGullakCommand command, CancellationToken cancellationToken)
        {
            return await _service.UpdateMasjidGullakDataAsync(command);
        }
    }
}
