using GameHeaven.Dtos.CPUDtos;
using GameHeaven.Dtos.DeveloperDtos;
using GameHeaven.Dtos.DirectXDtos;
using GameHeaven.Dtos.FranchiseDtos;
using GameHeaven.Dtos.GameDtos;
using GameHeaven.Dtos.GenreDtos;
using GameHeaven.Dtos.GPUDtos;
using GameHeaven.Dtos.OsDtos;
using GameHeaven.Dtos.PlatformDtos;
using GameHeaven.Dtos.PublisherDtos;
using GameHeaven.Dtos.StatusDtos;
using GameHeaven.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GameHeaven.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GameController : Controller
    {
        // GET: GameController
        public async Task<ActionResult> Index()
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var games = await Request<List<GameDto>>.GetAsync(APILinks.GAME_URL, token);
            return View(games);
        }

        // GET: GameController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GameController/Create
        public async Task<ActionResult> Create()
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var publishers = await Request<List<PublisherDto>>.GetAsync(APILinks.PUBLISHER_URL, token);
            var developers = await Request<List<DeveloperDto>>.GetAsync(APILinks.DEVELOPER_URL, token);
            var oses = await Request<List<OsDto>>.GetAsync(APILinks.OS_URL, token);
            var directXs = await Request<List<DirectXDto>>.GetAsync(APILinks.DIRECTX_URL, token);
            var cpus = await Request<List<CPUDto>>.GetAsync(APILinks.CPU_URL, token);
            var gpus = await Request<List<GPUDto>>.GetAsync(APILinks.GPU_URL, token);
            var statuses = await Request<List<StatusDto>>.GetAsync(APILinks.STATUS_URL, token);
            var platforms = await Request<List<PlatformDto>>.GetAsync(APILinks.PLATFORM_URL, token);
            var genres = await Request<List<GenreDto>>.GetAsync(APILinks.GENRE_URL, token);
            var franchises = await Request<List<FranchiseDto>>.GetAsync(APILinks.FRANCHISE_URL, token);
            GameViewModel gameViewModel = new()
            {
                MinCPUsSelectItems = cpus.Select(cpu => new SelectListItem
                {
                    Text = cpu.Name,
                    Value = cpu.Id.ToString(),
                }),
                MinGPUsSelectItems = gpus.Select(gpu => new SelectListItem
                {
                    Text = gpu.Name,
                    Value = gpu.Id.ToString(),
                }),
                DeveloperSelectItems = developers.Select(developer => new SelectListItem
                {
                    Text = developer.Name,
                    Value = developer.Id.ToString(),
                }),
                PublisherSelectItems = publishers.Select(publishers => new SelectListItem
                {
                    Text = publishers.Name,
                    Value = publishers.Id.ToString(),
                }),
                MinDirectXsSelectItems = directXs.Select(directx => new SelectListItem
                {
                    Text = directx.Name,
                    Value = directx.Id.ToString(),
                }),
                FranchisesSelectItems = franchises.Select(franchise => new SelectListItem
                {
                    Text = franchise.Name,
                    Value = franchise.Id.ToString(),
                }),
                GenresSelectItems = genres.Select(genre => new SelectListItem
                {
                    Text = genre.Name,
                    Value = genre.Id.ToString(),
                }),
                MinOsesSelectItems = oses.Select(os => new SelectListItem
                {
                    Text = os.Name,
                    Value = os.Id.ToString(),
                }),
                PlatformsSelectItems = platforms.Select(platform => new SelectListItem
                {
                    Text = platform.Name,
                    Value = platform.Id.ToString(),
                }),
                StatusesSelectItems = statuses.Select(status => new SelectListItem
                {
                    Text = status.Name,
                    Value = status.Id.ToString(),
                }),
            };
            return View(gameViewModel);
        }

        // POST: GameController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GameViewModel gameViewModel)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];

            if (ModelState.IsValid)
            {
                var filePath = Path.GetTempPath();
                var coverPath = Path.Combine(filePath, gameViewModel.CreateGame.Cover.FileName);
                using (var stream = new FileStream(coverPath, FileMode.Create))
                {
                    gameViewModel.CreateGame.Cover.CopyTo(stream);
                }
                List<(string, string)> filePaths = new()
                {
                    (coverPath, "Cover"),
                };
                foreach (var image in gameViewModel.CreateGame.Images)
                {
                    var imagePath = Path.Combine(filePath, image.FileName);
                    using (var str = new FileStream(imagePath, FileMode.Create))
                    {
                        image.CopyTo(str);
                    }
                    filePaths.Add((imagePath, "Images"));
                }
                foreach (var video in gameViewModel.CreateGame.Videos)
                {
                    var videoPath = Path.Combine(filePath, video.FileName);
                    using (var str = new FileStream(videoPath, FileMode.Create))
                    {
                        video.CopyTo(str);
                    }
                    filePaths.Add((videoPath, "Videos"));
                }

                List<(string, string)> variables = new();
                variables.Add(("Name", gameViewModel.CreateGame.Name));
                variables.Add(("Description", gameViewModel.CreateGame.Description));
                variables.Add(("Price", gameViewModel.CreateGame.Price.ToString()));
                variables.Add(("StatusId", gameViewModel.CreateGame.StatusId.ToString()));
                variables.Add(("PublisherId", gameViewModel.CreateGame.PublisherId.ToString()));
                variables.Add(("ReleaseDate", gameViewModel.CreateGame.ReleaseDate.ToString()));
                foreach (var id in gameViewModel.CreateGame.GenresIds)
                {
                    variables.Add(("GenresIds", id.ToString()));
                }
                foreach (var id in gameViewModel.CreateGame.PlatformIds)
                {
                    variables.Add(("PlatformIds", id.ToString()));
                }
                foreach (var id in gameViewModel.CreateGame.DeveloperIds)
                {
                    if (id != 0)
                    {
                        variables.Add(("DeveloperIds", id.ToString()));
                    }
                }
                if (gameViewModel.CreateGame.FranchiseId != 0)
                    variables.Add(("FranchiseId", gameViewModel.CreateGame.FranchiseId.ToString()));
                if (gameViewModel.CreateGame.RecommendedSystemRequirements.Storage != null)
                    variables.Add(("RecommendedSystemRequirements.Storage", gameViewModel.CreateGame.RecommendedSystemRequirements.Storage.ToString()));
                if (gameViewModel.CreateGame.RecommendedSystemRequirements.OsId != 0)
                    variables.Add(("RecommendedSystemRequirements.OsId", gameViewModel.CreateGame.RecommendedSystemRequirements.OsId.ToString()));
                if (gameViewModel.CreateGame.RecommendedSystemRequirements.GPUId != 0)
                    variables.Add(("RecommendedSystemRequirements.GPUId", gameViewModel.CreateGame.RecommendedSystemRequirements.GPUId.ToString()));
                if (gameViewModel.CreateGame.RecommendedSystemRequirements.CPUId != 0)
                    variables.Add(("RecommendedSystemRequirements.CPUId", gameViewModel.CreateGame.RecommendedSystemRequirements.CPUId.ToString()));
                if (gameViewModel.CreateGame.RecommendedSystemRequirements.DirectXId != 0)
                    variables.Add(("RecommendedSystemRequirements.DirectXId", gameViewModel.CreateGame.RecommendedSystemRequirements.DirectXId.ToString()));
                if (gameViewModel.CreateGame.RecommendedSystemRequirements.Ram != null)
                    variables.Add(("RecommendedSystemRequirements.Ram", gameViewModel.CreateGame.RecommendedSystemRequirements.Ram.ToString()));
                if (gameViewModel.CreateGame.RecommendedSystemRequirements.AdditionalNotes != null)
                    variables.Add(("RecommendedSystemRequirements.AdditionalNotes", gameViewModel.CreateGame.RecommendedSystemRequirements.AdditionalNotes));
                if (gameViewModel.CreateGame.MinimumSystemRequirements.Storage != null)
                    variables.Add(("MinimumSystemRequirements.Storage", gameViewModel.CreateGame.MinimumSystemRequirements.Storage.ToString()));
                if (gameViewModel.CreateGame.MinimumSystemRequirements.OsId != 0)
                    variables.Add(("MinimumSystemRequirements.OsId", gameViewModel.CreateGame.MinimumSystemRequirements.OsId.ToString()));
                if (gameViewModel.CreateGame.MinimumSystemRequirements.GPUId != 0)
                    variables.Add(("MinimumSystemRequirements.GPUId", gameViewModel.CreateGame.MinimumSystemRequirements.GPUId.ToString()));
                if (gameViewModel.CreateGame.MinimumSystemRequirements.CPUId != 0)
                    variables.Add(("MinimumSystemRequirements.CPUId", gameViewModel.CreateGame.MinimumSystemRequirements.CPUId.ToString()));
                if (gameViewModel.CreateGame.MinimumSystemRequirements.DirectXId != 0)
                    variables.Add(("MinimumSystemRequirements.DirectXId", gameViewModel.CreateGame.MinimumSystemRequirements.DirectXId.ToString()));
                if (gameViewModel.CreateGame.MinimumSystemRequirements.Ram != null)
                    variables.Add(("MinimumSystemRequirements.Ram", gameViewModel.CreateGame.MinimumSystemRequirements.Ram.ToString()));
                if (gameViewModel.CreateGame.MinimumSystemRequirements.AdditionalNotes != null)
                    variables.Add(("MinimumSystemRequirements.AdditionalNotes", gameViewModel.CreateGame.MinimumSystemRequirements.AdditionalNotes));

                var rep = await Request<GameDto>.PostAsync(APILinks.GAME_URL, null, "multipart/form-data", token: token, filePaths, variables);
                if (rep.Success)
                {
                    return RedirectToAction("Index");
                }
                return View(gameViewModel);
            }
            var publishers = await Request<List<PublisherDto>>.GetAsync(APILinks.PUBLISHER_URL, token);
            var developers = await Request<List<DeveloperDto>>.GetAsync(APILinks.DEVELOPER_URL, token);
            var oses = await Request<List<OsDto>>.GetAsync(APILinks.OS_URL, token);
            var directXs = await Request<List<DirectXDto>>.GetAsync(APILinks.DIRECTX_URL, token);
            var cpus = await Request<List<CPUDto>>.GetAsync(APILinks.CPU_URL, token);
            var gpus = await Request<List<GPUDto>>.GetAsync(APILinks.GPU_URL, token);
            var statuses = await Request<List<StatusDto>>.GetAsync(APILinks.STATUS_URL, token);
            var platforms = await Request<List<PlatformDto>>.GetAsync(APILinks.PLATFORM_URL, token);
            var genres = await Request<List<GenreDto>>.GetAsync(APILinks.GENRE_URL, token);
            var franchises = await Request<List<FranchiseDto>>.GetAsync(APILinks.FRANCHISE_URL, token);
            gameViewModel.MinCPUsSelectItems = cpus.Select(cpu => new SelectListItem
            {
                Text = cpu.Name,
                Value = cpu.Id.ToString(),
                Selected = gameViewModel.CreateGame.MinimumSystemRequirements.CPUId == cpu.Id
            });
            gameViewModel.MinGPUsSelectItems = gpus.Select(gpu => new SelectListItem
            {
                Text = gpu.Name,
                Value = gpu.Id.ToString(),
                Selected = gameViewModel.CreateGame.MinimumSystemRequirements.GPUId == gpu.Id
            });
            gameViewModel.MinOsesSelectItems = oses.Select(os => new SelectListItem
            {
                Text = os.Name,
                Value = os.Id.ToString(),
                Selected = gameViewModel.CreateGame.MinimumSystemRequirements.OsId == os.Id

            });
            gameViewModel.MinDirectXsSelectItems = directXs.Select(directx => new SelectListItem
            {
                Text = directx.Name,
                Value = directx.Id.ToString(),
                Selected = gameViewModel.CreateGame.MinimumSystemRequirements.DirectXId == directx.Id

            });
            gameViewModel.DeveloperSelectItems = developers.Select(developer => new SelectListItem
            {
                Text = developer.Name,
                Value = developer.Id.ToString(),
                Selected = gameViewModel.CreateGame.DeveloperIds != null ? gameViewModel.CreateGame.DeveloperIds.Contains(developer.Id) : false,
            });
            gameViewModel.PublisherSelectItems = publishers.Select(publisher => new SelectListItem
            {
                Text = publisher.Name,
                Value = publisher.Id.ToString(),
                Selected = gameViewModel.CreateGame.PublisherId == publisher.Id
            });
            gameViewModel.FranchisesSelectItems = franchises.Select(franchise => new SelectListItem
            {
                Text = franchise.Name,
                Value = franchise.Id.ToString(),
                Selected = gameViewModel.CreateGame.FranchiseId != null ? gameViewModel.CreateGame.FranchiseId == franchise.Id : false
            });
            gameViewModel.GenresSelectItems = genres.Select(genre => new SelectListItem
            {
                Text = genre.Name,
                Value = genre.Id.ToString(),
                Selected = gameViewModel.CreateGame.GenresIds.Contains(genre.Id)
            });
            gameViewModel.PlatformsSelectItems = platforms.Select(platform => new SelectListItem
            {
                Text = platform.Name,
                Value = platform.Id.ToString(),
                Selected = gameViewModel.CreateGame.PlatformIds.Contains(platform.Id)
            });
            gameViewModel.StatusesSelectItems = statuses.Select(status => new SelectListItem
            {
                Text = status.Name,
                Value = status.Id.ToString(),
                Selected = gameViewModel.CreateGame.StatusId == status.Id,
            });
            return View(gameViewModel);
        }

        // GET: GameController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            var publishers = await Request<List<PublisherDto>>.GetAsync(APILinks.PUBLISHER_URL, token);
            var developers = await Request<List<DeveloperDto>>.GetAsync(APILinks.DEVELOPER_URL, token);
            var oses = await Request<List<OsDto>>.GetAsync(APILinks.OS_URL, token);
            var directXs = await Request<List<DirectXDto>>.GetAsync(APILinks.DIRECTX_URL, token);
            var cpus = await Request<List<CPUDto>>.GetAsync(APILinks.CPU_URL, token);
            var gpus = await Request<List<GPUDto>>.GetAsync(APILinks.GPU_URL, token);
            var statuses = await Request<List<StatusDto>>.GetAsync(APILinks.STATUS_URL, token);
            var platforms = await Request<List<PlatformDto>>.GetAsync(APILinks.PLATFORM_URL, token);
            var genres = await Request<List<GenreDto>>.GetAsync(APILinks.GENRE_URL, token);
            var franchises = await Request<List<FranchiseDto>>.GetAsync(APILinks.FRANCHISE_URL, token);
            var game = await Request<UpdateGameDto>.GetAsync(APILinks.GAME_URL + "/" + id, token);
            GameViewModel gameViewModel = new()
            {
                UpdateGameDto = game,
                MinCPUsSelectItems = cpus.Select(cpu => new SelectListItem
                {
                    Text = cpu.Name,
                    Value = cpu.Id.ToString(),
                    Selected = game.MinimumSystemRequirements != null ? game.MinimumSystemRequirements.CPU.Id == cpu.Id : false,
                }),
                MinGPUsSelectItems = gpus.Select(gpu => new SelectListItem
                {
                    Text = gpu.Name,
                    Value = gpu.Id.ToString(),
                    Selected = game.MinimumSystemRequirements != null ? game.MinimumSystemRequirements.GPU.Id == gpu.Id : false,
                }),
                MinOsesSelectItems = oses.Select(os => new SelectListItem
                {
                    Text = os.Name,
                    Value = os.Id.ToString(),
                    Selected = game.MinimumSystemRequirements != null ? game.MinimumSystemRequirements.Os.Id == os.Id : false

                }),
                MinDirectXsSelectItems = directXs.Select(directx => new SelectListItem
                {
                    Text = directx.Name,
                    Value = directx.Id.ToString(),
                    Selected = game.MinimumSystemRequirements != null ? game.MinimumSystemRequirements.DirectX.Id == directx.Id : false

                }),
                RecCPUsSelectItems = cpus.Select(cpu => new SelectListItem
                {
                    Text = cpu.Name,
                    Value = cpu.Id.ToString(),
                    Selected = game.RecommendedSystemRequirements != null ? game.RecommendedSystemRequirements.CPU.Id == cpu.Id : false
                }),
                RecGPUsSelectItems = gpus.Select(gpu => new SelectListItem
                {
                    Text = gpu.Name,
                    Value = gpu.Id.ToString(),
                    Selected = game.RecommendedSystemRequirements != null ? game.RecommendedSystemRequirements.GPU.Id == gpu.Id : false
                }),
                RecOsesSelectItems = oses.Select(os => new SelectListItem
                {
                    Text = os.Name,
                    Value = os.Id.ToString(),
                    Selected = game.RecommendedSystemRequirements != null ? game.RecommendedSystemRequirements.Os.Id == os.Id : false

                }),
                RecDirectXsSelectItems = directXs.Select(directx => new SelectListItem
                {
                    Text = directx.Name,
                    Value = directx.Id.ToString(),
                    Selected = game.RecommendedSystemRequirements != null ? game.RecommendedSystemRequirements.DirectX.Id == directx.Id : false

                }),
                DeveloperSelectItems = developers.Select(developer => new SelectListItem
                {
                    Text = developer.Name,
                    Value = developer.Id.ToString(),
                    Selected = game.Developers != null ? game.Developers.Select(dev => dev.Id).Contains(developer.Id) : false,
                }),
                PublisherSelectItems = publishers.Select(publisher => new SelectListItem
                {
                    Text = publisher.Name,
                    Value = publisher.Id.ToString(),
                    Selected = game.Publisher.Id == publisher.Id
                }),
                FranchisesSelectItems = franchises.Select(franchise => new SelectListItem
                {
                    Text = franchise.Name,
                    Value = franchise.Id.ToString(),
                    Selected = game.Franchise != null ? game.Franchise.Id == franchise.Id : false
                }),
                GenresSelectItems = genres.Select(genre => new SelectListItem
                {
                    Text = genre.Name,
                    Value = genre.Id.ToString(),
                    Selected = game.Genres.Select(genre => genre.Id).Contains(genre.Id)
                }),
                PlatformsSelectItems = platforms.Select(platform => new SelectListItem
                {
                    Text = platform.Name,
                    Value = platform.Id.ToString(),
                    Selected = game.Platforms.Select(platform => platform.Id).Contains(platform.Id)
                }),
                StatusesSelectItems = statuses.Select(status => new SelectListItem
                {
                    Text = status.Name,
                    Value = status.Id.ToString(),
                    Selected = game.Status.Id == status.Id,
                })
            };
            return View(gameViewModel);
        }


        // POST: GameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, GameViewModel gameViewModel)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            if (ModelState.IsValid)
            {

                var filePath = Path.GetTempPath();
                List<(string, string)> filePaths = new();
                if (gameViewModel.UpdateGameDto.Cover != null)
                {
                    var coverPath = Path.Combine(filePath, gameViewModel.UpdateGameDto.Cover.FileName);
                    using (var stream = new FileStream(coverPath, FileMode.Create))
                    {
                        gameViewModel.UpdateGameDto.Cover.CopyTo(stream);
                    }
                    filePaths.Add((coverPath, "Cover"));
                }
                if (gameViewModel.UpdateGameDto.Images != null)
                {

                    foreach (var image in gameViewModel.UpdateGameDto.Images)
                    {
                        var imagePath = Path.Combine(filePath, image.FileName);
                        using (var str = new FileStream(imagePath, FileMode.Create))
                        {
                            image.CopyTo(str);
                        }
                        filePaths.Add((imagePath, "Images"));
                    }
                }
                if (gameViewModel.UpdateGameDto.Videos != null)
                {
                    foreach (var video in gameViewModel.UpdateGameDto.Videos)
                    {
                        var videoPath = Path.Combine(filePath, video.FileName);
                        using (var str = new FileStream(videoPath, FileMode.Create))
                        {
                            video.CopyTo(str);
                        }
                        filePaths.Add((videoPath, "Videos"));
                    }
                }

                List<(string, string)> variables = new();
                variables.Add(("Name", gameViewModel.UpdateGameDto.Name));
                variables.Add(("Description", gameViewModel.UpdateGameDto.Description));
                variables.Add(("Price", gameViewModel.UpdateGameDto.Price.ToString()));
                variables.Add(("StatusId", gameViewModel.UpdateGameDto.StatusId.ToString()));
                variables.Add(("PublisherId", gameViewModel.UpdateGameDto.PublisherId.ToString()));
                variables.Add(("ReleaseDate", gameViewModel.UpdateGameDto.ReleaseDate.ToString()));
                foreach (var gid in gameViewModel.UpdateGameDto.GenresIds)
                {
                    variables.Add(("GenresIds", gid.ToString()));
                }
                foreach (var pid in gameViewModel.UpdateGameDto.PlatformIds)
                {
                    variables.Add(("PlatformIds", pid.ToString()));
                }
                foreach (var did in gameViewModel.UpdateGameDto.DeveloperIds)
                {
                    if (did != 0)
                    {
                        variables.Add(("DeveloperIds", did.ToString()));
                    }
                }
                if (gameViewModel.UpdateGameDto.FranchiseId != 0)
                    variables.Add(("FranchiseId", gameViewModel.UpdateGameDto.FranchiseId.ToString()));
                if (gameViewModel.UpdateGameDto.UpdatedRecommendedSystemRequirements.Storage != null)
                    variables.Add(("RecommendedSystemRequirements.Storage", gameViewModel.UpdateGameDto.UpdatedRecommendedSystemRequirements.Storage.ToString()));
                if (gameViewModel.UpdateGameDto.UpdatedRecommendedSystemRequirements.OsId != 0)
                    variables.Add(("RecommendedSystemRequirements.OsId", gameViewModel.UpdateGameDto.UpdatedRecommendedSystemRequirements.OsId.ToString()));
                if (gameViewModel.UpdateGameDto.UpdatedRecommendedSystemRequirements.GPUId != 0)
                    variables.Add(("RecommendedSystemRequirements.GPUId", gameViewModel.UpdateGameDto.UpdatedRecommendedSystemRequirements.GPUId.ToString()));
                if (gameViewModel.UpdateGameDto.UpdatedRecommendedSystemRequirements.CPUId != 0)
                    variables.Add(("RecommendedSystemRequirements.CPUId", gameViewModel.UpdateGameDto.UpdatedRecommendedSystemRequirements.CPUId.ToString()));
                if (gameViewModel.UpdateGameDto.UpdatedRecommendedSystemRequirements.DirectXId != 0)
                    variables.Add(("RecommendedSystemRequirements.DirectXId", gameViewModel.UpdateGameDto.UpdatedRecommendedSystemRequirements.DirectXId.ToString()));
                if (gameViewModel.UpdateGameDto.UpdatedRecommendedSystemRequirements.Ram != null)
                    variables.Add(("RecommendedSystemRequirements.Ram", gameViewModel.UpdateGameDto.UpdatedRecommendedSystemRequirements.Ram.ToString()));
                if (gameViewModel.UpdateGameDto.UpdatedRecommendedSystemRequirements.AdditionalNotes != null)
                    variables.Add(("RecommendedSystemRequirements.AdditionalNotes", gameViewModel.UpdateGameDto.UpdatedRecommendedSystemRequirements.AdditionalNotes));
                if (gameViewModel.UpdateGameDto.UpdatedMinimumSystemRequirements.Storage != null)
                    variables.Add(("MinimumSystemRequirements.Storage", gameViewModel.UpdateGameDto.UpdatedRecommendedSystemRequirements.Storage.ToString()));
                if (gameViewModel.UpdateGameDto.UpdatedMinimumSystemRequirements.OsId != 0)
                    variables.Add(("MinimumSystemRequirements.OsId", gameViewModel.UpdateGameDto.UpdatedMinimumSystemRequirements.OsId.ToString()));
                if (gameViewModel.UpdateGameDto.UpdatedMinimumSystemRequirements.GPUId != 0)
                    variables.Add(("MinimumSystemRequirements.GPUId", gameViewModel.UpdateGameDto.UpdatedMinimumSystemRequirements.GPUId.ToString()));
                if (gameViewModel.UpdateGameDto.UpdatedMinimumSystemRequirements.CPUId != 0)
                    variables.Add(("MinimumSystemRequirements.CPUId", gameViewModel.UpdateGameDto.UpdatedMinimumSystemRequirements.CPUId.ToString()));
                if (gameViewModel.UpdateGameDto.UpdatedMinimumSystemRequirements.DirectXId != 0)
                    variables.Add(("MinimumSystemRequirements.DirectXId", gameViewModel.UpdateGameDto.UpdatedMinimumSystemRequirements.DirectXId.ToString()));
                if (gameViewModel.UpdateGameDto.UpdatedMinimumSystemRequirements.Ram != null)
                    variables.Add(("MinimumSystemRequirements.Ram", gameViewModel.UpdateGameDto.UpdatedMinimumSystemRequirements.Ram.ToString()));
                if (gameViewModel.UpdateGameDto.UpdatedMinimumSystemRequirements.AdditionalNotes != null)
                    variables.Add(("MinimumSystemRequirements.AdditionalNotes", gameViewModel.UpdateGameDto.UpdatedMinimumSystemRequirements.AdditionalNotes));

                var rep = await Request<GameDto>.PutAsync(APILinks.GAME_URL + "/" + id, null, "multipart/form-data", token: token, filePaths, variables);
                if (rep.Success)
                {
                    return RedirectToAction("Index");
                }
                return View(gameViewModel);
            }
            var publishers = await Request<List<PublisherDto>>.GetAsync(APILinks.PUBLISHER_URL, token);
            var developers = await Request<List<DeveloperDto>>.GetAsync(APILinks.DEVELOPER_URL, token);
            var oses = await Request<List<OsDto>>.GetAsync(APILinks.OS_URL, token);
            var directXs = await Request<List<DirectXDto>>.GetAsync(APILinks.DIRECTX_URL, token);
            var cpus = await Request<List<CPUDto>>.GetAsync(APILinks.CPU_URL, token);
            var gpus = await Request<List<GPUDto>>.GetAsync(APILinks.GPU_URL, token);
            var statuses = await Request<List<StatusDto>>.GetAsync(APILinks.STATUS_URL, token);
            var platforms = await Request<List<PlatformDto>>.GetAsync(APILinks.PLATFORM_URL, token);
            var genres = await Request<List<GenreDto>>.GetAsync(APILinks.GENRE_URL, token);
            var franchises = await Request<List<FranchiseDto>>.GetAsync(APILinks.FRANCHISE_URL, token);
            gameViewModel.MinCPUsSelectItems = cpus.Select(cpu => new SelectListItem
            {
                Text = cpu.Name,
                Value = cpu.Id.ToString(),
                Selected = gameViewModel.UpdateGameDto.UpdatedMinimumSystemRequirements.CPUId == cpu.Id
            });
            gameViewModel.MinGPUsSelectItems = gpus.Select(gpu => new SelectListItem
            {
                Text = gpu.Name,
                Value = gpu.Id.ToString(),
                Selected = gameViewModel.UpdateGameDto.UpdatedMinimumSystemRequirements.GPUId == gpu.Id
            });
            gameViewModel.MinOsesSelectItems = oses.Select(os => new SelectListItem
            {
                Text = os.Name,
                Value = os.Id.ToString(),
                Selected = gameViewModel.UpdateGameDto.UpdatedMinimumSystemRequirements.OsId == os.Id

            });
            gameViewModel.MinDirectXsSelectItems = directXs.Select(directx => new SelectListItem
            {
                Text = directx.Name,
                Value = directx.Id.ToString(),
                Selected = gameViewModel.UpdateGameDto.UpdatedMinimumSystemRequirements.DirectXId == directx.Id

            });
            gameViewModel.RecCPUsSelectItems = cpus.Select(cpu => new SelectListItem
            {
                Text = cpu.Name,
                Value = cpu.Id.ToString(),
                Selected = gameViewModel.UpdateGameDto.UpdatedRecommendedSystemRequirements.CPUId == cpu.Id
            });
            gameViewModel.RecGPUsSelectItems = gpus.Select(gpu => new SelectListItem
            {
                Text = gpu.Name,
                Value = gpu.Id.ToString(),
                Selected = gameViewModel.UpdateGameDto.UpdatedRecommendedSystemRequirements.GPUId == gpu.Id
            });
            gameViewModel.RecOsesSelectItems = oses.Select(os => new SelectListItem
            {
                Text = os.Name,
                Value = os.Id.ToString(),
                Selected = gameViewModel.UpdateGameDto.UpdatedRecommendedSystemRequirements.OsId == os.Id

            });
            gameViewModel.RecDirectXsSelectItems = directXs.Select(directx => new SelectListItem
            {
                Text = directx.Name,
                Value = directx.Id.ToString(),
                Selected = gameViewModel.UpdateGameDto.UpdatedRecommendedSystemRequirements.DirectXId == directx.Id

            });
            gameViewModel.DeveloperSelectItems = developers.Select(developer => new SelectListItem
            {
                Text = developer.Name,
                Value = developer.Id.ToString(),
                Selected = gameViewModel.UpdateGameDto.DeveloperIds != null ? gameViewModel.CreateGame.DeveloperIds.Contains(developer.Id) : false,
            });
            gameViewModel.PublisherSelectItems = publishers.Select(publisher => new SelectListItem
            {
                Text = publisher.Name,
                Value = publisher.Id.ToString(),
                Selected = gameViewModel.UpdateGameDto.PublisherId == publisher.Id
            });
            gameViewModel.FranchisesSelectItems = franchises.Select(franchise => new SelectListItem
            {
                Text = franchise.Name,
                Value = franchise.Id.ToString(),
                Selected = gameViewModel.UpdateGameDto.FranchiseId != null ? gameViewModel.CreateGame.FranchiseId == franchise.Id : false
            });
            gameViewModel.GenresSelectItems = genres.Select(genre => new SelectListItem
            {
                Text = genre.Name,
                Value = genre.Id.ToString(),
                Selected = gameViewModel.UpdateGameDto.GenresIds.Contains(genre.Id)
            });
            gameViewModel.PlatformsSelectItems = platforms.Select(platform => new SelectListItem
            {
                Text = platform.Name,
                Value = platform.Id.ToString(),
                Selected = gameViewModel.UpdateGameDto.PlatformIds.Contains(platform.Id)
            });
            gameViewModel.StatusesSelectItems = statuses.Select(status => new SelectListItem
            {
                Text = status.Name,
                Value = status.Id.ToString(),
                Selected = gameViewModel.UpdateGameDto.StatusId == status.Id,
            });
            return View(gameViewModel);

        }

        // GET: GameController/Delete/5
        // GET: DeveloperController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var token = Request.Cookies[Constants.JWT.ToString()];
            string link = APILinks.GAME_URL + "/" + id;
            return View(await Request<GameDto>.GetAsync(link, token));
        }

        // POST: DeveloperController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, GameDto game)
        {
            if (ModelState.IsValid)
            {
                var token = Request.Cookies[Constants.JWT.ToString()];
                await Request<GameDto>.DeleteAsync(APILinks.GAME_URL + "/" + id, token);
                return RedirectToAction("Index");
            }
            return View(game);
        }
    }
}
