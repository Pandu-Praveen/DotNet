using System;
using System.Collections.Generic;
class Member{
    
    List<Book> myBooks;
    private static int memCounter = 1;
    private int id;
    private string memberName;
    
    public int Id{
        get{ return id; }
        set{ id = value; }
    }
    
    public string MemberName{
        get{ return memberName; }
        set{ memberName = value; }
    }
    
    
    public Member(string memberName){
        id = memCounter++;
        this.memberName = memberName;
        myBooks = new List<Book>();
    }
    
    public void BorrowBook(Book book,Librarian librarian){
        
        Book myBook = librarian.GiveBookToMember(this,book);
        if(myBook!=null){
            myBooks.Add(myBook);
        }
        // else{
        //     Console.WriteLine("There is problem in getting a book");
        // }
    }
    
    public void DisplayMyBooks(){
        if(myBooks.Count!=0){
            foreach(Book book in myBooks){
                Console.WriteLine(book);
            }
        }
        else{
            Console.WriteLine("You have No books yet!");
        }
    }
}




