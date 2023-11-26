using System.ComponentModel.DataAnnotations;

namespace AscentBackend.Models
{
    public class AssessmentCenter
    {
        [Key]
        public int acId {  get; set; }
        public DateTime date { get; set; }
        public int userId { get; set; }
        public User? coordinator { get; set; }
    }
}
