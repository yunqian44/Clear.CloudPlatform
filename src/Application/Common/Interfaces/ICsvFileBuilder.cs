using Clear.CloudPlatform.Application.TodoLists.Queries.ExportTodos;

namespace Clear.CloudPlatform.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
