using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Ex.Models
{
    public class Person
    {
        [Key()]
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Adress> Endereco { get; set; }
    }
}
