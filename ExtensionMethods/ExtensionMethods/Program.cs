namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            String post = "King is well aware of how to nourish the Army";
           post.IndexOf(5);
            var result = post.Shorten(5);
            Console.WriteLine(result);
            var book = new Linq().GetBooks();
            var CheaperBooks = from b in book         //link Query Operator
                               where b.Price < 10
                               orderby b.Title
                               select b.Title;
           
            //Linq Extension Methods
            var cheapBook=book.Where(b=>b.Price < 10).ToList().OrderBy(b=>b.Title).Select(b=>b.Title);
            foreach(var boo in cheapBook)
            {
                Console.WriteLine(boo);
            }
            var books=book.LastOrDefault(b=>b.Title== "ASP .NET");
            var maxPrice = book.Max(b => b.Price);
            var minPrice = book.Min(b => b.Price);

            Console.WriteLine(books.Title + " " + books.Price);
        }
    }
    public static class StringExtension
    {

        public static string Shorten(this String str, int numberOfWords)
        {

            if (numberOfWords < 0)
                throw new ArgumentOutOfRangeException("number of words should be more than zero");
            if (numberOfWords == 0) { return ""; }
            var words = str.Split(' ');
            if (words.Length <= numberOfWords) { return str; }
            return string.Join(" ", words.Take(numberOfWords));
        }
    }
}
