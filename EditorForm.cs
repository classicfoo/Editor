using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

public class EditorForm: BetterForm
{
	EditorRichTextBox rtb = new EditorRichTextBox();
	EditorStatusStrip statusStrip2 = new EditorStatusStrip();
	
	private string _fileName;
	public string FileName
    {
		get
		{
			return this._fileName;
		}
		set
		{
			this._fileName = value;
			this.Text = this.GetWindowTitle();
		}
    }
	
	public EditorForm()
	{
		string[] args = Environment.GetCommandLineArgs();
		if(args.Length > 1)
		{
			FileName = Path.GetFileName(args[1]);
			LoadFile(FileName);
		}
		
		this.Width = 700;
		this.Height = 500;
		this.CenterToScreen();
		this.Controls.Add(rtb);
		this.Text = GetWindowTitle();
		
		rtb.KeyDown += new KeyEventHandler(Rtb_KeyDown);
		rtb.SelectionChanged += new EventHandler(Rtb_SelectionChanged);
	}
	
	public void Rtb_SelectionChanged(Object sender, EventArgs e)
	{
		this.Text = GetWindowTitle();
	}

	public string GetWindowTitle()
	{
		rtb.LineNum = rtb.GetLineFromCharIndex(rtb.SelectionStart) + 1;
		string fileName = FileName;
		if(String.IsNullOrEmpty(fileName))
		{
			fileName = Directory.GetCurrentDirectory() + "\\Untitled.txt";
		}
		return String.Format("Editor - {0} - Line: {1}", fileName, rtb.LineNum);
	}

	public void Rtb_KeyDown(Object sender, KeyEventArgs e)
	{

		if(e.Control && e.KeyCode == Keys.G)
		{
			GoToDialog gtd = new GoToDialog();
			if (gtd.ShowDialog() == DialogResult.OK)
			{
				int input = Convert.ToInt32(gtd.Input);
				rtb.GoTo(input);
			}
		}

		if(e.Control && e.KeyCode == Keys.S)
		{
			if(String.IsNullOrEmpty(FileName))
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
		ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*" ;
		ofd.FilterIndex = 2 ;
		ofd.RestoreDirectory = false ;
		if (ofd.ShowDialog() == DialogResult.OK)
		{
			LoadFile(ofd.FileName);
		}
	}
	
	public void LoadFile(string fileName)
	{
		if (!String.IsNullOrEmpty(fileName))
		{		
			using (StreamReader reader = new StreamReader(fileName))
			{
				string txt = "";
				txt = reader.ReadToEnd();
				//reverse notepad compatibility
				txt = txt.Replace("\r\n","\n");
				rtb.Text = txt;
			}
		}
		this.FileName = fileName;
	}
	
	public void SaveAs()
	{
		SaveFileDialog sfd = new SaveFileDialog();
		sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"  ;
		sfd.FilterIndex = 2 ;
		sfd.RestoreDirectory = true ;
		if(sfd.ShowDialog() == DialogResult.OK)
		{
			FileName = sfd.FileName;
			Save();
		}
	}
	
	public void Save()
	{
		using (StreamWriter writer = new StreamWriter(FileName))
		{
			//make it notepad compatitble
			string txt = rtb.Text.Replace("\n","\r\n");
			writer.WriteLine(txt);
		}			
	}
}





























