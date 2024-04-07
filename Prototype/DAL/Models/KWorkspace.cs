namespace DAL.Models
{
    public class KWorkspace
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "Untitled Workspace";
        public string? KUserId { get; set; }
        public List<KBoard>? Boards { get; set; }
    }
}
