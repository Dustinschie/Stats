using Stats.DataAccess.Entities;
using Stats.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stats.DataAccess
{
    public class StatsService: IStatsService
    {
        private Repository<Game> _games;
        private Repository<Team> _teams;
        private Repository<Player> _players;
        private Repository<GameEvent> _gameEvents;
        
        private StatsDbContext _context;

        public StatsService(StatsDbContext context = null)
        {
            _context = context == null ? new StatsDbContext() : context;
        }

        public Repository<Game> Games
        {
            get 
            { 
                 if(_games == null)
                 {
                     _games = new GameRepository(_context);
                 }
                 return _games;
            }
        }

        public Repository<Team> Teams
        {
            get 
            {
                if (_teams == null)
                {
                    _teams = new TeamRepository(_context);
                }
                return _teams;
            }
        }

        public Repository<Player> Players
        {
            get 
            {
                if (_players == null)
                {
                    _players = new PlayerRepository(_context);
                }
                return _players; 
            }
        }

        public Repository<GameEvent> GameEvents
        {
            get 
            {
                if (_gameEvents == null)
                {
                    _gameEvents = new GameEventRepository(_context);
                }
                return _gameEvents;
            }
        }
    }
}