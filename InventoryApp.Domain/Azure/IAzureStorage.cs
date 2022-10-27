using Microsoft.AspNetCore.Http;

namespace InventoryApp.Domain.Azure
{
    public interface IAzureStorage
    {
        Task<bool> UploadAsync(IFormFile file, Guid materialId);
        Task<bool> DeleteAsync(string blobFilename);
        Task<string> DisplayPicture(string fileName);
    }
}
