using Boilerplate.Contracts.IServices.Repositories.FileUploader;
using Boilerplate.Core.Entities.FilesLibrary;
using Boilerplate.Infrastructure.Services.Custom;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.Services.Repositories.FileUploader;

public class FileUploaderRepository : GenericRepository<FilesLibrary>, IFileUploaderRepository
{
    public FileUploaderRepository(DbContext context) : base(context)
    {
    }
}