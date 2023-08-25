using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using XP.API.DTO;
using XP.Business.Interfaces;
using XP.Business.Models;

namespace XP.API.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IMapper mapper,
                                 IUsuarioService usuarioService)
        {
            _mapper = mapper;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IEnumerable<UsuarioDTO>> ListarTodos()
        {
            var usuarios = _mapper.Map<IEnumerable<UsuarioDTO>>(await _usuarioService.BuscarTodos());

            return usuarios;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UsuarioDTO>> ObterPorId(Guid id)
        {
            var usuario = _mapper.Map<UsuarioDTO>(await _usuarioService.BuscaDetalhada(id));

            return Ok(usuario);
        }

        [HttpPost("adicionar-usuario")]
        public async Task<ActionResult> Adicionar(UsuarioDTO usuarioDTO)
        {
            await _usuarioService.Adicionar(_mapper.Map<Usuario>(usuarioDTO));

            return Ok(usuarioDTO);
        }

        [HttpPut("atualizar-usuario")]
        public async Task<ActionResult<UsuarioDTO>> Atualizar(UsuarioDTO usuarioDTO)
        {
            await _usuarioService.Atualizar(_mapper.Map<Usuario>(usuarioDTO));

            return Ok(usuarioDTO);

        }

        [HttpDelete("remover-usuario/{id:guid}")]
        public async Task<ActionResult<UsuarioDTO>> Excluir(Guid id)
        {
            await _usuarioService.Remover(id);

            return Ok();
        }
    }
}