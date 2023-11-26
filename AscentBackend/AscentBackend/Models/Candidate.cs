namespace AscentBackend.Models
{
    public class Candidate
    {
        public int candidateId {  get; set; }
        public string firstName { get; set; } = null!;
        public string lastName { get; set; } = null!;
        public string? resume {  get; set; }
        public string? visaStatus { get; set; }
        public string? degree { get; set; }
        public string? notes { get; set; }
        public DateTime date { get; set; }
        public string? contact { get; set; }
        public string email { get; set; } = null!;
        public required Stream stream { get; set; }
    }
}
