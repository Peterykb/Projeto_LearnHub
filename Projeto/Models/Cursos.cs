using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Models
{
    public class Cursos
    {
        [Key]
        public int Id_curso { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Data_criacao { get; set; }
        public bool Disponível { get; set; } = true;
        public double Preco { get; set; }
        public int InstrutorId { get; set; }

        public InstrutorInformacoes? Instrutor { get; set; }

        // Definição da chave estrangeira
        public ICollection<Matricula>? Matriculas { get; set; } = new List<Matricula>();
        public ICollection<CursoCategoria> CursoCategorias { get; set; } = new List<CursoCategoria>();
        public ICollection<Modulos> Modulos { get; set; } = new List<Modulos>();
        public ICollection<Comentarios> Comentarios { get; set; } = new List<Comentarios>();
        public ICollection<Carrinho>? carrinho { get; set; }
    }
}
