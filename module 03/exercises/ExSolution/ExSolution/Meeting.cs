using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExSolution
{
    public class Meeting
    {
        public string Title { get; set; } = "";

        public DateTime Start { get; set; } = DateTime.Now;

        public TimeSpan Length { get; set; } = TimeSpan.Zero;
    }
}
