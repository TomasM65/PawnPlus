﻿using PawnPlus.Core.Forms;
using System;

namespace PawnPlus.Core.Events
{
    public class DocumentChangedEventArgs : EventArgs
    {
        public Editor Editor { get; }

        public DocumentChangedEventArgs(Editor editor)
        {
            this.Editor = editor;
        }
    }
}
