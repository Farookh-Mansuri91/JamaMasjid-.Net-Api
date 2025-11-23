using MediatR;
using SunniNooriMasjidAPI.Features.Models.MasjidGullak.Response;

namespace SunniNooriMasjidAPI.Features.MasjidGullak.Queries;

public class GetGullakQuery : IRequest<IEnumerable<GullakResponseModel>> { }
