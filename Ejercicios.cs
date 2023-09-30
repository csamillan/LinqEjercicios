public class Ejercicios
{
    private List<Book> BookCollection = new List<Book>();

    public Ejercicios()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.BookCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }

    //Mostrar toda la Colleccion
    public List<Book> TodaLaColeccion()
    {
        return BookCollection.ToList();
    }

    //Mostrar los Libros despues del Año 2000
    public List<Book> EjercicioWhere1()
    {
        return BookCollection.Where(p => p.PublishedDate.Year > 2000).ToList();
    }

    //Mostrar los Libros con mas de 250 paginas y que en su titulo lleven la palabra "in Action"
    public List<Book> EjercicioWhere2()
    {
        return BookCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action")).ToList();
    }

    //Buscar los Libros que contiene la palabra "Python" en su nombre.
    public List<Book> EjercicioWhere3()
    {
        return BookCollection.Where(p => p.Categories.Contains("Python")).ToList();
    }

    //Valida si todos los libros que tiene un valor en el campo Status
    public bool EjercicioAll()
    {
        return BookCollection.All(P => P.Status != string.Empty);
    }

    //Valida si alguno de los libros fue publicado en 1950, (y validamos otra condicion para poner que fue entre 1950 y 2000)
    public bool EjerciciosAny()
    {
        return BookCollection.Any(p => p.PublishedDate.Year > 1950 && p.PublishedDate.Year < 2000);
    }

    //Buscar los libros que en su titulo tenga la palabra "Java" y ordernarlo de manera Asc por titulo
    public List<Book> EjercicioOrderByAsc()
    {
        return BookCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title).ToList();
    }

    //Buscar los libros que contengan mas de 450 paginas y ordernarlos por paginas de manera descendente
    public List<Book> EjercicioOrderByDesc()
    {
        return BookCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount).ToList();
    }

    //Buscar los 3 primeros libros con menor fecha de publicacion que en su titulo contengan la palabra "Java"
    public List<Book> EjercicioTake()
    {
        return BookCollection.Where(p => p.Categories.Contains("Java"))
                                                    .OrderByDescending(p => p.PublishedDate)
                                                    .Take(3)
                                                    .ToList();
    }

    //Mostrar el tercer y cuarto libro con mas de 400 Hojas
    public List<Book> EjercicioSkip()
    {
        return BookCollection.Where(p => p.PageCount > 400)
                                .Take(4)
                                .Skip(2)
                                .ToList();
    }


    //Mostrar solamente el titulo y el numero de paginas de los 3 primeros libros.
    public List<Book> EjercicioSelect()
    {
        return BookCollection.Take(3)
                            .Select(p => new Book() { Title = p.Title, PageCount = p.PageCount })
                            .ToList();

    }

    //este forma de contar es una mala practica
    public int NumeroLibrosEntre200y500Int()
    {
        return BookCollection.Where(p => p.PageCount >= 200 && p.PageCount <= 500).Count();
    }

    public long NumeroLibrosEntre200y500()
    {
        return BookCollection.Where(p => p.PageCount >= 200 && p.PageCount <= 500).LongCount();
    }
    //Forma correcta de contar
    //Contar los libros que tienen entre 200 a 500 paginas
    public int EjerciciosCount()
    {
        return BookCollection.Count(p => p.PageCount >= 200 && p.PageCount <= 500);
    }

    //Long Count es para cuando se tiene un numero muy alto de informacion
    public long EjerciciosLongCount()
    {
        return BookCollection.LongCount(p => p.PageCount >= 200 && p.PageCount <= 500);
    }

    //Buscar la menor fecha de publicacion entre todos los libros
    public DateTime EjercicioMin()
    {
        return BookCollection.Min(p => p.PublishedDate);
    }

    //Buscar el mayor numero de pagina entre todos los libros
    public int EjercicioMax()
    {
        return BookCollection.Max(p => p.PageCount);
    }

    //Buscar el libro con menor cantidad de paginas, pero que estas sean mayores a 0
    public Book EjercicioMinBy()
    {
        return BookCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
    }

    //Buscar el libro con la fecha mas reciente de publicacion
    public Book EjercicioMaxBy()
    {
        return BookCollection.MaxBy(p => p.PublishedDate);
    }

    //Sumar todas las paginas de los libros que tengasn entre 0 a 500 hojas
    public int EjercicioSum()
    {
        return BookCollection.Where(p => p.PageCount >= 0 && p.PageCount <= 500).Sum(p => p.PageCount);
    }

    //Mostrar todos los titulos de los libros que fueron publicados despues del 2015
    public string EjercicioAggregate()
    {
        return BookCollection.Where(p => p.PublishedDate.Year > 2015)
                            .Aggregate("", (TitulosLibros, next) =>
                            {
                                if (TitulosLibros != string.Empty)
                                {
                                    TitulosLibros += " - " + next.Title;
                                }
                                else
                                {
                                    TitulosLibros += next.Title;
                                }

                                return TitulosLibros;
                            });
    }

    //Calcule el promedio de los caracteres que tienen los titulos de todos los libros
    public double EjercicioAverage()
    {
        return BookCollection.Average(p => p.Title.Length);
    }

    //Muestrame los Libros publicados despues del 2000 agrupados por Año
    public List<IGrouping<int, Book>> EjercicioGroupBy()
    {
        return BookCollection.Where(p => p.PublishedDate.Year >= 2000)
                                .GroupBy(p => p.PublishedDate.Year)
                                .ToList();
    }

    //Mostrar un diccionario de libros filtrados por la primera letra del titulo
    public ILookup<char, Book> EjercicioLookup()
    {
        return BookCollection.ToLookup(p => p.Title[0], p => p);
    }

    //Mostrar los Libros publicados despues del 2005 y con mas de 500 paginas
    public List<Book> EjercicioJoin()
    {
        var LibrosDespuesDel2005 = BookCollection.Where(p => p.PublishedDate.Year > 2005);
        var LibrosConMasDe500Pag = BookCollection.Where(p => p.PageCount > 500);

        return LibrosDespuesDel2005.Join(LibrosConMasDe500Pag, p => p.Title, x => x.Title, (p, x) => p).ToList();
    }
}