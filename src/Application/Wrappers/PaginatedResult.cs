using System.Net;

namespace Application.Wrappers;

public class PaginatedResult<T>
{
    public PaginatedResult(List<T>? data, object meta)
    {
        Data = data;
        Meta = meta;
    }

    internal PaginatedResult(bool succeeded, object meta, List<T>? data = default, int count = 0, int page = 1,
        int pageSize = 10, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        Data = data;
        CurrentPage = page;
        Succeeded = succeeded;
        Meta = meta;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
        StatusCode = statusCode;
    }

    public List<T>? Data { get; set; }

    public HttpStatusCode StatusCode { get; set; }

    public int CurrentPage { get; set; }

    public int TotalPages { get; set; }

    public int TotalCount { get; set; }

    public object Meta { get; set; }

    public int PageSize { get; set; }

    public bool HasPreviousPage => CurrentPage > 1;

    public bool HasNextPage => CurrentPage < TotalPages;

    public List<string> Messages { get; set; } = new();

    public bool Succeeded { get; set; }

    public static PaginatedResult<T> Success(List<T> data, int count, int page, int pageSize)
    {
        return new PaginatedResult<T>(true, data, null, count, page, pageSize);
    }

    public static PaginatedResult<T> InternalServerError(List<T> data, int count, int page, int pageSize)
    {
        return new PaginatedResult<T>(false, new List<T>(), null, count, page, pageSize,
            HttpStatusCode.InternalServerError);
    }

    public static PaginatedResult<T> Unauthorized(List<T> data, int count, int page, int pageSize)
    {
        return new PaginatedResult<T>(false, new List<T>(), null, count, page, pageSize, HttpStatusCode.Unauthorized);
    }

    public static PaginatedResult<T> BadRequest(List<T> data, int count, int page, int pageSize)
    {
        return new PaginatedResult<T>(false, new List<T>(), null, count, page, pageSize, HttpStatusCode.BadRequest);
    }
}