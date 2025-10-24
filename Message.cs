using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study
{
    public class Message
    {
        private string _content;

        public Guid Id { get; private set; }

        public string Content
        {
            get => _content;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    _content = "*";
                else if (value.Length < 1)
                    _content = "*";
                else
                    _content = value;
            }
        }

        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public DateTime CreatedDate { get; private set; }

        public Message()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }
    }
}
