using System;
using System.Collections.Generic;
using EcoleSwip.DTO.School;
using EcoleSwip.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EcoleSwip.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolController : ControllerBase
    {
        private readonly ILogger<SchoolController> _logger;

        private SchoolService _schoolService { get; set; }

        public SchoolController(ILogger<SchoolController> logger, SchoolService schoolService)
        {
            _logger = logger;
            _schoolService = schoolService;
        }

        [HttpGet]
        [Route("{sigle}")]
        public IEnumerable<SchoolReadDto> getAllSchool(string sigle)
        {
            return _schoolService.FindByName(sigle);
        }
    }
}
