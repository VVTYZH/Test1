using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Data.Models
{
    public class AgeCategory
    {
        [Key]
        public int Id { get; set; }

        public int Min { get; set; }

        public int Max { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<Book> Books { get; set; }
    }
}
