namespace DAL.Models
{
    public class KTask
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "Untitled Task";
        public string Description { get; set; } = "Task Description";
        public int Position { get; set; } = 0;
        public string KColumnId { get; set; }

    }
}
