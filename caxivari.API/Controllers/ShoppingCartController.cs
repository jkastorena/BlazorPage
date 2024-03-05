using caxivari.DATA;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [ Route( "api/[controller]" )]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly CaxivariContext _context;

        public ShoppingCartController(CaxivariContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ShoppingCart>> Get()
        {
            return _context.ShoppingCarts.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ShoppingCart> Get(int id)
        {
            return _context.ShoppingCarts.Find(id) ?? (ActionResult<ShoppingCart>) NotFound();
        }

        [HttpPost]
        public ActionResult<ShoppingCart> Post(ShoppingCart shoppingCart)
        {
            try{
                _context.ShoppingCarts.Add(shoppingCart);
                _context.SaveChanges();
            return shoppingCart;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }     
    }
}
