namespace XP.API.DTO
{
    public class UsuarioDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }

        public IEnumerable<EnderecoDTO> Enderecos { get; set; }
        public IEnumerable<EmailDTO> Emails { get; set; }
    }
}
