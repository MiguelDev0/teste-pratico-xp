using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using XP.API.DTO;
using XP.Business.Interfaces;
using XP.Business.Models;
using XP.Data.Ropositories;

namespace XP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IEmailRepository _emailRepository;
        public UsuarioController(IMapper mapper,
                                 IUsuarioRepository usuarioRepository,
                                 IUsuarioService usuarioService,
                                 IEnderecoRepository enderecoRepository,
                                 IEmailRepository emailRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
            _enderecoRepository = enderecoRepository;
            _emailRepository = emailRepository;
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

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UsuarioDTO>> ObterPorId(Guid id)
        {
            var usuario = await ObterUsuarioEmailEndereco(id);

            if (usuario == null) return NotFound();

            return usuario;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> Adicionar(UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid) return NotFound(ModelState);

            await _usuarioService.Adicionar(_mapper.Map<Usuario>(usuarioDTO));

            return Ok(usuarioDTO);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<UsuarioDTO>> Atualizar(Guid id, UsuarioDTO usuarioDTO)
        {
            if (id != usuarioDTO.Id)
            {
                return NotFound("O id informado não é o mesmo que foi passado na query " + usuarioDTO);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _usuarioService.Atualizar(_mapper.Map<Usuario>(usuarioDTO));

            return Ok(usuarioDTO);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<UsuarioDTO>> Excluir(Guid id)
        {
            var usuarioDTO = await ObterUsuarioEmailEndereco(id);

            if (usuarioDTO == null) return NotFound();

            await _usuarioService.Remover(id);

            return Ok(usuarioDTO);
        }

        [HttpGet("obter-endereco/{id:guid}")]
        public async Task<EnderecoDTO> ObterEnderecoPorId(Guid id)
        {
            var enderecoDTO = _mapper.Map<EnderecoDTO>(await _enderecoRepository.ObterPorId(id));
            return enderecoDTO;
        }

        [HttpGet("obter-email/{id:guid}")]
        public async Task<EnderecoDTO> ObterEmailPorId(Guid id)
        {
            var enderecoDTO = _mapper.Map<EnderecoDTO>(await _emailRepository.ObterPorId(id));
            return enderecoDTO;
        }

        [HttpPut("atualizar-endereco/{id:guid}")]
        public async Task<IActionResult> AtualizarEndereco(Guid id, EnderecoDTO enderecoDTO)
        {
            if (id != enderecoDTO.Id)
            {
                return NotFound(enderecoDTO + " O id informado não é o mesmo que foi passado na query");
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _usuarioService.AtualizarEndereco(_mapper.Map<Endereco>(enderecoDTO));

            return Ok(enderecoDTO);
        }

        [HttpPut("atualizar-email/{id:guid}")]
        public async Task<IActionResult> AtualizarEmail(Guid id, EmailDTO emailDTO)
        {
            if (id != emailDTO.Id)
            {
                return NotFound("O id informado não é o mesmo que foi passado na query");
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _usuarioService.AtualizarEmail(_mapper.Map<Email>(emailDTO));

            return Ok(emailDTO);
        }

        private async Task<UsuarioDTO> ObterUsuarioEmailEndereco(Guid id)
        {
            return _mapper.Map<UsuarioDTO>(await _usuarioRepository.ObterDetalhesDoCliente(id));
        }
    }
}