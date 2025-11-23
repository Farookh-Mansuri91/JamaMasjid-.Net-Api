namespace SunniNooriMasjidAPI.Features.Models.YearlyIncome.Response
{
    public class YearlyIncomeResponseModel
    {
       public int Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MohallaName { get; set;}
        public string Caste { get; set;}
        public DateTime PaymentDate { get; set;}
        public decimal MasjidAmount { get; set; }
        
        public decimal QabristaanAmount { get; set;}
        public decimal MasjidProgramAmount { get; set;}
        public string Remarks { get; set;}
        public decimal TotalMasjidAmount { get; set;}
        public decimal TotalQabaristan {  get; set;}
        public decimal TotalMasjidProgramAmount { get; set;}
        public decimal TotalMasjidGullakAmount { get; set;}
        public decimal GrandtotalAmount { get; set;}



    }
}
