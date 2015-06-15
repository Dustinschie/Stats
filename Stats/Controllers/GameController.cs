using Stats.DataAccess;
using Stats.Filters;
using Stats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Stats.Controllers
{
    public class GameController : BaseAPIController
    {
        public GameController(IStatsService statsService) : base(statsService) { }

        public IHttpActionResult Get()
        {
            try
            {
                var gameEntities = StatsService.Games.Get();
                Object gameModels = gameEntities.Select(ModelFactory.Create);
                return Ok(gameModels);
            }
            catch (Exception ex)
            {
#if DEBUG
                return InternalServerError(ex);       
#endif    
                return InternalServerError();
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var gameEntity = StatsService.Games.Get(id);
                Object gameModel = ModelFactory.Create(gameEntity);
                return Ok(gameModel);
            }
            catch (Exception ex)
            {
#if DEBUG
                return InternalServerError(ex);
#endif
                return InternalServerError();
            }
        }
        [ModelValidator]
        public IHttpActionResult CreateEvent([FromBody] GameEventModel gameEventModel)
        {
            try
            {
                var gameEntity = StatsService.Games.Get(gameEventModel.GameID);
                var playerEntity = StatsService.Players.Get(gameEventModel.PlayerID);

                var pointValue = gameEventModel.PointValue;
                var gameEventEntity = ModelFactory.Create(gameEntity, playerEntity, pointValue);
                StatsService.GameEvents.Insert(gameEventEntity);

                return Created("", gameEventModel);
            }
            catch (Exception ex)
            {
#if DEBUG
                return InternalServerError(ex);
#endif
                return InternalServerError(); 
                
            }
        }
    }   
}
