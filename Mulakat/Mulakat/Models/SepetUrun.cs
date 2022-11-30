using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mulakat.Models
{
    public class SepetUrun
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SepetUrunID { get; set; }
        public int Tutar { get; set; }
        public String Aciklama { get; set; }
        public int SepetID { get; set; }
        public virtual Sepet Sepet { get; set; }
    }
}
