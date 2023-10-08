using System.Linq;
using GBGLibrary.Models;

namespace GBGLibrary
{
    internal class Program
    {
        static Library library = new Library();
        static Member Aanya = new Member();

        static void Main(string[] args)
        {
            bool isLoop = false;
            while (!isLoop)
            {
                Console.WriteLine("*******************************");
                Console.WriteLine("Library management system");
                Console.WriteLine("1. Add book");
                Console.WriteLine("2. Checkout Book");
                Console.WriteLine("3. Return book");
                Console.WriteLine("4. View library stats");
                Console.WriteLine("5. Exit");
                Console.WriteLine("*******************************");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        CheckOutBook();
                        break;
                    case 3:
                        ReturnBook();
                        break;
                    case 4:
                        ShowStats();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the menu");
                        isLoop = true;
                        break;


                }

            }

        }

        static void AddBook()
        {
            Console.WriteLine("Add new book");

            Console.WriteLine("Enter book title");
            string title = Console.ReadLine();

            Console.WriteLine("\nEnter book author");
            string author = Console.ReadLine();

            Console.WriteLine("\nEnter ISBN");
            string ISBN = Console.ReadLine();

            Console.WriteLine("\nEnter total copies\n");
            int totalcopies = int.Parse(Console.ReadLine());

            Book newBook = new Book()
            {
                Title = title,
                Author = author,
                ISBN = ISBN,
                TotalCopies = totalcopies,
                AvailableCopies = totalcopies
            };

            library.Books.Add(newBook);
            Console.WriteLine($"A new book {newBook.Title} was added!");
        }

        static void CheckOutBook()
        {
            Console.WriteLine("Enter the book title :");
            string bookTitle = Console.ReadLine();
            foreach (Book item in library.Books)
            {
                if (item.Title == bookTitle)
                {
                    Aanya.CheckoutBook(item);
                }
            }
        }

        static void ReturnBook()
        {
            Console.WriteLine("Enter the book title which you want to return");
            string bookTitle = Console.ReadLine();
            var book = BookToRemove(Aanya.CheckOutBooks, bookTitle);
            Aanya.CheckOutBooks.Remove(book);
            Console.WriteLine($"Book {bookTitle} has been returned successfully.");

        }

        static public Book BookToRemove(List<Book> books, string bookTitle)
        {
            foreach (Book item in Aanya.CheckOutBooks)
            {
                if (item.Title == bookTitle)
                {
                    return item;
                }
            }
            return new Book();
        }

        static void ShowStats()
        {
            library.LibraryStats();
        }


    }



}