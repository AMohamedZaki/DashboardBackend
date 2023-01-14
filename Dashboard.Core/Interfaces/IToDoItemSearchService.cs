using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Result;
using Dashboard.Core.ProjectAggregate;

namespace Dashboard.Core.Interfaces;

public interface IToDoItemSearchService
{
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
}
