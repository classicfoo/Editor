using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

public class EditorMenuStrip : MenuStrip
{
	public EditorMenuStrip()
	{
		ToolStripMenuItem file = new ToolStripMenuItem();
		file.Name = "File";
		file.Text = "File";
		this.Items.Add(file);
		
			ToolStripMenuItem open = new ToolStripMenuItem();
			open.Name = "Open";
			open.Text = "Open...";
			file.DropDownItems.Add(open);
		
			ToolStripMenuItem save= new ToolStripMenuItem();
			save.Name = "Save";
			save.Text = "Save...";
			file.DropDownItems.Add(save);
			
			ToolStripMenuItem close= new ToolStripMenuItem();
			close.Name = "Close";
			close.Text = "Close";
			file.DropDownItems.Add(close);
		
		ToolStripMenuItem edit = new ToolStripMenuItem();
		edit.Name = "Edit";
		edit.Text = "Edit";
		this.Items.Add(edit);
		
			ToolStripMenuItem preferences = new ToolStripMenuItem();
			preferences.Name = "Preferences";
			preferences.Text = "Preferences";
			edit.DropDownItems.Add(preferences);
		
		ToolStripMenuItem macro = new ToolStripMenuItem();
		macro.Name = "Macro";
		macro.Text = "Macro";
		this.Items.Add(macro);
		
		ToolStripMenuItem help = new ToolStripMenuItem();
		help.Name = "Help";
		help.Text = "Help";
		this.Items.Add(help);
		
			ToolStripMenuItem about = new ToolStripMenuItem();
			about.Name = "About";
			about.Text = "About";
			help.DropDownItems.Add(about);
		
		this.BackColor = Color.White;
	}
}