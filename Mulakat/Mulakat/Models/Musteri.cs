using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mulakat.Models
{
    public class Musteri
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MusteriID { get; set; }
        public String Ad { get; set; }
        public String Soyad { get; set; }
        public String Sehir { get; set; }
    }
}
