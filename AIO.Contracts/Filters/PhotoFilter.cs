using AIO.Contracts.Helpers;

namespace AIO.Contracts.Filters;

public class PhotoFilter : Pager
{
    public long PhotoAlbumId { get; set; }
    public bool? IsPinned { get; set; } = null;
}
public class PhotoWithAlbumFilter : Pager
{
    public long PhotoAlbumId { get; set; }
}