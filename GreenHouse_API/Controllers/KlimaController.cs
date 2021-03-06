using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using GreenHouse_API.Managers;
using GreenHouse_API.Interfaces;
using GreenHouse_API.Models;
using ModelLib;

namespace GreenHouse_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlimaController : ControllerBase
    {
        private IGreenHouseManagers _mgr = new GreenHouseManager();

        //public KlimaController(GreenHouseDbContext context)
        //{
        //    _mgr = new GreenHouseManagerDB(context);
        //}

        [HttpGet]
        [Route("all/Values")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            return Ok(_mgr.GetAll());
        }

        [HttpGet("{date}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(DateTime date)
        {
            return Ok(_mgr.Get(date));
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetLatest()
        {
            return Ok(_mgr.GetLatest());
        }

        [HttpGet]
        [Route("get/last/24h")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Getlast24()
        {
            return Ok(_mgr.GetLast24Hours());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Klima klima)
        {
            try
            {
                return Ok(_mgr.Create(klima));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
