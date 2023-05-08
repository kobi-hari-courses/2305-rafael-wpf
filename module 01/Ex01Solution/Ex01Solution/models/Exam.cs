using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01Solution
{
    public class Exam
    {
        public string DisplayName { get; set; } = "";

        public List<Question> Questions { get; } = new List<Question>();

        public Dictionary<string, Answer> Answers { get; } = new Dictionary<string, Answer>();

        public ExamScore Score { get; set; }


    }
}
