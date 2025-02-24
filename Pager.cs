public class Pager
{
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public int StartPage { get; set; }
    public int EndPage { get; set; }
    public int PageSize { get; set; }

    public Pager(int totalRecords, int currentPage, int pageSize)
    {
        TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
        CurrentPage = currentPage;
        StartPage = Math.Max(1, currentPage - 2);
        EndPage = Math.Min(TotalPages, currentPage + 2);
        PageSize = pageSize;
    }
}
