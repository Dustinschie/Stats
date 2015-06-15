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
    public class PlayerController : BaseAPIController
    {
        public PlayerController(IStatsService statsService): base(statsService)
        {
        }

        public IHttpActionResult Get()
        {
            try
            {
                var players = StatsService.Players.Get();
                var models = players.Select(ModelFactory.Create);

                return Ok(models);
            }
            catch (Exception ex)
            {
                // logging
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
                var player = StatsService.Players.Get(id);
                var model = ModelFactory.Create(player);

                return Ok(model);
            }
            catch (Exception ex)
            {
                // logging
#if DEBUG
                return InternalServerError(ex);
#endif
                return InternalServerError();
            }

        }
        [ModelValidator]
        public IHttpActionResult Post([FromBody] PlayerModel playerModel)
        {
            //if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var playerEntity = ModelFactory.Create(playerModel);
                var player = StatsService.Players.Insert(playerEntity);

                var model = ModelFactory.Create(player);
                return Created(playerModel.URL, model);
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
        public IHttpActionResult Put([FromBody] PlayerModel playerModel)
        {
            try
            {
                var playerEntity = ModelFactory.Create(playerModel);
                var player = StatsService.Players.Update(playerEntity);

                var model = ModelFactory.Create(player);
                return Ok(model);

            }
            catch (Exception ex)
            {
#if DEBUG
                return InternalServerError(ex);
#endif
                return InternalServerError();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                var playerEntity = StatsService.Players.Get(id);
                if(playerEntity != null)
                    StatsService.Players.Delete(playerEntity);
                else
                    return NotFound();

                return Ok();
            }catch(Exception ex)
            {
#if DEBUG
                return InternalServerError(ex);
#endif
                return InternalServerError();
            }
        }
    }
}
