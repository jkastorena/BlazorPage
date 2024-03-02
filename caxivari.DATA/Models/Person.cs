 
using System.ComponentModel.DataAnnotations; 
namespace caxivari.DATA;

public class Person
{
    [ Key ]
    public int PesonaId { get; set; }
    [ Required ]
    public string Name { get; set; } = default!;
    [ Required ]
    public string Email { get; set; } = default!;
}
