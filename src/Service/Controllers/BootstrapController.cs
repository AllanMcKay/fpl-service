using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Data.Interfaces;
using Data.Models;
using Engine;

namespace Site.Controllers
{
    [Route("fpl/[controller]")]
    public class BootstrapController : Controller
    {
        IFPLRepository<FPLPlayer> _playerRepo;

        public BootstrapController(IFPLRepository<FPLPlayer> repo)
        {
            _playerRepo=repo;
        }

        // GET api/values
        [HttpGet("update")]
        public string Update()
        {
            var loader = new Loader(_playerRepo);
            try
            { 
                loader.Load();
                return "FPL Players bootstrapped successfully.";
            }
            catch(Exception ex)
            {
                return "Error occurred bootstrapping FPL Players. "+ex.Message;
            }
        }
    }
}
