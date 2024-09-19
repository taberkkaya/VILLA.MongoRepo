using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.Dto.Dtos.MessageDtos
{
    public class ResultMessageDtos
    {
        public ObjectId Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
