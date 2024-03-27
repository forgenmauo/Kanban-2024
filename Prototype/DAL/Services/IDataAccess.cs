using DAL.Models;

namespace DAL.Services
{
    public interface IDataAccess
    {
        Task<IEnumerable<KColumn>> GetBoardColumns(string boardId);
        Task<IEnumerable<KTask>> GetColumnTasks(string columnId);
        Task<IEnumerable<KUser>> GetKanbanUsers();
        Task<KUser> GetKanbanUser(string email);
        
        Task<IEnumerable<KWorkspace>> GetUserWorkspaces(string userId);
        Task<IEnumerable<KBoard>> GetWorkspaceBoards(string workspaceId);
        Task PostKanbanUser(KUser user);
        Task PostKanbanWorkspace(KWorkspace workspace);
        Task PostKanbanBoard(KBoard board);
        Task PostKanbanColumn(KColumn column);
        Task PostKanbanTask(KTask task);




    }
}