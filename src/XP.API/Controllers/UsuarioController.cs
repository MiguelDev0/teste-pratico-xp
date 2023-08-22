using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using XP.API.DTO;
using XP.Business.Interfaces;

namespace XP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IMapper mapper,
                                 IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }
        [HttpGet("hello")]
        public string helloWorld()
        {
            return "Teste de fumaça";
        }
        [HttpGet]
        public async Task<IEnumerable<UsuarioDTO>> ListarTodos()
        {
            var usuarios = _mapper.Map<IEnumerable<UsuarioDTO>>(await _usuarioRepository.ObterTodos());

            return usuarios;
        }

        private async Task<UsuarioDTO> ObterFornecedorProdutosEndereco(Guid id)
        {
            return _mapper.Map<UsuarioDTO>(await _usuarioRepository.ListarTodosOsClientes(id));
        }
    }
}