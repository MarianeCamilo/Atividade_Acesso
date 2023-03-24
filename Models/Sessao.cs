using System;
using System.Collections.Generic;

namespace Model 
{
    public class Sessao
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Token { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataExpiracao { get; set; }

        public static List<Sessao> Sessoes { get; set; } = new List<Sessao>();

        public Sessao()
        {
        }

        public Sessao(
            int id,
            string usuarioid,
            string token,
            DateTime datacriacao,
            DateTime dataexpiracao
        )
        {
            Id = id;
            Usuario = usuarioid;
            Token = token;
            DateTime = datacriacao;
            Usuario = Usuario;
            DateTime = dataexpiracao;

            Sessoes.Add(this);
        }

        public override string ToString()
        {
            return $"Id: {Id}, Usuario: {UsuarioId}, Token: {Token}, Usuario: {Usuario}, Data de criação: {DataCriacao}, Data de expiração: {DataCriacaoExpiracao}";
        }
            
        public static void AlterarSessao(
            int id,
            Usuario usuarioid,
            Token token,
            DateTime datacriacao,
            Usuario Usuario,
            DateTime dataexpiracao
        )
        {
            Sessao sessao = BuscarSessao(id);
            sessao.Token token;
            sessao.DateTime = datacriacao;
            sessao.Usuario = Usuario;
            sessao.DateTime = dataexpiracao;
        }

        public static void ExcluirSessao(int id)
        {
            Sessao sessao = BuscarSessao(id);
            Sessoes.Remove(sessao);
        }

        public static Sessao BuscarSessao(int id)
        {
            Sessao? sessao = Sessoes.Find(r => r.Id == id);
            if (sessao == null) {
                throw new Exception("Sessão não encontrada");
            }

            return sessao;
        }
    }
}