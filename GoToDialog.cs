using System;
using System.Windows.Forms;
using System.Drawing;

public class GoToDialog : PromptDialog
{
	public GoToDialog()
	{
		
		tb.Width = 160;
		
		this.Text = "Go To Line";		
		this.Width = tb.Location.X + tb.Width + 20;
		this.Height = btn_ok.Location.Y + btn_ok.Height + 40;
		this.label.Text = "Line Number:";
		this.FormBorderStyle = FormBorderStyle.FixedSingle;

		
	}
}
