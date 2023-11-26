using System.ComponentModel.DataAnnotations;

namespace AscentBackend.Models
{
    public class InterviewPack
    {
        [Key]
        public String packName { get; set; } = null!;
        public List<User> users { get; set; } = new List<User>();
        public List<Stream> streams { get; set; } = new List<Stream>();
    }
}
