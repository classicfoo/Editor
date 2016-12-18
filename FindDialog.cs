using System;
using System.Windows.Forms;
using System.Drawing;


public class FindDialog : PromptDialog
{
	public EditorForm ef;

	public FindDialog(EditorForm ef)
	{
		this.Text = "Find";
		this.ef = ef;

		label.Text = "Find what:";
		btn_ok.Text = "Find:";

	}

	public override void btn_ok_click(Object sender, EventArgs e)
	{
		Input = tb.Text;
		ef.FindString(Input);
	}
	
}

