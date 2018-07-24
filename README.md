# Credit Card Class
## Purpose
![](media/9bbdc7e084304163e44b2530af76b8f7.jpg)
This project is an extension of the **Credit Card** project. It uses the classes
that were used and/or developed for the previous project, and adds a
*CreditCardList* class. The *CreditCardList* class will encapsulate a **private
List\<CreditCard\>** and it will provide the functionality required by the rest
of the project. This class (as is the case will all classes) should be
self-contained; that is, if one needs to perform an action on a collection of
*CreditCards*, one should be able to invoke a *CreditCardList* method to take
the desired action. **The intent of this assignment is to demonstrate your
knowledge of how to use List\<T\>, implement IEquatable\<T\> and
IEnumerable\<T\> along with operators including indexers in user-defined
classes. Do not find ways to avoid this intent.**

## Test Data
Using a text editor such as *NotePad++* or the *Visual Studio code editor*,
create a pipe character (“\|”) delimited text file containing the test data that
you (should have) used in the previous project. So that all programs can be
tested against a common test data file, the content of a line in the file should
be the **card user’s name**, **phone number**, **email address**, **card
number**, and **expiration date** (**mm/yyyy**) in that order. For example, one
line of the file may contain the information shown here:

>   **Chester Drawers\|(423)
>   439-6111\|Drawers\@BoPeep.com\|1234567890120987\|12/2018**

The file should contain at least 12 test cases including a variety of types of
valid, non-expired cards and a variety of cards that are expired or are invalid
for other reasons (invalid card number, invalid email address, invalid phone
number, etc.). Be sure your test data covers all cases adequately. This file may
have as many different credit card records as needed, and you may have multiple
test data files. The text data files for your project should be in a subfolder
of the project folder and it should be named **CreditCardData.** In the real
world, these credit card records would need to be stored in an encrypted
database for security rather than in a plain text file.

## CreditCardList Class – Additional Specifications
This class is designed to manage a collection of *CreditCard* objects. Any
processing related to a single *CreditCard* (validation, expiration testing,
formatting for output, etc.) should be done in the *CreditCard* class itself.

The **CreditCardList** class must have a public *Count* property that allows a
user of the class to determine how many *CreditCards* are currently in the list,
but the user should not be able to directly change this number. It should have a
*Boolean SaveNeeded* property that indicates whether there has been a change
made to the *List* since the last time it was saved to a file. There may be
other properties as needed.

The *CreditCardList* class should have a *default constructor* that creates an
empty *CreditCardList*. It should also have a *constructor* that takes a string
parameter containing a file name (with path if needed). This *second
constructor* should create a new *List* and populate it with *CreditCard*
information from the specified text file.

The class should have at least public methods that support the following
capabilities:

-   Add a *CreditCard* to the list (using *operator+*)

-   Remove a specified *CreditCard* from the list if it is present (using
    *operator-*)

-   Retrieve the *CreditCard* in position *n* of the list if *n* is between 0
    and *Count* using an *integer indexer*

-   Retrieve the *CreditCard* with a specified number if it exists using the
    *BinarySearch* method from *List\<T\>* in the implementation of a *String
    indexer*

-   Retrieve a *List* of all *CreditCard* objects belonging to a specified
    person

-   Retrieve a *List* of all non-expired, valid *CreditCards*

-   Sort the *List* based on the credit card number using the *Sort* method in
    *List\<T\>*

-   Save the entire *List* of *CreditCard* objects in a text file in the same
    format as described above

You may have as many other public and/or private methods as are helpful. In any
method that modifies the current *List*, the *SaveNeeded* property should be set
to *True*. In the *Save* method (if successful) and both *constructors*, the
*SaveNeeded* property should be set to *False*. Handle any exceptions
appropriately.

## CreditCard Class

Correct any known deficiencies in the class and update it to implement the
necessary *interfaces* needed for this assignment. Use good programming
practices as discussed in class.

## Driver Class

Maintain the functionality from the previous assignment, but revise the **menu**
to allow for the user of this program to

1.  Create a new empty *CreditCardList*

2.  Open a text file and populate a *CreditCardList*

3.  Add a *CreditCard* to the current *CreditCardList*

4.  Remove a *CreditCard* from the current *CreditCardList*

5.  Retrieve and display a *CreditCard* from position **n** in the list

6.  Retrieve and display a *CreditCard* by its card number

7.  Retrieve and display all *CreditCards* belonging to a specified person

8.  Retrieve and display all *non*-*expired valid credit cards*

9.  Sort the *CreditCards* in the *CreditCardList* by card number

10. Display all *CreditCards* in the *CreditCardList*

11. Exit the program

Whenever the user indicates a desire to create a new credit card list, open an
existing credit card list, or exit the program, any currently active lists that
need saving should be saved in a user-specified text file. In implementing your
driver, be sure to handle unexpected cases such as a user asking to **Add** a
**CreditCard** to a list that has never been created or a user asking to
retrieve a **CreditCard** that does not exist.

The driver should use the *OpenFileDialog* and *SaveFileDialog* appropriately to
determine what file to process when the user’s request results in the need to
**open** or **save** a file. The driver should handle all interaction with the
user, but all significant processing should take place in the appropriate one of
the other classes. Make sure that your **Open/SaveFileDialog** opens to the
folder containing your test data by default so one does not have to “guess” in
which folder it is, and **that folder with its test data must be included in
your submission**.

The project may be either a console application or a GUI application. It must
run successfully on the Windows 10 computers used by the instructor and TA.
