using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBGLibrary.Models
{
    //2a
    internal class Member : LibraryUser
    {
        //2b
        public  string Address {  get; set; }
        public List<Book> CheckOutBooks { get; set; } = new List<Book>();

        //7a.
        public  int OverDueFees { get; set; }  
        
        //6.
        public void CheckoutBook(Book book)
        {
            if(book.AvailableCopies > 0)
            {
                book.AvailableCopies--;
                CheckOutBooks.Add(book);
                Console.WriteLine($"{book.Title} book has been checked out successfully.");
            }
            else
            {
                Console.WriteLine($"Sorry all the copies {book.Title} are currently checked out");
            }
        }
        public void ReturnBook(Book book)
        {
            if (CheckOutBooks.Contains(book))
            {
                CheckOutBooks.Remove(book);
                book.AvailableCopies++;
                Console.WriteLine($"{book.Title} book has been returned successfully");
            }
            else 
            {
                Console.WriteLine($"The book {book.Title} was not checked out by this member");
            }

        }

        public void ViewTransactionHistory(Library library , Member member)
        {
            List<Transactions> membersTransactions = new List<Transactions>();
            foreach(Transactions transaction in library.Transactions)
            {
                if(transaction.Member.ID== ID)
                {
                    membersTransactions.Add(transaction);
                }
            }
            Console.WriteLine($"Transactions for member {Name}");
            if( membersTransactions.Count > 0)
            {
                foreach(Transactions transaction in membersTransactions)
                {
                    string returnDateString;
                    if (transaction.ReturnDate.HasValue)
                    {
                        returnDateString = transaction.ReturnDate.Value.ToString();
                    }
                    else
                    {
                        returnDateString = "Not returned";
                    }
                    Console.WriteLine($"Book: {transaction.Book.Title}, Issue Date {transaction.IssueDate.ToString()}, Returned Date: {returnDateString}");
                }
            }
            else
            {
                Console.WriteLine("No transactions found");
            }
        }
    }
}
