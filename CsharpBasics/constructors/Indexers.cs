using System;

public class Library
{
    private string[] books = new string[5];

    // Indexer
    public string this[int index]
    {
        get
        {
            return books[index];
        }

        set
        {
            books[index] = value;
        }
    }
}