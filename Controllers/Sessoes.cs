using System;
using System.Collections.Generic;

namespace Controller
{
    public class Sessao
    {
        public static Model.Sessao Login(   // criando login com email e senha
            string email,
            string password
        )
        {
            try {
                Model.Usuario usuario = Usuario.BuscarPorEmail(email);     // criando usuario vinculado com e-mail para realizar as buscas do usuario pelo email

                if (usuario.Senha != password) {
                    throw new Exception("Senha inválida");      // validação da senha
                }

                return new Model.Sessao(usuario.Id);
            } catch
            {
                throw new Exception("Login inválido");      // validação do usuário
            }
        }

        public static void Logoff(      // criando expiração do login
            string id
        )
        {
            int idInt = int.Parse(id);
            Model.Sessao.AlterarSessao(idInt, new DateTime());
        }

        public static List<Model.Sessao> ListarSessoes()    // listar todas as sessoes
        {
            return Model.Sessao.ListarSessoes();
        }
    }
}