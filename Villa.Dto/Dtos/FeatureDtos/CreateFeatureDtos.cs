using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.Dto.Dtos.FeatureDtos
{
    public class CreateFeatureDtos
    {
        public ObjectId Id { get; set; }
        public string? ImgUrl { get; set; }
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public string? Square { get; set; }
        public string? Contract { get; set; }
        public string? Payment { get; set; }
        public string? Safety { get; set; }
    }
}
