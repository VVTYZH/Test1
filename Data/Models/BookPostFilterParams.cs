using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class BookPostFilterParams
    {
        [Range(-3000, 2020)]
        public int? FromYear { get; set; }
        [Range(-3000, 2020)]
        public int? ToYear { get; set; }
        public virtual Author Author { get; set; }
        public virtual AgeCategory AgeCategory { get; set; }
        public virtual CoverType CoverType { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
