# 👟 Adım Adım Ayakkabı - Dynamic Shoe Showcase & In-Memory CRUD System

![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET Core MVC](https://img.shields.io/badge/ASP.NET_Core-MVC-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![HTML5](https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/CSS3-1572B6?style=for-the-badge&logo=css3&logoColor=white)

**Adım Adım Ayakkabı**, ASP.NET Core 8.0 MVC mimarisi kullanılarak geliştirilmiş, herhangi bir harici veritabanı kurulumu gerektirmeden (**In-Memory / Bellek İçi Veri Yönetimi**) çalışan, modern kullanıcı vitrini ve bağımsız admin yönetim paneline sahip dinamik bir e-ticaret vitrin projesidir.

---

## 🌟 Öne Çıkan Özellikler

### 1. 🛍️ Kullanıcı Vitrini (Müşteri Arayüzü)
- **Modern & Akıcı Tasarım**: CSS Grid ve Flexbox kullanılarak tasarlanmış responsive ürün kartları.
- **Mikro Animasyonlar**: Kartların üzerine gelindiğinde derinlik katan gölge, yükselme efekti ve ayakkabı resimlerinde yumuşak büyüme (`scale`) animasyonu.
- **Temiz Kullanıcı Deneyimi**: Ziyaretçilerin sadece ürünleri inceleyip satın alabileceği, karmaşık butonlardan arındırılmış yalın vitrin.
- **Dinamik Veri Bağlantısı**: Admin panelinden eklenen tüm ürünler anında vitrinde for döngüsüyle listelenir.

### 2. ⚙️ Admin Yönetim Paneli (CRUD Masası)
- **Merkezi Yönetim**: Tüm ürünlerin tek bir tablo üzerinden takip edilebildiği sade ve işlevsel admin listesi.
- **Görsel / Dosya Yükleme (`IFormFile`)**: Bilgisayardan istenilen görseli (PNG, JPG, WEBP) seçip sunucuya (`wwwroot/uploads/`) kaydetme desteği.
- **Canlı Görsel Önizleme**: Ürün eklerken ve güncellerken seçilen görselin anlık olarak form üzerinde gösterilmesi.
- **Tam CRUD Desteği**:
  - ➕ **Add (Ekleme)**: Başlık, açıklama, fiyat ve resim yükleme ile yeni ürün oluşturma.
  - ✏️ **Edit (Güncelleme)**: Mevcut ürün bilgilerini ve görselini değiştirme.
  - 🗑️ **Delete (Silme)**: İstenmeyen ürünleri anında listeden kaldırma.

### 3. ⚡ Veritabanı Bağımsız Mimari (In-Memory)
- SQL Server, PostgreSQL veya MySQL kurulumuna gerek duymaz.
- Veriler `static List<Ayakkabi>` yapısıyla bellekte tutulur, anında kurulup hemen çalıştırılabilir.

---

## 🏗️ Proje Mimarisi ve Dizin Yapısı

```text
WebApplication55/
│
├── Controllers/
│   ├── AyakkabiController.cs    # Vitrin ve Admin CRUD metotları (In-Memory)
│   └── HomeController.cs        # Varsayılan controller
│
├── Models/
│   ├── Ayakkabi.cs              # Id, Baslik, Aciklama, Fiyat, ResimUrl, IFormFile
│   └── ErrorViewModel.cs
│
├── Views/
│   ├── Ayakkabi/
│   │   ├── Index.cshtml         # Kullanıcı vitrini (Dinamik HTML/CSS kartlar)
│   │   ├── List.cshtml          # Admin yönetim tablosu
│   │   ├── Add.cshtml           # Yeni ayakkabı ekleme & resim yükleme formu
│   │   └── Edit.cshtml          # Ayakkabı düzenleme & görsel güncelleme formu
│   └── Shared/
│       └── _Layout.cshtml
│
├── wwwroot/
│   ├── ayakabısite/             # Orijinal HTML, CSS ve statik logo/resimler
│   │   └── images/
│   └── uploads/                 # Kullanıcının yüklediği yeni ürün resimleri
│
└── Program.cs                   # Uygulama başlangıç konfigürasyonu ve default route
