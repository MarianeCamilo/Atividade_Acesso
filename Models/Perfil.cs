using System;
using System.Collections.Generic;

namespace Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Usuario { get; set; }

        public 

        public static List<Usuario> Perfis { get; set; } = new List<Usuario>();

        public Usuario(int id, string usuarioId, string Usuario)
        {
            Id = id;
            UsuarioId = usuarioId;
            Usuario = Usuario;

            Perfis.Add(this);
        }

        public Usuario()
        {
        }

        public override string ToString()
        {
            return $"Id: {Id}, Id do usuário: {UsuarioId}, Usuario: {Usuario}";
        }
            /*
        public static void AlterarUsuario(
            int id,
            int usuarioId,
            string Usuario
        )
        {
            Usuario Usuario = BuscarUsuario(id);
            Usuario.UsuarioId = usuarioId;
            Usuario.Usuario = Usuario;
        }

        public static void ExcluirUsuario(int id)
        {
            Usuario Usuario = BuscarUsuario(id);
            Perfis.Remove(Usuario);
        }

        public static Usuario BuscarUsuario(int id)
        {
            Usuario? Usuario = Perfis.Find(c => c.Id == id);
            if (Usuario == null) {
                throw new Exception("Usuario não encontrado");
            }

            return Usuario;
        }
        */
        public static Usuario BuscarUsuario(int id) {
            Database db = new Database();
            try
            {
                Usuario Usuario = (from p in db.Perfis
                                 join u in db.Usuarios on p.UsuarioId equals u.Id
                                 where p.Id == id
                                 select p).First();         // buscar Usuario no banco de dados
                return Usuario;
            }
            catch (Exception)
            {
                throw new Exception("Usuario não encontrado");       // tratamento de exceção para quando o Usuario não é encontrado no banco
            }
        }

        public static Usuario BuscarUsuarioPorUsuario(int UsuarioId) {
            Database db = new Database();
            try
            {
                Usuario Usuario = (from p in db.Perfis
                                 where p.UsuarioId == UsuarioId
                                 select p).First();
                return Usuario;                      // buscar Usuario pelo usuário no banco de dados
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void ExcluirUsuario(int id) {
            Database db = new Database();       // buscar e excluir Usuario no banco de dados

            Usuario Usuario = BuscarUsuario(id);
            db.Perfis.Remove(Usuario);
            db.SaveChanges();
        }

        public static List<Usuario> ListarPerfis()
        {
            Database db = new Database();
            return db.Perfis.Include("Usuario").ToList();      // serve para listar perfis de usuário no banco de dados do sistema
        }
    }
}