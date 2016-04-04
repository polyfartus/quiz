using System;
using Gtk;

namespace Quiz
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            Application.Init ();
            var win = new MainWindow ();

            win.Show ();
            Application.Run ();
        }
    }
}
