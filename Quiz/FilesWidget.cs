using System;
using System.Collections.Generic;
using System.IO;
using Gtk;
using Pango;

namespace Quiz
{
    public class FileEventArgs : EventArgs 
    {
        public string Path { get; set; }
    }

    [System.ComponentModel.ToolboxItem(true)]
    public partial class FilesWidget : Gtk.Bin
    {
        public event EventHandler<FileEventArgs> Selected;

        TreeStore store;

        public FilesWidget()
        {
            this.Build();

            this.treeview1.CanFocus = false;
            {
                var column = new Gtk.TreeViewColumn ();
                column.Title = "Name";

                var cell = new CellRendererText();
                column.PackStart(cell, true);
                column.AddAttribute(cell, "text", 0);
                this.treeview1.AppendColumn(column);
            }

            this.treeview1.HeadersVisible = true;

            store = new Gtk.TreeStore (typeof(string));

            this.treeview1.Model = store;

            this.treeview1.ModifyFont(FontDescription.FromString("Courier 16"));

            DisplayRoot();

            this.treeview1.Selection.Changed += (o, args) => 
                {
                    if (this.Selected != null)
                    {
                        var args2 = new FileEventArgs();

                        args2.Path = this.SelectedPath;

                        Selected(this, args2);
                    }
                };
        }

        public string SelectedPath
        {
            get
            {
                TreeIter iter;

                if (this.treeview1.Selection.GetSelected(out iter))
                {
                    var value = this.store.GetValue(iter, 0);

                    return (string)value;
                }

                return null;
            }
        }

        public void DisplayRoot()
        {
            DisplayFolder(null, "files");

            this.treeview1.ExpandAll();
        }

        public void DisplayFolder(
            TreeIter? parent,
            string name)
        {
            TreeIter? iter = null;

            if (parent != null)
            {
                //iter = store.AppendValues(parent.Value, name);
            }
            else
            {
                //iter = store.AppendValues(name);
            }

            var files = Directory.EnumerateFiles(name);

            DisplayFiles(iter, files);

            var folders = Directory.EnumerateDirectories(name);

            DisplayFolders(parent, folders);
        }

        public void DisplayFolders(
            TreeIter? parent,
            IEnumerable<string> folders)
        {
            foreach(var folder in folders)
            {
                DisplayFolder(parent, folder);
            }
        }

        public void DisplayFiles(
            TreeIter? parent,
            IEnumerable<string> files)
        {
            foreach(var file in files)
            {
                if (!file.EndsWith("xml"))
                {
                    continue;
                }

                if (parent != null)
                {
                    store.AppendValues(parent.Value, file);
                }
                else
                {
                    store.AppendValues(file);
                }
            }
        }

        protected void OnTreeview1ButtonPressEvent(object o, ButtonPressEventArgs args)
        {
        }
    }
}

