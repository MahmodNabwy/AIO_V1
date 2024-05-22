using Boilerplate.Contracts.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boilerplate.Core.Entities.FilesLibrary;

[Table("files_library")]

public class FilesLibrary : BaseEntityUpdate
{
    [Column("file")]
    [MaxLength(250)]
    public string File { get; set; }
    [MaxLength(250)]
    [Column("directory")]
    public string directory { get; set; }

    [Column("file_name")]
    [MaxLength(250)]
    public string FileName { get; set; }
    [MaxLength(250)]
    [Column("file_type")]
    public string FileType { get; set; }
    [NotMapped]
    public string Image => Path.Combine(directory, FileType, File).ToHostUrl();

    [MaxLength(250)]

    [Column("thumbnail")]
    public string? Thumbnail { get; set; }
    [NotMapped]
    public string? ThumbnailUrl => Thumbnail == null ? null : Path.Combine(directory, FileType, Thumbnail).ToHostUrl();

}