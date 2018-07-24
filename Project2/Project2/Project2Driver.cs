//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 2 - CreditCardList
//	File Name:		CreditCardDriver.cs
//	Description:	CreditCardDriver for Credit Card Class for user	
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Justin Adams, adamsjl3@etsu.edu, Undergrad CS, East Tennessee State University
//	Created:		Thursday, September 19, 2017
//	Copyright:		Justin Adams, 2017
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Project2
{

	/// <summary>
	/// Credit Card Driver Program For Project2
	/// </summary>
	class CreditCardDriver
	{
		#region static variables
		/// <summary>
		/// The open option
		/// </summary>
		public static int OPEN = 0;
		/// <summary>
		/// The save option
		/// </summary>
		public static int SAVE = 1;
		#endregion

		#region Main
		/// <summary>
		/// Mains the specified arguments.
		/// </summary>
		/// <param name="args">The arguments.</param>
		[STAThread]
		static void Main (string [ ] args)
		{
			CreditCardList Cards = null;
			ConsoleColor Background = ConsoleColor.Blue;
			ConsoleColor Foreground = ConsoleColor.White;
			string welcomeMessage = "Welcome to the customer control log. This program will allow you to add new customers" +
				", update existing customers, and store their forms of payment. Where would you like to start?";
			string exitMessage = "Thank you, for using this program if you have any question.\n" +
									"\nPlease contact me at:\n\n" +
									"Justin Adams\n" +
									"Adamsjl3@etsu.edu\n" +
									"CSCI 2210\n";

			string [ ] MenuMain = { "Create Card List",
									"Open Card List",
									"Add Credit Card",
									"Remove Credit Card",
									"Display Credit Card",
									"Find Credit Card By Number",
									"Find Credit Cards By Customer",
									"Display All Valid Cards",
									"Sort Credit By Number",
									"Display All Cards",
									"Exit Program" };
			string [ ] MenuChange = { "Name",
									"Email",
									"Phone",
									"Card Number",
									"Card Expiration"};
			//Set Colors for Console
			Console.BackgroundColor = Background;
			Console.ForegroundColor = Foreground;
			Console.Clear ( );

			//Display Welcome Message
			Utility.Message (welcomeMessage, "Welcome");
			//Add Menu switch between the choices
			int Selection = -1; //Selection index for menu
			do
			{
				//Reset Index
				Selection = -1;
				try
				{
					Selection = Utility.Menu (MenuMain);
				}//End try statement
				catch (Exception e)
				{
					//Display Error Message
					MessageBox.Show (e.Message,
									"Error",
									MessageBoxButtons.OK,
									MessageBoxIcon.Error);
				}//End catch statement
				switch (Selection)
				{
					case 1://Create new credit card list
						if (Cards != null && Cards.SaveNeeded)
						{
							RequestSave (Cards);
							Cards = new CreditCardList ( );
						}//End if statement
						Cards = new CreditCardList ( );	
						break;
					case 2://Open credit card list from list
						try
						{
							Cards = new CreditCardList (GetPath (OPEN));
							MessageBox.Show ("Credit card list was opened",
											"Opened",
											MessageBoxButtons.OK);
						}//End try statement
						catch (Exception e)
						{
							//Display Error Message
							MessageBox.Show (e.Message,
											"Error",
											MessageBoxButtons.OK,
											MessageBoxIcon.Error);
						}//End catch statement
						break;
					case 3://Add credit card to list
						if (Cards != null)
						{
							try
							{
								Cards += AddCard (MenuChange);
							}//End try statement
							catch (Exception e)
							{
								//Display Error Message
								MessageBox.Show (e.Message,
												"Error",
												MessageBoxButtons.OK,
												MessageBoxIcon.Error);
							}//End catch statement 
						}//End if statement
						else
						{
							MessageBox.Show ("Please create a card list first",
											"Error",
												MessageBoxButtons.OK,
												MessageBoxIcon.Error);
						}//End else statement
						break;
					case 4://Remove credit card from list
						if (Cards != null)
						{
							try
							{
								Cards -= GetCard (Cards);
							}//End try statement
							catch (Exception e)
							{
								//Display Error Message
								MessageBox.Show (e.Message,
												"Error",
												MessageBoxButtons.OK,
												MessageBoxIcon.Error);
							}//End catch statement 
						}//End if statement
						else
						{
							MessageBox.Show ("Please create a card list first",
											"Error",
												MessageBoxButtons.OK,
												MessageBoxIcon.Error);
						}//End else statement
						break;
					case 5://Find card by position
						if (Cards != null)
						{
							try
							{
								DisplayCard (GetCard (Cards));
								Utility.PressAnyKey ( );
							}//End try statement
							catch (Exception e)
							{
								//Display Error Message
								MessageBox.Show (e.Message,
												"Error",
												MessageBoxButtons.OK,
												MessageBoxIcon.Error);
							}//End catch statement 
						}//End if statement
						else
						{
							MessageBox.Show ("Please create a card list first",
											"Error",
												MessageBoxButtons.OK,
												MessageBoxIcon.Error);
						}//End else statement
						break;
					case 6://Find card by the card number
						if (Cards != null)
						{
							try
							{
								Console.WriteLine ("What is the number");
								DisplayCard (Cards [Console.ReadLine ( )]);
								Utility.PressAnyKey ( );
							}//End try statement
							catch (Exception e)
							{
								//Display Error Message
								MessageBox.Show (e.Message,
												"Error",
												MessageBoxButtons.OK,
												MessageBoxIcon.Error);
							}//End catch statement 
						}//End if statement
						else
						{
							MessageBox.Show ("Please create a card list first",
											"Error",
												MessageBoxButtons.OK,
												MessageBoxIcon.Error);
						}//End else statement
						break;
					case 7://Find card or cards by customer name
						if (Cards != null)
						{
							try
							{
								Console.WriteLine ("What is the name");
								List<CreditCard> Names = Cards.RetrieveCardByName (Console.ReadLine ( ));
								foreach (CreditCard card in Names)
								{
									DisplayCard (card);
								}//End foreach loop
								Utility.PressAnyKey ( );
							}//End try statement
							catch (Exception e)
							{
								//Display Error Message
								MessageBox.Show (e.Message,
												"Error",
												MessageBoxButtons.OK,
												MessageBoxIcon.Error);
							}//End catch statement 
						}//End if statement
						else
						{
							MessageBox.Show ("Please create a card list first",
											"Error",
												MessageBoxButtons.OK,
												MessageBoxIcon.Error);
						}//End else statement
						break;
					case 8://Display all valid cards
						if (Cards != null)
						{
							try
							{
								List<CreditCard> Names = Cards.RetrieveCards ( );
								foreach (CreditCard card in Names)
								{
									DisplayCard (card);
								}//End foreach loop
								Utility.PressAnyKey ( );
							}//End try statement
							catch (Exception e)
							{
								//Display Error Message
								MessageBox.Show (e.Message,
												"Error",
												MessageBoxButtons.OK,
												MessageBoxIcon.Error);
							}//End catch statement 
						}//End if statement
						else
						{
							MessageBox.Show ("Please create a card list first",
											"Error",
												MessageBoxButtons.OK,
												MessageBoxIcon.Error);
						}//End else statement
						break;
					case 9://Sort cards by number
						if (Cards != null)
						{
							Cards.Sort ( ); 
						}//End if statement
						else
						{
							MessageBox.Show ("Please create a card list first",
											"Error",
												MessageBoxButtons.OK,
												MessageBoxIcon.Error);
						}//End else statement
						break;
					case 10://Display all cards in list
						if (Cards != null)
						{
							DisplayAllCards (Cards);
							Utility.PressAnyKey ( ); 
						}//End if statement
						else
						{
							MessageBox.Show ("Please create a card list first",
											"Error",
												MessageBoxButtons.OK,
												MessageBoxIcon.Error);
						}//End else statement
						break;
					case 11://Exit program
						if (Cards != null)
						{
							if (Cards.SaveNeeded)
							{
								RequestSave (Cards);
							}//End if statement
							else
							{
								Utility.Message (exitMessage, "Exit");
								System.Environment.Exit (0);
							}//End else statement
						}//End if statement
						else
						{
							Utility.Message (exitMessage, "Exit");
							System.Environment.Exit (0);
						}//End else statement
						break;
					default:
						break;
				}//End switch statement
			}while (Selection != 11); //End do-while loop
		}//End Main (string [ ])
#endregion

		#region Extra methods
		/// <summary>
		/// Gets the card.
		/// </summary>
		/// <param name="cards">The cards.</param>
		/// <returns>Card</returns>
		private static CreditCard GetCard (CreditCardList cards)
		{
			int choice = -1;
			do
			{
				DisplayAllCards (cards);
				Console.WriteLine ("\n\nWhich card");
				try
				{
					choice = Int32.Parse (Console.ReadLine ( ));
				}
				catch (Exception e)
				{
					//Display Error Message
					MessageBox.Show (e.Message,
									"Error",
									MessageBoxButtons.OK,
									MessageBoxIcon.Error);
				}
			} while (choice < 1 || cards.Count < choice);
			return cards[choice - 1];
		}//End GetCard (CreditCardList)
		 /// <summary>
		 /// Adds the card.
		 /// </summary>
		 /// <param name="menuOption">The menu option.</param>
		 /// <returns>New Credit Card</returns>
		private static CreditCard AddCard (string [ ] menuOption)
		{
			DialogResult result;//Holder of user input
			CreditCard CardTemp = new CreditCard ( );   //Temporary holder for data
			//Run until end of menu option
			for (int i = 0 ; i < menuOption.Length ; i++)
			{
				//Switch on menu option to collect data
				switch (i)
				{
					case 0://Add Name
						result = DialogResult.Yes;
						while (result == DialogResult.Yes)
						{
							//Get name From User
							try
							{
								
								CardTemp.owner.Name = Utility.GetData (menuOption [i]);
								result = DialogResult.No;
							}//End try statement
							//Display error message
							catch (Exception e)
							{
								result = MessageBox.Show ("Invalid data\n\n" +
															e.Message +
															"Would like to try again?",
															"Error",
															MessageBoxButtons.YesNo,
															MessageBoxIcon.Error);
							}//End catch statement
						}//End while loop
						break;
					case 1://Add Email
						result = DialogResult.Yes;
						while (result == DialogResult.Yes)
						{
							try
							{
								//Get email from user
								CardTemp.owner.EmailAddress = Utility.GetData (menuOption [i]);
								result = DialogResult.No;
							}//End try statement
							catch (Exception e)
							{
								result = MessageBox.Show ("Invalid data\n\n" +
															e.Message +
															"Would like to try again?",
															"Error",
															MessageBoxButtons.YesNo,
															MessageBoxIcon.Error);
							}//End catch statement
						}//End while loop
						break;
					case 2://Add Phone Number
						result = DialogResult.Yes;
						while (result == DialogResult.Yes)
						{
							try
							{
								//Get Phone Number from user
								CardTemp.owner.PhoneNumber = Utility.GetData (menuOption [i]);
								result = DialogResult.No;
							}//End try statement
							catch (Exception e)
							{
								result = MessageBox.Show ("Invalid data\n\n" +
															e.Message +
															"Would like to try again?",
															"Error",
															MessageBoxButtons.YesNo,
															MessageBoxIcon.Error);
							}//End catch statement
						}//End while loop
						break;
					case 3://Add Credit Card Number
						result = DialogResult.Yes;
						while (result == DialogResult.Yes)
						{
							try
							{
								//Get Card Number from user
								CardTemp.IIN = Utility.GetData (menuOption [i]);
								result = DialogResult.No;
							}//End try statement
							catch (Exception e)
							{
								result = MessageBox.Show ("Invalid data\n\n" +
															e.Message +
															"Would like to try again?",
															"Error",
															MessageBoxButtons.YesNo,
															MessageBoxIcon.Error);
							}//End catch statement
						}//End while loop
						break;
					case 4://Add Credit Card Expiration
						result = DialogResult.Yes;
						while (result == DialogResult.Yes)
						{
							try
							{
								//Get Expiration from user
								CardTemp.Expiration = Utility.GetData (menuOption [i]);
								result = DialogResult.No;
							}//End try statement
							catch (Exception e)
							{
								result = MessageBox.Show ("Invalid data\n\n" +
															e.Message +
															"Would like to try again?",
															"Error",
															MessageBoxButtons.YesNo,
															MessageBoxIcon.Error);
							}//End catch statement
						}//End while loop
						break;
					default:
						break;
				}//End switch statement
			}//end for loop
			return CardTemp;
		}//End AddCard (string[])

		/// <summary>
		/// Gets the file path.
		/// </summary>
		/// <param name="choice">The choice.</param>
		/// <returns>Path to file</returns>
		private static string GetPath (int choice)
		{
			Stream stream = null;	//Holder of stream object
			string path = "";       //Holder of path location
			//Switch on ether user needs to save or read file
			switch (choice)
			{
				case 0://Check Open path
					OpenFileDialog OpenFile = new OpenFileDialog ( );
					OpenFile.InitialDirectory = Application.StartupPath + @"..\..";
					OpenFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
					if (OpenFile.ShowDialog ( ) == DialogResult.OK)
					{
						try
						{
							if ((stream = OpenFile.OpenFile ( )) != null)
							{
								path = OpenFile.FileName;
							}//End if statement
						}//End try statement
						catch (Exception ex)
						{
							MessageBox.Show ("Error: Could not read file from disk. Original error: " + ex.Message);
						}//End catch statement
					}
					break;
				case 1://Check Save path
					SaveFileDialog SaveFile = new SaveFileDialog ( );
					SaveFile.InitialDirectory = Application.StartupPath + @"..\..";
					SaveFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
					if (SaveFile.ShowDialog ( ) == DialogResult.OK)
					{
						try
						{
							if ((stream = SaveFile.OpenFile ( )) != null)
							{
								path = SaveFile.FileName;
							}//End if statement
						}//End try statement
						catch (Exception ex)
						{
							MessageBox.Show ("Error: Could not read file from disk. Original error: " + ex.Message);
						}//End catch statement
					}
					break;
				default:
					break;
			}//End switch statement
			return path;
		}//End GetPath (int)

		 /// <summary>
		 /// Displays all Card in list.
		 /// </summary>
		 /// <param name="cards">The cards.</param>
		public static void DisplayAllCards (CreditCardList cards)
		{
			int index = 0; //Index of current value
			//Display all Cards
			foreach (CreditCard card in cards)
			{
				Console.WriteLine ((index+1) + ".\n" + card.ToString ( )+ "\n\n");
				index++;
			}
		}//End DisplayAllCards (CreditCardList)

		 /// <summary>
		 /// Displays the card.
		 /// </summary>
		 /// <param name="card">The card.</param>
		public static void DisplayCard (CreditCard card)
		{
			Console.WriteLine (card.ToString ( ) + "\n\n");
		}//End DisplayCard (CreditCard)

		 /// <summary>
		 /// Requests the save.
		 /// </summary>
		 /// <param name="cards">The cards.</param>
		public static void RequestSave (CreditCardList cards)
		{
			//User try to exit dialog
			DialogResult result;
			result = MessageBox.Show ("Would like to save the list " +
										"before continuing",
										"Error",
										MessageBoxButtons.YesNo,
										MessageBoxIcon.Error);
			if (result == DialogResult.Yes)
			{
				cards.SaveDataFile (GetPath (SAVE));
				MessageBox.Show ("File was saved");
			}//End else-if statement	
		}//End RequestSave (CreditCardList)
		#endregion
	}//End CreditCardDriver
}//End Project2
