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
        public string title = "Untitled Show";
        public List<Episode> episodes = new List<Episode>();

        public Dictionary<string, string> notes = new Dictionary<string, string>(); // Title : Contents
        public Dictionary<string, Episode> templates = new Dictionary<string, Episode>(); // Template name. Episode template.

        public int versionID = Updater.getVersionID(); // Version ID of the show.

        public void updateNote(string name, string value)
        {
            notes[name] = value;
        }

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

            versionID = Updater.getVersionID();
        }
    }
}