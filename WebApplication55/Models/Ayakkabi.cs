using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace WebApplication55.Models
{
    public class Ayakkabi
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık / Ayakkabı Adı zorunludur.")]
        [Display(Name = "Ayakkabı Başlığı")]
        public string Baslik { get; set; } = string.Empty;

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fiyat zorunludur.")]
        [Display(Name = "Fiyat (₺)")]
        public decimal Fiyat { get; set; }

        [Display(Name = "Resim Yolu / URL")]
        public string? ResimUrl { get; set; }

        [NotMapped]
        [Display(Name = "Resim Yükle")]
        public IFormFile? ResimDosyasi { get; set; }
    }
}
