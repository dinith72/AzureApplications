using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestFileStorage
{
    public interface IBlobService
    {
        public Task<Stream> GetBlobAsyc(string name);

        public Task UploadFileBlob(string filename, string filePath);
        public Task<Stream> GetBlobFileShare(string name);


    }
}
