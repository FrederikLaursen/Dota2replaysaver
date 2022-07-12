﻿using BusinessLogic;
using Dota2replaysaver.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Dota2replaysaver.Controllers
{
    [ApiController]
    [Route("matches")]
    public class MatchController : Controller
    {
        private BusinessLogic.MatchLogic _ML;
        public MatchController(IMatchLogic data)
        {
            _ML = new BusinessLogic.MatchLogic(data);
        }

        [HttpGet(Name = "GetMatchesInit")]
        //[HttpGet("{id}")]
        public async Task<IActionResult> InitialReplaySave()
        {
            return Ok(_ML.GetMatches(123));
        }
}
}
