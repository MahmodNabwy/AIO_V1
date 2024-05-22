namespace AIO.Contracts.DTOs.Getter.FileLibrary;

public class FileLibraryGetterDTO
{
    public long Id { get; set; }
    public string Image { get; set; }
    public string FileName { get; set; }
    public string? Thumbnail { get; set; }
}