using Stats.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace Stats.Models
{
    public interface IModelFactory
    {
        PlayerModel Create(Player player);
        Player Create(PlayerModel playerModel);

        TeamModel Create(Team team);
        Team Create(TeamModel teamModel);

        GameModel Create(Game game);

        GameEventModel Create(GameEvent gameEvent);

        GameEvent Create(Game gameEntity, Player playerEntity, int pointValue);
    }
    public class ModelFactory: IModelFactory
    {
        private UrlHelper _urlHelper;

        public ModelFactory(HttpRequestMessage message)
        {
            _urlHelper = new UrlHelper(message);
        }

        public PlayerModel Create(Player player)
        {
            return new PlayerModel { 
                URL = _urlHelper.Link("DefaultApi", new {id = player.ID}),
                FirstName = player.FirstName, 
                LastName = player.LastName, 
                PlayerID = player.ID, 
                TeamID = player.Team != null ? player.Team.ID : 0, 
                TeamName = player.Team != null ? player.Team.Name : null
            };
        }

        public Player Create(PlayerModel playerModel)
        {
            if(playerModel.PlayerID == 0)
            {
                return new Player
                {
                    FirstName = playerModel.FirstName,
                    LastName = playerModel.LastName,
                    updatedDate = DateTime.Now
                };
            }
            return new Player { 
                ID = playerModel.PlayerID,
                FirstName = playerModel.FirstName, 
                LastName = playerModel.LastName, 
                updatedDate = DateTime.Now
            };
        }

        public TeamModel Create(Team team)
        {
            return new TeamModel { 
                TeamID = team.ID, 
                TeamName = team.Name,
                Players = new List<PlayerModel>(team.Players.Select(Create))
            };
        }

        public Team Create(TeamModel teamModel)
        {
            return new Team { 
                ID = teamModel.TeamID,
                Name = teamModel.TeamName, 
                updatedDate = DateTime.Now, 
                Players = new List<Player>(teamModel.Players.Select(Create))
            };
        }

        public GameModel Create(Game game)
        {
            return new GameModel
            {
                AwayTeam = Create(game.AwayTeam),
                HomeTeam = Create(game.HomeTeam),
                GameEvents = game.GameEvents.Select(Create).ToList(),
                GameID = game.ID,
                StartTime = game.StartTime
            };
        }

        public GameEventModel Create(GameEvent gameEvent)
        {
            return new GameEventModel
            {
                GameID = gameEvent.ID,
                PlayerID = gameEvent.Player.ID,
                PointValue = gameEvent.PointValue
            };
        }

        public GameEvent Create(Game gameEntity, Player playerEntity, int pointValue)
        {
            return new GameEvent
            {
                Game = gameEntity,
                Player = playerEntity,
                PointValue = pointValue,
                updatedDate = DateTime.Now
            };
        }
    }
}