# Dinamik Portfolyo ve Yönetim Paneli

[English](README.md) | **Türkçe**

**ASP.NET Core MVC**, **C#**, **Entity Framework Core**, **Microsoft SQL Server** ve **Bootstrap 5** ile geliştirilmiş, veritabanı destekli ve mobil uyumlu bir kişisel portfolyo uygulaması. Proje, ziyaretçilere açık bir portfolyo sitesi ile içerik, proje ve iletişim mesajlarını yönetmeye yönelik bir admin panelinden oluşur.

## Özellikler

### Portfolyo sitesi
- Razor ViewComponent yapısıyla dinamik giriş, hakkımda, eğitim, deneyim, yetenek, proje ve iletişim bölümleri
- Kategoriye göre proje filtreleme ve responsive tasarım
- Yazı animasyonları, kaydırma efektleri ve etkileşimli menü
- Doğrulama içeren iletişim formu ve mesajların veritabanına kaydedilmesi
- CV indirme

### Yönetim paneli
- Proje, yetenek, eğitim, deneyim ve mesaj istatistikleri
- Son projeler ve son mesajlar
- Portfolyo içerikleri için CRUD işlemleri
- Proje ve yetenek kategorilerinin yönetimi
- Projelerde aktif/pasif durum yönetimi
- Mesaj detayları ve okundu/okunmadı takibi
- CV yönetimi

## Kullanılan Teknolojiler

| Alan | Teknolojiler |
| --- | --- |
| Backend | C#, ASP.NET Core MVC |
| Veri erişimi | Entity Framework Core, LINQ |
| Veritabanı | Microsoft SQL Server |
| Frontend | Razor, HTML5, CSS3, JavaScript |
| Arayüz | Bootstrap 5, Bootstrap Icons |
| Mimari | MVC, Razor ViewComponents |
| Araçlar | Visual Studio, Git, GitHub |

## Proje Yapısı

```text
MYAcademy_Portfolio/
├── Areas/Admin/
├── Controllers/
├── Context/
├── Entities/
├── Models/
├── ViewComponents/
├── Views/
├── wwwroot/
├── Migrations/
└── Program.cs
```

## Kurulum

1. Repository'yi klonlayın ve solution dosyasını Visual Studio'da açın.
2. Yerel SQL Server bağlantısını user secrets veya ortam değişkenleri üzerinden yapılandırın.
3. Bağımlılıkları geri yükleyin ve projedeki mevcut EF Core migration'larını uygulayın:

```bash
dotnet restore
dotnet ef database update
```

4. Uygulamayı başlatın:

```bash
dotnet run
```

> SQL Server, projenin hedeflediği .NET SDK sürümü ve `dotnet ef` için EF Core CLI gereklidir. Şifreleri veya gizli bilgileri GitHub'a yüklemeyin.

## Ekran Görüntüleri

Portfolyo ve yönetim panelinin ekran görüntüleri yakında eklenecek.

## Kazanımlarım

Bu proje kapsamında MVC mimarisi, EF Core ve LINQ, CRUD işlemleri, ilişkisel veri modelleri, yeniden kullanılabilir ViewComponent yapıları, dashboard istatistikleri ve responsive web arayüzleri üzerine çalıştım.

## Geliştirici

**Yaren Kasımoğlu**  
Bilgisayar Mühendisi · .NET Geliştirici · Dijitalleşme ve Otomasyon

ASP.NET Core MVC öğrenme ve portfolyo geliştirme sürecim kapsamında hazırlanmıştır.
