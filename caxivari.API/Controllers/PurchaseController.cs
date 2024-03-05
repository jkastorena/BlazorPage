using caxivari.DATA;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [ Route( "api/[controller]" )]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly CaxivariContext _context;

        public PurchaseController(CaxivariContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Purchase>> Get()
        {
            return _context.Purchases.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Purchase> Get(int id)
        {
            return _context.Purchases.Find(id) ?? (ActionResult<Purchase>) NotFound();
        }

        [HttpPost]
        public ActionResult<bool> Post( Purchase puirchase)
        {
            try{
                _context.Purchases.Add(puirchase);
                _context.SaveChanges();
                return true;
            }
            catch(Exception){
                return false;
            }
        } 

    }
}
