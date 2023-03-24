using System;

namespace Controller
{
    public class Usuario
    {   /*
          public static void CadastrarUsuario(
            string id,
            int usuarioid,
            string Usuario
        ) {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
        }

        public static void AlterarUsuario(
            string id,
            int usuarioid,
            string Usuario
        ) {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
        }

        public static void ExcluirUsuario(string id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            Model.Usuario.ExcluirUsuario(idConvert);
        }

        public static Model.Usuario BuscarUsuario(string id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            return Model.Usuario.BuscarUsuario(idConvert);
        }

        public static List<Model.Usuario> ListarPerfis()
        {
            return Model.Usuario.Perfis;
        }
        */

        public static Model.Usuario CadastrarUsuario(     // cadastrar Usuario instanciando model e Usuario
            string idUsuario,
            string tipo
        )
        {
            int idUsuarioInt = int.Parse(idUsuario);
            Model.Usuario usuario = Model.Usuario.BuscarUsuario(idUsuarioInt);  // buscar usuario por id

            if (!Enum.TryParse<Model.TipoUsuario>(tipo, out Model.TipoUsuario tipoUsuario) == false) {
                throw new Exception("Tipo de Usuario inválido");  // tratamento de exceção da enumeração do Usuario 
            }

            if (Model.Usuario.BuscarUsuarioPorUsuario(usuario.Id) != null) {
                throw new Exception("Usuário já possui Usuario");  // tratamento de exceção da enumeração do Usuario
            }

            return new Model.Usuario(usuario.Id, tipoUsuario);      // 
        }

        public static void ExcluirUsuario(   // ecluir Usuario pelo id
            string id
        )
        {
            int idInt = int.Parse(id);
            Model.Usuario.ExcluirUsuario(idInt);
        }

        public static List<Model.Usuario> ListarPerfis()     //listar perfis pelo instanceamento entre model e Usuario
        {
            return Model.Usuario.ListarPerfis();
        }
    }
}