using System;

namespace Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public static List<Usuario> Usuarios { get; set; } = new List<Usuario>();

        public Usuario(int id, string nome, string email, string senha)
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;

            Usuarios.Add(this);
        }

        public Usuario()
        {
        }

        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Nome}, E-mail: {Email}, Senha: {Senha}";
        }
            /*
        public static void AlterarUsuario(
            int id,
            string nome,
            string email,
            string senha
        )
        {
            Usuario usuario = BuscarUsuario(id);
            usuario.Nome = nome;
        }

        public static void ExcluirUsuario(int id)
        {
            Usuario usuario = BuscarUsuario(id); 
            Usuarios.Remove(usuario);
        }

        public static Usuario BuscarUsuario(int id)
        {
            Usuario? usuario = Usuarios.Find(c => c.Id == id);
            if (usuario == null) {
                throw new Exception("Usuario não encontrada");
            }

            return usuario;
        }
        */
        
        public static Model.Usuario BuscarUsuario(
            int id
        )
        {
            Database db = new Database();
            try
            {
                Model.Usuario usuario = (from u in db.Usuarios
                                     where u.Id == id
                                     select u).First();
                return usuario;     // buscar usuário no banco de dados
            } catch
            {
                throw new System.Exception("Usuário não encontrado"); //// tratamento de exceção para quando o usuário não é encontrado no banco
            }
            
        }

        public static Usuario AlterarUsuario(
            int id,
            string nome,
            string email,
            string senha        // alterar dados do usuário
        )
        {
            try
            {
                Usuario usuario = BuscarUsuario(id);
                usuario.Email = email;
                usuario.Nome = nome;
                usuario.Senha = senha;
                Database db = new Database();
                db.Usuarios.Update(usuario);
                db.SaveChanges();

                return usuario;
            }
            catch (System.Exception e)      // tratamento de exceção na alteração do usuário
            {
                throw e;
            }
        }

        public static void ExcluirUsuario(      // excluir usuário  do banco de dados
            int id
        )
        {
            try
            {
                Model.Usuario usuario = BuscarUsuario(id);
                Database db = new Database();
                db.Usuarios.Remove(usuario);
                db.SaveChanges();
            }
            catch (System.Exception e)      // tratamento de exceção na usuário do usuário
            {
                throw e;
            }
        }

        public static List<Model.Usuario> ListarUsuarios() {        // listar usuário no banco de dados
            Database db = new Database();
            List<Model.Usuario> usuarios = (from u in db.Usuarios
                                        select u).ToList();
            return usuarios;
        }


        public static Model.Usuario BuscarPorEmail(string email) {  // buscar usuário pelo e-mail
            try {
                Database db = new Database();
                Model.Usuario usuario = (from u in db.Usuarios
                                            where u.Email == email
                                            select u).First();
                return usuario;
            } catch {
                throw new System.Exception("Usuário não encontrado"); // tratamento de exceção na busca do usuário informando que não foi encontrado
            }
        }
    }
}