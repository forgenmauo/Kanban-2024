namespace DAL.Models
{
    public class KUser
    {
        public string Id { get; set; } = "Blank Id";
        public string UserName { get; set; } = "Blank UserName";
        public string Email { get; set; } = "Blank Email";

        public List<KWorkspace> Workspaces { get; set; } = new List<KWorkspace>();
        
    }
}
