using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RemoteNotes.Service.Client.UAT.Helper;
using RemoteNotes.Service.Domain;
using RemoteNotes.Service.Domain.DTO;
using TechTalk.SpecFlow;
using NUnit.Framework;
using RemoteNotes.Service.Client.UAT.Enter;
namespace RemoteNote.Service.Client.UAT.Testers
{
    [Binding]
    public class NotesTester
    {
        private List<NoteDTO> notes;
        private NoteDTO newNote;
        [Then(@"I see my notes")]
        public void ThenISeeMyNotes()
        {
            var holdUserInfo = SystemEnterTester.userInfo;
            notes = TestingContext.GetFrontServiceClient().GetNotes(holdUserInfo.Account.Id);
            Assert.True(notes.Count>0);
        }
        [When(@"I try to change one of my notes")]
        public void TryToChangeOneNote()
        {
            newNote = new NoteDTO();
            newNote.Id = 0;
            newNote.Text = "changedText";
            newNote.Title = "changedTitle";
            newNote.PublishTime = DateTime.Now;
        }
        [Then(@"I see te result that my note is changed")]
        public void MyNoteIsChanged()
        {
            try
            {
                var holdUserInfo = SystemEnterTester.userInfo;
                TestingContext.GetFrontServiceClient().EditNote(newNote);
            }
            catch (Exception ex) 
            {
                TestingContext.LastException = ex;
            }
            Assert.That(TestingContext.LastException == null);
        }
        [When(@"I try to create a new note")]
        public void ICreateNewNote() 
        {
        
        }
    }
}
