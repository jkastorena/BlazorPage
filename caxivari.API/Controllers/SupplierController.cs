using System.Diagnostics;
using caxivari.DATA;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [ Route( "api/[controller]" )]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly CaxivariContext _context;

        public SupplierController(CaxivariContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Supplier>> Get()
        {
            return _context.Suppliers.ToList();
        }
        
        [HttpGet("{id}")]
        public ActionResult<Supplier> Get(int id)
        {
            return _context.Suppliers.Find(id) ?? (ActionResult<Supplier>) NotFound() ;
        }
        
        [HttpPost]
        public ActionResult<bool> Post(Supplier supplier)
        {
            try{
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();
                return true;
            }
            catch ( Exception ex )
            {
                Debug.WriteLine( ex.Message );
                return BadRequest();
            }
        }
    }
}
