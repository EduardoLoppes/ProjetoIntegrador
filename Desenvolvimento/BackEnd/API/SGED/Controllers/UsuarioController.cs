using Microsoft.AspNetCore.Mvc;
using SGED.Context;
using SGED.Objects.Interfaces.Pessoa;
using SGED.Objects.DTO.Entities;
using SGED.Services.Interfaces;

namespace SGED.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize("ApiScope")]
    public class UsuarioController : Controller
    {

        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService, AppDBContext context)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> Get()
        {
            var usuariosDTO = await _usuarioService.GetAll();
            return Ok(usuariosDTO);
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public async Task<ActionResult<UsuarioDTO>> Get(int id)
        {
            var usuarioDTO = await _usuarioService.GetById(id);
            if (usuarioDTO == null) return NotFound("Usuario não encontradas!");
            return Ok(usuarioDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO is null) return BadRequest("Dado(s) inválido(s)!");
            usuarioDTO.EmailPessoa = usuarioDTO.EmailPessoa.ToLower();

            var usuariosDTO = await _usuarioService.GetAll();

            string email = "";
            string cpfcnpj = "";
            string rgie = "";

            int response = usuarioDTO.CpfCnpj();
            if (response == 0) cpfcnpj = "Documento incompleto!";
            else if (response == -1) cpfcnpj = "CPF inválido!";
            else if (response == -2) cpfcnpj = "CNPJ inválido!";

            response = usuarioDTO.RgIe();
            if (response == 0) rgie = "Documento incompleto!";
            else if (response == -1) rgie = "RG inválido!";
            else if (response == -2) rgie = "IE inválido!";

            if (usuariosDTO is not null)
            {
                string existCpfCnpj = "";
                string existRgIe = "";

                foreach (var usuario in usuariosDTO)
                {
                    if (usuarioDTO.EmailPessoa == usuario.EmailPessoa) email = "O e-mail informado já existe!";

                    if (usuarioDTO.CpfCnpjPessoa == usuario.CpfCnpjPessoa)
                    {
                        if (usuarioDTO.CpfCnpjPessoa.Length == 14) existCpfCnpj = "O CPF informado já existe!";
                        else existCpfCnpj = "O CNPJ informado já existe!";
                    };

                    if (usuarioDTO.RgIePessoa == usuario.RgIePessoa)
                    {
                        if (usuarioDTO.RgIePessoa.Length == 12) existRgIe = "O RG informado já existe!";
                        else existRgIe = "O IE informado já existe!";
                    };
                }

                if (cpfcnpj == "") cpfcnpj = existCpfCnpj;
                if (rgie == "") rgie = existRgIe;
            }

            if (usuarioDTO.EmailPessoa == "devops@development.com") email = "O e-mail informado já existe!";

            if (email == "" && cpfcnpj == "" && rgie == "")
            {
                await _usuarioService.Create(usuarioDTO);
                return new CreatedAtRouteResult("GetUsuario", new { id = usuarioDTO.Id }, usuarioDTO);
            }

            return BadRequest(new { email, cpfcnpj, rgie });
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO.Id == 1) return BadRequest("Dado(s) inválido(s)!");
            if (usuarioDTO is null) return BadRequest("Dado(s) inválido(s)!");
            usuarioDTO.EmailPessoa = usuarioDTO.EmailPessoa.ToLower();

            var usuariosDTO = await _usuarioService.GetAll();
            usuariosDTO = usuariosDTO.Where(u => u.Id != usuarioDTO.Id);

            string email = "";
            string cpfcnpj = "";
            string rgie = "";

            int response = usuarioDTO.CpfCnpj();
            if (response == 0) cpfcnpj = "Documento incompleto!";
            else if (response == -1) cpfcnpj = "CPF inválido!";
            else if (response == -2) cpfcnpj = "CNPJ inválido!";

            response = usuarioDTO.RgIe();
            if (response == 0) rgie = "Documento incompleto!";
            else if (response == -1) rgie = "RG inválido!";
            else if (response == -2) rgie = "IE inválido!";

            if (usuariosDTO is not null)
            {
                string existCpfCnpj = "";
                string existRgIe = "";

                foreach (var usuario in usuariosDTO)
                {
                    if (usuarioDTO.EmailPessoa == usuario.EmailPessoa) email = "O e-mail informado já existe!";

                    if (usuarioDTO.CpfCnpjPessoa == usuario.CpfCnpjPessoa)
                    {
                        if (usuarioDTO.CpfCnpjPessoa.Length == 14) existCpfCnpj = "O CPF informado já existe!";
                        else existCpfCnpj = "O CNPJ informado já existe!";
                    };

                    if (usuarioDTO.RgIePessoa == usuario.RgIePessoa)
                    {
                        if (usuarioDTO.RgIePessoa.Length == 12) existRgIe = "O RG informado já existe!";
                        else existRgIe = "O IE informado já existe!";
                    };
                }

                if (cpfcnpj == "") cpfcnpj = existCpfCnpj;
                if (rgie == "") rgie = existRgIe;
            }

            if (usuarioDTO.EmailPessoa == "devops@development.com") email = "O e-mail informado já existe!";

            if (email == "" && cpfcnpj == "" && rgie == "")
            {
                await _usuarioService.Update(usuarioDTO);
                return Ok(usuarioDTO);
            }

            return BadRequest(new { email, cpfcnpj, rgie });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioDTO>> Delete(int id)
        {
            if (id == 1) return NotFound("Usuário não encontrado!");

            var usuarioDTO = await _usuarioService.GetById(id);
            if (usuarioDTO == null) return NotFound("Usuário não encontrado!");
            await _usuarioService.Remove(id);
            return Ok(usuarioDTO);
        }

    }
}
