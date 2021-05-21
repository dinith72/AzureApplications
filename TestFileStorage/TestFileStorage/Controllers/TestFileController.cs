using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestFileStorage.Controllers
{
    public class TestFileController : Controller
    {
        private IBlobService _blobService;

        public TestFileController(IBlobService blobService)
        {
            _blobService = blobService;
        }

        [HttpGet("blob")]
        public Task<Stream> GetBlobData()
        {
            return _blobService.GetBlobAsyc("testName");
        }


    }
}
