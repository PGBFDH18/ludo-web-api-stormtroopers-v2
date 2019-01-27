using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LudoGameEngine;
using LudoWebApiTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LudoWebApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LudoController : ControllerBase
    {

        //private static ILudoGame _game;
        //public LudoController(ILudoGame game)
        //{
        //    _game = game;
        //}
        //GET: api/Ludo

       [HttpGet]
        //public List<LudoGame> Get()
        //{
            
        //}
        //public void LudoGame()
        //{
        //    LudoGame myGame = new LudoGame();
        //}

        //GET: api/Ludo/5
        [HttpGet("{id}", Name = "Get")]
        public LudoGameApi Get(int id)
        {
           //return new LudoGame[];
           // LudoGame game = new LudoGame(new Diece());
           // LudoGame game1 = new LudoGame(new Diece());
           // List<LudoGame> gameNmber1 = new List<LudoGame>();
                
                
                //LudoGameApi() { StateOfTheGame = game.ToString() };
            //rturn "value";
        }














        // POST: api/Ludo
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Ludo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
