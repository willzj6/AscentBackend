namespace AscentBackend.Models
{
    public class Availability
    {
        public int availabilityId { get; set; }
        public DateTime availability {  get; set; }
        public required User user { get; set; }
    }
}
