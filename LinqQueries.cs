public class LinqQueries
{
    private List<Book> ListBook = new List<Book>();
    public LinqQueries(){
        using(StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.ListBook = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions(){PropertyNameCaseInsensitive = true});
            
        }
    }

    public IEnumerable<Book> findAll()
    {
        return this.ListBook;
    }

}