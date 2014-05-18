﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Teamodoro.Persistence.Entities
{
    public class InterruptionType : MongoEntity
    {
        public ObjectId TeamId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}