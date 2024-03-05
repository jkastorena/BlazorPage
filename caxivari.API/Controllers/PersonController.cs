using System.Diagnostics;
using caxivari.DATA;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [ Route( "api/[controller]" )]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly CaxivariContext _context;

        public PersonController(CaxivariContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> PersonGetAll()
        {
            return _context.Persons.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Person> PersonGet(int id)
        {
            Person? _person = _context.Persons.Find(id);
            if (_person == null)
            {
                return NotFound();
            }

            return _person;
        }

        [ HttpPost ]
        public ActionResult<bool> AddPerson( Person person )
        {
            try
            {
                _context.Persons.Add( person );
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex){
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        [ HttpDelete ]
        public ActionResult<bool> DeletePerson( int id )
        {
            Person? peroson = _context.Persons.Find( id );
            if ( peroson == null ) return false;

            _context.Persons.Remove( peroson );
            _context.SaveChanges();

            return true;
        }

        [ HttpPut ]
        public ActionResult<bool> UpdatePerson( Person person )
        {
            try
            {
                _context.Persons.Update( person );
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message );
                return false;
            }
        }
    }
}
