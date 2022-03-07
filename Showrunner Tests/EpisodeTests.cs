using Microsoft.VisualStudio.TestTools.UnitTesting;
using Showrunner;
using System;

namespace Showrunner_Tests
{
    [TestClass]
    public class EpisodeTests
    {
        /**
         * Note Manipulation
         */
        [TestMethod]
        public void updateNote_settingValueOfNewNote_setsNoteNameToValue()
        {
            // Arrange the Test
            Episode episode = new Episode();

            // Perform the Action (Act)
            episode.updateNote("Note Name", "Value\nOf\nNote");

            // Assert the Result
            Assert.AreEqual<string>("Value\nOf\nNote", episode.getNote("Note Name"));
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
            Assert.AreEqual<string>("New Value", episode.getNote("Note Name"));
        }

        [TestMethod]
        public void removeNote_removeNote_noteIsRemoved()
        {
            // Arrange the Test
            Episode episode = new Episode();

            // Perform the Action (Act)
            episode.updateNote("Note Name", "Value\nOf\nNote"); // Create note
            episode.removeNote("Note Name");

            // Assert the Result
            Assert.AreEqual<string>(null, episode.getNote("Note Name"));
        }

        [TestMethod]
        public void getNotes_addNotesAndCheckList_returnsListOfNotes()
        {
            // Arrange the Test
            Episode episode = new Episode();

            // Perform the Action (Act)
            episode.updateNote("Note1", "Value\nOf\nNote"); // Create note
            episode.updateNote("Note3", "Value\nOf\nNote"); // Create note
            episode.updateNote("Note2", "Value\nOf\nNote"); // Create note

            // Assert the Result
            Assert.AreEqual("Note1", episode.getNoteList()[0]);
            Assert.AreEqual("Note3", episode.getNoteList()[1]);
            Assert.AreEqual("Note2", episode.getNoteList()[2]);
        }

        [TestMethod]
        public void getNote_addItemAndGetNote_returnsNote()
        {
            // Arrange the Test
            Episode episode = new Episode();

            // Perform the Action (Act)
            episode.updateNote("Note1", "Value\nOf\nNote"); // Create note

            // Assert the Result
            Assert.AreEqual("Value\nOf\nNote", episode.getNote("Note1"));
        }

        [TestMethod]
        public void getNote_addItemsAndGetNote_returnsNote()
        {
            // Arrange the Test
            Episode episode = new Episode();

            // Perform the Action (Act)
            episode.updateNote("Note1", "Value\nOf\nNote"); // Create note
            episode.updateNote("Note3", "Value\nOf\nNote"); // Create note
            episode.updateNote("Note2", "Value\nOf\nNote"); // Create note

            // Assert the Result
            Assert.AreEqual("Value\nOf\nNote", episode.getNote("Note1"));
        }


        /**
         * To Do Manipulation
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
            Assert.AreEqual(value, episode.getToDo("Todo Name"));
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
            Assert.AreEqual(value, episode.getToDo("Todo Name"));
        }

        [TestMethod]
        public void removeToDo_removeExistingToDo_removesTheTodo()
        {
            // Arrange the Test
            Episode episode = new Episode();

            // Perform the Action (Act)
            episode.updateToDo("ToDo Name", new System.Collections.Generic.Dictionary<string, bool>()); // Create todo
            episode.removeToDo("ToDo Name");

            // Assert the Result
            Assert.AreEqual<string>(null, episode.getNote("ToDo Name"));
        }

        [TestMethod]
        public void getToDoList_addItemsAndCheckList_ItemsMatch()
        {
            // Arrange the Test
            Episode episode = new Episode();

            // Perform the Action (Act)
            episode.updateToDo("ToDo1", new System.Collections.Generic.Dictionary<string, bool>()); // Create todo
            episode.updateToDo("ToDo3", new System.Collections.Generic.Dictionary<string, bool>()); // Create todo
            episode.updateToDo("ToDo2", new System.Collections.Generic.Dictionary<string, bool>()); // Create todo

            // Assert the Result
            Assert.AreEqual("ToDo1", episode.getToDoList()[0]);
            Assert.AreEqual("ToDo3", episode.getToDoList()[1]);
            Assert.AreEqual("ToDo2", episode.getToDoList()[2]);
        }

        /**
         * Clone
         */

        [TestMethod]
        public void Clone_cloningAnEpisode_fieldsAreTheSame()
        {
            // Arrange the Test
            Episode episode = new Episode();

            episode.updateNote("Note1", "");
            episode.updateNote("Note5", "");
            episode.updateNote("Note3", "");

            episode.updateToDo("ToDo1", new System.Collections.Generic.Dictionary<string, bool>());
            episode.updateToDo("ToDo5", new System.Collections.Generic.Dictionary<string, bool>());
            episode.updateToDo("ToDo3", new System.Collections.Generic.Dictionary<string, bool>());

            // Perform the Action (Act)
            Episode clone = (Episode) episode.Clone();

            // Assert the Result
            Assert.AreEqual(episode.getTitle(), clone.getTitle());
            Assert.AreEqual(episode.getSeason(), clone.getSeason());

            Assert.AreEqual(episode.getNoteList()[0], clone.getNoteList()[0]);
            Assert.AreEqual(episode.getNoteList()[1], clone.getNoteList()[1]);
            Assert.AreEqual(episode.getNoteList()[2], clone.getNoteList()[2]);

            Assert.AreEqual(episode.getToDoList()[0], clone.getToDoList()[0]);
            Assert.AreEqual(episode.getToDoList()[1], clone.getToDoList()[1]);
            Assert.AreEqual(episode.getToDoList()[2], clone.getToDoList()[2]);

            System.Diagnostics.Debug.Print(episode.getNoteList() + " " + clone.getNoteList());
        }

        /**
         * Title
         */
        [TestMethod]
        public void getTitle_defaultTitle_returnsUntitledEpisode()
        {
            Episode episode = new Episode();

            Assert.AreEqual("Untitled Episode", episode.getTitle());
        }

        [TestMethod]
        public void getTitle_setTitle_returnsTheNewTitle()
        {
            Episode episode = new Episode();

            episode.setTitle("New Title");

            Assert.AreEqual("New Title", episode.getTitle());
        }

        /**
         * Season
         */
        [TestMethod]
        public void getSeason_defaultSeason_returnsDefaultSeason()
        {
            Episode episode = new Episode();

            Assert.AreEqual("Default Season", episode.getSeason());
        }

        [TestMethod]
        public void getSeason_setSeason_returnsTheNewSeason()
        {
            Episode episode = new Episode();

            episode.setSeason("New Season");

            Assert.AreEqual("New Season", episode.getSeason());
        }
    }
}
