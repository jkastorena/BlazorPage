using System.Diagnostics;
using caxivari.DATA;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [ Route( "api/[controller]" )]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly CaxivariContext _context;

        public ProductController(CaxivariContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return _context.Products.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return _context.Products.Find(id) ?? ( ActionResult<Product> ) NotFound();
        }

        [HttpPost]
        public ActionResult<bool> Post(Product product)
        {
            try 
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return true;
            }
            catch ( Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}
