using Microsoft.AspNetCore.Mvc;
using GameHeaven.Models;
using GameHeaven.ViewModels;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System;
using GameHeaven.Dtos.DeveloperDtos;
using GameHeaven.Dtos.GameDtos;
using System.Collections.Generic;

namespace GameHeaven.Controllers
{
    public class DeveloperController : Controller
    {

        [Route("developer/{id}")]
        public async Task<IActionResult> IndexAsync(int id)
        {
            var dev = await Request<DeveloperDto>.GetAsync(APILinks.DEVELOPER_URL + "/" + id);
            var games = await Request<List<GameDto>>.GetAsync(APILinks.GAME_URL);

            List<GameDto> devGames = new List<GameDto>();
            foreach (var game in games)
            {
                foreach(var d in game.Developers)
                {
                    if (d.Id == id)
                    {
                        StringBuilder str = new StringBuilder("");

                        var imgs = game.ImagesPath.Split(",").ToList();
                        imgs.ForEach(img => {
                            str.Append(img.Trim(new Char[] { '[', '"', ']' }));
                            str.Append(",");
                        });
                        game.ImagesPath = str.ToString();

                        devGames.Add(game);
                        break;
                    }
                }
            }

            ViewBag.games = devGames;

            return View(dev);

        }
    }
}
