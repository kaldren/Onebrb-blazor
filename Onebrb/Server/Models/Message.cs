using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onebrb.Server.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime DateSent { get; set; }
        public string AuthorId { get; set; }
        public string RecipientId { get; set; }
        public bool IsDeletedForAuthor { get; set; }
        public bool IsArchivedForAuthor { get; set; }
        public bool IsDeletedForRecipient { get; set; }
        public bool IsArchivedForRecipient { get; set; }
    }
}
