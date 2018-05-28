using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Data.Models;
using Data.Interfaces;

namespace Engine
{
    public class Loader
    {
        private readonly IFPLRepository<FPLPlayer> _playerRepo;

        public Loader(IFPLRepository<FPLPlayer> repo){
            _playerRepo = repo;
        }

        public void Load()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var resp = client.GetStringAsync("https://fantasy.premierleague.com/drf/bootstrap-static").Result;

                var boot = JsonConvert.DeserializeObject<BootStrap>(resp);

                foreach(FPLPlayer p in boot.elements)
                {
                    _playerRepo.Save(p);
                }

            }
        }
    }
}
;