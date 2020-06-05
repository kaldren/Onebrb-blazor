using System;
using System.Collections.Generic;
using System.Text;

namespace Onebrb.Shared.ViewModels.Message
{
    public class MessageViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public string AuthorId { get; set; }
        public string Recipient { get; set; }
        public string RecipientId { get; set; }
        public DateTime DateSent { get; set; }
    }
}
