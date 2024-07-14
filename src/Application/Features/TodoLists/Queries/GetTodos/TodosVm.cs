using Application.Common.Models;

namespace Application.Features.TodoLists.Queries.GetTodos;

public class TodosVm
{
    public List<LookupDto> PriorityLevels { get; init; } = [];

    public IReadOnlyCollection<TodoListDto> Lists { get; init; } = Array.Empty<TodoListDto>();
}