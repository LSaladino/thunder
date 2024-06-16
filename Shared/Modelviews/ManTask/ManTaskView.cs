namespace Shared.Modelviews.ManTask
{
    public class ManTaskView : ICloneable
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? CollaboratorName { get; set; }
        public string? Comments { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ManTaskView TypedClone()
        {
            return (ManTaskView)Clone();
        }

        public object Clone()
        {
            var manTask = (ManTaskView)MemberwiseClone();
            return manTask;
        }
    }
}
