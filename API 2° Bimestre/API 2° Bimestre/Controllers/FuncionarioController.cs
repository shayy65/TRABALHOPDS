using API_2__Bimestre.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;
using API_2__Bimestre.Dto;
namespace API_2__Bimestre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        public string arquivo = "C:/Users/2022102020081.IFRO/Desktop/pds 2°Bimestre.txt";


        [HttpPost("Cadastrar funcionário")]
        public IActionResult Post([FromBody] FuncionarioDTO item)
        {
           
            var funcionarios = LerArquivo();
            var funcionario = new Funcionario();
            funcionario.Id = funcionarios.Count + 1;

            funcionario.Nome = item.Nome;
            funcionario.cpf = item.cpf;
            funcionario.CTPS = item.CTPS;
            funcionario.RG = item.RG;
            funcionario.Funcao = item.Funcao;
            funcionario.Setor = item.Setor;
            funcionario.Sala = item.Sala;
            funcionario.Telefone = item.Telefone;
            funcionario.UF = item.UF;
            funcionario.Cidade = item.Cidade;
            funcionario.Bairro = item.Bairro;
            funcionario.Numero = item.Numero;
            funcionario.CEP = item.CEP;

            bool resultadocpf = ValidacaoCPF.ValidaCPF(item.cpf);

            if (resultadocpf == false)
            {
                return BadRequest("CPF Inválido");
            }

            return Ok("Funcionário cadastrado com sucesso:" + item );
        }

        [HttpGet ("Listar Funcionários")]
        public IActionResult GetFuncionario()
        {
            return Ok(LerArquivo());

        }

        [HttpGet("Vizualizar funcionário por ID")]

        public IActionResult GetById(int id)
        {
            var funcionario = LerArquivo().FirstOrDefault(f => f.Id == id);

            if (funcionario == null)
            {
                return NotFound("Funcionário não encontrado.");
            }

            return Ok(funcionario);
        }

        [HttpPut("Atualizar registro de funcionário")]
        public IActionResult Put(int id, [FromBody] FuncionarioDTO item)
        {
            var funcionarios = LerArquivo();
            var funcionario = LerArquivo().Where(itemg => itemg.Id == id).FirstOrDefault();
            if (funcionario == null)
            {
                return NotFound("Funcionário não encontrado");
            }

            funcionarios.Remove(funcionario);

            bool resultadocpf = ValidacaoCPF.ValidaCPF(item.cpf);

            if (resultadocpf == false)
            {
                return BadRequest("CPF Inválido");
            }

            
            funcionario.Id = id;
            funcionario.Nome = item.Nome;
            funcionario.cpf = item.cpf;
            funcionario.CTPS = item.CTPS;
            funcionario.RG = item.RG;
            funcionario.Funcao = item.Funcao;
            funcionario.Setor = item.Setor;
            funcionario.Sala = item.Sala;
            funcionario.Telefone = item.Telefone;
            funcionario.UF = item.UF;
            funcionario.Cidade = item.Cidade;
            funcionario.Bairro = item.Bairro;
            funcionario.Numero = item.Numero;
            funcionario.CEP = item.CEP;

            funcionarios.Add(funcionario);

            SalvarLista(funcionarios);

            return Ok("Funcionário atualizado com sucesso" + funcionario);

        }

        [HttpDelete("Apagar funcionário")]
        public IActionResult Delete(int id)
        {
            var funcionarios = LerArquivo();
            var funcionario = funcionarios.Where(item => item.Id == id).FirstOrDefault();

            if (funcionario == null)
            {
                return NotFound("Funcionário encontrado");
            }

            funcionarios.Remove(funcionario);

            SalvarLista(funcionarios);

            return Ok("Funcionário removido com sucesso");
        }

        private void SalvarFuncionario(Funcionario funcionario)
        {
            using (var writer = new StreamWriter(arquivo, true))
            {
                var line = $"{funcionario.Id}|{funcionario.Nome}|{funcionario.cpf}|{funcionario.CTPS}|{funcionario.RG}|{funcionario.Funcao}|{funcionario.Setor}|{funcionario.Sala}|{funcionario.Telefone}|{funcionario.UF}|{funcionario.Cidade}|{funcionario.Bairro}|{funcionario.Numero}|{funcionario.CEP}";
                writer.WriteLine(line);
            }
        }

        private List<Funcionario> LerArquivo()
        {
            var funcionarios = new List<Funcionario>();

            if (System.IO.File.Exists(arquivo))
            {
                using (var reader = new StreamReader(arquivo))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var fields = line.Split('|');
                        var funcionario = new Funcionario
                        {
                            Id = int.Parse(fields[0]),
                            Nome = fields[1],
                            cpf = fields[2],
                            CTPS = fields[3],
                            RG = fields[4],
                            Funcao = fields[5],
                            Setor = fields[6],
                            Sala = fields[7],
                            Telefone = fields[8],
                            UF = fields[9],
                            Cidade = fields[10],
                            Bairro = fields[11],
                            Numero = fields[12],
                            CEP = fields[13]
                        };
                        funcionarios.Add(funcionario);
                    }
                }
            }

            return funcionarios;
        }

        private void SalvarLista(List<Funcionario> funcionarios)
        {
            using (var writer = new StreamWriter(arquivo, false))
            {
                foreach (var funcionario in funcionarios)
                {
                    var line = $"{funcionario.Id}|{funcionario.Nome}|{funcionario.cpf}|{funcionario.CTPS}|{funcionario.RG}|{funcionario.Funcao}|{funcionario.Setor}|{funcionario.Sala}|{funcionario.Telefone}|{funcionario.UF}|{funcionario.Cidade}|{funcionario.Bairro}|{funcionario.Numero}|{funcionario.CEP}";
                    writer.WriteLine(line);
                }
            }
        }
    }
}
