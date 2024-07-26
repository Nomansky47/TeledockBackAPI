using Microsoft.AspNetCore.Mvc;
using TeledockBackAPI.Model;

namespace TeledockBackAPI.Controllers
{
    [Route("Home")]
    public class APIController : Controller
    {
        Context _context;
        public APIController(Context context)
        {
            _context = context;
        }

        [HttpPost("register/founder/{inn}/{clientid}/{surname}/{name}/{patronymic}")]
        public IActionResult RegisterFounder(int inn, int clientid,string surname, string name, string patronymic)
        {
            if (_context.Founders.FirstOrDefault(p => p.INN == inn) == null)
            {
                var founder = new Founder();
                founder.Surname = surname;
                founder.Name = name;
                founder.INN = inn;
                founder.ClientID = clientid;
                founder.Patronymic = patronymic;
                founder.AddDate= DateTime.Now.Date;
                founder.UpdateDate = DateTime.Now.Date;
                _context.Founders.Add(founder);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
        [HttpPost("register/client/{inn}/{name}/{isindividual}")]
        public IActionResult RegisterClient(int inn, string name, bool isindividual)
        {
            if (_context.Clients.FirstOrDefault(p => p.INN == inn) == null)
            {
                var client = new Client();
                client.INN = inn;
                client.Name = name;
                client.IsIndividual = isindividual;
                client.AddDate = DateTime.Now.Date;
                client.UpdateDate = DateTimeOffset.Now.Date;
                _context.Clients.Add(client);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
        [HttpPut("change/client/{id}/{inn}/{name}/{isindividual}")]
        public IActionResult ChangeClient(int id,int inn, string name, bool isindividual)
        {
            var client = _context.Clients.FirstOrDefault(p => p.Id == id);
            if (client != null)
            {
                client.INN = inn;
                client.Name = name;
                client.IsIndividual = isindividual;
                client.UpdateDate = DateTimeOffset.Now.Date;
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("change/founder/{id}/{inn}/{clientid}/{surname}/{name}/{patronymic}")]
        public IActionResult ChangeFounder(int id, int inn, int clientid, string surname, string name, string patronymic)
        {
            var founder = _context.Founders.FirstOrDefault(p => p.Id == id);
            if (founder != null)
            {
                founder.Surname = surname;
                founder.Name = name;
                founder.INN = inn;
                founder.ClientID = clientid;
                founder.Patronymic = patronymic;
                founder.UpdateDate = DateTimeOffset.Now.Date;
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        [HttpGet]
        [Route("founder/{id}")]
        public Founder GetFounder(int id)
        {
            return _context.Founders.FirstOrDefault(p => p.Id == id);
        }

        [HttpGet]
        [Route("client/{id}")]
        public Client GetClient(int id)
        {
            return _context.Clients.FirstOrDefault(p => p.Id == id);
        }

        [HttpGet]
        [Route("clients")]
        public IEnumerable<Client> GetClients()
        {
            return _context.Clients.ToList();
        }

        [HttpGet]
        [Route("founders")]
        public IEnumerable<Founder> GetFounders()
        {
            return _context.Founders.ToList();
        }

    }
}
