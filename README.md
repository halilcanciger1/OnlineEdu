# 🎓 OnlineEdu - Eğitim Yönetim Platformu

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-MVC_%26_API-5C2D91?style=for-the-badge&logo=asp.net&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/EF_Core-Code_First-39A6C2?style=for-the-badge&logo=nuget&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-Auth-black?style=for-the-badge&logo=JSON%20web%20tokens)

**OnlineEdu**, .NET 8 ve N-Katmanlı (N-Tier) mimari kullanılarak geliştirilmiş; eğitmenler, öğrenciler ve yöneticiler için çok yönlü bir çevrimiçi eğitim, kurs ve içerik yönetim platformudur.

## 🚀 Proje Hakkında

Bu proje, bir online eğitim platformunun ihtiyaç duyabileceği tüm temel gereksinimleri karşılamak üzere tasarlanmıştır. Kurs yönetiminden blog paylaşımlarına, öğretmen-öğrenci etkileşiminden mesajlaşmaya kadar kapsamlı özellikler sunar. Proje, dış sistemler için hizmet veren bir RESTful API (`OnlineEdu.API`) ve son kullanıcılara hitap eden MVC tabanlı dinamik bir Web Arayüzü (`OnlineEdu.WebUI`) barındırmaktadır.

## 🏛️ Mimari Yapı (N-Tier Architecture)

Proje modern yazılım prensiplerine (Clean Code & SOLID) uygun olarak Katmanlı Mimari ile inşa edilmiştir:
- **`OnlineEdu.Entity` (Varlık Katmanı):** Veritabanı modelleri ve tabloların karşılıkları (Course, AppUser, Blog vb.).
- **`OnlineEdu.DataAccess` (Veri Erişim Katmanı):** Entity Framework Core yapılandırmaları, DbContext ve Repository (desen) implementasyonları.
- **`OnlineEdu.Business` (İş Katmanı):** İş kurallarının, validasyonların ve servislerin bulunduğu çekirdek katman.
- **`OnlineEdu.DTO` (Veri Transfer Objeleri):** API ve Web katmanları ile veritabanı arasında köprü kuran, verilerin filtrelenerek taşındığı nesneler.
- **`OnlineEdu.API` (Sunucu Katmanı):** Dış sistemler veya frontend projeleri ile haberleşen RESTful API uç noktaları.
- **`OnlineEdu.WebUI` (Kullanıcı Arayüzü Katmanı):** ASP.NET Core MVC ile geliştirilmiş, sistemle doğrudan etkileşimi sağlayan arayüz. Kendi içerisinde 3 farklı `Area` (Admin, Student, Teacher) barındırır.

## ✨ Öne Çıkan Özellikler

- 🔐 **Kimlik Doğrulama & Yetkilendirme:** ASP.NET Core Identity altyapısı ile entegre edilmiş JWT (JSON Web Token) tabanlı güvenli giriş ve rol yönetimi (Admin, Öğretmen, Öğrenci).
- 🎓 **Kapsamlı Kurs Yönetimi:** Kategori bazlı kurs oluşturma, kurs videoları ekleme/yönetme ve öğrencilerin istedikleri kurslara kayıt (`CourseRegister`) olması.
- ✍️ **Blog & İçerik Yönetimi (CMS):** Gelişmiş blog sistemi ve sitenin dinamik alanlarının (Hakkımızda, Ana Banner, İletişim, Referanslar) panel üzerinden yönetilmesi.
- 💬 **Etkileşim:** Kullanıcılar arası mesajlaşma modülü ve e-bülten aboneliği (Subscriber).
- 🔌 **API Desteği:** Mobil uygulamalar veya farklı SPA (React, Vue, Angular) projeleriyle tam uyumlu çalışabilmesi için Swagger destekli Web API.
- 🧹 **Temiz Kod Altyapısı:** AutoMapper ile nesne eşleme ve FluentValidation ile katı kural tabanlı veri doğrulama işlemleri.

## 💻 Teknoloji Yığını (Tech Stack)

- **Backend:** .NET 8.0, C#, ASP.NET Core Web API, ASP.NET Core MVC
- **Veritabanı:** Microsoft SQL Server
- **ORM:** Entity Framework Core (Proxies destekli Lazy Loading)
- **Güvenlik:** ASP.NET Core Identity, JWT Bearer
- **Kütüphaneler:** AutoMapper, FluentValidation, Swashbuckle (Swagger)

## 🛠 Kurulum ve Çalıştırma

### 📋 Gereksinimler
- .NET 8 SDK
- Microsoft SQL Server (Örn: SQLEXPRESS)
- Visual Studio 2022 veya dengi bir IDE

### ⚙️ Adımlar

1. **Projeyi Klonlayın:**
   ```bash
   git clone <repo_url>
   cd OnlineEdu
   ```

2. **Veritabanı Bağlantı Ayarlarını Yapılandırın:**
   `OnlineEdu.API` ve `OnlineEdu.WebUI` projeleri içerisindeki `appsettings.json` dosyalarını açıp, `SqlConnection` bölümündeki `server=` kısmını kendi SQL Server adınıza göre güncelleyin.
   ```json
   "ConnectionStrings": {
     "SqlConnection": "server=SIZIN_SUNUCU_ADINIZ; database=OnlineEduDb; Integrated Security=true; TrustServerCertificate=True;"
   }
   ```

3. **Veritabanını Oluşturun (Migration):**
   Package Manager Console (PMC) üzerinden `OnlineEdu.DataAccess` projesini seçerek veya terminalden veritabanını oluşturun:
   ```bash
   # Terminal üzerinden (Proje kök dizininde çalıştırın)
   dotnet ef database update --project OnlineEdu.DataAccess --startup-project OnlineEdu.API
   ```

4. **Projeyi Başlatma:**
   - Proje içerisinde `OnlineEdu.slnLaunch` konfigürasyonu bulunmaktadır. Visual Studio'da **"Multiple Startup Projects"** ayarını seçerek `OnlineEdu.API` ve `OnlineEdu.WebUI` projelerini aynı anda başlatabilirsiniz.
   - API projesi Swagger dokümantasyonunu ayaklandıracak, MVC projesi ise tarayıcıda kullanıcı arayüzünü açacaktır.

---
> **Geliştirici Notu:** Bu proje, modüler ve yüksek performanslı yapısı sayesinde eğitim kurumları, özel ders verenler ve kurs platformu kurmak isteyenler için ölçeklenebilir bir temel oluşturur.

