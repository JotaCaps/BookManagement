﻿using BookManagement.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Application.Models
{
    public class RegisterBookInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório!")]
        [StringLength(100 , ErrorMessage = "O título deve ter no máximo 100 caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O autor é obrigatório!")]
        public string Author { get; set; }
        public string ISBN { get; set; }

        [Range(100, 2100, ErrorMessage = "Ano de publicação inválido")]
        public int PublicationYear { get; set; }

        public Book ToEntity()
            => new(Id, Title, Author, ISBN, PublicationYear);
    }
}
