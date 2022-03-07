using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Showrunner
{
    [Serializable]
    public class Show : Noteable
    {
        private string title = "Untitled Show";
        private List<Episode> episodes = new List<Episode>();

        private Dictionary<string, string> notes = new Dictionary<string, string>(); // Title : Contents
        private Dictionary<string, Episode> templates = new Dictionary<string, Episode>(); // Template name. Episode template.

        // Folder - Notes
        private Dictionary<string, List<string>> noteFolders = new Dictionary<string, List<string>>();

        private int versionID = Updater.getVersionID(); // Version ID of the show.

        /**
         * Templates
         */
        public string[] getTemplates()
        {
            return templates.Keys.ToArray();
        }

        public void addTemplate(string name, Episode episode)
        {
            templates[name] = episode;
        }

        public Episode getTemplate(string name)
        {
            if (!templates.ContainsKey(name))
            {
                return null;
            }
            return templates[name];
        }

        /**
         * Version
         */
        public int getVersionID()
        {
            return versionID;
        }

        /**
         * Title
         */
        public string getTitle()
        {
            return title;
        }

        public void setTitle(string title)
        {
            this.title = title;
        }

        /**
         * Episode
         */
        public List<Episode> getEpisodes()
        {
            return episodes;
        }

        public void addEpisode(Episode episode)
        {
            episodes.Add(episode);
        }

        public void removeEpisode(int index)
        {
            episodes.RemoveAt(index);
        }

        public Episode getEpisode(int index)
        {
            return episodes[index];
        }

        public void moveEpisodeUp(int index)
        {
            Episode episode = getEpisode(index);

            episodes.RemoveAt(index);
            episodes.Insert(index - 1, episode);
        }

        public void moveEpisodeDown(int index)
        {
            Episode episode = getEpisode(index);

            episodes.RemoveAt(index);
            episodes.Insert(index + 1, episode);
        }

        /**
         * Notes
         */
        public void updateNote(string name, string value)
        {
            notes[name] = value;
        }

        public void removeNote(string name)
        {
            notes.Remove(name);
        }

        public string getNote(string name)
        {
            return notes[name];
        }

        public string[] getNotes()
        {
            return notes.Keys.ToArray();
        }

        /**
         * Update
         */
        public void update()
        {
            if (templates == null) // Templates
            {
                templates = new Dictionary<string, Episode>();
            }

            foreach (Episode episode in episodes)
            {
                // Update season if there isn't one.
                if (episode.getSeason() == null)
                {
                    episode.setSeason("Default Season");
                }
            }

            if (noteFolders == null)
            {
                noteFolders = new Dictionary<string, List<string>>();
            }

            versionID = Updater.getVersionID();
        }

        /**
         * Note Folders
         */
        public void addToFolder(string note, string folder)
        {
            if (!noteFolders.ContainsKey(folder))
            {
                noteFolders[folder] = new List<string>();
            }

            List<string> list = ((List<string>)noteFolders[folder]);

            if (list.Contains(note))
            {
                return;
            }

            list.Add(note);
        }

        public void removeFromFolder(string note, string folder)
        {
            if (!noteFolders.ContainsKey(folder))
            {
                return;
            }

            List<string> list = ((List<string>)noteFolders[folder]);

            if (!list.Contains(note))
            {
                return;
            }

            list.Remove(note);
            
            if (list.Count == 0)
            {
                noteFolders.Remove(folder);
            }
        }

        public string[] getNotesInFolder(string folder)
        {
            if (!noteFolders.ContainsKey(folder))
            {
                return new string[] { };
            }

            return noteFolders[folder].ToArray();
        }

        public string[] getFolders()
        {
            return noteFolders.Keys.ToArray();
        }
    }
}