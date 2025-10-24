# Mesajlaşma Sistemi

Basit bir konsol tabanlı mesajlaşma uygulaması. Generic Repository pattern kullanılarak geliştirilmiştir.

## Özellikler

- ✅ Kullanıcı kaydı ve girişi
- ✅ Kullanıcılar arası mesajlaşma
- ✅ Username veya ID ile mesaj gönderme
- ✅ Gelen mesajları görüntüleme
- ✅ Generic Repository pattern ile CRUD işlemleri

## Kullanım

### 1. Kullanıcı Kaydı
```csharp
service.Register("ahmet123", "password123", "ahmet@example.com", "Ahmet", "Yılmaz");
```

### 2. Giriş Yapma
```csharp
service.Login("ahmet123", "password123");
```

### 3. Mesaj Gönderme
```csharp
// Username ile
service.SendMessage("mehmet", "Merhaba!");

// ID ile
service.SendMessage("guid-buraya", "Selam!");
```

### 4. Mesajları Görüntüleme
```csharp
service.ViewMessages();
```

### 5. Çıkış
```csharp
service.Logout();
```

## Validasyon Kuralları

### User
- **Username**: 3-20 karakter (fazlası kırpılır, azı * ile doldurulur)
- **Password**: Min 8 karakter (azı * ile doldurulur)
- **Email**: Boş geçilemez
- **FirstName/LastName**: Boş geçilemez

### Message
- **Content**: Min 1 karakter (boşsa * ile doldurulur)
- **SenderId/ReceiverId**: Boş geçilemez

## Çalıştırma
```bash
dotnet run
```

veya Visual Studio'da F5 ile çalıştırın.

## Proje Yapısı
```
├── Entities
│   ├── User.cs
│   └── Message.cs
├── Repository
│   ├── IRepository.cs
│   └── Repository.cs
├── Services
│   └── MessagingService.cs
└── Program.cs
```

## Gereksinimler

- .NET 6.0 veya üzeri
