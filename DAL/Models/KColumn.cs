namespace DAL.Models
{
    public class KColumn
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "Untitled Column";
        public string? KBoardId { get; set; }
        public List<KTask> Tasks { get; set; } = new List<KTask>();

    }
}
