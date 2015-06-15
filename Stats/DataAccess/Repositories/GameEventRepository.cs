using Stats.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stats.DataAccess.Repositories
{
    public class GameEventRepository : Repository<GameEvent>
    {
        public GameEventRepository(StatsDbContext context) : base(context) { }
    }
}