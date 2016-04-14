using System;

namespace Quiz
{
    public partial class PictureDlg : Gtk.Dialog
    {
        public PictureDlg(string path)
        {
            this.Build();

            this.image201.File = path;
        }
    }
}

