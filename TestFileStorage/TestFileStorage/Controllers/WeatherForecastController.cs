using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestFileStorage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IBlobService _blobService;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger , IBlobService blobService)
        {
            _logger = logger;
            _blobService = blobService;
            
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("blob")]
        public Task<Stream> GetBlobData()
        {
            return _blobService.GetBlobAsyc("testfile");
        }
        
        [HttpGet("file")]
        public async Task<string> GetFileData()
        {
            Stream stream = await _blobService.GetBlobFileShare("test");

            using StreamReader streamReader = new StreamReader(stream);
            using JsonTextReader reader = new JsonTextReader(streamReader);
            JObject tree = (JObject)JToken.ReadFrom(reader);
            try
            {
                var metaJsonAttributes = tree["changeDetectionAttributes"];
                return metaJsonAttributes.ToString();
               
            }
            catch (Exception ex)
            {
                
            }
            return string.Empty;
        }
    }
}
