
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Microsoft.WindowsAzure.Storage.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestFileStorage
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceclient;
        private readonly ShareClient _shareClient;

        public BlobService(BlobServiceClient blobServiceclient , ShareClient shareClient)
        {
            _blobServiceclient = blobServiceclient;
            _shareClient = shareClient;
        }

        public async Task<Stream> GetBlobAsyc(string name)
        {
            var containerClinet = _blobServiceclient.GetBlobContainerClient("testcontainer");
            var blobClient = containerClinet.GetBlobClient("Logo2.png");

            BlobDownloadInfo info = await blobClient.DownloadAsync();

            return info.Content;


        }

        public async Task<Stream> GetBlobFileShare(string name)
        {
            try
            {
                string path = "https://irentaastorage.file.core.windows.net/testfileshare/test/testl2";
                string shareclientPath  = $"{_shareClient.Uri.AbsoluteUri}/";
                string directoryPath = path.Replace(shareclientPath, string.Empty);
                ShareDirectoryClient directory = _shareClient.GetDirectoryClient(directoryPath);
                ShareFileClient file = directory.GetFileClient("testJson.json");
                ShareFileDownloadInfo download = file.Download();

                // string filePath = "https://irentaastorage.file.core.windows.net/testfileshare/test/testJson.json";
                // ShareFileClient file = new ShareFileClient(parseUri(filePath));
                //CloudFile file = new CloudFile(parseUri(filePath));
                //var download = await file.DownloadToStreamAsync();
                return download.Content;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return null;
            }
           
        }

        public Task UploadFileBlob(string filename, string filePath)
        {
            throw new NotImplementedException();
        }

        private Uri parseUri(string uri)
        {
            var url = new Uri(uri);
            return url;
        }
    }
}
