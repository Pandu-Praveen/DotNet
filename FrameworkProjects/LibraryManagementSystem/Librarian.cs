using System;
using System.Collections.Generic;
class Librarian{
    private List<Book> books;
    
    public Librarian(){
        books = new List<Book>();
    }
    
    public void AddBook(Book currBook){
        books.Add(currBook);
        
    }
    public void BooksDetails(){
        if(books.Count!=0){
            foreach(Book b in books){
                Console.WriteLine(b);
            }
        }
        else{
            Console.WriteLine("No Books Available in the library");
        }
    }
    public Book GiveBookToMember(Member member , Book book){
        var b = books.Find(i=> book.Id==i.Id);
        //  Console.WriteLine(book.Id+" "+b);
        if(b!=null){
            Console.WriteLine($"Book {book.Id} issued to Member {member.Id} :-)");
            BorrowBooks.AddRecord( member, book);
            return book;
        }
        else{
            Console.WriteLine("Sorry! the book is not Available.");
            return null;
        }
        
    }
}



