using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using DAL.Models;

namespace DAL.Services
{
    public class DataAccess : IDataAccess
    {
        private readonly HttpClient httpClient;

        public DataAccess(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<KUser> GetKanbanUser(string email) => await httpClient.GetFromJsonAsync<KUser>($"api/KUsers/{email}");
        public async Task<IEnumerable<KUser>> GetKanbanUsers() => await httpClient.GetFromJsonAsync<IEnumerable<KUser>>("api/KUsers");
        public async Task<IEnumerable<KWorkspace>> GetUserWorkspaces(string userId) => await httpClient.GetFromJsonAsync<IEnumerable<KWorkspace>>($"api/KWorkspaces/{userId}");
        public async Task<IEnumerable<KBoard>> GetWorkspaceBoards(string workspaceId) => await httpClient.GetFromJsonAsync<IEnumerable<KBoard>>($"api/KBoards/{workspaceId}");
        public async Task<IEnumerable<KColumn>> GetBoardColumns(string boardId) => await httpClient.GetFromJsonAsync<IEnumerable<KColumn>>($"api/KColumns/{boardId}");
        public async Task<IEnumerable<KTask>> GetColumnTasks(string columnId) => await httpClient.GetFromJsonAsync<IEnumerable<KTask>>($"api/KTasks/{columnId}");

        public async Task PostKanbanUser(KUser user) => await httpClient.PostAsJsonAsync("api/KUsers", user);
        public async Task PostKanbanWorkspace(KWorkspace workspace) => await httpClient.PostAsJsonAsync("api/KWorkspaces", workspace);
        public async Task PostKanbanBoard(KBoard board) => await httpClient.PostAsJsonAsync("api/KBoards", board);
        public async Task PostKanbanColumn(KColumn column) => await httpClient.PostAsJsonAsync("api/KColumns", column);
        public async Task PostKanbanTask(KTask task) => await httpClient.PostAsJsonAsync("api/KTasks", task);

    }
}
