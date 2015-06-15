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
    public class TeamController : BaseAPIController
    {
        public TeamController(IStatsService statsService) : base(statsService)
        {
        }
        public IHttpActionResult Get()
        {
            try
            {
                var teams = StatsService.Teams.Get();
                var models = teams.Select(ModelFactory.Create);

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
                var teams = StatsService.Teams.Get(id);
                var model = ModelFactory.Create(teams);

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
        public IHttpActionResult Post([FromBody] TeamModel teamModel)
        {
            //if (!ModelState.IsValid) return BadRequest(ModelState);
            var teamEntity = ModelFactory.Create(teamModel);
            var team = StatsService.Teams.Insert(teamEntity);

            var model = ModelFactory.Create(team);
            return Created("", model);
        }
    }
}
