using MediatR;
using SunniNooriMasjidAPI.Features.Models.MasjidGullak.Response;

namespace SunniNooriMasjidAPI.Features.MasjidGullak.Commands
{
    public class UpdateGullakCommand:IRequest<UpdateGullakResponseModel>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
        public int UpdatedBy { get; set; } = 4;
        public DateTime UpdatedOn { get; set;}=DateTime.Now;

    }
}
