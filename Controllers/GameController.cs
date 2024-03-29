﻿using Microsoft.AspNetCore.Mvc;
using GameHeaven.Models;
using GameHeaven.ViewModels;
using GameHeaven.Dtos.GameDtos;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;

namespace GameHeaven.Controllers
{
    public class GameController : Controller
    {
        [Route("game/{id}")]
        public async Task<IActionResult> IndexAsync(int id)
        {
            var game = await Request<GameDto>.GetAsync(APILinks.GAME_URL + "/" + id);

            StringBuilder str = new StringBuilder("");
            StringBuilder str2 = new StringBuilder("");

            var imgs = game.ImagesPath.Split(",").ToList();
            imgs.ForEach(img =>
            {
                str.Append(img.Trim(new Char[] { '[', '"', ']' }));
                str.Append(",");
            });
            var vids = game.VideosPath.Split(",").ToList();
            vids.ForEach(vid =>
            {
                str2.Append(vid.Trim(new Char[] { '[', '"', ']' }));
                str2.Append(",");
            });
            game.ImagesPath = str.ToString();
            game.VideosPath = str2.ToString();
            return View(game);
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> Search(string name)
        {
            var games = await Request<List<GameDto>>.GetAsync(APILinks.GAME_URL);
            if (name != null)
            {

                return Ok(games.Where(game => game.Name.Contains(name)).ToList());
            }
            else
            {
                return Ok(games);
            }

        }

    }
}
