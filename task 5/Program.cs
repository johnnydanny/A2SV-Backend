namespace Lib
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public Book (string title, string author, string isbn, int publicationYear)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            PublicationYear = publicationYear;
        }

    }
    class MediaItem 
    {
        public string Title { get; set; }
        public string MediaType { get; set; }
        public int Duration { get; set; }
        public MediaItem (string title, string mediaType, int duration) 
        {
            Title = title;
            MediaType = mediaType;
            Duration = duration;
        }
    }

    class Library 
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Book>Books {get; private set; }
        public List<MediaItem>MediaItems {get; private set; }

        public Library (string name, string address) 
        {
            Name = name;
            Address = address;
            Books = new List<Book>();
            MediaItems = new List<MediaItem>();
        }

        public void AddBook (Book book)
        {
            Books.Add(book);
            Console.WriteLine($"Added {book.Title} to the book collection");
        }

        public void RemoveBook (Book book) 
        {
            if (Books.Contains(book)) 
            {
                Books.Remove(book);
                Console.WriteLine($"Removed {book.Title} from the book collection");
            }
            else
            {
                Console.WriteLine($"Cannot find {book.Title}");
            }
        }

        public void AddMediaItem(MediaItem item)
        {
            MediaItems.Add(item);
            Console.WriteLine($"Added {item.Title} to media collection");
        }

        public void RemoveMediaItem (MediaItem mediaItem) 
        {
            if (MediaItems.Contains(mediaItem))
            {
                MediaItems.Remove(mediaItem);
                Console.WriteLine($"Removed {mediaItem.Title} from the media collection");
            }
            else
            {
                Console.WriteLine($"Cannot find {mediaItem.Title} in the media collection");
            }
        }

        public void PrintCatalog()
        {
            Console.WriteLine($"\nLibrary Name: {Name}");
            Console.WriteLine($"Library Address: {Address}");

            Console.WriteLine("\nBooks in Catalog:\n");
            foreach (var book in Books)
            {
                Console.WriteLine($"""
                    Title : {book.Title}
                    ISBN  : {book.ISBN}
                    Year  : {book.PublicationYear}

                """);
            }

            Console.WriteLine("\nMedia Items in Catalog:\n");
            foreach (var item in MediaItems)
            {
                Console.WriteLine($""" 
                    Title : {item.Title}
                    MediaType: {item.MediaType}
                    Duration :  {item.Duration} minutes

                """);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Library library = new Library("JohnDman", "154 vinland st.");

            Book book1 = new Book("Purple hibiscus", "Chimanmanda Adichie", "ISBN-111", 1999);
            Book book2 = new Book("Half a yellow sun", "Chimanmanda Adichie", "ISBN-234", 2000);

            MediaItem mediaItem1 = new MediaItem("Documentary 1", "DVD", 200);
            MediaItem mediaItem2 = new MediaItem("Documentary 2", "CD", 250);

            // add books
            library.AddBook(book1);
            library.AddBook(book2);

            // add mediaItems
            library.AddMediaItem(mediaItem1);
            library.AddMediaItem(mediaItem2);

            // print
            library.PrintCatalog();

            // remove items
            library.RemoveBook(book1);
            library.RemoveMediaItem(mediaItem1);

            // print updated version
            library.PrintCatalog();
            
            // remove all
            library.RemoveBook(book2);
            library.RemoveMediaItem(mediaItem2);
            
            // print updated version
            library.PrintCatalog();
        }
    }
}