﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.Dto.Dtos.DealDtos
{
    public class CreateDealDto
    {
        public string? Type { get; set; }
        public string? ImgUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Square { get; set; }
        public int Floor { get; set; }
        public int RoomCount { get; set; }
        public bool HasParkingArea { get; set; }
        public string? PaymentType { get; set; }
    }
}
