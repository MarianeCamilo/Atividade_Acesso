using System;

namespace Controller
{
    public class Usuario
    {   
        public static Model.Usuario CriarUsuario(
            string nome,
            string email,
            string senha
        )
        {

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");    // invalidando caracteres que não são permitidos para cadastrar ou pesquisar um email
            Match match = regex.Match(email);

            if (!match.Success)
                throw new Exception("Email inválido");

            Model.Usuario usuario = new Model.Usuario(
                nome,
                email,
                senha
            );
            return usuario;
        }

         public static Model.Usuario AlterarUsuario(       // alterar usuario
            string id,
            string nome,
            string email,
            string senha
        )
        {
            try
            {
                int idUsuario = Int32.Parse(id);

                return Model.Usuario.AlterarUsuario(        // alterar dados do usuario
                    idUsuario,
                    nome,
                    email,
                    senha
                );
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void ExcluirUsuario(      // excluir usuario
            string id
        )
        {
            try
            {
                int idUsuario = Int32.Parse(id);

                Model.Usuario.ExcluirUsuario(idUsuario);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Model.Usuario> ListarUsuarios() {       // listar todos os usuarios
            return Model.Usuario.ListarUsuarios();
        }


        public static Model.Usuario BuscarPorEmail(string email) {      // buscar usuarios por email
            return Model.Usuario.BuscarPorEmail(email);
        }

        
        /*
        public static void CadastrarUsuario(string id, string nome)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            Model.Usuario usuario = new Model.Usuario(idConvert, nome);
        }
            

        public static void AlterarUsuario(string email)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            Model.Usuario.AlterarUsuario(idConvert, nome);
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

        public static List<Model.Usuario> ListarUsuarios()
        {
            return Model.Usuario.Usuarios;
        }
        */


    }
}