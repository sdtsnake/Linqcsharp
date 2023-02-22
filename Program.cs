LinqQueries query = new LinqQueries();
ListAllJson(query.findAll());

void ListAllJson(IEnumerable<Book> ListBooks)
{
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo","N. Pagina","Fecha de publicacion");
    foreach(var item in ListBooks)
    {
        Console.WriteLine("{0,-60} {1, 9} {2, 11}\n",item.Title,item.PageCount,item.PublishedDate.ToShortDateString());
    }

}




