using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Data.Interfaces;
using Data.Models;

namespace Site.Controllers
{
    [Route("fpl/[controller]")]
    public class PlayerController : Controller
    {
        IFPLRepository<FPLPlayer> _playerRepo;

        public PlayerController(IFPLRepository<FPLPlayer> repo)
        {
            _playerRepo=repo;
        }

        // GET api/values
        [HttpGet("{id}")]
        public FPLPlayer Get(int id)
        {
            return _playerRepo.Get(id);
        }

        [HttpPost()]
        public List<FPLPlayer> Find([FromBody] string firstname, string lastname)
        {
            return _playerRepo.Find(new string[] {firstname,lastname});
        }
    }
}
