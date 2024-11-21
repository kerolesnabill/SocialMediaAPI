using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using SocialMediaDomain.Interfaces;

namespace SocialMediaInfrastructure.Storage;

internal class BlobStorageService(IConfiguration configuration) : IBlobStorageService
{
    private readonly string _connectionString = configuration.GetConnectionString("BlobStorage")!;
    public async Task<string> UploadToBlobAsync(Stream data, string filename, string containerName)
    {
        var blobServiceClient = new BlobServiceClient(_connectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

        var blobClient = containerClient.GetBlobClient(filename);

        await blobClient.UploadAsync(data);

        return blobClient.Uri.ToString();
    }
}
