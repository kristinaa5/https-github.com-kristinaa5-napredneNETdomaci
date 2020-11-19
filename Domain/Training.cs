using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Training
    {
        public int TrainingId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }


        public override string ToString()
        {
            return $"{TrainingId}: {Name}, {Date.ToString("dd-MM-yy")}";
        }
    }
}
