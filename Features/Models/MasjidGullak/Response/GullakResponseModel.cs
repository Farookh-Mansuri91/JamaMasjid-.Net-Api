namespace SunniNooriMasjidAPI.Features.Models.MasjidGullak.Response
{
    public class GullakResponseModel
    {
        /// <summary>
        /// Unique Identifier for the Gullak entry
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date of the collection
        /// </summary>
        public DateTime CollectionDate { get; set; }

        /// <summary>
        /// Amount collected
        /// </summary>
        public decimal AmountCollected { get; set; }
        public int VillageId { get; set; }

        /// <summary>
        /// Description or remarks for the collection
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// Name of the Treasurer who recorded the entry
        /// </summary>
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Timestamp of when the record was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Timestamp of the last update to the record
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
