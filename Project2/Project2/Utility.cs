//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 2 - CreditCardList
//	File Name:		Utility.cs
//	Description:	Utility Class for Project 2	
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Justin Adams, adamsjl3@etsu.edu, Undergrad CS, East Tennessee State University
//	Created:		Thursday, September 19, 2017
//	Copyright:		Justin Adams, 2017
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
	/// <summary>
	/// Utility Class for helping programs with common utilities
	/// </summary>
	class Utility
	{
		#region Class methods
		/// <summary>
		/// Presses any key to continue program.
		/// </summary>
		public static void PressAnyKey ( )
		{
			Console.WriteLine ("Press a key to continue");
			Console.ReadLine ( );
		}//End PressAnyKey ( )

		 /// <summary>
		 /// Welcomes the message.
		 /// </summary>
		 /// <param name="info">The information.</param>
		 /// <param name="title">The title.</param>
		public static void Message (string info, string title)
		{
			MessageBox.Show (info, title);
		}//End WelcomeMessage (string,string)

		 /// <summary>
		 /// Menus the specified menu.
		 /// </summary>
		 /// <param name="menu">The menu.</param>
		 /// <returns>User selection from menu items</returns>
		 /// <exception cref="Exception">Invalid Selection</exception>
		public static int Menu (string [ ] menu)
		{
			int Selection = -1;
			Console.Clear ( );
			Console.WriteLine ("Please make a selection");
			for (int i = 0 ; i < menu.Length ; i++)
			{
				Console.WriteLine ((i + 1) + ". " + menu [i]);
			}//end for loop
			try
			{
				Selection = Int32.Parse (Console.ReadLine ( ));
			}
			catch (Exception e)
			{
				Selection = -1;
				throw new Exception ("Invalid Selection");
			}
			return Selection;
		}//End Menu (string[])

		 /// <summary>
		 /// Gets the data.
		 /// </summary>
		 /// <param name="variable">The variable.</param>
		 /// <returns>Value from console</returns>
		public static string GetData (string variable)
		{
			Console.Clear ( );
			Console.WriteLine ("What is the " + variable);
			return Console.ReadLine ( );
		}//End GetData (string)
		#endregion
		/*
		/// <summary>
		/// Reads the file.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <param name="delim">The delimiter.</param>
		/// <returns>
		/// Stream of data from file
		/// </returns>
		public static string [ ] ReadFile (string path)
		{
			List<string> Data = new List<string> ( );
			string TempHolder = "";
			int counter = 0;

			// Read the file line by line.
			System.IO.StreamReader file =
			   new System.IO.StreamReader (path);
			while ((TempHolder = file.ReadLine ( )) != null)
			{
				Data.Add (file.ReadLine ( ));
				counter++;
			}//End while loop
			file.Close ( );
			return Data.ToArray ( );
		}//ReadFile (string, string)*/
		/*
		/// <summary>
		/// Display menus with specified menu items.
		/// </summary>
		/// <param name="menuItems">The menu items.</param>
		/// <param name="fore">The fore.</param>
		/// <param name="back">The back.</param>
		/// <returns>Selection from menu</returns>
		public static int DisplayMenu (string[] menuItems, ConsoleColor fore, ConsoleColor back)
		{
			int Selection = 0;	//Selection from user
			while (true)
			{
				for (int i = 0 ; i < menuItems.Length ; i++)
				{
					if (Selection == i)
					{
						Console.BackgroundColor = back;
						Console.ForegroundColor = fore;
						Console.WriteLine (">>>"+menuItems [i]);
						Console.ResetColor ( );
					}//End if statement
					else
					{
						Console.WriteLine (menuItems [i]);
					}//End else statement
				}//end for loop
				ConsoleKeyInfo Ckey = Console.ReadKey ( );
				switch (Ckey.Key)
				{
					case ConsoleKey.UpArrow://Up Arrow
						if ((Selection - 1) < menuItems.Length)
						{
							Selection = menuItems.Length - 1;
						}//End if statement
						else
						{
							Selection--;
						}//End else statement
						break;
					case ConsoleKey.DownArrow://Down Arrow
						if ((Selection + 1) > menuItems.Length -1)
						{
							Selection = 0;
						}//End if statement
						else
						{
							Selection++;
						}//End else statement
						break;
					case ConsoleKey.Enter://Enter Key
						if (Ckey.Key == ConsoleKey.Enter)
						{
							return Selection;
						}//End if statement
						break;
					default:
						break;
				}//End switch statement
				Console.Clear ( );
			}//End while loop
			return Selection;
		}//End DisplayMenu (string[], ConsoleColor, ConsoleColor)
		*/
	}//End Utility
}//End Project2 NEED CLEANING
