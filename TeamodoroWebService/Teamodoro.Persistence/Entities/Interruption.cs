using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Teamodoro.Persistence.Entities
{
    public class Interruption
    {
        public DateTime InterruptionTime { get; set; }
        public ObjectId InterruptionTypeId { get; set; }
        public string Reason { get; set; }
        public bool Abandoned { get; set; }
    }
}
