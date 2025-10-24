using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study
{
    public class MessagingService
    {
        private Repository<User> _userRepository;
        private Repository<Message> _messageRepository;
        private User _currentUser;

        public MessagingService()
        {
            _userRepository = new Repository<User>();
            _messageRepository = new Repository<Message>();
        }

        public void Register(string username, string password, string email, string firstName, string lastName)
        {
            try
            {
                var user = new User
                {
                    Username = username,
                    Password = password,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName
                };

                _userRepository.Add(user);
                Console.WriteLine($"Kayıt başarılı. Kullanıcı ID: {user.Id}");
                Console.WriteLine($"Username: {user.Username}");
                Console.WriteLine($"Email: {user.Email} (Confirm: {user.EmailConfirm})");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kayıt hatası: {ex.Message}");
            }
        }

        public bool Login(string username, string password)
        {
            var user = _userRepository.GetAll()
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                _currentUser = user;
                Console.WriteLine($"Giriş başarılı. {user.FirstName} {user.LastName}");
                return true;
            }
            else
            {
                Console.WriteLine("Kullanıcı adı veya şifre hatalı!");
                return false;
            }
        }

        public void Logout()
        {
            if (_currentUser != null)
            {
                Console.WriteLine($"Çıkış yapıldı. {_currentUser.FirstName}!");
                _currentUser = null;
            }
            else
            {
                Console.WriteLine("Zaten giriş yapmadınız!");
            }
        }

        public void SendMessage(string receiverIdentifier, string content)
        {
            if (_currentUser == null)
            {
                Console.WriteLine("Mesaj göndermek için giriş yapmalısınız!");
                return;
            }

            User receiver = null;

            if (Guid.TryParse(receiverIdentifier, out Guid receiverId))
            {
                receiver = _userRepository.GetById(receiverId);
            }
            else
            {
                receiver = _userRepository.GetAll()
                    .FirstOrDefault(u => u.Username == receiverIdentifier);
            }

            if (receiver == null)
            {
                Console.WriteLine("Alıcı bulunamadı!");
                return;
            }

            var message = new Message
            {
                Content = content,
                SenderId = _currentUser.Id,
                ReceiverId = receiver.Id
            };

            _messageRepository.Add(message);
            Console.WriteLine($"Mesaj gönderildi. ({_currentUser.Username} → {receiver.Username})");
        }

        public void ViewMessages()
        {
            if (_currentUser == null)
            {
                Console.WriteLine("Mesajları görmek için giriş yapmalısınız!");
                return;
            }

            var messages = _messageRepository.GetAll()
                .Where(m => m.ReceiverId == _currentUser.Id)
                .OrderBy(m => m.CreatedDate)
                .ToList();

            if (messages.Count == 0)
            {
                Console.WriteLine("Hiç mesajınız yok.");
                return;
            }

            Console.WriteLine($"\nGelen Mesajlar ({messages.Count} adet):");
            Console.WriteLine(new string('=', 60));

            foreach (var message in messages)
            {
                var sender = _userRepository.GetById(message.SenderId);
                Console.WriteLine($"\n[{message.CreatedDate:dd.MM.yyyy HH:mm}] - Kimden: {sender?.Username ?? "Bilinmeyen"}");
                Console.WriteLine($"Mesaj: {message.Content}");
                Console.WriteLine($"Mesaj ID: {message.Id}");
            }

            Console.WriteLine(new string('=', 60));
        }

        public void ListUsers()
        {
            var users = _userRepository.GetAll();
            Console.WriteLine($"\n Kayıtlı Kullanıcılar ({users.Count} adet):");
            Console.WriteLine(new string('=', 60));

            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}");
                Console.WriteLine($"Username: {user.Username}");
                Console.WriteLine($"Ad Soyad: {user.FirstName} {user.LastName}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine(new string('-', 60));
            }
        }

        public User GetCurrentUser() => _currentUser;
    }
}
