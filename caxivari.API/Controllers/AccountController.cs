using caxivari.DATA;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MyApp.Namespace
{
    [ Route( "api/[controller]" )]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly CaxivariContext _context;

        public AccountController(CaxivariContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            return _context.Accounts;
        }
        
        [HttpGet("{id}")]
        public ActionResult<Account> Get(int id)
        {
            return _context.Accounts.Find(id) ?? ( ActionResult<Account> ) NotFound();
        }

        [HttpPost]
        public ActionResult<bool> Post(Account account)
        {
            try{
                _context.Accounts.Add(account);
                _context.SaveChanges();
                return true;
            }
            catch ( Exception ex )
            {
                Debug.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        
    }
}
