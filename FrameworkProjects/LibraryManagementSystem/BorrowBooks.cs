using System;
using System.Collections.Generic;
class BorrowBooks{
    
    static Dictionary<Member,List<Book>> borrowDetails = new Dictionary<Member,List<Book>>();
    
    public static void AddRecord(Member member,Book book){
        if(!borrowDetails.ContainsKey(member)){
            borrowDetails[member] = new List<Book>();
        }
        borrowDetails[member].Add(book);
    } 
    
    public void ShowAllRecords(){
        Console.WriteLine("\n--- Borrowed Books per Members ----");
        foreach(var entry in borrowDetails){
            Console.WriteLine($"\n{entry.Key.MemberName} borrowed");
            foreach(var book in entry.Value){
                Console.WriteLine($"-{book.Id}| {book.BookName}");
            }
        }
    }
    
}