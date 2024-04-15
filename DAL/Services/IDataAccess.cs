using DAL.Models;

namespace DAL.Services
{
    public interface IDataAccess
    {
        Task<KUser> GetKanbanUser(string email);
        Task<List<KWorkspace>> GetUserWorkspaces(string userId);
        Task<List<KBoard>> GetWorkspaceBoards(string workspaceId);
        Task<List<KColumn>> GetBoardColumns(string boardId);
        Task<List<KTask>> GetColumnTasks(string columnId);
        
        Task PostKanbanUser(KUser user);
        Task PostKanbanWorkspace(KWorkspace workspace);
        Task PostKanbanBoard(KBoard board);
        Task PostKanbanColumn(KColumn column);
        Task PostKanbanTask(KTask task);




    }
}