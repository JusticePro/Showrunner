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

        
        /***
         * Load a show from a file.
         */
        public static Show loadShow(string path)
        {
            Show show = new Show();

            if (!File.Exists(path))
            {
                throw new IOException("File doesn't exist");
            }

            byte[] data = File.ReadAllBytes(path);

            int pointer = 0; // This represents where the position of the data reading is. After each byte read, this increases.

            /*
             * Title
             */

            byte titleLength = data[0]; // Length of the title.
            pointer++; // Add one byte to the pointer

            string title = Encoding.ASCII.GetString(data, pointer, titleLength); // Read the title.
            pointer += titleLength; // Move past the title.

            /* Set the show's title. */
            show.title = title;

            /*
             * Notes
             */
            uint noteCount = BitConverter.ToUInt32(data, pointer); // This amount of notes there are.
            pointer += 4; // Move past the uInt.

            uint[] noteLengths = new uint[noteCount];

            // Read the uInts that equal to the length of the indiviudal note data.
            for (int i = 0; i < noteCount; i++)
            {
                noteLengths[i] = BitConverter.ToUInt32(data, pointer);
                pointer += 4; // Move past the uInt.
            }

            // Read each note.
            foreach (uint noteLength in noteLengths)
            {
                byte[] noteData = data.Skip(pointer).Take((int)noteLength).ToArray();

                byte nameLength = noteData[0];
                string name = Encoding.ASCII.GetString(noteData, 1, nameLength);

                string contents = Encoding.ASCII.GetString(noteData, 1 + nameLength, noteData.Length - (1 + nameLength));

                /* Add a note */
                show.notes[name] = contents;

                pointer += (int)noteLength;
            }

            /*
             * Episodes
             */
            uint episodeCount = BitConverter.ToUInt32(data, pointer); // This amount of notes there are.
            pointer += 4; // Move past the uInt.

            uint[] episodeLengths = new uint[episodeCount];

            // Read the uInts that equal to the length of the indiviudal episode data.
            for (int i = 0; i < noteCount; i++)
            {
                noteLengths[i] = BitConverter.ToUInt32(data, pointer);
                pointer += 4; // Move past the uInt.
            }

            foreach (uint episodeLength in episodeLengths)
            {
                byte[] episodeData = data.Skip(pointer).Take((int)episodeLength).ToArray();

                /* Add an episode. */
                show.episodes.Add(Episode.readEpisode(episodeData));
                pointer += (int)episodeLength;
            }

            return show;
        }

        public void update()
        {
            if (templates == null) // Templates
            {
                templates = new Dictionary<string, Episode>();
            }
            versionID = Updater.getVersionID();
        }

        public void saveShow(string path)
        {
            List<byte> data = new List<byte>();
            
            /**
             * Title
             */

            byte[] t = Encoding.ASCII.GetBytes(title); // Title to bytes.
            byte titleLength = (byte) t.Length; // Title length

            data.Add(titleLength); // Add title headers (length)
            data.AddRange(t); // Add title

            /**
             * Notes
             */

            uint noteCount = (uint) notes.Count; // Note Count

            data.AddRange(BitConverter.GetBytes(noteCount)); // Add Note Count

            List<uint> noteLengths = new List<uint>();
            List<byte[]> noteData = new List<byte[]>();

            // For each note
            foreach (string note in notes.Keys)
            {
                byte[] nd = Encoding.ASCII.GetBytes(notes[note]); // Note Data
                byte[] noteTitle = Encoding.ASCII.GetBytes(notes[note]);
                List<byte> ndata = new List<byte>(); // Note Data + Name

                ndata.Add((byte)noteTitle.Length);
                ndata.AddRange(noteTitle);
                ndata.AddRange(nd);

                noteLengths.Add((uint)ndata.ToArray().Length);
                noteData.Add(ndata.ToArray());
            }

            foreach (uint nl in noteLengths)
            {
                data.AddRange(BitConverter.GetBytes(nl)); // Add Note Length
            }

            foreach (byte[] nd in noteData)
            {
                data.AddRange(nd); // Add Note Contents
            }

            /**
             * Episode
             */
            List<uint> episodeLengths = new List<uint>();
            List<byte[]> episodeData = new List<byte[]>();

            // For each note
            foreach (Episode episode in episodes)
            {
                byte[] ed = episode.toBytes();
                episodeLengths.Add((uint)ed.Length);
                episodeData.Add(ed);
            }

            foreach (uint el in episodeLengths)
            {
                data.AddRange(BitConverter.GetBytes(el)); // Add Note Length
            }

            foreach (byte[] ed in noteData)
            {
                data.AddRange(ed); // Add Note Contents
            }

            /**
             * Write File
             */

            File.WriteAllBytes(path, data.ToArray()); // Write data.
        }

    }
}