//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 2 - CreditCardList
//	File Name:		CardInfo.txt
//	Description:	Debugger text file for validation	
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Justin Adams, adamsjl3@etsu.edu, Undergrad CS, East Tennessee State University
//	Created:		Thursday, September 23, 2017
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
	/// <summary>
	/// Holds and verify of credit card owner information and card information
	/// </summary>
	/// <seealso cref="System.IComparable{Project1.CreditCardOwner}" />
	/// <seealso cref="System.IEquatable{Project1.CreditCardOwner}" />
	public class CreditCardOwner : IComparable<CreditCardOwner>, IEquatable<CreditCardOwner>
	{
		#region class Property
		/// <summary>
		/// The name
		/// </summary>
		private string _Name;

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		/// <exception cref="Exception">Invalid format needs to be at least two words: \n" +
		/// "John Doe\n" +
		/// "Business Inc." +
		/// "Please try again\n</exception>
		public string Name
		{

			get
			{
				return _Name;
			}//End get
			set
			{
				if (Regex.IsMatch (value, @"[^\s]+(\s.+)\b"))
				{
					_Name = value;
				} //End if statement
				else
				{
					_Name = "John Doe";
					throw new Exception ("Invalid format needs to be at least two words: \n" +
										"John Doe\n" +
										"Business Inc.");
				}//End else statement
			}//End set
		}//End Name

		/// <summary>
		/// The phone number
		/// </summary>
		private string _PhoneNumber;

		/// <summary>
		/// Gets or sets the phone number.
		/// </summary>
		/// <value>
		/// The phone number.
		/// </value>
		/// <exception cref="Exception">Invalid format needs to be:\n" +
		/// 							"000-000-0000\n</exception>
		public string PhoneNumber
		{
			get
			{
				return _PhoneNumber;
			}//End get
			set
			{
				if (Regex.IsMatch (value, @"^(\(?\d{3}[)\- \.]?)? ?\d{3}[\-\. ]?\d{4}$"))
				{
					_PhoneNumber = value;
				}//End if statement
				else
				{
					_PhoneNumber = "(000) 000-0000";
					throw new Exception ("Invalid format needs to be:\n" +
										"(000)000-0000\n");
				}//End else statement
			}//End set
		}//End PhoneNumber

		/// <summary>
		/// The email address
		/// </summary>
		private string _EmailAddress;

		/// <summary>
		/// Gets or sets the email address.
		/// </summary>
		/// <value>
		/// The email address.
		/// </value>
		/// <exception cref="Exception">Invalid format needs to be:\n" +
		/// "example@example.com\n"</exception>
		public string EmailAddress
		{
			get
			{
				return _EmailAddress;
			}//End get
			set
			{
				if (Regex.IsMatch (value, @"\b[a-z0-9._%=+-]+@[a-z0-9._%=-\[]+.\w{2,}"))
				{
					_EmailAddress = value;
				}//End if statement
				else
				{
					_EmailAddress = "example@example.com";
					throw new Exception ("Invalid format needs to be:\n" +
										"example@example.com\n");
				}//End else statement
			}//End set
		}//End EmailAddress
		#endregion

		#region class Constructors
		/// <summary>
		/// Initializes an default instance of the <see cref="CreditCardOwner"/> class.
		/// </summary>
		public CreditCardOwner ( )
		{
			Name = "John Doe";
			PhoneNumber = "000-000-0000";
			EmailAddress = "example@example.com";;
		}//End CreditCardOwner ( )

		/// <summary>
		/// Initializes a new instance of the <see cref="CreditCardOwner"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="address">The address.</param>
		/// <param name="phoneNumber">The phone number.</param>
		/// <param name="emailAddress">The email address.</param>
		public CreditCardOwner (string name, string phoneNumber, string emailAddress)
		{
			this.Name = name;
			this.PhoneNumber = phoneNumber;
			this.EmailAddress = emailAddress;
		}//End CreditCardOwner (string, string, string, string, string)

		/// <summary>
		/// Initializes a copy instance of the <see cref="CreditCardOwner"/> class.
		/// </summary>
		/// <param name="creditCardOwner">The credit card owner.</param>
		public CreditCardOwner (CreditCardOwner creditCardOwner)
		{
			this.Name = creditCardOwner.Name;
			this.PhoneNumber = creditCardOwner.PhoneNumber;
			this.EmailAddress = creditCardOwner.EmailAddress;
		}//End CreditCardOwner (CreditCardOwner)
		#endregion

		#region IComparable<CreditCardOwner> implementation
		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="other">An object to compare with this instance.</param>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="other" /> in the sort order.  Zero This instance occurs in the same position in the sort order as <paramref name="other" />. Greater than zero This instance follows <paramref name="other" /> in the sort order.
		/// </returns>
		public int CompareTo (CreditCardOwner other)
		{
			return base.GetHashCode ( ).CompareTo (other.GetHashCode ( ));
		}//End CompareTo (CreditCardOwner)
		#endregion

		#region IEquatable<Name> implementation
		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
		/// </returns>
		bool IEquatable<CreditCardOwner>.Equals (CreditCardOwner other)
		{
			return Name == other.Name;
		}//End IEquatable<CreditCardOwner>.Equals (CreditCardOwner)

		/// <summary>
		/// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
		/// <returns>
		///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		/// <exception cref="ArgumentException">Parameter is not a credit card owner</exception>
		public override bool Equals (object obj)
		{
			if (obj == null)
			{
				return base.Equals (obj);
			}
			else if (!(obj is CreditCardOwner))
			{
				throw new ArgumentException ("Parameter is not a credit card owner");
			}
			else return base.Equals (obj as CreditCardOwner);
		}//End Equals (object)

		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		/// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		/// </returns>
		public override int GetHashCode ( )
		{
			return Name.GetHashCode ( );
		}//End GetHashCode ( )
		#endregion

		#region ToString Methods
		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString ( )
		{
			string strTemp = "Name: \t\t" + this.Name +
							"\nPhone: \t\t" + this.PhoneNumber +
							"\nEmail: \t\t" + this.EmailAddress;
			return strTemp;
		}//End ToString ( )
		#endregion

	}//End CreditCardOwner
}//End Project2
