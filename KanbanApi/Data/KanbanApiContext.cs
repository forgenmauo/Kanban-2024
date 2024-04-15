using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace KanbanApi.Data
{
    public class KanbanApiContext : DbContext
    {
        public KanbanApiContext(DbContextOptions<KanbanApiContext> options) : base(options)
        {
        }
        public DbSet<DAL.Models.KUser> KUsers { get; set; } = default!;
        public DbSet<DAL.Models.KWorkspace> KWorkspaces { get; set; } = default!;
        public DbSet<DAL.Models.KBoard> KBoards { get; set; } = default!;
        public DbSet<DAL.Models.KColumn> KColumns { get; set; } = default!;
        public DbSet<DAL.Models.KTask> KTasks { get; set; } = default!;
    }
}
