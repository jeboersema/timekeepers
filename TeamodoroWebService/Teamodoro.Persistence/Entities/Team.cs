using MongoDB.Bson;

namespace Teamodoro.Persistence.Entities
{
    public class Team : MongoEntity
    {
        public ObjectId TeamOwnerId { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public bool IsPublic { get; set; }
        public decimal PomodoroLength { get; set; }
        public decimal ShortBreakLength { get; set; }
        public decimal LongBreakLength { get; set; }
        public int PomodorosBetweenLongBreaks { get; set; }
    }
}
