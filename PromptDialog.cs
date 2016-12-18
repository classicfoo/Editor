using System;
using System.Windows.Forms;
using System.Drawing;


public class PromptDialog : BetterForm
{
	public string Input = "";
	
	public Label label = new Label();
	public TextBox tb = new TextBox();
	public Button btn_ok = new Button();
	public Button btn_cancel = new Button();
	
	public PromptDialog()
	{
			
		//this
		this.Text = "Prompt";
		this.Width = 350;
		this.Height = 150;
		this.AcceptButton = btn_ok;
		this.CenterToScreen();
		
		//LABEL
		label.Text = "Input: ";
		label.Location = new Point(label.Location.X + 10, label.Location.Y + 10);
	
		//TEXTBOX
		tb.Width = tb.Width + 200;
		tb.Location = new Point(label.Location.X, label.Location.Y + label.Height);
		
		//OK BUTTON
		btn_ok.Text = "OK";
		btn_ok.DialogResult = DialogResult.OK;
		btn_ok.Location = new Point(tb.Location.X, tb.Location.Y + 10 + tb.Height);
		
		//CANCEL BUTTON
		btn_cancel.Text = "Cancel";
		btn_cancel.DialogResult = DialogResult.Cancel;
		int width = tb.Location.X + btn_ok.Width + 10;
		int height = tb.Location.Y + 10 + tb.Height;
		btn_cancel.Location = new Point(width, height);

		//Add controls
		this.Controls.Add(label);
		this.Controls.Add(tb);
		this.Controls.Add(btn_ok);
		this.Controls.Add(btn_cancel);

		//EVENTS
		btn_cancel.Click += new EventHandler(btn_cancel_click);
		btn_ok.Click += new EventHandler(btn_ok_click);

	}
	
	public virtual void btn_cancel_click(Object sender, EventArgs e)
	{
		this.Close();
	}
	
	public virtual void btn_ok_click(Object sender, EventArgs e)
	{
		Input = tb.Text;
		this.Close();
	}
	
}

