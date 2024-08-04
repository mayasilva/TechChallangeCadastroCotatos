using System.Reflection.Metadata.Ecma335;

namespace Core.Input
{
    public class ContatoUpdateInput
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public int DDD { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }
    }
}
