namespace SunniNooriMasjidAPI.Features.Models.MasjidCommittee.Response
{
    public class ImamHistoryResponseModel
    {


        public int ImamId { get; set; }
        public string ImamName { get; set; }
        public string FatherName { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? LastServingDate { get; set; }

        public string? MasjidAddress { get; set; }
        public string? Address { get; set; }
        public string? ContactNumber { get; set; }
        public string TotalService { get; set; }
        public string City { get; set; }
        public decimal salary { get; set; }
        public string ImamImage { get; set; }
        public string Education { get; set; }
        public string ImamBio { get; set; }
        public string ImamVision { get; set; }

        public string RoleDescription { get; set; }
        public string Remarks { get; set; }



    }
}
