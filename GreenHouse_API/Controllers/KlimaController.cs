using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenHouse_API.Managers;
using GreenHouse_API.Interfaces;

namespace GreenHouse_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlimaController : ControllerBase
    {
        private IGreenHouseManagers _mgr = new GreenHouseManager();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            return Ok(_mgr.GetAll());
        }

        [HttpGet("{date}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int date)
        {
            return Ok(_mgr.Get(date));
        }



    }
}
