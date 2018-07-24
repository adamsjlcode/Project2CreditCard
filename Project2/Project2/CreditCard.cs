//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 2 - CreditCardList
//	File Name:		CreditCard.cs
//	Description:	Credit Card Class used to validate information provided by user	
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project2
{
	#region class enum
	/// <summary>
	///	The Card Type
	/// </summary>
	public enum CardType
	{
		/// <summary>
		/// The invalid
		/// </summary>
		INVALID,
		/// <summary>
		/// The visa
		/// </summary>
		VISA,
		/// <summary>
		/// The Mastercard
		/// </summary>
		MASTERCARD,
		/// <summary>
		/// The American express
		/// </summary>
		AMERICAN_EXPRESS,
		/// <summary>
		/// The discover
		/// </summary>
		DISCOVER,
		/// <summary>
		/// The diners club
		/// </summary>
		DINERS_CLUB,
		/// <summary>
		/// The other
		/// </summary>
		OTHER
	}//End CardType
	 /// <summary>
	 /// Major Industry Identifier  
	 /// </summary>
	public enum MII
	{
		/// <summary>
		/// The invalid
		/// </summary>
		INVALID,
		/// <summary>
		/// The airlines
		/// </summary>
		AIRLINES,
		/// <summary>
		/// The travel
		/// </summary>
		TRAVEL,
		/// <summary>
		/// The banking and financial
		/// </summary>
		BANKING_AND_FINANCIAL,
		/// <summary>
		/// The merchandising and banking financial
		/// </summary>
		MERCHANDISING_AND_BANKING_FINANCIAL,
		/// <summary>
		/// The petroleum
		/// </summary>
		PETROLEUM,
		/// <summary>
		/// The health care telecommunications
		/// </summary>
		HEALTHCARE_TELECOMMUNICATIONS,
		/// <summary>
		/// The national assignment
		/// </summary>
		NATIONAL_ASSIGNMENT
	}//End MMI
	#endregion
	/// <summary>
	/// Credit card class used to store and validate credit card information
	/// </summary>
	/// <seealso cref="System.IEquatable{Project2.CreditCard}" />
	/// <seealso cref="System.IComparable{Project2.CreditCard}" />
	public class CreditCard : IEquatable<CreditCard>, IComparable<CreditCard>
	{
		#region class Property
		public CreditCardOwner owner;
		 /// <summary>
		 /// Gets or sets the type.
		 /// </summary>
		 /// <value>
		 /// The type.
		 /// </value>
		private CardType Type { get; set; }//End CardType

		/// <summary>
		/// Gets or sets the mii.
		/// </summary>
		/// <value>
		/// The mii.
		/// </value>
		private MII MII { get; set; }//End MII
		/// <summary>
		/// Gets or sets the account number.
		/// </summary>
		/// <value>
		/// The account number.
		/// </value>
		private string AccountNumber { get; set; }//End	AccountNumber

		/// <summary>
		/// Gets or sets the check digit.
		/// </summary>
		/// <value>
		/// The check digit.
		/// </value>
		private string CheckDigit { get; set; }//End CheckDigit

		/// <summary>
		/// The iin
		/// </summary>
		private string _IIN;

		/// <summary>
		/// Gets or sets the iin.
		/// </summary>
		/// <value>
		/// The iin.
		/// </value>
		public string IIN
		{
			get
			{
				return _IIN;
			}
			set
			{
				if (LuhnAlgorithm (value))
				{
					//Set the IIN number
					_IIN = value;
					SetValue (value);
					ValidCard = true;
				}//End if statement
				else
				{
					ValidCard = false;
					//Throw error message if card number is invalid
					throw new Exception ("Invalid Card Number" + value);
				}//End else statement
			}
		}//End IIN

		/// <summary>
		/// The expiration
		/// </summary>
		private string _Expiration;
		/// <summary>
		/// Gets or sets the expiration.
		/// </summary>
		/// <value>
		/// The expiration.
		/// </value>
		public string Expiration
		{
			get
			{
				return _Expiration;
			}
			set
			{
				if (CheckExpiration (value))
				{
					//Set the IIN number
					_Expiration = value;
					ValidCard = true;
				}//End if statement
				else
				{
					ValidCard = false;
					//Throw error message if card number is invalid
					throw new Exception ("Invalid Expiration");
				}//End else statement	
			}
		}//End Expiration

		public bool ValidCard;

		/// <summary>
		/// The current date
		/// </summary>
		public DateTime CurrentDate = DateTime.Today;
		#endregion

		#region class Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="CreditCard" /> class.
		/// </summary>
		public CreditCard ( )
		{
			owner = new CreditCardOwner ("John Doe", "(000) 000-0000", "example@example.com");
			IIN = "00000000000019";
			Expiration = CurrentDate.Month.ToString ("MM") + "/" + CurrentDate.Year;
			ValidCard = false;
		}//End CreditCard

		/// <summary>
		/// Initializes a new instance of the <see cref="CreditCard"/> class.
		/// </summary>
		/// <param name="iIN">The i in.</param>
		/// <param name="expiration">The expiration.</param>
		/// <exception cref="Exception">Invalid Card Number</exception>
		public CreditCard (string iIN, string expiration)
		{
			
			if (LuhnAlgorithm (iIN) && CheckExpiration (expiration))
			{
				//Set the IIN number
				SetValue (iIN);
				Expiration = expiration;
				ValidCard = true;
			}//End if statement
			else
			{
				ValidCard = false;
				//Throw error message if card number is invalid
				throw new Exception ("Invalid Card Number");
			}
		}//End CreditCard (string)

		 /// <summary>
		 /// Initializes a new instance of the <see cref="CreditCard"/> class.
		 /// </summary>
		 /// <param name="iIN">The i in.</param>
		 /// <exception cref="Exception">Invalid Card Number</exception>
		public CreditCard (string name, string phoneNumber, string emailAddress,
													string iIN, string expiration)
		{
			owner = new CreditCardOwner (name, phoneNumber, emailAddress);
			//Removes any unusable characters from card number
			for (int i = 0 ; i < iIN.Length ; i++)
			{
				if (iIN [i].ToString ( ).Contains (@" \][|}{+=_-)(*&^%$#@!`~:;<,>.?/"))
				{
					iIN.Remove (i, 1);
					i--;
				}
			}
			if (LuhnAlgorithm (iIN))
			{
				//Set Card Number
				IIN = iIN;
			}//End if statement
			else
			{
				ValidCard = false;
				//Throw error message if card number or expiration is invalid
				throw new Exception ("Invalid Card Number: " + iIN);
			}//End else statement
			if (CheckExpiration (expiration))
			{
				ValidCard = true;
				//Set Expiration
				Expiration = expiration;
			}//End if statement
			else
			{
				ValidCard = false;
				Expiration = CurrentDate.Month + "/" + CurrentDate.Year;
			}//End else statement

		}//End CreditCard (string)

		/// <summary>
		/// Initializes a copy instance of the <see cref="CreditCard"/> class.
		/// </summary>
		/// <param name="card">The card.</param>
		public CreditCard (CreditCard card)
		{

			owner = new CreditCardOwner ( );
			this.owner.Name = card.owner.Name;
			this.owner.PhoneNumber = card.owner.PhoneNumber;
			this.owner.EmailAddress = card.owner.EmailAddress;
			this.IIN = card.IIN;
			this.Expiration = card.Expiration;
			ValidCard = CheckExpiration(Expiration);
		}//End CreditCard (CreditCard)

		/// <summary>
		/// Initializes a new instance of the <see cref="CreditCard"/> class.
		/// </summary>
		/// <param name="iIN">The i in.</param>
		public CreditCard (string iIN)
		{
			IIN = iIN;
		}//End CreditCard (string)
		#endregion

		#region class methods
		/// <summary>
		/// Sets the value.
		/// </summary>
		/// <param name="iIN">The i in.</param>
		public void SetValue (string iIN)
		{
			//Find Major Industry Identifier Type
			MajorIndustryIdentifierType (iIN [0].ToString ( ));
			//Find Check Card Type
			CheckCardType (iIN);
			//Remove Major Industry Identifier
			iIN = iIN.Remove (0, 1);
			//Find Check Digit
			CheckDigit = iIN [iIN.Length - 1].ToString ( );
			//Remove Check Digit
			iIN = iIN.Remove (iIN.Length - 1, 1);
			//Find Account Number
			AccountNumber = iIN.Substring (iIN.Length - 6);
			//Set Expiration
		}//End SetValue (string)

		/// <summary>
		/// Names the matches.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns>Whether name matches</returns>
		public bool NameMatches (string name)
		{
			return this.owner.Name == name;
		}//End NameMatches (string)

		/// <summary>
		/// Luhns the algorithm.
		/// </summary>
		/// <param name="IIN">The iin.</param>
		/// <returns>If card number is a valid number</returns>
		public bool LuhnAlgorithm (string IIN)
		{
			int Sum = 0;        //Holder of the sum of card number
			int [ ] numbers = new int [IIN.Length];
			for (int i = 0 ; i < IIN.Length ; i++)
			{
				numbers [i] = Int32.Parse (IIN.Substring (i, 1));
			}
			for (int i = numbers.Length - 1 ; i >= 0 ; i--)
			{
				int number = numbers [i];
				bool div2 = false;
				if (div2)
				{
					number *= 2;
					if (number > 9)
					{
						number -= 9;
					}//End if statement
					Sum += number;
					div2 = !div2;
				}//End if statement
			}
			return (Sum % 10 == 0);
		}//End LuhnAlgorithm (string)
		 
		 /// <summary>
		 /// Checks the type of the card.
		 /// </summary>
		 /// <param name="iIN">The i in.</param>
		public void CheckCardType (string iIN)
		{
			if (Regex.Match (iIN, @"\b4\d{12}|(\b4\d{15})").Success)
			{
				Type = CardType.VISA;
			}//End if statement
			else if (Regex.Match (iIN, @"\b5(1|5)\d{14}").Success)
			{
				Type = CardType.MASTERCARD;
			}//End else if statement
			else if (Regex.Match (iIN, @"\b3(4|7)\d{13}").Success)
			{
				Type = CardType.AMERICAN_EXPRESS;
			}//End else if statement
			else if (Regex.Match (iIN, @"(\b6011\d{11})|(\b644\d{12})|(\b65\d{13})").Success)
			{
				Type = CardType.DISCOVER;
			}//End else if statement
			else if (Regex.Match (iIN, @"\b30(0,5)\d{11}").Success)
			{
				Type = CardType.DINERS_CLUB;
			}//End else if statement
			else
			{
				Type = CardType.INVALID;
			}//End else statement
		}//End CheckCardType (string)

		/// <summary>
		/// Majors the type of the industry identifier.
		/// </summary>
		/// <param name="iIN">The i in.</param>
		public void MajorIndustryIdentifierType (string iIN)
		{
			switch (Int32.Parse (iIN [0].ToString ( )))
			{
				case 1:
				case 2:
					MII = MII.AIRLINES;
					break;
				case 3:
					MII = MII.TRAVEL;
					break;
				case 4:
				case 5:
					MII = MII.BANKING_AND_FINANCIAL;
					break;
				case 6:
					MII = MII.MERCHANDISING_AND_BANKING_FINANCIAL;
					break;
				case 7:
					MII = MII.PETROLEUM;
					break;
				case 8:
					MII = MII.HEALTHCARE_TELECOMMUNICATIONS;
					break;
				case 9:
					MII = MII.NATIONAL_ASSIGNMENT;
					break;
				default:
					break;
			}//End switch statement
		}//End MajorIndustryIdentifierType (string)

		/// <summary>
		/// Checks the expiration.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <exception cref="Exception">Invalid Expiration Date</exception>
		public bool CheckExpiration (string date)
		{
			bool valid = false;
			if (Regex.IsMatch (date, @"^(0[1-9]|1[0-2]|[1-9])\/?([0-9]{4}|[0-9]{2})$"))
			{
				string [ ] temp = date.Split ('/');
				//Check year
				if (CurrentDate.Year == Int32.Parse (temp [1]))
				{
					//Check month
					if (CurrentDate.Month < Int32.Parse (temp [0]))
					{
						Expiration = CurrentDate.Month + "/" + CurrentDate.Year;
						ValidCard = false;
					}//End if statement
					else
					{
						ValidCard = true;
						valid = true;
					}//End else statement 
				}//End if statement
				else
				{
					ValidCard = true;
					valid = true;
				}//End else statement	
			}//End if statement
			else
			{
				Expiration = CurrentDate.Month + "/" + CurrentDate.Year;
				ValidCard = false;
			}//End else statement
			return valid;
		}//End CheckExpiration (string)
		#endregion

		#region IComparable<CreditCard> implementation
		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="other">An object to compare with this instance.</param>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="other" /> in the sort order.  Zero This instance occurs in the same position in the sort order as <paramref name="other" />. Greater than zero This instance follows <paramref name="other" /> in the sort order.
		/// </returns>
		public int CompareTo (CreditCard other)
		{
			return this.IIN.CompareTo (other.IIN);
		}//End CompareTo (CreditCard)
		#endregion

		#region IEquatable<CreditCard> implementation	
		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
		/// </returns>
		public bool Equals (CreditCard other)
		{
			return (IIN.Equals (other.IIN) && Expiration.Equals (other.Expiration));
		}
		/// <summary>
		/// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
		/// <returns>
		///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		/// <exception cref="ArgumentException"></exception>
		public override bool Equals (object obj)
		{
			if (obj == null)
			{
				return base.Equals (obj);
			}
			if (!(obj is CreditCard))
			{
				throw new ArgumentException ($"Cannot compare a CreditCard and a {obj.GetType ( )} object.");
			}
			return Equals (obj as CreditCard);
		}//End Equals (object)
		 /// <summary>
		 /// Returns a hash code for this instance.
		 /// </summary>
		 /// <returns>
		 /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		 /// </returns>
		public override int GetHashCode ( )
		{
			return IIN.GetHashCode ( );
		}//End GetHashCode ( )
		#endregion
		
		#region ToString Methods
		public string FileToString ( )
		{

			return this.owner.Name +
					"|" + this.owner.PhoneNumber +
					"|" + this.owner.EmailAddress +
					"|" + IIN +
					"|" + Expiration;
		}//End FileToString ( )
		 /// <summary>
		 /// Returns a <see cref="System.String" /> that represents this instance.
		 /// </summary>
		 /// <returns>
		 /// A <see cref="System.String" /> that represents this instance.
		 /// </returns>
		public override string ToString ( )
		{

			return "Name: \t\t" + this.owner.Name +
					"\nPhone: \t\t" + this.owner.PhoneNumber +
					"\nEmail: \t\t" + this.owner.EmailAddress	+
					"\nMII:\t\t" + MII +
					"\nIIN:\t\t" + IIN +
					"\nAccount Number: " + AccountNumber +
					"\nCheck Digit:\t" + CheckDigit +
					"\nExpiration:\t" + Expiration +
					"\nType:\t\t" + Type +
					"\nValid:\t\t" + ValidCard;
		}//End ToString ( )
		#endregion
	}//End CreditCard
}//End Project1
