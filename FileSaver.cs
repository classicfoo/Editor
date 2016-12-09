using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

public class FileSaver : Form
{
	TextBox textBox = new TextBox();
	Form1 form1;

	public FileSaver(Form1 form1)
	{
		this.form1 = form1;
		this.Width = 300;
		this.Height = 100;
		this.CenterToScreen();
		form1.FileName = "Untitled.txt";
		textBox.Dock = DockStyle.Fill;
		Controls.Add(textBox);
		textBox.KeyDown += new KeyEventHandler(textBox_KeyDown);
		Show();
	}

	public void textBox_KeyDown(Object sender, KeyEventArgs e)
	{
		if(e.KeyCode == Keys.Enter)
		{
			form1.FileName = textBox.Text;
			form1.WriteFile();
			this.Close();
		}
	}


	
}
