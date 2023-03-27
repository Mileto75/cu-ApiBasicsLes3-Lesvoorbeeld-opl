using Microsoft.CodeAnalysis.CSharp.Syntax;
using Pri.Ca.Api.DTOs;
using Pri.Ca.Api.DTOs.Games;
using Pri.Ca.Core.Entities;

namespace Pri.Ca.Api.Extensions
{
    public static class Mappers
    {
        //extension
        public static GameResponseDto MaptoDto(this Game game)
        {
            return new GameResponseDto
            {
                Id = game.Id,
                Name = game.Name,
                Categories = game.Categories.Select
                (c => new BaseResponseDto 
                {
                    Id = c.Id,
                    Name = c.Name,
                }),
                Image = game.Image,

            };
        }
        //map from IEnumerable<Game> => GamesresponseDto
        public static GamesResponseDto MapToDto(this IEnumerable<Game> games)
        {
            return new GamesResponseDto
            {
                Games = games.Select(g => g.MaptoDto())
            };
        }
    }
}

