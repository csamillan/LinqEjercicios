class Program
{
    public static void Main(string[] args)
    {
        Ejercicios querys = new Ejercicios();

        //PrintValues(querys.EjercicioOrderByAsc());
        
        //Console.WriteLine($"Los Libros: {(querys.EjercicioAggregate())} ");

        //PrintGroup(querys.EjercicioGroupBy());

        printDictionary(querys.EjercicioLookup(),'a');
    }

    public static void PrintValues(List<Book> ListBooks)
    {
        Console.WriteLine("{0 , -70} {1, 7} {2 , 11} \n", "Titulo", "N. Paginas", "Fecha Publicacion");

        foreach (var item in ListBooks)
        {
            Console.WriteLine("{0 , -70} {1, 7} {2 , 11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
        }
    }

    public static void PrintGroup(List<IGrouping<int, Book>> ListadeLibros)
    {
        foreach (var grupo in ListadeLibros)
        {
            Console.WriteLine("");
            Console.WriteLine($"Grupo: {grupo.Key}");
            Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
            foreach (var item in grupo)
            {
                Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
            }
        }
    }

    public static void printDictionary(ILookup<char, Book> listBooks, char letter)
    {
        char letterUpper = Char.ToUpper(letter);
        if (listBooks[letterUpper].Count() == 0)
        {
            Console.WriteLine($"No hay libros que inicien con la letra '{letterUpper}'");
        }
        else
        {
            Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Título", "Nro. Páginas", "Fecha de Publicación");
            foreach (var book in listBooks[letterUpper])
            {
                Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
            }
        }
    }

}