using System;

namespace Quiz
{
    public partial class PictureDlg : Gtk.Dialog
    {
        readonly string path;

        public PictureDlg(string path)
        {
            this.path = path;

            this.Build();

            this.image1.File = path;
        }
    }
}

