using XP.Business.Models.Validations;
using XP.Business.Models;
using Xunit;
using XP.Business.Util;

namespace Xp.Teste.Services
{
    public class UsuarioServiceTests
    {
        [Fact]
        public void ValidacaoEmail()
        {
            var email = new Email()
            {
                Id = Guid.Parse("32E14322-B0FC-441B-B5E0-1F81611C723E"),
                EmailCadastro = "teste@teste.com",
                EmailPrincipal = null,
                Usuario = new Usuario(),
                UsuarioId = Guid.Parse("32E14322-B0FC-441B-B5E0-1F81611C723E")
            };

            var result = ValidarDadosEntrada.ExecutarValidacao(new EmailValidations(), email);
            Assert.Equal(true, result);
        }

        [Fact]
        public void ValidacaoTelefone()
        {
            var usuario = new Usuario()
            {
                Id = Guid.Parse("32E14322-B0FC-441B-B5E0-1F81611C723E"),
                Enderecos = new List<Endereco>(),
                Nome = "Miguel",
                Sobrenome = "Coutinho Neto",
                Telefone = "021999328922",
                Emails = new List<Email>()
            };

            var result = ValidarDadosEntrada.ExecutarValidacao(new UsuarioValidation(), usuario);
            Assert.Equal(true, result);
        }
    }
}
