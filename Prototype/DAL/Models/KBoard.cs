namespace DAL.Models
{
    public class KBoard
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "Untitled Board";
        public string? KWorkspaceId { get; set; }
        public List<KColumn>? Columns { get; set; }
    }
}
