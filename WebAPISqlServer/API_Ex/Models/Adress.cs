using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Ex.Models
{
    public class Adress
    {
        public int Id { get; set; } 
        public string Logradouro { get;set; }
        public int Numero { get; set; }

        [ForeignKey("Person")]
        public int IdPerson { get; set; }
        public Person Person { get; set; }
    }
}
