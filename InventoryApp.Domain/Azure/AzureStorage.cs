using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using InventoryApp.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Azure
{
    public class AzureStorage : IAzureStorage
    {
        private readonly BlobContainerClient _blobContainerClient;
        private readonly string _storageConnectionString;
        private readonly string _storageContainerName;
        private readonly ILogger _logger;
        public AzureStorage(ILogger<AzureStorage> logger)
        {
            IConfigurationRoot appSetting = Appsetting.GetConfiguration();
            _logger = logger;

            _storageConnectionString = appSetting.GetSection("AzureStore:ConnectionString").Value;
            _storageContainerName = appSetting.GetSection("AzureStore:BlobContainer").Value;

            _blobContainerClient = new BlobContainerClient(_storageConnectionString, _storageContainerName);
        }

        public async Task<bool> DeleteAsync(string blobFilename)
        {
            BlobClient file = _blobContainerClient.GetBlobClient(blobFilename);
            try
            {
                await file.DeleteAsync();
                return true;
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
            {
                _logger.LogError($"File {blobFilename} was not found.");
                throw new NotImplementedException(ex.Message);
            }
        }   

        public async Task<string> DisplayPicture(string fileName)
        {
            string uri = _blobContainerClient.Uri.ToString();
            return $"{uri}/{fileName}";
        }

        public async Task<bool> UploadAsync(IFormFile file)
        {
            try
            {
                BlobClient client = _blobContainerClient.GetBlobClient(file.FileName);
                var blobHttpHeader = new BlobHttpHeaders { ContentType = "image/jpeg" };
                await using (Stream? data = file.OpenReadStream())
                {
                    await client.UploadAsync(data, new BlobUploadOptions { HttpHeaders = blobHttpHeader });
                }
                return true;
            }
            catch (RequestFailedException e) when (e.ErrorCode == BlobErrorCode.BlobAlreadyExists)
            {
                _logger.LogError($"File with name {file.FileName} already exists in container. Set another name to store the file in the container {_storageContainerName}");
                throw new NotImplementedException(e.Message);
            }
            catch (RequestFailedException ex)
            {
                _logger.LogError($"Unhandled Exception. ID: {ex.StackTrace} - Message: {ex.Message}");
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}
