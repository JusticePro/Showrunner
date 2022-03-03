using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showrunner
{
    [Serializable]
    public class Episode : Noteable, Checkable, ICloneable
    {
        public string title = "Untitled Episode";
        public string season = "Default Season";

        public Dictionary<string, string> notes = new Dictionary<string, string>(); // Title : Contents
        public Dictionary<string, Dictionary<string, bool>> todoLists = new Dictionary<string, Dictionary<string, bool>>(); // Title : Contents (which is a list of strings and their check status)

        public void updateNote(string name, string value)
        {
            notes[name] = value;
        }

        public void updateToDo(string name, Dictionary<string, bool> values)
        {
            todoLists[name] = values;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
