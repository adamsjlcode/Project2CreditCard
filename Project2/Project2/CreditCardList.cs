//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 2 - CreditCardList
//	File Name:		CreditCardList.cs
//	Description:	Credit Card List Class used to manage credit card information provided by user	
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Justin Adams, adamsjl3@etsu.edu, Undergrad CS, East Tennessee State University
//	Created:		Thursday, September 19, 2017
//	Copyright:		Justin Adams, 2017
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
	/// <summary>
	/// Manager program for credit cards  
	/// </summary>
	/// <seealso cref="System.Collections.IEnumerable" />
	class CreditCardList : IEnumerable
	{
		#region class Property
		/// <summary>
		/// The cards
		/// </summary>
		private List<CreditCard> Cards;

		/// <summary>
		/// Gets or sets a value indicating whether [save needed].
		/// </summary>
		/// <value>
		///   <c>true</c> if [save needed]; otherwise, <c>false</c>.
		/// </value>
		public bool SaveNeeded { get; set; }// End SaveNeeded
		
		/// <summary>
		/// Gets the count.
		/// </summary>
		/// <value>
		/// The count.
		/// </value>
		public int Count
		{
			get
			{
				return Cards.Count;
			}//End get
		}//End Count
		#endregion

		#region class Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="CreditCardList"/> class.
		/// </summary>
		public CreditCardList ( )
		{
			Cards = new List<CreditCard> ( );
			SaveNeeded = false;
		}//End CreditCardList ( )
		 /// <summary>
		 /// Initializes a new instance of the <see cref="CreditCardList"/> class.
		 /// </summary>
		 /// <param name="path">The path.</param>
		public CreditCardList (string path)
		{
			Cards = new List<CreditCard> ( );
			LoadDataFile (path);
			SaveNeeded = false;
		}//End CreditCardList (string)
		#endregion

		#region this methods
		/// <summary>
		/// Gets or sets the <see cref="CreditCard"/> at the specified index.
		/// </summary>
		/// <value>
		/// The <see cref="CreditCard"/>.
		/// </value>
		/// <param name="index">The index.</param>
		/// <returns>Selected credit card</returns>
		/// <exception cref="Exception">Not a valid range</exception>
		public CreditCard this[int index]
		{
			get
			{
				if (index < 0 || index > Cards.Count - 1)
				{
					throw new Exception ("Not a valid range");
				}//End if statement
				else
				{
					return Cards [index];
				}//End else statement
			}//End get
			set
			{
				Cards [index] = value;
			}//End set
		}//End this [int]

		/// <summary>
		/// Gets the <see cref="CreditCard"/> with the specified i in.
		/// </summary>
		/// <value>
		/// The <see cref="CreditCard"/>.
		/// </value>
		/// <param name="iIN">The i in.</param>
		/// <returns>Selected credit card</returns>
		/// <exception cref="Exception">No matches the given card number: " + iIN</exception>
		public CreditCard this [string iIN]
		{
			get
			{
				Sort ( );
				CreditCard TempCard = new CreditCard (iIN: iIN);
				int indexer = Cards.BinarySearch (TempCard);
				if (indexer != -1)
				{
					return Cards [indexer];
				}//End if statement
				else
				{
					throw new Exception ("No matches the given card number: " + iIN);
				}//End else statement
			}//End get
		}//End this [string]
		#endregion
		
		#region operator methods
		/// <summary>
		/// Implements the operator -.
		/// </summary>
		/// <param name="cardList">The card list.</param>
		/// <param name="card">The card.</param>
		/// <returns>
		/// The result of the operator.
		/// </returns>
		public static CreditCardList operator - (CreditCardList cardList, CreditCard card)
		{
			cardList.Cards.Remove (card);
			cardList.SaveNeeded = true;
			return cardList;
		}//End operator - (CreditCardList, CreditCard)
		 /// <summary>
		 /// Implements the operator +.
		 /// </summary>
		 /// <param name="cardList">The card list.</param>
		 /// <param name="card">The card.</param>
		 /// <returns>
		 /// The result of the operator.
		 /// </returns>
		public static CreditCardList operator + (CreditCardList cardList, CreditCard card)
		{
			cardList.Cards.Add (card);
			cardList.SaveNeeded = true;
			return cardList;
		}//End operator - (CreditCardList, CreditCard)
		#endregion

		#region GetEnumerator
		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
		/// </returns>
		public IEnumerator GetEnumerator ( )
		{
			return  Cards.GetEnumerator ( );
		}//End GetEnumerator ( )
		#endregion

		#region Class Methods
		/// <summary>
		/// Retrieves the cards.
		/// </summary>
		/// <returns>Valid cards in current list</returns>
		/// <exception cref="Exception">No valid cards in the list</exception>
		public List<CreditCard> RetrieveCards ( )
		{
			List<CreditCard> GoodCards = new List<CreditCard> ( );
			for (int i = 0 ; i < Cards.Count ; i++)
			{
				if (Cards [i].ValidCard)
				{
					GoodCards.Add (Cards [i]);
				}//End if statement
				if (GoodCards.Count == 0)
				{
					throw new Exception ("No valid cards in the list");
				}//End if statement
			}//end for loop
			return GoodCards;
		}//End RetrieveCardByName ( )
		 /// <summary>
		 /// Retrieves the name of the card by.
		 /// </summary>
		 /// <param name="name">The name.</param>
		 /// <returns>Cards in current list by name</returns>
		 /// <exception cref="Exception">No cards match have this " + name</exception>
		public List<CreditCard> RetrieveCardByName (string name)
		{
			List<CreditCard> OwnerCards = new List<CreditCard> ( );
			for (int i = 0 ; i < Cards.Count ; i++)
			{
				if (Cards[i].NameMatches(name))
				{
					OwnerCards.Add (Cards [i]);
				}//End if statement
				if (OwnerCards.Count == 0)
				{
					throw new Exception ("No cards match have this " + name);
				}//End if statement
			}//end for loop
			return OwnerCards;
		}//End RetrieveCardByName (string)
		 /// <summary>
		 /// Sorts this instance.
		 /// </summary>
		public void Sort ( )
		{
			Cards.Sort ( );
			SaveNeeded = true;
		}//End Sort ( ) 
		 /// <summary>
		 /// Saves the data file.
		 /// </summary>
		 /// <param name="path">The path.</param>
		public void SaveDataFile (string path)
		{

			StreamWriter fileWriter = null;
			try
			{
				SaveNeeded = false;
				fileWriter = new StreamWriter (path);
				for (int i = 0 ; i < Cards.Count ; i++)
				{
				   try
					{
						fileWriter.WriteLine (Cards[i].FileToString());
						SaveNeeded = false;
					}//End try-statement
					catch (IndexOutOfRangeException e)
					{
						SaveNeeded = true;
						continue;
					}//End catch-statement
				}//end for loop		
			}//End try-statement
			finally
			{
				if (fileWriter != null)
				{
					fileWriter.Close ( );
				}//End if statement
			}//End finally-statement
		}//End SaveDataFile (string)
		 /// <summary>
		 /// Loads the data file.
		 /// </summary>
		 /// <param name="path">The path.</param>
		public void LoadDataFile (string path)
		{

			StreamReader fileReader = null;
			string [ ] fileData;
			try
			{
				SaveNeeded = false;
				fileReader = new StreamReader (path);
				while (fileReader.Peek ( ) != -1)
				{
					fileData = fileReader.ReadLine ( ).Split ('|');
					try
					{
						CreateNewCard (fileData);
					}//End try-statement
					catch (IndexOutOfRangeException e)
					{
						SaveNeeded = true;
						continue;
					}//End else-statement
				}//End while loop
			}//End try-statement
			finally
			{
				if (fileReader != null)
				{
					fileReader.Close ( );
				}//End if statement
			}//End finally-statement
		}//End LoadDataFile (string)
		 /// <summary>
		 /// Creates the new card.
		 /// </summary>
		 /// <param name="data">The data.</param>
		public void CreateNewCard(string[] data)
		{
			CreditCard TempCard = new CreditCard ( );
			TempCard = new CreditCard (data [0], 
										data [1], 
										data [2], 
										data [3], 
										data [4]);
			Cards.Add (new CreditCard (TempCard));
		}//End CreateNewCard(string[])
	#endregion

	}//End CreditCardList
}//End Project2
