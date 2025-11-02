using LivroManager.Data;
using LivroManager.Models;

namespace LivroManager.Controllers
{
    public class LivroController
    {
        private readonly ApplicationDbContext _context;

        public LivroController(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CriarLivro(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
        }

        public List<Livro> ListarLivros(int userId)
        {
            return _context.Livros.Where(l => l.UserId == userId).ToList();
        }

        public Livro GetLivro(int livroId, int userId)
        {
            return _context.Livros.FirstOrDefault(l => l.LivroId == livroId && l.UserId == userId);
        }

        public void AtualizarLivro(Livro livro)
        {
            var l = _context.Livros.FirstOrDefault(x => x.LivroId == livro.LivroId && x.UserId == livro.UserId);
            if (l != null)
            {
                l.Titulo = livro.Titulo;
                l.Autor = livro.Autor;
                l.DataPublicacao = livro.DataPublicacao;
                l.Categoria = livro.Categoria;
                l.Descricao = livro.Descricao;
                _context.SaveChanges();
            }
        }

        public void DeletarLivro(int livroId, int userId)
        {
            var l = _context.Livros.FirstOrDefault(x => x.LivroId == livroId && x.UserId == userId);
            if (l != null)
            {
                _context.Livros.Remove(l);
                _context.SaveChanges();
            }
        }
    }
}
