public class LinqQueries
{
    private List<Book> ListBook = new List<Book>();
    private List<BookResume> ListBookResume = new List<BookResume>();
    public LinqQueries(){
        using(StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.ListBook = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions(){PropertyNameCaseInsensitive = true});
            this.ListBookResume = System.Text.Json.JsonSerializer.Deserialize<List<BookResume>>(json, new System.Text.Json.JsonSerializerOptions(){PropertyNameCaseInsensitive = true});
            
        }
    }

    public IEnumerable<Book> findAll()
    {
        return this.ListBook;
    }

    public IEnumerable<Book> BooksAfter2000(){

        // extension de metodo
        //return this.ListBook.Where(p=> p.PublishedDate.Year > 2000);

        //query expresion
        return from l in ListBook where l.PublishedDate.Year > 2000 select l;

    }
    public IEnumerable<Book> BooksPage250WordsInAction(){

        // extension de metodo
        // return this.ListBook.Where(p=> p.PageCount>250 && p.Title.Contains("in Action"));


        //query expresion
        return from l in ListBook where l.PageCount > 250 && l.Title.Contains("in Action") select l;

    }

    public bool BooksAllHaveStatus(){

        return ListBook.All(p=> p.Status != string.Empty); 

    }

    public bool BookAnyYear2005(){
        return ListBook.Any(p=> p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> BooksAllPyton(){

        return ListBook.Where(p=> p.Categories.Contains("Python"));

    }

    public IEnumerable<Book> BooksJavaAsend(){
        return ListBook
        .Where(p=> p.Categories.Contains("Java"))
        .OrderBy(p=> p.Title);

    }
    
    public IEnumerable<Book> BooksPages450Desend(){
        return ListBook.Where(p=> p.PageCount>450)
        .OrderByDescending(p=> p.PageCount);

    }

    public IEnumerable<Book> ThreeBooksJavaDateAsend(){
        return ListBook
        .Where(p=> p.Categories
        .Contains("Java"))
        .OrderByDescending(p=> p.PublishedDate)
        .Take(3);

    }

    public IEnumerable<Book> ThreeAndFourBookMorePage400(){

        return ListBook
        .Where(p=> p.PageCount > 400)
        .Take(4)
        .Skip(2);
    }

    public IEnumerable<BookResume> ThreeBooks(){

        return ListBookResume.Take(3)
        .Select(p=> new BookResume() {Title = p.Title, PageCount = p.PageCount});
    }

    public int QuantyBooks200and500Pages(){
        //return ListBook.Where(p=> p.PageCount>= 200 && p.PageCount<=500).Count();
        return ListBook.Count(p=> p.PageCount>= 200 && p.PageCount<=500);
    }

    public DateTime ShortestPublicationDate(){
        return ListBook.Min(p=> p.PublishedDate);
    }

    public int MaxPageBook(){
        return ListBook.Max(p=> p.PageCount);
    }

    public Book LessPagesBook(){

        return ListBook.Where(p=> p.PageCount>0).MinBy(p=> p.PageCount);
    }

    public Book MostRescentPublicationDateBook(){
        return ListBook.MaxBy(p=> p.PublishedDate);
    }  
    public int SumPageBooksBetweenCeroAndFiveHundredPages(){
        return ListBook.Where(p=> p.PageCount>0 && p.PageCount<=500).Sum(p=> p.PageCount);
    }  

    public string TitleBooksAfter2015(){
        return ListBook.Where(p=> p.PublishedDate.Year > 2015)
        .Aggregate("", (TitulosLibros, next) =>{
            if(TitulosLibros != string.Empty)
                TitulosLibros += " - " + next.Title;
            else
                TitulosLibros += next.Title;

            return TitulosLibros;
        });
    }

    public double AverageTitleChars(){

        return ListBook.Average(p=> p.Title.Length);
    }

    public IEnumerable<IGrouping<int,Book>> BookBefore2000GrupByYear(){

        return ListBook.Where(p=> p.PublishedDate.Year>=2000).GroupBy(p=> p.PublishedDate.Year);
    }

    public ILookup<char, Book> BooksByCharInitTitle(){
        return ListBook.ToLookup(p=> p.Title[0], p=> p);
    }

    public IEnumerable<Book> BooksAfter2005PageMore500(){

        var BooksAfter2005 = ListBook.Where(p=> p.PublishedDate.Year > 2005);

        var BooksMore500 = ListBook.Where(p=> p.PageCount > 500);

        return BooksAfter2005.Join(BooksMore500,P=>P.Title,x=> x.Title,(p,x)=>p);


    }





}