using System.Diagnostics;
using caxivari.DATA;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [ Route( "api/[controller]" )]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CaxivariContext _context;

        public CustomerController(CaxivariContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAll()
        {
            return _context.Customers.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetById(int id)
        {
            return _context.Customers.Find(id) ?? ( ActionResult<Customer> ) NotFound();
        }

        [HttpPost]
        public ActionResult<bool> Post(Customer customer)
        {
            try{
                _context.Customers.Add(customer);
            _context.SaveChanges();
            return true;
            }
            catch ( Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            
        }



    }
}
