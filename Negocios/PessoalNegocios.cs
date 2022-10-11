using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoBancoDados;
using ObjetoTransferencia;

namespace Negocios
{
    public class PessoalNegocios
    {
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();

        //Inserir
        
        public string Inserir(Pessoal pessoal)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@datacad", pessoal.datacad);
                acessoDadosSqlServer.AdicionarParametros("@nome", pessoal.nome);
                acessoDadosSqlServer.AdicionarParametros("@nascimento", pessoal.nascimento);
                acessoDadosSqlServer.AdicionarParametros("@email", pessoal.email);
                acessoDadosSqlServer.AdicionarParametros("@telefone", pessoal.telefone);
                acessoDadosSqlServer.AdicionarParametros("@celular", pessoal.celular);
                //acessoDadosSqlServer.AdicionarParametros("@foto", pessoal.foto);
                //acessoDadosSqlServer.AdicionarParametros("@digital", pessoal.digital);
                acessoDadosSqlServer.AdicionarParametros("@evangelico", pessoal.evangelico);
                acessoDadosSqlServer.AdicionarParametros("@ibrn", pessoal.ibrn);
                acessoDadosSqlServer.AdicionarParametros("@igreja", pessoal.igreja);
                acessoDadosSqlServer.AdicionarParametros("@ano", pessoal.ano);
                acessoDadosSqlServer.AdicionarParametros("@grupo", pessoal.grupo);

                string idPessoal = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPessoalInserir").ToString();

                return idPessoal;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public string GrupoInserir(Grupo grupo)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@assunto", grupo.Assunto);
                acessoDadosSqlServer.AdicionarParametros("@IdLider", grupo.IdLider);
                acessoDadosSqlServer.AdicionarParametros("@IdCoLider", grupo.IdCoLider);

                string idGrupo = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspGrupoInserir").ToString();

                return idGrupo;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        //Reinscrever

        public string Reinscrever(Pessoal pessoal)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@id", pessoal.id);
                acessoDadosSqlServer.AdicionarParametros("@ano", pessoal.ano);
                acessoDadosSqlServer.AdicionarParametros("@Lider", pessoal.Lider);
                string idPessoal = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPessoalReinscrever").ToString();

                return idPessoal;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        //Alterar

        public string Alterar(Pessoal pessoal)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@id", pessoal.id);
                acessoDadosSqlServer.AdicionarParametros("@datacad", pessoal.datacad);
                acessoDadosSqlServer.AdicionarParametros("@nome", pessoal.nome);
                acessoDadosSqlServer.AdicionarParametros("@nascimento", pessoal.nascimento);
                acessoDadosSqlServer.AdicionarParametros("@email", pessoal.email);
                acessoDadosSqlServer.AdicionarParametros("@telefone", pessoal.telefone);
                acessoDadosSqlServer.AdicionarParametros("@celular", pessoal.celular);
               //acessoDadosSqlServer.AdicionarParametros("@foto", pessoal.foto);
               //acessoDadosSqlServer.AdicionarParametros("@digital", pessoal.digital);
                acessoDadosSqlServer.AdicionarParametros("@evangelico", pessoal.evangelico);
                acessoDadosSqlServer.AdicionarParametros("@ibrn", pessoal.ibrn);
                acessoDadosSqlServer.AdicionarParametros("@igreja", pessoal.igreja);
                acessoDadosSqlServer.AdicionarParametros("@ano", pessoal.ano);
                acessoDadosSqlServer.AdicionarParametros("@grupo", pessoal.grupo);
                
                string idPessoal = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPessoalAlterar").ToString();

                return idPessoal;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        //Excluir

        public string Excluir(Pessoal pessoal)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@id", pessoal.id);
               // acessoDadosSqlServer.AdicionarParametros("@Ano", pessoal.id);
                string idPessoal = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPessoalExcluir").ToString();

                return idPessoal;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Deletar(Pessoal pessoal)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@id", pessoal.id);
                // acessoDadosSqlServer.AdicionarParametros("@Ano", pessoal.id);
                string idPessoal = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPessoalDeletar").ToString();

                return idPessoal;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //Consultar por nome

        public PessoalCollection ConsultarPorNome(string nome)
        {
            try
            {
                PessoalCollection pessoalColection = new PessoalCollection();

                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@nome", nome);

                DataTable dataTablePessoal = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPessoalConsultarPorNome");
                int nu = 0;
                foreach (DataRow linha in dataTablePessoal.Rows)
                {
                    //Criar uma pessoa vazia
                    //Colocar os dados dalinha nela
                    //Adicionar lea na coleção
                    nu = nu + 1;
                    Pessoal pessoal = new Pessoal();

                    pessoal.id = Convert.ToInt32(linha["id"]);
                    pessoal.datacad    = Convert.ToDateTime(linha["datacad"]);
                    pessoal.nome = Convert.ToString(linha["nome"]);
                    pessoal.nascimento = Convert.ToDateTime(linha["nascimento"]);
                    pessoal.email = Convert.ToString(linha["email"]);
                    pessoal.telefone = Convert.ToString(linha["telefone"]);
                    pessoal.celular = Convert.ToString(linha["celular"]);
                    pessoal.igreja = Convert.ToString(linha["igreja"]);
                    pessoal.evangelico = Convert.ToString(linha["evangelico"]);
                    pessoal.ibrn = Convert.ToString(linha["ibrn"]);
                    pessoal.num = nu;

                    pessoalColection.Add(pessoal);
                }

                             
                return pessoalColection;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar a Pessoa por nome. Detalhes: " + ex.Message);
            }
        }

        public PessoalCollection ConsultarPresenca(string nome)
        {
            try
            {
                PessoalCollection pessoalColection = new PessoalCollection();

                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@nome", nome);

                DataTable dataTablePessoal = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPessoalConsultaPresencaPorNome");

                foreach (DataRow linha in dataTablePessoal.Rows)
                {
                    //Criar uma pessoa vazia
                    //Colocar os dados dalinha nela
                    //Adicionar lea na coleção
                    Pessoal pessoals = new Pessoal();

                    pessoals.nome = Convert.ToString(linha["nome"]);
                    pessoals.frequencia = Convert.ToInt32(linha["frequencia"]);
                   

                    pessoalColection.Add(pessoals);
                }


                return pessoalColection;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar a Pessoa por nome. Detalhes: " + ex.Message);
            }
        }

        //Get Presença
        public LicoesCollection GetPresenca(string nome)
        {
            try
            {
                LicoesCollection licoesCollection = new LicoesCollection();

                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@nome", nome);

                DataTable dataTablePessoal = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPessoalGetPresenca");

                foreach (DataRow linha in dataTablePessoal.Rows)
                {
                    Licoes licoes = new Licoes();

                    licoes.nome = Convert.ToString(linha["nome"]);
                    licoes.dataChamada = Convert.ToDateTime(linha["dataChamada"]);
                    licoes.Descricao = Convert.ToString(linha["Descricao"]);

                    licoesCollection.Add(licoes);
                }


                return licoesCollection;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar as Liçoes desta Pessoa. Detalhes: " + ex.Message);
            }
        }

        //Consultar Excluído

        public PessoalCollection ConsultarPessoaCadastrada(string nome)
        {
            try
            {
                PessoalCollection pessoalColection = new PessoalCollection();
                
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@nome", nome);

                DataTable dataTablePessoal = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPessoalCadastrada");
                int nu = 0;
                foreach (DataRow linha in dataTablePessoal.Rows)
                {
                    //Criar uma pessoa vazia
                    //Colocar os dados dalinha nela
                    //Adicionar ela na coleção
                    nu = nu + 1;
                    Pessoal pessoal = new Pessoal();

                    pessoal.id = Convert.ToInt32(linha["id"]);
                    pessoal.datacad = Convert.ToDateTime(linha["datacad"]);
                    pessoal.nome = Convert.ToString(linha["nome"]);
                    pessoal.nascimento = Convert.ToDateTime(linha["nascimento"]);
                    pessoal.email = Convert.ToString(linha["email"]);
                    pessoal.telefone = Convert.ToString(linha["telefone"]);
                    pessoal.celular = Convert.ToString(linha["celular"]);
                    //pessoal.foto       = Convert.ToString(linha["foto"]);
                    //pessoal.digital    = Convert.ToString(linha["digital"]);
                    pessoal.evangelico = Convert.ToString(linha["evangelico"]);
                    pessoal.ibrn = Convert.ToString(linha["ibrn"]);
                    pessoal.igreja = Convert.ToString(linha["igreja"]);
                    //pessoal.ano = Convert.ToInt32(linha["ano"]);
                    pessoal.num = nu;

                    pessoalColection.Add(pessoal);

                }

                return pessoalColection;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar a Pessoa excluída. Detalhes: " + ex.Message);
            }
        }

        //Get Agenda

        public AgendaCollection GetAgenda()
        {
            try
            {
                AgendaCollection agendaCollection = new AgendaCollection();

                DataTable dataTableAgenda = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPessoalGetAgenda");

                foreach (DataRow linha in dataTableAgenda.Rows)
                {
                    Agenda agenda = new Agenda();

                    agenda.DataAgenda = Convert.ToDateTime(linha["DataAgenda"]);
                    agenda.Descricao = Convert.ToString(linha["Descricao"]);

                    agendaCollection.Add(agenda);
                }


                return agendaCollection;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar as Agenda deste Ano. Detalhes: " + ex.Message);
            }
        }

        public AgendaCollection GetAgendaFutura()
        {
            try
            {
                AgendaCollection agendaCollection = new AgendaCollection();

                DataTable dataTableAgenda = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPessoalGetAgendaFutura");

                foreach (DataRow linha in dataTableAgenda.Rows)
                {
                    Agenda agenda = new Agenda();

                    agenda.DataAgenda = Convert.ToDateTime(linha["DataAgenda"]);
                    agenda.Descricao = Convert.ToString(linha["Descricao"]);

                    agendaCollection.Add(agenda);
                }


                return agendaCollection;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar as Agenda deste Ano. Detalhes: " + ex.Message);
            }
        }
        //Consultar por Id

        public PessoalCollection ConsultarPorId(int id)
        {
            try
            {
                PessoalCollection pessoalColection = new PessoalCollection();

                acessoDadosSqlServer.LimparParametros();

                DataTable dataTablePessoal = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspPessoalConsultarPorId");

                foreach (DataRow linha in dataTablePessoal.Rows)
                {
                    Pessoal pessoal = new Pessoal();

                    pessoal.id         = Convert.ToInt32(linha["id"]);
                    pessoal.datacad    = Convert.ToDateTime(linha["datacad"]);
                    pessoal.nome       = Convert.ToString(linha["nome"]);
                    pessoal.nascimento = Convert.ToDateTime(linha["nascimento"]);
                    pessoal.email      = Convert.ToString(linha["email"]);
                    pessoal.telefone   = Convert.ToString(linha["telefone"]);
                    pessoal.celular    = Convert.ToString(linha["celular"]);
                   // pessoal.foto       = Convert.ToString(linha["foto"]);
                  //  pessoal.digital    = Convert.ToString(linha["digital"]);
                    pessoal.evangelico = Convert.ToString(linha["evangelico"]);
                    pessoal.ibrn       = Convert.ToString(linha["ibrn"]);
                    pessoal.igreja     = Convert.ToString(linha["igreja"]);
                    pessoal.ano        = Convert.ToInt32(linha["ano"]);


                    pessoalColection.Add(pessoal);

                }

                return pessoalColection;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar a Pessoa por Código. Detalhes: " + ex.Message);
            }
        }

        public string InserirPresenca(Pessoal pessoal)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@id", pessoal.id);
                string idPresenca = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPessoalPresenca").ToString();

                return idPresenca;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public string InserirAgenda(Agenda agenda)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@DataAgenda", agenda.DataAgenda);
                acessoDadosSqlServer.AdicionarParametros("@Descricao", agenda.Descricao);
                string idAgenda = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspAgendaInserir").ToString();

                return idAgenda;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
    }
}