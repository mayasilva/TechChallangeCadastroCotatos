using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Core.Entity
{
    [Table("Contato")]
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public required int DDD { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }

    }
}
