using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Onebrb.Server.Models
{
    public class ApplicationUserMessage
    {
        public long Id { get; set; }
        [ForeignKey("Id")]
        public Guid MessageId { get; set; }
        public Message Message { get; set; }

        [ForeignKey("Id")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
