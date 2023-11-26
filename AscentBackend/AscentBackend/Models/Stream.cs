using System.ComponentModel.DataAnnotations;

namespace AscentBackend.Models
{
    public class Stream
    {
        [Key]
        public string streamName { get; set; } = null!;

        public List<InterviewPack> interviewPacks { get; set; } = new List<InterviewPack>();
    }
}
