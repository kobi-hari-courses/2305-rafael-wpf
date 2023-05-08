using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01Solution
{
    public class Question
    {
        public string Id { get; set; } = "";
        public string Caption { get; set; } = "";
        public List<string> Answers { get; } = new List<string>();
        public int CorrectAnswer { get; set; } = 0;


    }
}
