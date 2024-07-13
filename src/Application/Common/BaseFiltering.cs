namespace Application.Common;

public record BaseFiltering(
    int Size,
    int Start,
    int Length,
    string[] OrderBy,
    DateTime? From,
    DateTime? To,
    string? Search);