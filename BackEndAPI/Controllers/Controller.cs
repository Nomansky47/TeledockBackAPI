using Microsoft.AspNetCore.Mvc;
using TeledockBackAPI.Model;

namespace TeledockBackAPI.Controllers
{
    [Route("Home")]
    public class APIController : Controller
    {
        Repo<Founder> FounderRepo;
        Repo<Client> ClientRepo;
        public APIController(Context context)
        {
            FounderRepo=new Repo<Founder>(context);
            ClientRepo=new Repo<Client>(context);
            
        }

        [HttpPost("register/founder")]
        public IActionResult RegisterFounder(int inn, int clientid,string surname, string name, string patronymic)
        {
            var Founders=FounderRepo.GetAll();
            if (Founders.FirstOrDefault(p => p.INN == inn) == null)
            {
                var founder = new Founder();
                founder.Surname = surname;
                founder.Name = name;
                founder.INN = inn;
                founder.ClientID = clientid;
                founder.Patronymic = patronymic;
                founder.AddDate= DateTime.Now.Date;
                founder.UpdateDate = DateTime.Now.Date;
                FounderRepo.Add(founder);
                return Ok();
            }
            return NotFound();
        }
        [HttpPost("register/client")]
        public IActionResult RegisterClient(int inn, string name, bool isindividual)
        {
            var Clients=ClientRepo.GetAll();
            if (Clients.FirstOrDefault(p => p.INN == inn) == null)
            {
                var client = new Client();
                client.INN = inn;
                client.Name = name;
                client.IsIndividual = isindividual;
                client.AddDate = DateTime.Now.Date;
                client.UpdateDate = DateTimeOffset.Now.Date;
                ClientRepo.Add(client);
                return Ok();
            }
            return NotFound();
        }
        [HttpPut("change/client")]
        public IActionResult ChangeClient(int id,int inn, string name, bool isindividual)
        {
            var client = ClientRepo.GetId(id);
            if (client != null)
            {
                client.INN = inn;
                client.Name = name;
                client.IsIndividual = isindividual;
                client.UpdateDate = DateTimeOffset.Now.Date;
                ClientRepo.Update(client);
                
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("change/founder")]
        public IActionResult ChangeFounder(int id, int inn, int clientid, string surname, string name, string patronymic)
        {
            var founder = FounderRepo.GetId(id);
            if (founder != null)
            {
                founder.Surname = surname;
                founder.Name = name;
                founder.INN = inn;
                founder.ClientID = clientid;
                founder.Patronymic = patronymic;
                founder.UpdateDate = DateTimeOffset.Now.Date;
                FounderRepo.Update(founder);
                return Ok();
            }
            return NotFound();
        }

        [HttpGet]
        [Route("founder/{id}")]
        public Founder GetFounder(int id)
        {
            return FounderRepo.GetId(id);
        }

        [HttpGet]
        [Route("client/{id}")]
        public Client GetClient(int id)
        {
            return ClientRepo.GetId(id);
        }

        [HttpGet]
        [Route("clients")]
        public IEnumerable<Client> GetClients()
        {
            return ClientRepo.GetAll();
        }

        [HttpGet]
        [Route("founders")]
        public IEnumerable<Founder> GetFounders()
        {
            return FounderRepo.GetAll();
        }

    }
}
