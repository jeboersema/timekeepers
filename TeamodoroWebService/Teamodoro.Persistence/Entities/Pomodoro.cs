﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Teamodoro.Persistence.Entities
{
    public class Pomodoro : MongoEntity
    {
        public string UserId { get; set; }
        public string TeamId { get; set; }
        public string Description { get; set; }
        public DateTime Started { get; set; }
        public List<Interruption> Interruptions { get; set; }
    }
}
