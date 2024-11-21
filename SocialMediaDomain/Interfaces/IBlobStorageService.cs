using SocialMediaDomain.Constants;

namespace SocialMediaDomain.Interfaces;

public interface IBlobStorageService
{
    Task<string> UploadToBlobAsync(Stream data, string filename, string containerName);
}
