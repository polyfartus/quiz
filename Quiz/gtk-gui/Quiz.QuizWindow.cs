
// This file has been generated by the GUI designer. Do not modify.
namespace Quiz
{
	public partial class QuizWindow
	{
		private global::Gtk.VBox vbox1;
		
		private global::Quiz.QuizWidget quizwidget2;
		
		private global::Gtk.HButtonBox hbuttonbox4;
		
		private global::Gtk.Button buttonClose;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Quiz.QuizWindow
			this.Name = "Quiz.QuizWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("QuizWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			// Container child Quiz.QuizWindow.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.quizwidget2 = new global::Quiz.QuizWidget ();
			this.quizwidget2.Events = ((global::Gdk.EventMask)(256));
			this.quizwidget2.Name = "quizwidget2";
			this.vbox1.Add (this.quizwidget2);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.quizwidget2]));
			w1.Position = 0;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbuttonbox4 = new global::Gtk.HButtonBox ();
			this.hbuttonbox4.Name = "hbuttonbox4";
			this.hbuttonbox4.BorderWidth = ((uint)(2));
			this.hbuttonbox4.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child hbuttonbox4.Gtk.ButtonBox+ButtonBoxChild
			this.buttonClose = new global::Gtk.Button ();
			this.buttonClose.CanFocus = true;
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.UseUnderline = true;
			this.buttonClose.Label = global::Mono.Unix.Catalog.GetString ("Close");
			this.hbuttonbox4.Add (this.buttonClose);
			global::Gtk.ButtonBox.ButtonBoxChild w2 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox4 [this.buttonClose]));
			w2.Expand = false;
			w2.Fill = false;
			this.vbox1.Add (this.hbuttonbox4);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbuttonbox4]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			w3.Padding = ((uint)(5));
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 585;
			this.DefaultHeight = 431;
			this.Show ();
			this.buttonClose.Clicked += new global::System.EventHandler (this.OnButtonCloseClicked);
		}
	}
}
