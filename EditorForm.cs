using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

public class Form1: Form
{
	RichTextBox rtb = new RichTextBox();
	public string FileName {get;set;}
	public int LineNum {get;set;}

	public Form1()
	{
		string[] args = Environment.GetCommandLineArgs();
		if(args.Length > 1)
		{
			FileName = Path.GetFileName(args[1]);
		}
		this.Text = this.GetWindowTitle();
		this.Width = 700;
		this.Height = 500;
		this.CenterToScreen();
		rtb.Dock = DockStyle.Fill;
		rtb.AcceptsTab = true;
		rtb.WordWrap = false;
		rtb.Font = new Font("Consolas", 11);
		rtb.BorderStyle = BorderStyle.None;
		this.Controls.Add(rtb);
		rtb.KeyDown += new KeyEventHandler(Rtb_KeyDown);
		rtb.SelectionChanged += new EventHandler(Rtb_SelectionChanged);
		Reload();
	}

	public void Reload()
	{
		if (FileName != null)
		{		
			using (StreamReader reader = new StreamReader(FileName))
			{
				//MessageBox.Show("Loaded!");
					
				//reverse notepad compatibility
				var txt = reader.ReadToEnd().Replace("\r\n","\n");
	
				rtb.Text = txt;

			}
		}
	}
	public void WriteFile()
	{
		using (StreamWriter writer = new StreamWriter(FileName))
		{
			//make it notepad compatitble
			var txt = rtb.Text.Replace("\n","\r\n");
			writer.WriteLine(txt);
			MessageBox.Show("Saved!");
		}
	}

	public void Rtb_SelectionChanged(Object sender, EventArgs e)
	{
		this.Text = GetWindowTitle();
	}

	public string GetWindowTitle()
	{
		LineNum = rtb.GetLineFromCharIndex(rtb.SelectionStart) + 1;
		return String.Format("Editor - {0} - Line: {1}", FileName, LineNum);
	}

	public void GoTo(int LineNum)
	{
		var index = rtb.GetFirstCharIndexFromLine(LineNum - 1);
		rtb.SelectionStart = index;
	}

	public void Rtb_KeyDown(Object sender, KeyEventArgs e)
	{
		if(e.Control && e.KeyCode == Keys.G)
		{
			new GoToForm(this);
		}

		if(e.Control && e.KeyCode == Keys.S)
		{
			if(FileName == null)
			{
				new FileSaver(this);
			}
			else 
			{
				WriteFile();
			}
		}
		else if(e.Control && e.KeyCode == Keys.L)
		{
			new FileOpener(this);
		}

		else if (e.KeyCode == Keys.Escape)
		{
			this.Close();
		}
	}
}





























