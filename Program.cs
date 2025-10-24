using study;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var service = new MessagingService();

        Console.WriteLine("=== MESAJLAŞMA SİSTEMİ DEMO ===\n");

        Console.WriteLine("--- Kullanıcı 1 Kaydı ---");
        service.Register("ahmet123", "password123", "ahmet@example.com", "Ahmet", "Yılmaz");

        Console.WriteLine("\n--- Kullanıcı 2 Kaydı ---");
        service.Register("me", "pass", "mehmet@example.com", "Mehmet", "Kaya");

        Console.WriteLine();
        service.ListUsers();

        Console.WriteLine("\n--- Kullanıcı 1 Giriş ---");
        service.Login("ahmet123", "password123");

        Console.WriteLine("\n--- Mesaj Gönderme ---");
        service.SendMessage("**m", "Merhaba Mehmet! Nasılsın?");

        Console.WriteLine("\n--- Çıkış ---");
        service.Logout();

        Console.WriteLine("\n--- Kullanıcı 2 Giriş ---");
        service.Login("**m", "pass****");

        Console.WriteLine("\n--- Gelen Mesajlar ---");
        service.ViewMessages();

        Console.WriteLine("\n--- Cevap Gönderme ---");
        service.SendMessage("ahmet123", "İyiyim, teşekkürler! Sen nasılsın?");

        service.Logout();

        Console.WriteLine("\n--- Kullanıcı 1 Tekrar Giriş ---");
        service.Login("ahmet123", "password123");
        service.ViewMessages();

        Console.WriteLine("\n\nDemo tamamlandı. Çıkmak için bir tuşa basın...");
        Console.ReadKey();
    }
}
