using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace thuctapAPI.Model
{
    public class Warehouse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdWS { get; set; }
        public string Section { get; set; }
        public string Code { get; set; }
        public string Purpose { get; set; }
        public int IdCreator { get; set; }


    }
}
