using BusinessLogic;
using Dota2replaysaver.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Dota2replaysaver.Controllers
{
    [ApiController]
    [Route("matches")]
    public class MatchController : Controller
    {
        private readonly IMatchLogic _data;
        public MatchController(IMatchLogic data)
        {
            _data = data;
        }

        [HttpGet(Name = "GetMatchesInit")]
        //[HttpGet("{id}")]
        public async Task<IActionResult> InitialReplaySave()
        {
            return Ok(_data.GetMatches(387424));
        }
}
}
