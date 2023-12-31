﻿namespace XP.Business.Models
{
    public class Endereco : Entity
    {
        public Guid UsuarioId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public bool EnderecoPrincipal { get; set; }

        public Usuario Usuario { get; set; }
    }
}
