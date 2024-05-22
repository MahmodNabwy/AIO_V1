using AIO.Contracts.Enums;
using AIO.Contracts.Helpers;

namespace AIO.Contracts.Filters;

public class VideoLibraryCategoryFilter :Pager
{
    public string? Title { get; set; }
    public VideoType? VideoType { get; set; }
}