using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace thuctapAPI.Model
{
    public class SurveyArticle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSA { get; set; }
        public int IdArticle { get; set; }
        public int IdCreator { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status { get; set; }

    }
}
