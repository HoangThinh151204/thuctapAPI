using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace thuctapAPI.Model
{
    public class AccountNotification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdAcc { get; set; }
        public int IdNoti { get; set; }
        public int IdReceiver { get; set; }

    }
}
