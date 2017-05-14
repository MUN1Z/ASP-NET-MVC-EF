using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MVC.Models;

namespace Service.Implementations
{
    public static class PessoaService
    {
        public static void Salvar(Pessoa pessoa)
        {
            using (var db = new MyContext())
            {
                if (pessoa.Codigo > 0)
                {
                    db.Pessoa.Attach(pessoa);
                    db.Entry(pessoa).State = EntityState.Modified;
                }
                else
                    db.Pessoa.Add(pessoa);

                db.SaveChanges();
            }
        }

        public static Pessoa Obter(int codigo)
        {
            using (var db = new MyContext())
            {
                return db.Pessoa.Find(codigo);
            }
        }

        public static List<Pessoa> Listar()
        {
            using (var db = new MyContext())
            {
                return db.Pessoa.ToList();
            }
        }

        public static void Deletar(int codigo)
        {
            using (var db = new MyContext())
            {
                var pessoa = db.Pessoa.Find(codigo);
                if (pessoa != null)
                {
                    db.Pessoa.Attach(pessoa);
                    db.Pessoa.Remove(pessoa);

                    db.SaveChanges();
                }
            }
        }
    }
}
