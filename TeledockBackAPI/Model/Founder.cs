using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TeledockBackAPI.Model
{
    public class Founder
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int INN { get; set; }
        [Required]
        public int ClientID { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Patronymic { get; set; }
        [Required]
        [Column(TypeName = "timestamp(6)")]
        public DateTime AddDate { get; set; }
        [Required]
        [Column(TypeName = "timestamp(6)")]
        public DateTime UpdateDate { get; set; }
        [JsonIgnore]
        [ForeignKey("ClientID")]
        public virtual Client Clients { get; set; }

    }
}
