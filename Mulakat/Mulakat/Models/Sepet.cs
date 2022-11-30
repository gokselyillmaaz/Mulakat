using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mulakat.Models
{
    public class Sepet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SepetID { get; set; }
        public int MusteriID { get; set; }
        public virtual Musteri Musteri { get; set; }
        public List<SepetUrun> sepetUruns { get; set; }
    }
}
