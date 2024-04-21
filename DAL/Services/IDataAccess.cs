using DAL.Models;

namespace DAL.Services
{
    public interface IDataAccess
    {

        Task<KUser> GetKanbanUser(string id);
        Task<List<KWorkspace>> GetUserWorkspaces(string userId);
        Task<List<KBoard>> GetWorkspaceBoards(string workspaceId);
        Task<List<KColumn>> GetBoardColumns(string boardId);
        Task<List<KTask>> GetColumnTasks(string columnId);
        
        Task PostKanbanUser(KUser user);
        Task PostKanbanWorkspace(KWorkspace workspace);
        Task PostKanbanBoard(KBoard board);
        Task PostKanbanColumn(KColumn column);
        Task PostKanbanTask(KTask task);

        Task UpdateWorkspace(KWorkspace workspace);
        Task UpdateBoard(KBoard board);
        Task UpdateColumn(KColumn column);
        Task UpdateTask(KTask task);

        Task DeleteTask(KTask task);
        Task DeleteColumn(KColumn column);
        Task DeleteBoard(KBoard board);
        Task DeleteWorkspace(KWorkspace workspace);




    }
}