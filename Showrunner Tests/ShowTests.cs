using Microsoft.VisualStudio.TestTools.UnitTesting;
using Showrunner;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Showrunner_Tests
{
    [TestClass]
    public class ShowTests
    {
        /**
         * Templates
         */
        [TestMethod]
        public void getTemplates_addTemplates_returnsListOfTemplates()
        {
            Show show = new Show();

            show.addTemplate("T1", new Episode());
            show.addTemplate("T3", new Episode());
            show.addTemplate("T2", new Episode());

            Assert.AreEqual("T1", show.getTemplates()[0]);
            Assert.AreEqual("T3", show.getTemplates()[1]);
            Assert.AreEqual("T2", show.getTemplates()[2]);
        }

        [TestMethod]
        public void getTemplate_addTemplates_returnTemplateEpisode()
        {
            Show show = new Show();
            Episode e = new Episode();

            show.addTemplate("T1", e);

            Assert.AreEqual(e, show.getTemplate("T1"));
        }

        [TestMethod]
        public void getTemplate_addTemplates_returnNull()
        {
            Show show = new Show();

            Assert.AreEqual(null, show.getTemplate("T1"));
        }

        /**
         * Version ID
         */
        [TestMethod]
        public void getVersionID_newShowMade_versionIDIsTheIDFromTheUpdater()
        {
            // Setup
            Show show = new Show();

            Assert.AreEqual(Updater.getVersionID(), show.getVersionID());
        }

        /**
         * Update
         */
        /*[TestMethod]
        public void update_updateNoTemplate_templateIsCreated()
        {
            // Setup
            Show show = new Show();
            show.templates = null;

            // Act
            show.update();

            // Assert
            Assert.IsNotNull(show.templates);
            Assert.IsInstanceOfType(show.templates, typeof(Dictionary<string, Episode>));
        }*/

        [TestMethod]
        public void update_updateNoSeasons_seasonsAreSetToDefaultSeason()
        {
            // Setup
            Show show = new Show();
            Episode episode1 = new Episode();
            Episode episode2 = new Episode();

            episode1.setSeason(null);
            episode2.setSeason(null);

            // Add Episodes
            show.addEpisode(episode1);
            show.addEpisode(episode2);

            // Act
            show.update();

            // Assert
            Assert.AreEqual("Default Season", show.getEpisode(0).getSeason());
            Assert.AreEqual("Default Season", show.getEpisode(1).getSeason());
        }

        /**
         * Title
         */
        [TestMethod]
        public void setTitle_setNewTitle_getTitleReturnsNewTitle()
        {
            // Setup
            Show show = new Show();

            // Act
            show.setTitle("Title123");

            // Assert
            Assert.AreEqual("Title123", show.getTitle());
        }

        [TestMethod]
        public void getTitle_getDefaultTitle_getTitleReturnsDefaultTitle()
        {
            // Setup
            Show show = new Show();

            // Assert
            Assert.AreEqual("Untitled Show", show.getTitle());
        }

        /**
         * Episode Manipulation
         */
        // addEpisode and getEpisodes.
        [TestMethod]
        public void getEpisodes_addEpisodesAndGetEpisodes_addsEpisodesToListAndReturnsTheList()
        {
            // Setup
            Show show = new Show();

            // Act
            Episode episode1 = new Episode();
            episode1.setTitle("Title1");

            Episode episode2 = new Episode();
            episode2.setTitle("Title2");

            show.addEpisode(episode1);
            show.addEpisode(episode2);

            // Assert
            Assert.AreEqual(episode1, show.getEpisodes()[0]);
            Assert.AreEqual(episode2, show.getEpisodes()[1]);
        }

        [TestMethod]
        public void removeEpisode_removeEpisode_addEpisodeThenRemoveEpisode()
        {
            // Setup
            Show show = new Show();

            Episode episode1 = new Episode();
            episode1.setTitle("Title1");

            show.addEpisode(episode1);

            Episode episode2 = new Episode();
            episode2.setTitle("Title3");

            show.addEpisode(episode2);

            // Act
            show.removeEpisode(0);

            // Assert
            Assert.AreEqual(episode2, show.getEpisode(0));
        }

        [TestMethod]
        public void getEpisode_getEpisode_addEpisodeThenGetEpisode()
        {
            // Setup
            Show show = new Show();

            // Act
            Episode episode1 = new Episode();
            episode1.setTitle("Title1");

            Episode episode2 = new Episode();
            episode2.setTitle("Title2");

            show.addEpisode(episode1);
            show.addEpisode(episode2);

            // Assert
            Assert.AreEqual(episode1, show.getEpisode(0));
            Assert.AreEqual(episode2, show.getEpisode(1));
        }

        [TestMethod]
        public void moveEpisodeUp_addEpisodesAndMoveUp_changesOrder()
        {
            // Setup
            Show show = new Show();

            Episode episode1 = new Episode();
            episode1.setTitle("Title1");

            Episode episode2 = new Episode();
            episode2.setTitle("Title2");

            show.addEpisode(episode1);
            show.addEpisode(episode2);

            // Act
            show.moveEpisodeUp(1);

            // Assert
            Assert.AreEqual(episode2, show.getEpisode(0));
            Assert.AreEqual(episode1, show.getEpisode(1));
        }

        [TestMethod]
        public void moveEpisodeDown_addEpisodesAndMoveDown_changesOrder()
        {
            // Setup
            Show show = new Show();

            Episode episode1 = new Episode();
            episode1.setTitle("Title1");

            Episode episode2 = new Episode();
            episode2.setTitle("Title2");

            show.addEpisode(episode1);
            show.addEpisode(episode2);

            // Act
            show.moveEpisodeDown(0);

            // Assert
            Assert.AreEqual(episode2, show.getEpisode(0));
            Assert.AreEqual(episode1, show.getEpisode(1));
        }

        /**
         * Note Manipulation
         */
        [TestMethod]
        public void updateNote_createNewNote_newNoteIsCreated()
        {
            // Setup
            Show show = new Show();

            // Act
            show.updateNote("newNote", "asdf123");

            // Assert
            Assert.AreEqual("asdf123", show.getNote("newNote"));
        }

        [TestMethod]
        public void updateNote_updateNote_noteIsUpdated()
        {
            // Setup
            Show show = new Show();
            show.updateNote("newNote", "asdf123");

            // Act
            show.updateNote("newNote", "qwerty456");

            // Assert
            Assert.AreEqual("qwerty456", show.getNote("newNote"));
        }

        [TestMethod]
        public void removeNote_removeNote_noteIsRemoved()
        {
            // Setup
            Show show = new Show();
            show.updateNote("newNote", "asdf123");

            // Act
            show.removeNote("newNote");

            // Assert
            Assert.IsFalse(show.getNotes().Contains("newNote"));
        }

        [TestMethod]
        public void getNotes_getListOfNotes_returnsListOfNotes()
        {
            // Setup
            Show show = new Show();
            show.updateNote("newNote", "asdf123");
            show.updateNote("newNote2", "qwerty456");

            // Assert
            Assert.AreEqual("newNote", show.getNotes()[0]);
            Assert.AreEqual("newNote2", show.getNotes()[1]);
        }

        /**
         * Note Folders
         */
        [TestMethod]
        public void getNotesInFolder_addNotesAndGetFolder_returnsListOfNoteNames()
        {
            // Setup
            Show show = new Show();

            show.updateNote("Note1", "n");
            show.updateNote("Note3", "n2");
            show.updateNote("Note2", "n3");
            show.updateNote("Note5", "n255");
            show.updateNote("Note4", "n344");

            // Act
            show.addToFolder("Note 5", "Notes");
            show.addToFolder("Note 5", "Notes"); // Should cancel duplicates.
            show.addToFolder("Note 4", "Notes");

            // Assert
            Assert.AreEqual("Note 5", show.getNotesInFolder("Notes")[0]);
            Assert.AreEqual("Note 4", show.getNotesInFolder("Notes")[1]);
        }

        [TestMethod]
        public void addToFolder_removeNoteAndGetFolder_returnsListOfNoteNamesMinusRemovedNote()
        {
            // Setup
            Show show = new Show();

            show.updateNote("Note1", "n");
            show.updateNote("Note3", "n2");
            show.updateNote("Note2", "n3");
            show.updateNote("Note5", "n255");
            show.updateNote("Note4", "n344");

            show.addToFolder("Note 5", "Notes");
            show.addToFolder("Note 4", "Notes");

            show.addToFolder("Note 1", "Notes 3");

            // Act
            show.removeFromFolder("Note 5", "Notes");
            show.removeFromFolder("Note 1", "Notes 3");

            // Assert
            Assert.AreEqual("Note 4", show.getNotesInFolder("Notes")[0]);
            Assert.AreEqual(1, show.getNotesInFolder("Notes").Length);

            Assert.IsTrue(show.getFolders().Length == 1); // Notes 3 doesn't exist.
        }

        [TestMethod]
        public void getFolders_addNotesAndGetFolders_returnsListOfFolders()
        {
            // Setup
            Show show = new Show();

            show.updateNote("Note1", "n");
            show.updateNote("Note3", "n2");
            show.updateNote("Note2", "n3");
            show.updateNote("Note5", "n255");
            show.updateNote("Note4", "n344");

            show.addToFolder("Note 5", "Notes");
            show.addToFolder("Note 4", "Notes 2");

            // Assert
            Assert.AreEqual("Notes", show.getFolders()[0]);
            Assert.AreEqual("Notes 2", show.getFolders()[1]);
        }
    }
}
