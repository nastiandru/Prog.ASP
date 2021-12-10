using Prog_Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prog_Lab1.Models
{
    public class BlogItem
    {
        public BlogItem()
        {
           Tags = new HashSet<Tag>();
        }

        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Musisz podać tytuł")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Musisz wpisac treść")]
        [MinLength(5, ErrorMessage = "Treść powinna mieć co najmniej 5 znaków")]

        public string Content { get; set; }

        public DateTime CreationTimestamp { get; set; }

        public ICollection<Tag> Tags;
    }
}
