using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР2
{
    internal class Library
    {
        public static Dictionary<Reader,Book> BR = new Dictionary<Reader,Book>();
        public static List<Reader> readers = new List<Reader>();
        public static List<Book> books = new List<Book>();
        public static Library Initial()
        {
            var res=new Library();
            var book= new Book();
            book.author = "Korotkova A.C.";
            book.genre = Genre.Detectiv;
            book.kode = "001";
            book.name = "C# KODE";
            book.condition = Condition.OffHand;
            books.Add(book);

            book = new Book();
            book.author = "Putnikov B.S.";
            book.genre = Genre.Roman;
            book.kode = "002";
            book.name = "New way";
            book.condition = Condition.OnHand;
            books.Add(book);
            return res;
        }

        public void GetBook(int kod, Reader reader)
        {
            Book pBook=null;
            foreach (Book book in books)
            {
                if (int.Parse(book.kode) == kod)
                {
                    pBook = book;
                }
            }
            if(pBook != null)
            {
                if (pBook.condition.Equals(Condition.OffHand))
                {
                    pBook.condition = Condition.OnHand;
                    BR.Add(reader, pBook);
                    Console.WriteLine("Выдача книги зафиксирована");
                }
                else
                {
                    Console.WriteLine("Книга занята!");
                }
            }
            else
            {
                Console.WriteLine("Книги с таким кодом нет");
            }
        }

        public void ListBooks()
        {
            if (books.Count != 0)
            {
                foreach (Book book in books)
                {
                    Console.WriteLine(book.kode+"\n"+book.name+ "\n" + book.author+ "\n" + book.genre+ "\n" + book.condition);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Список книг пуст");
            }
        }
    }
}
