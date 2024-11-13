using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace thuctapAPI.Model
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNoti { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int IdCreator { get; set; }

    }
}
