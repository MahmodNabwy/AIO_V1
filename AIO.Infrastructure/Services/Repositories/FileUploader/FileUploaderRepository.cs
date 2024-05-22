using AIO.Contracts.IServices.Repositories.FileUploader;
using AIO.Core.Entities.FilesLibrary;
using AIO.Infrastructure.Services.Custom;
using Microsoft.EntityFrameworkCore;

namespace AIO.Infrastructure.Services.Repositories.FileUploader;

public class FileUploaderRepository : GenericRepository<FilesLibrary>, IFileUploaderRepository
{
    public FileUploaderRepository(DbContext context) : base(context)
    {
    }
}