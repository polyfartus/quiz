
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.VBox vbox1;
	
	private global::Quiz.FilesWidget fileswidget2;
	
	private global::Gtk.HBox hbox1;
	
	private global::Gtk.HButtonBox hbuttonbox3;
	
	private global::Gtk.Button buttonReset;
	
	private global::Gtk.TextView textview1;
	
	private global::Gtk.HButtonBox hbuttonbox2;
	
	private global::Gtk.Button buttonTake;
	
	private global::Gtk.Button buttonClose;

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
		this.hbuttonbox3 = new global::Gtk.HButtonBox ();
		this.hbuttonbox3.WidthRequest = 20;
		this.hbuttonbox3.Name = "hbuttonbox3";
		this.hbuttonbox3.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(3));
		// Container child hbuttonbox3.Gtk.ButtonBox+ButtonBoxChild
		this.buttonReset = new global::Gtk.Button ();
		this.buttonReset.CanFocus = true;
		this.buttonReset.Name = "buttonReset";
		this.buttonReset.UseUnderline = true;
		this.buttonReset.Label = global::Mono.Unix.Catalog.GetString ("Reset");
		this.hbuttonbox3.Add (this.buttonReset);
		global::Gtk.ButtonBox.ButtonBoxChild w2 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox3 [this.buttonReset]));
		w2.Expand = false;
		w2.Fill = false;
		this.hbox1.Add (this.hbuttonbox3);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.hbuttonbox3]));
		w3.Position = 0;
		// Container child hbox1.Gtk.Box+BoxChild
		this.textview1 = new global::Gtk.TextView ();
		this.textview1.CanFocus = true;
		this.textview1.Name = "textview1";
		this.textview1.Editable = false;
		this.textview1.CursorVisible = false;
		this.hbox1.Add (this.textview1);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.textview1]));
		w4.Position = 1;
		// Container child hbox1.Gtk.Box+BoxChild
		this.hbuttonbox2 = new global::Gtk.HButtonBox ();
		this.hbuttonbox2.Name = "hbuttonbox2";
		// Container child hbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
		this.buttonTake = new global::Gtk.Button ();
		this.buttonTake.CanFocus = true;
		this.buttonTake.Name = "buttonTake";
		this.buttonTake.UseUnderline = true;
		this.buttonTake.Label = global::Mono.Unix.Catalog.GetString ("Take Quiz");
		this.hbuttonbox2.Add (this.buttonTake);
		global::Gtk.ButtonBox.ButtonBoxChild w5 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2 [this.buttonTake]));
		w5.Expand = false;
		w5.Fill = false;
		// Container child hbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
		this.buttonClose = new global::Gtk.Button ();
		this.buttonClose.CanFocus = true;
		this.buttonClose.Name = "buttonClose";
		this.buttonClose.UseUnderline = true;
		this.buttonClose.Label = global::Mono.Unix.Catalog.GetString ("Close");
		this.hbuttonbox2.Add (this.buttonClose);
		global::Gtk.ButtonBox.ButtonBoxChild w6 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2 [this.buttonClose]));
		w6.Position = 1;
		w6.Expand = false;
		w6.Fill = false;
		this.hbox1.Add (this.hbuttonbox2);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.hbuttonbox2]));
		w7.Position = 3;
		w7.Expand = false;
		this.vbox1.Add (this.hbox1);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
		w8.Position = 1;
		w8.Expand = false;
		w8.Fill = false;
		w8.Padding = ((uint)(10));
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 480;
		this.DefaultHeight = 399;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.buttonReset.Clicked += new global::System.EventHandler (this.OnButtonResetClicked);
		this.buttonTake.Clicked += new global::System.EventHandler (this.OnButtonTakeClicked);
		this.buttonClose.Clicked += new global::System.EventHandler (this.OnButtonCloseClicked);
	}
}
