
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.VBox vbox1;
	private global::Quiz.FilesWidget fileswidget2;
	private global::Gtk.HBox hbox1;
	private global::Gtk.Button buttonTake;
	
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("Quiz");
		this.Icon = global::Stetic.IconLoader.LoadIcon (this, "gtk-edit", global::Gtk.IconSize.Menu);
		this.WindowPosition = ((global::Gtk.WindowPosition)(1));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.fileswidget2 = new global::Quiz.FilesWidget ();
		this.fileswidget2.Events = ((global::Gdk.EventMask)(256));
		this.fileswidget2.Name = "fileswidget2";
		this.vbox1.Add (this.fileswidget2);
		global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.fileswidget2]));
		w1.Position = 0;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		this.hbox1.BorderWidth = ((uint)(5));
		// Container child hbox1.Gtk.Box+BoxChild
		this.buttonTake = new global::Gtk.Button ();
		this.buttonTake.CanFocus = true;
		this.buttonTake.Name = "buttonTake";
		this.buttonTake.UseUnderline = true;
		this.buttonTake.Label = global::Mono.Unix.Catalog.GetString ("Take Quiz");
		this.hbox1.Add (this.buttonTake);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonTake]));
		w2.Position = 2;
		w2.Expand = false;
		w2.Fill = false;
		this.vbox1.Add (this.hbox1);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
		w3.Position = 1;
		w3.Expand = false;
		w3.Fill = false;
		w3.Padding = ((uint)(10));
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 441;
		this.DefaultHeight = 399;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.buttonTake.Clicked += new global::System.EventHandler (this.OnButtonTakeClicked);
	}
}
