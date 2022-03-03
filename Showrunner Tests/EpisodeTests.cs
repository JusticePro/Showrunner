using Microsoft.VisualStudio.TestTools.UnitTesting;
using Showrunner;
using System;

namespace Showrunner_Tests
{
    [TestClass]
    public class EpisodeTests
    {
        /**
         * Update Note
         */
        [TestMethod]
        public void updateNote_settingValueOfNewNote_setsNoteNameToValue()
        {
            // Arrange the Test
            Episode episode = new Episode();

            // Perform the Action (Act)
            episode.updateNote("Note Name", "Value\nOf\nNote");

            // Assert the Result
            Assert.AreEqual<string>(episode.notes["Note Name"], "Value\nOf\nNote");
        }

        [TestMethod]
        public void updateNote_settingValueOfExistingNote_setsNoteNameToValue()
        {
            // Arrange the Test
            Episode episode = new Episode();

            // Perform the Action (Act)
            episode.updateNote("Note Name", "Value\nOf\nNote"); // Create note

            episode.updateNote("Note Name", "New Value"); // Update note

            // Assert the Result
            Assert.AreEqual<string>(episode.notes["Note Name"], "New Value");
        }

        /**
         * Update To Do
         */

        [TestMethod]
        public void updateToDo_settingValueOfNewToDo_setsToDoNameToValue()
        {
            // Arrange the Test
            Episode episode = new Episode();
            System.Collections.Generic.Dictionary<string, bool> value = new System.Collections.Generic.Dictionary<string, bool>();
            value["item1"] = true;
            value["item2"] = false;

            // Perform the Action (Act)
            episode.updateToDo("Todo Name", value);

            // Assert the Result
            Assert.AreEqual(episode.todoLists["Todo Name"], value);
        }

        [TestMethod]
        public void updateToDo_settingValueOfExistingToDo_setsToDoNameToValue()
        {
            // Arrange the Test
            Episode episode = new Episode();
            System.Collections.Generic.Dictionary<string, bool> value = new System.Collections.Generic.Dictionary<string, bool>();
            value["item1"] = true;
            value["item2"] = false;

            // Perform the Action (Act)
            episode.updateToDo("Todo Name", value);

            value["item1"] = false;
            value["item2"] = true;
            episode.updateToDo("Todo Name", value);

            // Assert the Result
            Assert.AreEqual(episode.todoLists["Todo Name"], value);
        }

        [TestMethod]
        public void Clone_cloningAnEpisode_fieldsAreTheSame()
        {
            // Arrange the Test
            Episode episode = new Episode();

            // Perform the Action (Act)
            Episode clone = (Episode) episode.Clone();

            // Assert the Result
            Assert.AreEqual(episode.title, clone.title);
            Assert.AreEqual(episode.season, clone.season);
            Assert.AreEqual(episode.notes, clone.notes);
            Assert.AreEqual(episode.todoLists, clone.todoLists);
        }
    }
}
