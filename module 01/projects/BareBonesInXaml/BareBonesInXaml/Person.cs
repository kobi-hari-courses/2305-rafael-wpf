using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BareBonesInXaml
{
    [TypeConverter(typeof(PersonConverter))]
    public class Person
    {
        private string _displayName = "John";
        public string DisplayName
        {
            get
            {
                return _displayName;
            } set
            {
                _displayName = value;
            }
        }

        public int Age { get; set; } = 42;

        public Person Mother { get; set; }

        public List<Person> Friends { get; set; }

        public Dictionary<string, Person> Relatives { get; set; }

        public override string ToString()
        {
            return DisplayName;
        }

        public Person()
        {
            Friends = new List<Person>();
            Relatives = new Dictionary<string, Person>();

        }


    }
}
