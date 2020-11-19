using System;

namespace Domain
{
    public class User
    {

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int TrainingId { get; set; }

        public Training Training { get; set; }

        public override string ToString()
        {
            return $"{UserId}: {FirstName} {LastName}, {Address}, {Training.Name}";
        }
    }
}
