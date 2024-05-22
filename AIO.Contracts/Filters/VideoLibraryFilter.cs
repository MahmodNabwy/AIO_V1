using AIO.Contracts.Enums;
using AIO.Contracts.Helpers;

namespace AIO.Contracts.Filters;

public class VideoLibraryFilter : AdminFilterBase
{
    public string? Title { get; set; }
    public VideoType? VideoType { get; set; }
    public int VideoTypee { get; set; }

}
public class VideoAndRadioFilter : Pager
{
    public VideoType? VideoType { get; set; }
}