LinqQueries query = new LinqQueries();

// Todos lo libros
//ListBooks(query.findAll());

//Libros despues del 2000
//ListBooks(query.BooksAfter2000());

//Libros con 250 paginas y con in Action en el titulo
//ListBooks(query.BooksPage250WordsInAction());

//Si todos los libros tienen status
//Console.WriteLine($"Todos los libros tiene estatus ? {query.BooksAllHaveStatus()}");

//Si algun libro publicado en 2005
//Console.WriteLine($"Algun libro publicado en 2005 ? {query.BookAnyYear2005()}");


//Todos los libros de pyton
//ListBooks(query.BooksAllPyton());

//Libros de java odenados por nombre
//ListBooks(query.BooksJavaAsend());

//Libros de mas de 450 paginas y ordenado desendente
//ListBooks(query.BooksPages450Desend());

//Los tres primero libros de java ordenados por fecha asendente
//ListBooks(query.ThreeBooksJavaDateAsend());

//Los libros que superan 400 paginas  el 3 y el 4
//ListBooks(query.ThreeAndFourBookMorePage400());

//Tres primero libros de la coleccion
//ListBooksResume(query.ThreeBooks());

//numero de libros entre 400 y 500 paginas
//Console.WriteLine($"Numero de libros con paginas entre 400 y 500 {query.QuantyBooks200and500Pages()}");

//Libro con la fecha de publicacon mas antigua
//Console.WriteLine($"La fehca del libro mas antiguo en publicarse es ? {query.ShortestPublicationDate().ToShortDateString()}");

//Libro con mayor numero de paginas
//Console.WriteLine($"Libro con mas numero de paginas ? {query.MaxPageBook()}");

// El libro con el menor numero de paginas.
//var bookLessPages = query.LessPagesBook();
//Console.WriteLine($"{bookLessPages.Title} - {bookLessPages.PageCount}");

// El libro con fecha de publicacion mas reciente
//var bookMorePages = query.MostRescentPublicationDateBook();
//Console.WriteLine($"{bookMorePages.Title} - {bookMorePages.PublishedDate.ToShortDateString()}");

// Sumatoria de las paginas de libros con menos de 500 paginas
//Console.WriteLine($"Total del numero de paginas de los libros inferiores de 500 paginas ? {query.SumPageBooksBetweenCeroAndFiveHundredPages()}");

//Titulos de libros con fecha de publicacion mayor a 2015
//Console.WriteLine($"Libros con fecha de publicacion superior a 2015 :  {query.TitleBooksAfter2015()}");

//Promedios de caracteres por titulos de los libros
//Console.WriteLine($"Promedio de caracteres por titulos :  {query.AverageTitleChars()}");

//Libros publicados despues de 2000 agrupado por año
//ListBookGrup(query.BookBefore2000GrupByYear());

//Libros por el primer caracter
//var LookupBooks = query.BooksByCharInitTitle();
//ListBookLookup(LookupBooks,'B');


// Libros con fecha de publicacion mayor a 2005 y con mas de 500 pagina joins    
ListBooks(query.BooksAfter2005PageMore500());




void ListBookLookup(ILookup<char,Book> ListBooks, char word){

    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo","N. Pagina","Fecha de publicacion");
    foreach(var item in ListBooks[word])
    {
        Console.WriteLine("{0,-60} {1, 9} {2, 15}",item.Title,item.PageCount,item.PublishedDate.ToShortDateString());
    }
}

void ListBookGrup(IEnumerable<IGrouping<int,Book>> ListBooks){
    foreach(var group in ListBooks){
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {group.Key}");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo","N. Pagina","Fecha de publicacion");
        foreach(var item in group){
        
        Console.WriteLine("{0,-60} {1, 9} {2, 15}",item.Title,item.PageCount,item.PublishedDate.ToShortDateString());
        }
    }
}

void ListBooks(IEnumerable<Book> ListBooks)
{
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo","N. Pagina","Fecha de publicacion");
    foreach(var item in ListBooks)
    {
        Console.WriteLine("{0,-60} {1, 9} {2, 15}",item.Title,item.PageCount,item.PublishedDate.ToShortDateString());
    }

}

void ListBooksResume(IEnumerable<BookResume> ListBooksResume)
{
    Console.WriteLine("{0,-60} {1, 15} \n", "Titulo","N. Pagina");
    foreach(var item in ListBooksResume)
    {
        Console.WriteLine("{0,-60} {1, 9}",item.Title,item.PageCount);
    }

}


