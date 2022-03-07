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
        private string title = "Untitled Episode";
        private string season = "Default Season";

        private Dictionary<string, string> notes = new Dictionary<string, string>(); // Title : Contents
        private Dictionary<string, Dictionary<string, bool>> todoLists = new Dictionary<string, Dictionary<string, bool>>(); // Title : Contents (which is a list of strings and their check status)

        /**
         * Note
         */
        public void updateNote(string name, string value)
        {
            notes[name] = value;
        }

        public string getNote(string name)
        {
            if (!notes.ContainsKey(name))
            {
                return null;
            }
            return notes[name];
        }

        public string[] getNoteList()
        {
            return notes.Keys.ToArray<string>();
        }

        public void removeNote(string name)
        {
            notes.Remove(name);
        }

        /**
         * To Do
         */
        public void updateToDo(string name, Dictionary<string, bool> values)
        {
            todoLists[name] = values;
        }

        public Dictionary<string, bool> getToDo(string name)
        {
            return todoLists[name];
        }

        public void removeToDo(string name)
        {
            todoLists.Remove(name);
        }

        public string[] getToDoList()
        {
            return todoLists.Keys.ToArray<string>();
        }

        /**
         * Title
         */
        public void setTitle(string title)
        {
            this.title = title;
        }

        public string getTitle()
        {
            return title;
        }

        /**
         * Season
         */
        public void setSeason(string season)
        {
            this.season = season;
        }

        public string getSeason()
        {
            return season;
        }

        /**
         * Clone
         */
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
