using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResumeParserCore.Processor;
using ResumeParserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeParserService.Controllers
{
    [Route("api/Resume")]
    [Produces("application/json")]
    public class ResumeParserController : ControllerBase
    {

        private readonly ILogger<ResumeParserController> _logger;
        private readonly IProcessor _processor;

        public ResumeParserController(ILogger<ResumeParserController> logger, IProcessor processor)
        {
            _logger = logger;
            _processor = processor;
        }

        [Route("~/api/Parse")]
        [HttpGet]
        public IList<Resume> Get()
        {

            var files = Directory.GetFiles("Resumes").Select(Path.GetFullPath);
            List<Resume> resumes = new List<Resume>();
            foreach (var file in files)
            {
                var output = _processor.Process(file);
                resumes.Add(output);
            }
            return resumes;
           
        }
    }
}
