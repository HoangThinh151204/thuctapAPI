using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace thuctapAPI.Model
{
    public class JobImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdImg { get; set; }
        public int IdJob { get; set; }
        public string Image { get; set; }
        public DateTime DateTaken { get; set; }


    }
}
