using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

public class EditorStatusStrip : StatusStrip
{
	public ToolStripStatusLabel tssl_LineNum = new ToolStripStatusLabel();
	
	int _lineNum;
	public int LineNum
	{
		get
		{
			return _lineNum;
		}
		set
		{
			_lineNum = value;
			tssl_LineNum.Text = String.Format("Line: {0}",value.ToString());
		}
	}
	
	public EditorStatusStrip()
	{
		this.Items.Add(tssl_LineNum);
		this.BackColor = Color.White;
	}
	
	
}

