namespace XP.Business.Models
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }

        public IEnumerable<Endereco> Enderecos { get; set; }
        public IEnumerable<Email> Emails { get; set; }
    }
}
