using Stats.DataAccess.Entities;
using Stats.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stats.DataAccess
{
    public interface IStatsService
    {
        Repository<Game> Games { get; }
        Repository<Team> Teams { get; }
        Repository<Player> Players { get; }
        Repository<GameEvent> GameEvents { get; }
    }
}