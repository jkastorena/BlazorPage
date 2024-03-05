using caxivari.DATA;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [ Route( "api/[controller]" )]
    [ApiController]
    public class ColaboratorController : ControllerBase
    {
        private readonly CaxivariContext _context;

        public ColaboratorController(CaxivariContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Collaborator>> Get()
        {
            return _context.Collaborators;
        }

        [HttpGet("{id}")]
        public ActionResult<Collaborator> Get(int id)
        {
            return _context.Collaborators.Find(id) ?? (ActionResult<Collaborator>)NotFound();
        }

        [HttpPost]
        public ActionResult<bool> Post( Collaborator Colab)
        {
            try{
                _context.Collaborators.Add(Colab);
                _context.SaveChanges();
                return true;
            }catch{
                return false;
            }
        }


    }
}
