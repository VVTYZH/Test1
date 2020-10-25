using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{

    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Range(-3000, 2020)]
        public int Year { get; set; }

        public int AuthoreId { get; set; }
        public virtual Author Author { get; set; }

        public int AgeCategoryId { get; set; }
        public virtual AgeCategory AgeCategory { get; set; }

        public int CoverTypeId { get; set; }
        public virtual CoverType CoverType { get; set; }

        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
