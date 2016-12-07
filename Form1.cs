using System;
using System.Windows.Forms;
using System.IO;
using System.Threading;

public class Form1: Form
{
	RichTextBox rtb = new RichTextBox();
	public string FileName {get;set;}

	public Form1()
	{
		string[] args = Environment.GetCommandLineArgs();
		if(args.Length > 1)
		{
			FileName = Path.GetFileName(args[1]);
		}
		this.Text = "Editor";
		this.Width = 700;
		this.Height = 700;
		rtb.Dock = DockStyle.Fill;
		rtb.AcceptsTab = true;
		rtb.WordWrap = false;
		this.Controls.Add(rtb);
		rtb.KeyDown += new KeyEventHandler(Rtb_KeyDown);
		Reload();
	}

	public void Reload()
	{
		if (FileName != null)
		{		
			using (StreamReader reader = new StreamReader(FileName))
			{
				MessageBox.Show(FileName);
					
				//reverse notepad compatibility
				var txt = reader.ReadToEnd().Replace("\r\n","\n");
	
				rtb.Text = txt;

			}
		}
	}

	public void Rtb_KeyDown(Object sender, KeyEventArgs e)
	{
		if(e.Control && e.KeyCode == Keys.S)
		{
			using (StreamWriter writer = new StreamWriter(FileName))
			{
				//make it notepad compatitble
				var txt = rtb.Text.Replace("\n","\r\n");

				writer.WriteLine(txt);

				MessageBox.Show("Saved!");
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








