using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace thuctapAPI.Model
{
    public class Visitor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVisitor { get; set; }
        public int IdAcc { get; set; }
        public int IdWS { get; set; }

    }
}
