﻿using System;

namespace RemoteNotes.Service.Domain.DTO
{
    public class NoteDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public AccountDTO Account { get; set; }

        public DateTime PublishTime { get; set; }

        public DateTime ModifyTime { get; set; }

        public byte[] Image { get; set; }

        public string Text { get; set; }
    }
}
