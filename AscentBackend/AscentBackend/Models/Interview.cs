namespace AscentBackend.Models
{
    public class Interview
    {
        public int interviewId { get; set; }
        public required AssessmentCenter assessmeCenter { get; set; }
        public User? user { get; set; }
        public required Candidate candidate { get; set; }
        public InterviewPack? interviewPack { get; set; }
        public DateTime time { get; set; }
    }
}
