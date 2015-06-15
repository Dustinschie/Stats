using Stats.DataAccess;
using Stats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Stats.Controllers
{
    public class BaseAPIController : ApiController
    {
         private readonly IStatsService _service;
        private IModelFactory _modelFactory;
        protected BaseAPIController(IStatsService statsService)
        {
            _service = statsService;
        }

        protected IModelFactory ModelFactory
        {
            get 
            { 
                if(_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(Request);
                }
                return _modelFactory;
  
            }
        }

        protected IStatsService StatsService
        {
            get { return _service; }
        }
    }
}
