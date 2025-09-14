using System;
using System.Collections.Generic;

class HelloWorld {
  static void Main() {
    
    Book b1 = new Book("Money");
    Book b2 = new Book("Cat");
    Book b3 = new Book("Data Structures and Algo");
    Book b4 = new Book("Programming in Java");
    Book b5 = new Book("Biography for Pandu");
    Librarian l1 = new Librarian();
    l1.AddBook(b1);
    l1.AddBook(b2);
    l1.AddBook(b3);
    l1.AddBook(b4);
    l1.AddBook(b5);
    l1.BooksDetails();
    Console.WriteLine("====================================");
    
    Member m1 = new Member("Pandu");
    m1.BorrowBook(b5,l1);
    m1.BorrowBook(b2,l1);
    m1.BorrowBook(b3,l1);
    Console.WriteLine("====================================");
    m1.DisplayMyBooks();
    Member m2 = new Member("Saravana");
    m2.BorrowBook(b1,l1);
    m2.BorrowBook(b2,l1);
    m2.BorrowBook(b3,l1);
    Member m3 = new Member("Santhosh");
    m3.BorrowBook(b2,l1);
    m3.BorrowBook(b4,l1);
    m3.BorrowBook(b3,l1);
    BorrowBooks bb = new BorrowBooks();
    bb.ShowAllRecords();
    
    
    
    
    
  }
}