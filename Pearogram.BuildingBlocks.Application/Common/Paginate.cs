namespace Pearogram.BuildingBlocks.Application.Common;

public class Paginate
{
    public Paginate(int index)
    {
        Index = index;
    }
    public Paginate()
    {
    }
    public Paginate(int index = 0, string? searchKey = null)
    {
        Index = index;
        SearchKey = searchKey;
    }

    public int Index { get; set; }
    public int PageSize { get; set; }
    public string? SearchKey { get; set; }
}
