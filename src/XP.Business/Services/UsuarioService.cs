using FluentValidation;
using XP.Business.Interfaces;
using XP.Business.Models;
using XP.Business.Models.Validations;

namespace XP.Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IEmailRepository _emailRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository,
                              IEmailRepository emailRepository,
                              IEnderecoRepository enderecoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _emailRepository = emailRepository;
            _enderecoRepository = enderecoRepository;
        }
        public async Task<bool> Adicionar(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return false;

            if (_usuarioRepository.Buscar(f => f.Telefone == usuario.Telefone).Result.Any())
            {
                return false;
            }

            await _usuarioRepository.Adicionar(usuario);
            return true;
        }

        public async Task<bool> Atualizar(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return false;

            if (_usuarioRepository.Buscar(f => f.Telefone == usuario.Telefone && f.Id != usuario.Id).Result.Any())
            {
                return false;
            }

            await _usuarioRepository.Atualizar(usuario);

            return true;
        }

        public async Task AtualizarEmail(Email email)
        {
            if (!ExecutarValidacao(new EmailValidations(), email)) return;

            await _emailRepository.Atualizar(email);
        }


        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task<bool> Remover(Guid id)
        {
            var endereco = await _enderecoRepository.ObterPorId(id);
            var emails = await _emailRepository.ObterPorId(id);

            if (endereco != null && emails != null)
            {
                await _enderecoRepository.Remover(endereco.Id);
                await _emailRepository.Remover(emails.Id);
            }

            await _usuarioRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
            _enderecoRepository?.Dispose();
            _emailRepository?.Dispose();
        }

        private bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            return false;
        }
    }
}
