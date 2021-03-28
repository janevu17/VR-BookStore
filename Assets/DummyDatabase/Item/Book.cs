using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book {
    public long isbn;
    public string title;
    public string author;
    public double price;
    public string course;
    public int section;

    public Book(long isbn, string title, string author, double price, string course, int section)
    {
        this.isbn = isbn;
        this.title = title;
        this.author = author;
        this.price = price;
        this.course = course;
        this.section = section;
    }

    public Book(Book book)
    {
        this.isbn = book.isbn;
        this.title = book.title;
        this.author = book.author;
        this.price = book.price;
        this.course = book.course;
        this.section = book.section;

    }

}
