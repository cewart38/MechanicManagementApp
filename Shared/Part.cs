using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicApp.Shared
{
    public class Part
    {

        public int ID { get; set ; } 
        public Job? Job { get; set ; }
        public int JobId { get; set ; }
        public string Name { get; set ; } = String.Empty;
        public double Cost { get; set ; }


    }
}
