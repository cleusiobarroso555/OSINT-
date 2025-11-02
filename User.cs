using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LivroManager.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public List<Livro> Livros { get; set; }
    }
}
