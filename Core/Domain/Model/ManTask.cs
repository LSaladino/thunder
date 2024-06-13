namespace Core.Domain.Model
{
    public class ManTask        
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? CollaboratorName { get; set; }
        public string? Comments { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
