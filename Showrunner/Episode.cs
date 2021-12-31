using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showrunner
{
    [Serializable]
    public class Episode : Noteable, Checkable
    {
        public string title = "Untitled Episode";
        
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

        public static Episode readEpisode(byte[] data)
        {
            Episode episode = new Episode();

            int p = 0; // Pointer

            /**
             * Title
             */

            byte titleLength = data[0];
            p++;

            byte[] titleBytes = data.Skip(p).Take((int)titleLength).ToArray();
            p += titleLength;

            episode.title = Encoding.ASCII.GetString(titleBytes); // Get Title

            /**
             * Notes
             */
            /*uint noteCount = BitConverter.ToUInt32(data, p);
            p += 4;

            for (int i = 0; i < noteCount; i++)
            {
                byte noteTitleLength = data[p];
                p++;

            }*/

            return episode;
        }

        public byte[] toBytes()
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
             * To Do Lists
             */
            uint todoCount = (uint)todoLists.Count;

            data.AddRange(BitConverter.GetBytes(todoCount));

            foreach (string title in todoLists.Keys)
            {
                List<byte> listData = new List<byte>();

                /**
                 * Title
                 */
                byte[] titleBytes = Encoding.ASCII.GetBytes(title);

                listData.Add((byte)titleBytes.Length);
                listData.AddRange(titleBytes);

                /**
                 * Items
                 */
                foreach (string item in todoLists[title].Keys)
                {
                    byte[] itemBytes = Encoding.ASCII.GetBytes(item);

                    listData.Add((byte)itemBytes.Length);
                    listData.AddRange(itemBytes);
                    listData.Add(todoLists[title][item] == true ? (byte)1 : (byte)0);

                    data.AddRange(BitConverter.GetBytes((uint)itemBytes.Length));
                    data.AddRange(itemBytes);
                }

                data.AddRange(BitConverter.GetBytes((uint)listData.ToArray().Length));
                data.AddRange(listData);
            }

            return data.ToArray();
        }

    }
}
