using caxivari.DATA;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [ Route( "api/[controller]" )]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly CaxivariContext _context;

        public RoleController(CaxivariContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Role>> Get()
        {
            return _context.Roles.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Role> Get(int id)
        {
            
            return _context.Roles.Find(id) ?? (ActionResult<Role>)NotFound();
        }


        [HttpPost]
        public ActionResult<bool> Post(Role role)
        {
            if (role == null)
            {
                return BadRequest();
            }

            _context.Roles.Add(role);
            _context.SaveChanges();
            return true;
        }

    }
}
