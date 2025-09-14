using System;
using System.Collections.Generic;
class Book{
    private static int counter = 1;
    private int id ;
    private string bookName;
    
    
    public int Id{
        get{ return id; }
         set{ id = value; }
    }
    public string BookName{
        get{ return bookName;}
        set{ bookName = value;}
    }
    
    public Book(string bookName){
        id = counter++;
        this.bookName = bookName;
        // Console.WriteLine(counter);
    }
    public override string ToString(){
        return $"Book_Id: {id} | Book_Name: {bookName}";
    }
}


