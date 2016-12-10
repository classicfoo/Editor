using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;

public class EditorRichTextBox : RichTextBox
{
	public int LineNum;
		
	public EditorRichTextBox()
	{
	
		this.Font = new Font("Courier New",10);
		this.Dock = DockStyle.Fill;
		this.AcceptsTab = true;
		this.WordWrap = false;
		this.BorderStyle = BorderStyle.None;
		
	}
	
	public void GoTo(int newLineNum)
	{
		int index = this.GetFirstCharIndexFromLine(newLineNum - 1);
		this.SelectionStart = index;
		HighLightLine();
	}
	
	public void HighLightLine()
	{
		int length = LastIndexOfLine() - FirstIndexOfLine();
		this.Select(FirstIndexOfLine(), length);
	}
	
	public int LastIndexOfLine()
	{
		return this.Find("\r",SelectionStart,RichTextBoxFinds.NoHighlight);
	}
	
	public int FirstIndexOfLine()
	{
		return this.GetFirstCharIndexFromLine(this.GetLineFromCharIndex(SelectionStart));
	}
	
	public void BeginUpdate() 
	{
        SendMessage(this.Handle, WM_SETREDRAW, (IntPtr)0, IntPtr.Zero);
    }
	
    public void EndUpdate()
	{
        SendMessage(this.Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero); 
        this.Invalidate();
    }
	
    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    private const int WM_SETREDRAW = 0x0b;
	
}
