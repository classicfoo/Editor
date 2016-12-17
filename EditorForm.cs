using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Reflection;


public class EditorForm: BetterForm
{
	EditorRichTextBox rtb = new EditorRichTextBox();
	EditorStatusStrip ss = new EditorStatusStrip();
	EditorMenuStrip ms = new EditorMenuStrip();

	private string _filePath;
	public string FilePath
	{
		get
		{
			return this._filePath;
		}
		set
		{
			this._filePath = value;
			this.Text = this.GetWindowTitle();
		}
	}

	Assembly _assembly;
	Stream _iconStream;
		
	public EditorForm()
	{
		try{
		_assembly = Assembly.GetExecutingAssembly();
		_iconStream = _assembly.GetManifestResourceStream("icon.ico");
		this.Icon = new Icon(_iconStream);
		} catch (Exception ex) {
			MessageBox.Show(ex.Message);
		}
	
		string[] args = Environment.GetCommandLineArgs();
		if(args.Length > 1)
		{
		
			FilePath = args[1];
			//MessageBox.Show(FilePath);
			LoadFile(FilePath);
		}
		
		//properties
		this.Width = 700;
		this.Height = 500;
		this.CenterToScreen();
		this.Text = GetWindowTitle();
		
		//binding
		this.ss.LineNum = rtb.LineNum;

		//add controls
		this.Controls.Add(rtb);
		this.Controls.Add(ss);
		this.Controls.Add(ms);

		//EVENTS

		//richtextbox events
		rtb.KeyDown += new KeyEventHandler(Rtb_KeyDown);
		rtb.SelectionChanged += new EventHandler(Rtb_SelectionChanged);

		//menustrip events
		ToolStripMenuItem file = (ToolStripMenuItem) ms.Items[0];
		file.DropDownItems[0].Click += delegate(Object o, EventArgs e) { OpenFile(); };
		file.DropDownItems[1].Click += delegate(Object o, EventArgs e) { SaveAs(); };
		file.DropDownItems[2].Click += delegate(Object o, EventArgs e) { this.Close(); };


	}

	public void Rtb_SelectionChanged(Object sender, EventArgs e)
	{
		this.Text = GetWindowTitle();
		ss.LineNum = rtb.LineNum;
	}

	public string GetWindowTitle()
	{
		rtb.LineNum = rtb.GetLineFromCharIndex(rtb.SelectionStart) + 1;
		string filePath = FilePath;
		if(String.IsNullOrEmpty(filePath))
		{
			filePath = Directory.GetCurrentDirectory() + "\\Untitled.txt";
		}
		
		string fileName = Path.GetFileName(filePath);
		//return String.Format("Editor - {0} - Line: {1}", fileName, rtb.LineNum);
		return String.Format("Editor - {0}", fileName);

	}

	public void Rtb_KeyDown(Object sender, KeyEventArgs e)
	{

		if(e.Control && e.KeyCode == Keys.G)
		{
			GoToDialog gtd = new GoToDialog();
			if (gtd.ShowDialog() == DialogResult.OK)
			{
				int input = Convert.ToInt32(gtd.Input);
				if(input > rtb.Lines.Length)
				{
					rtb.SelectionLength = 0;
				}
				else
				{
					rtb.GoTo(input);
				}
			}
			this.Text = GetWindowTitle();
		}

		if(e.Control && e.KeyCode == Keys.S)
		{
			if(String.IsNullOrEmpty(FilePath))
			{
				SaveAs();
			}
			else
			{
				Save();
			}
		}
		
		if(e.Control && e.KeyCode == Keys.O)
		{
			OpenFile();
		}
	}
	
	public void OpenFile()
	{
		OpenFileDialog ofd = new OpenFileDialog();
		ofd.InitialDirectory = Environment.CurrentDirectory;
		ofd.Filter = "txt files (*.txt)|*.txt| cs files (*.cs) |*.cs| All files (*.*)|*.*" ;
		ofd.FilterIndex = 2;
		ofd.RestoreDirectory = false ;
		if (ofd.ShowDialog() == DialogResult.OK)
		{
			LoadFile(ofd.FileName);
		}
	}
	
	public void LoadFile(string filePath)
	{
		if (!String.IsNullOrEmpty(filePath))
		{		
			using (StreamReader reader = new StreamReader(filePath))
			{
				string txt = "";
				txt = reader.ReadToEnd();
				//reverse notepad compatibility
				txt = txt.Replace("\r\n","\n");
				rtb.Text = txt;
			}
		}
		this.FilePath = filePath;
	}
	
	public void SaveAs()
	{
		SaveFileDialog sfd = new SaveFileDialog();
		sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
		sfd.FilterIndex = 2 ;
		sfd.RestoreDirectory = true ;
		if(sfd.ShowDialog() == DialogResult.OK)
		{
			FilePath = sfd.FileName;
			Save();
		}
	}
	
	public void Save()
	{
		using (StreamWriter writer = new StreamWriter(FilePath))
		{
			//make it notepad compatitble
			string txt = rtb.Text.Replace("\n","\r\n");
			writer.WriteLine(txt);
		}
		this.Text = GetWindowTitle()  + " (Saved)";
	}
}





































