using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace thuctapAPI.Model
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAnswer { get; set; }
        public string Content { get; set; }
        public bool IsMultipleChoice { get; set; }
        public int IdQuestion { get; set; }

     
    }
}
