using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;


public class EditorRichTextBox : RichTextBox
{
	public int LineNum;
	public int LastFindLocation;
	public string LastFindTarget;
		
	public EditorRichTextBox()
	{
	
		this.Font = new Font("Courier New",9);
		this.Dock = DockStyle.Fill;
		this.AcceptsTab = true;
		this.WordWrap = false;
		this.BorderStyle = BorderStyle.None;
		this.LastFindLocation = 0;
		this.LastFindTarget = "";
		this.SelectionIndent += 5;
		this.HideSelection = false;
		this.ScrollBars =  RichTextBoxScrollBars.ForcedBoth;
		
	}

	public void FindString(String target)
	{
		int result = this.Find(target, LastFindLocation, RichTextBoxFinds.NoHighlight);

		if(result == -1) 
		{
			string message;
			if(target.Equals(this.LastFindTarget))
			{				
				message = string.Format("End of search: \"{0}\"", target);
			}
			else
			{
				message = string.Format("Cannot find: \"{0}\"", target);
			}

			MessageBox.Show(message);
			this.LastFindLocation = 0;
			this.LastFindTarget = target;
		}
		else
		{
			this.Select(result, target.Length);
			this.LastFindLocation = result + target.Length;
			this.LastFindTarget = target;
		}
	}
	
	public void GoTo(int newLineNum)
	{
		int index = this.GetFirstCharIndexFromLine(newLineNum - 1);
		this.SelectionStart = index;
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

	public string[] SelectedLines()
	{
		return this.SelectedText.Split(new String[] {"\n"}, StringSplitOptions.RemoveEmptyEntries);
	}

	public int SelectedLineCount()
	{
		return this.SelectedText.Split(new String[] {"\n"}, StringSplitOptions.RemoveEmptyEntries).Length;
	}

/*
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

*/
	
}



