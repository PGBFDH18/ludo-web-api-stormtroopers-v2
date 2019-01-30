﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LudoGameEngine;
using WebAPI.Models;
using System.Collections.Specialized;
using System.Net;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]
    public class LudoController : Controller
    {
        public ILudoModel context;
        public LudoController(ILudoModel _context)
        {
            context = _context;
        }

        // POST: api/ludo/createnewgame
        [HttpPost("createnewgame")]
        public IActionResult CreateNewGame()
        {
            Guid guid = context.AddGame();
            guid.ToString().Replace('-','a');
            return Ok(guid);
        }

        // DELETE: api/ludo/{IDofTheGame(GUID ID)}/removegame
        [HttpDelete("{id}/removegame")]
        public IActionResult RemoveGame(Guid id)
        {
            if (!context.RemoveGame(id))
            {
                return NotFound(id);
            }
            else
            {
                return Ok();
            }
        }

        // POST: api/ludo/{IDofTheGame(GUID ID)}/players/addplayer?name={input}&colorID={input<=1,4=>}
        [HttpPost("{id}/players/addplayer")]
        public IActionResult AddPlayer(Guid id, string name, int colorID)
        {
            if (context.AddPlayer(id, name, colorID) == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(context.GetGameDetail(id).GetPlayer(colorID));
            }
        }

        // DELETE: api/ludo{{IDofTheGame(GUID ID)}/players
        [HttpDelete("{id}/players")]
        public IActionResult RemovePlayer(Guid id, int colorID)
        {
            if (!context.RemovePlayer(id, colorID))
            {
                return NotFound(new KeyValuePair<Guid, int>(id, colorID));
            }

            return Ok(new KeyValuePair<Guid, int>(id, colorID));
        }

        // GET: api/Ludo/getallgames
        [HttpGet("getallgames")]
        public IActionResult GetAllGames()
        {
            return Ok(context.GetAllGames());
        }

        // GET: api/ludo/{{IDofTheGame(GUID ID)}/getgamedetails
        [HttpGet("{id}/getgamedetails")]
        public IActionResult GetGameDetails(Guid id)
        {
            if (context.GetGameDetail(id) == null)
            {
                return NotFound(id);
            }

            return Ok(context.GetGameDetail(id));
        }

        // GET: api/ludo/{{IDofTheGame(GUID ID)}/players/getplayers
        [HttpGet("{id}/players/getplayers")]
        public IActionResult GetAllPlayers(Guid id)
        {
            if (context.GetAllPlayers(id) == null)
            {
                return NotFound(id);
            }

            return Ok(context.GetAllPlayers(id));
        }

        // GET: api/ludo/{{IDofTheGame(GUID ID)}/players?colorID={input}
        [HttpGet("{id}/players")]
        public IActionResult GetPlayerDetails(Guid id, int colorID)
        {
            if (context.GetPlayerDetails(id, colorID) == null)
            {
                return NotFound(id);
            }

            return Ok(context.GetPlayerDetails(id, colorID));
        }

        // PUT: api/ludo/{{IDofTheGame(GUID ID)}/changeplayerdetails
        [HttpPut("{id}/changeplayerdetails")]
        public IActionResult ChangePlayerDetails(Guid id,int oldColorID, string name, int colorID)
        {
            var foo = context.ChangePlayerDetails(id, oldColorID, name, colorID);

            if (foo == null)
            {
                return NotFound(foo);
            }

            return Ok(foo);
        }

        // PUT: api/ludo/{{IDofTheGame(GUID ID)}/startgame
        [HttpPut("{id}/startgame")]
        public IActionResult StartGame(Guid id)
        {
            return Ok(context.StartGame(id));
        }

        // GET: api/ludo/{{IDofTheGame(GUID ID)}/rolldice
        [HttpGet("{id}/rolldice")]
        public IActionResult RollDice(Guid id)
        {
            return Ok(context.RollDice(id));
        }

        // PUT: api/ludo/{{IDofTheGame(GUID ID)}/movepiece
        [HttpPut("{id}/movepiece")]
        public IActionResult MovePiece(Guid id, int pieceId, int numberOfFields)
        {
            return Ok(context.MovePiece(id, pieceId, numberOfFields));
        }

        // PUT: api/ludo/{{IDofTheGame(GUID ID)}/endturn
        [HttpPut("{id}/endturn")]
        public IActionResult EndTurn(Guid id)
        {
            context.EndTurn(id);
            return Ok();
        }

        // GET: api/ludo/{{IDofTheGame(GUID ID)}/getwinner
        [HttpGet("{id}/getwinner")]
        public IActionResult GetWinner(Guid id)
        {
            return Ok(context.GetWinner(id));
        }
    }
}