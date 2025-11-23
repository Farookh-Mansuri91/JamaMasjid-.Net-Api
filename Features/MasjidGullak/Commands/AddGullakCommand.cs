using MediatR;
using SunniNooriMasjidAPI.Features.Models.MasjidGullak.Response;

namespace SunniNooriMasjidAPI.Features.MasjidGullak.Commands;

public class AddGullakCommand : IRequest<UpdateGullakResponseModel>
{
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string Remarks { get; set; }
    public int VillageId { get; set; } = 1;
    public int AddedBy { get; set; } = 4;
    public DateTime AddedOn { get; set;}=DateTime.Now;
}
