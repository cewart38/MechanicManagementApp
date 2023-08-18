using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicApp.Shared
{
    public class Job
    {
        public int ID { get; set; }
        public Customer? Customer { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public string JobTitle { get; set; } = String.Empty;
        public bool IsCompleted { get; set; }
        public DateTime? FinishDate { get; set; }
        public int? TotalHours { get; set; }
    }
}
