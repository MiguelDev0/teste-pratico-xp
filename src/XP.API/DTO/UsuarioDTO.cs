﻿using System.ComponentModel.DataAnnotations;

namespace XP.API.DTO
{
    public class UsuarioDTO
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Telefone { get; set; }

        public IEnumerable<EnderecoDTO> Enderecos { get; set; }
        public IEnumerable<EmailDTO> Emails { get; set; }
    }
}
