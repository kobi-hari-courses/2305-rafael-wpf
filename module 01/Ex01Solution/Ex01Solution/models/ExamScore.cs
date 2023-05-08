using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01Solution
{
    [TypeConverter(typeof(ScoreConverter))]
    public class ExamScore
    {
        public int CorrectCount { get; set; }

        public int WrongCount { get; set; }
    }
}
