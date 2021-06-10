using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace DeMau1
{
    class DataProvider
    {
        XmlDocument doc;
        XmlElement root;
        string filename;

        public DataProvider()
        {
            doc = new XmlDocument();
            filename = "Config.xml";
            if (!File.Exists(filename))
            {
                XmlElement rootNode = doc.CreateElement("config");
                doc.AppendChild(rootNode);
                doc.Save(filename);
            }

            doc.Load(filename);
            root = doc.DocumentElement;
        }

        public Account GetAccount()
        {
            Account account = new Account();

            XmlNode usernameNode = root.SelectSingleNode("user");
            XmlNode passwordNode = root.SelectSingleNode("password");

            account.Username = usernameNode.InnerText;
            account.Password = passwordNode.InnerText;

            return account;
        }

        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();

            XmlNodeList nodelist = root.SelectNodes("books/book");

            foreach (XmlNode item in nodelist)
            {
                Book book = new Book();
                book.Author = item.Attributes[0].InnerText;
                book.Tittle = item.Attributes[1].InnerText;
                books.Add(book);
            }
            return books;
        }

        public void AddBook(Book book)
        {
            XmlElement node = doc.CreateElement("book");
            node.SetAttribute("author", book.Author);
            node.SetAttribute("tittle", book.Tittle);

            root.LastChild.AppendChild(node);

            doc.Save(filename);

        }

        public void DeleteBook(string tittle)
        {
            XmlNode node = root.SelectSingleNode($"books/book[@tittle=\'{tittle}\']");
            if (node != null)
            {
                root.LastChild.RemoveChild(node);
                doc.Save(filename);

            }
        }

        public void EditBook(string newAuthor, string newTittle, string keyword)
        {
            XmlNode node = root.SelectSingleNode($"books/book[@tittle=\'{keyword}\']");
            if (node != null)
            {
                XmlNode newNode = node;
                newNode.Attributes[0].InnerText = newAuthor;
                newNode.Attributes[1].InnerText = newTittle;
                root.LastChild.ReplaceChild(newNode, node);
                doc.Save(filename);
            }
        }
    }
}
