using System;
using System.Windows.Forms;
using System.Drawing;

public class BetterForm : Form
{	
	public BetterForm()
	{
		this.KeyPreview = true;
		this.KeyDown += new KeyEventHandler(form_KeyDown);
	}
	
	public void form_KeyDown(Object sender, KeyEventArgs e)
	{
		//Escape to exit
		if (e.KeyCode == Keys.Escape)
		{
			this.Close();
		}
	}
}

