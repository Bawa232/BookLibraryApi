using BookLibraryApi.Models;

namespace BookLibraryApi.Data
{
    public static class BookStore
    {
        public static  List<Book> BookList = new List<Book>
        {
            new Book{  Id = 1, Title = "Things Fall Apart", Author = "Chinua Achebe", ISBN = "9780743273565", PublishedDate = new DateTime(1925, 4, 10), Price = 10.99m },
            new Book{ Id = 2, Title = "Joys Of Motherhood", Author = "Buchi Emecheta", ISBN = "9846274465736", PublishedDate = new DateTime(1962, 3, 3), Price = 9.10m }
        };
    }
}
