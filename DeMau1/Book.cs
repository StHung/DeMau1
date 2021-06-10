using System;
using System.Collections.Generic;
using System.Text;

namespace DeMau1
{
    class Book
    {
        public string Author { get; set; }
        public string Tittle { get; set; }

        public Book()
        {

        }

        public Book(string author, string tittle)
        {
            Author = author;
            Tittle = tittle;
        }

    }
}
