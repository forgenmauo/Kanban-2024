namespace DAL.Models
{
    public class KBoard
    {
        public string Id { get; set; }
        public string Name { get; set; } = "Untitled Board";
        public string KWorkspaceId { get; set; }

        public List<KColumn> Columns { get; set; } = new List<KColumn>();
    }
}
