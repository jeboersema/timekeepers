using System;
using System.Collections.Generic;
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
