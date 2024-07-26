using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TeledockBackAPI.Model
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int INN { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsIndividual { get; set; }
        [Required]
        [Column(TypeName = "timestamp(6)")]
        public DateTime AddDate { get; set; }
        [Required]
        [Column(TypeName = "timestamp(6)")]
        public DateTime UpdateDate { get; set; }
        [JsonIgnore]
        public virtual ICollection<Founder> Founders { get; set; }
    }
}
