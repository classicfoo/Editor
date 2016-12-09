using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

public class GoToForm: Form
{
	TextBox textBox = new TextBox();
	Form1 form1;

	public GoToForm(Form1 form1)
	{
		this.Text = "GoTo";
		this.form1 = form1;
		this.Width = 300;
		this.Height = 100;
		textBox.Dock = DockStyle.Fill;
		Controls.Add(textBox);
		textBox.KeyDown += new KeyEventHandler(textBox_KeyDown);
		Show();
	}

	public void textBox_KeyDown(Object sender, KeyEventArgs e)
	{
		if(e.KeyCode == Keys.Enter)
		{
			form1.GoTo(Convert.ToInt32(textBox.Text));
			this.Close();
		}
	}


	
}






