using System;
using System.Windows.Forms;
using System.IO;

public class Program
{
	public static void Main(string[] args)
	{
		try{
			Application.Run(new Form1()); 
		}
		catch(Exception ex) {
			MessageBox.Show(ex.Message);
		}
	}
}



