using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Threading;

public class FileOpener : Form
{
	ListBox listBox = new ListBox();
	Form1 form1;

	public FileOpener(Form1 form1)
	{
		this.form1 = form1;
		listBox.Dock = DockStyle.Fill;
		Controls.Add(listBox);
		GetFiles();
		listBox.KeyDown += new KeyEventHandler(listBox_KeyDown);
		Show();
	}

	public void listBox_KeyDown(Object sender, KeyEventArgs e)
	{
		if(e.KeyCode == Keys.Enter)
		{
			form1.FileName = listBox.SelectedItem.ToString();
			form1.Reload();
			this.Close();
		}
	}

	public void GetFiles()
	{
		foreach(var f in Directory.GetFiles("."))
		{
			listBox.Items.Add(Path.GetFileName(f));
		}
	}
	
}