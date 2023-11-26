namespace AscentBackend.Models
{
    public class User
    {
        public int userId { get; set; }
        public string firstName { get; set; } = null!;
        public string lastName { get; set; } = null!;
        public string email { get; set; } = null!;
        public string password { get; set; } = null!;
        public required string role { get; set; }
        public string contact { get; set; } = string.Empty;
        public bool isActive { get; set; } = true;
        public List<InterviewPack> interviewPacks { get; set; } = new List<InterviewPack>();

    }
}
