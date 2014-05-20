using System;
using MongoDB.Bson;

namespace Teamodoro.Persistence.Entities
{
    public class Interruption
    {
        public DateTime InterruptionTime { get; set; }
        public string InterruptionTypeId { get; set; }
        public string Reason { get; set; }
        public bool Abandoned { get; set; }
    }
}
