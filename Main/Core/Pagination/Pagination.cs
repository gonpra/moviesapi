namespace MoviesApi.Main.Core.Pagination;

/// <summary>
/// Represents a Pageable object that contains pagination information.
/// </summary>
public class Pageable
{
    /// <summary>
    /// Initializes a new instance of the Pageable class with default values of page = 1 and size = 10.
    /// </summary>
    public Pageable()
    {
        Page = 1;
        Size = 10;
    }

    /// <summary>
    /// Initializes a new instance of the Pageable class with the provided page and size.
    /// </summary>
    /// <param name="page">The current page number</param>
    /// <param name="size">The number of objects per page</param>
    public Pageable(int page, int size)
    {
        Page = page < 1 ? 1 : page;
        Size = size;
    }

    /// <summary>
    /// Current page number.
    /// </summary>
    public int Page { get; set; }
    /// <summary>
    /// Number of objects per page.
    /// </summary>
    public int Size { get; set; }
}

/// <summary>
/// Represents a generic Pagination class used to paginate a list of objects of type T.
/// </summary>
/// <typeparam name="T">Type of objects to be paginated</typeparam>
public class Pagination<T>
{
    /// <summary>
    /// Paginates a list of objects of type T based on the provided Pageable object.
    /// </summary>
    /// <param name="content">List of objects to be paginated</param>
    /// <param name="pageable">Pageable object containing pagination information</param>
    /// <returns>A paginated list of objects of type T</returns>
    public static List<T> Paginate(List<T> content, Pageable pageable)
    {
        return content
            .Skip((pageable.Page - 1) * pageable.Size)
            .Take(pageable.Size)
            .ToList();
    }
    
    /// <summary>
    /// Initializes a new instance of the Pagination class with the provided content, pagination information, and total number of objects.
    /// </summary>
    /// <param name="content">The current page's content of type T</param>
    /// <param name="pageable">The Pageable object containing pagination information</param>
    /// <param name="total">The total number of objects</param>
    public Pagination(T content, Pageable pageable, int total)
    {
        Content = content;
        Page = pageable.Page;
        Size = pageable.Size;
        Total = total;
        TotalPages = Convert.ToInt32(Math.Ceiling(total / (double) pageable.Size));
    }

    /// <summary>
    /// Gets or sets the current page's content of type T.
    /// </summary>
    public T Content { get; set; }
    /// <summary>
    /// Gets or sets the current page number.
    /// </summary>
    public int Page { get; set; }
    /// <summary>
    /// Gets or sets the number of objects per page.
    /// </summary>
    public int Size { get; set; }
    /// <summary>
    /// Gets or sets the total number of pages.
    /// </summary>
    public int TotalPages { get; set; }
    /// <summary>
    /// Gets or sets the total number of objects.
    /// </summary>
    public int Total { get; set; }
}