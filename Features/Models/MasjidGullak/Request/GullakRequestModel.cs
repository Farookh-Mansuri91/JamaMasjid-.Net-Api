namespace SunniNooriMasjidAPI.Features.Models.MasjidGullak.Request
{
    public class GullakRequestModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; } 
        public DateTime CollectionDate { get; set; }
        public string Remarks {  get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int VillageId { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;

    }
}
