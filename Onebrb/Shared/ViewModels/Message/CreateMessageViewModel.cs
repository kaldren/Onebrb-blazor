using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onebrb.Shared.ViewModels.Message
{
    public class CreateMessageViewModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public string AuthorId { get; set; }
        public string Recipient { get; set; }
        public string RecipientId { get; set; }
    }
}
