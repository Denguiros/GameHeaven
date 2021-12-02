using GameHeaven.Dtos.GameDtos;
using System.Collections.Generic;

namespace GameHeaven.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public List<GameDto> Games { get; set; }
    }
}
