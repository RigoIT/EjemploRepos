// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using ImplementacionClases.Utils;
using ImplementacionClases.DTO; // Import para usar clases desde DTO
using ImplementacionClases.DAL; // Impor para usar clases desde DAL

// Ejemplo de Clase estática:
// Console.WriteLine(ConsoleUtils.Saludar("Enrique"));

/* 
 * Ejemplo de escritura por línea y por palabra(s)
 * Console.Write("Hola");
Console.Write(" Mundo"); */

/* Ejemplo de cambios de colores en consola 
Console.BackgroundColor = ConsoleColor.DarkGray;
Console.ForegroundColor = ConsoleColor.Green;
 */

/* Ejemplo Entrada / salida consola 
Console.Write("Escribe un nombre: ");
string nombre = Console.ReadLine();
Console.WriteLine($"Ha escrito {nombre}"); */

while (Menu())
{
    Console.ReadKey(); // pausa, solicitar la entrada de una tecla
}

static bool Menu()
{
    bool continuar = true;

    Console.Clear(); // Limpia la pantalla
    Console.Title = "Ejercicio Menú + Clases";

    Console.WriteLine("Menú de opciones");
    Console.WriteLine("================");
    Console.WriteLine("1) Listar datos");
    Console.WriteLine("2) Agregar datos");
    Console.WriteLine("");
    Console.WriteLine("0) Salir");

    string opcion = Console.ReadLine().Trim(); // " 1 " => "1"

    switch (opcion)
    {
        case "1":
            Console.WriteLine("Listado de datos registrados");
            OpcionListar();
            break;
        case "2":
            // Console.WriteLine("Escogió la opción 2");
            OpcionInsertar();
            break;
        case "0":
            Console.WriteLine("Saliendo del programa ...");
            continuar = false;
            break;
        default:
            Console.WriteLine("Opción no válida");
            break;
    }
    
    return continuar;
}

static void OpcionListar()
{
    DatoDAL datoDAL = new DatoDAL(); // Llamar a capa de acceso a datos

    List<DatoDTO> datos = new List<DatoDTO>(); // crear una lista para obtener los datos

    datos = datoDAL.Listar(); // obtener lista desde capa de acceso a datos

    // recorrer y mostrar datos de cada elemento de lista
    foreach (DatoDTO dato in datos)
    {
        Console.WriteLine("----------------------------------------------------------");
        Console.Write($"Id: {dato.Id} - ");
        Console.Write($"Flujo: {dato.Flujo} - ");
        Console.Write($"Temperatura: {dato.Temperatura} - ");
        Console.Write($"Nivel: {dato.Nivel} - ");
        Console.Write($"Voltaje: {dato.Voltaje}\n");
    } 
}

static void OpcionInsertar()
{
    /*
     *  int id
        float flujo
        float nivel
        float temperatura
        float voltaje
     */

    // Crearemos una instancia de DatoDAL
    DatoDAL datoDAL = new DatoDAL();

    try
    {
        Console.WriteLine("Ingrese el ID:");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese valor de temperatura:");
        float temperatura = float.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese valor de flujo:");
        float flujo = float.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese valor de nivel:");
        float nivel = float.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese valor de voltaje:");
        float voltaje = float.Parse(Console.ReadLine());

        // Crea el objeto
        DatoDTO nuevoIngresoDato = new DatoDTO() 
        { 
            Id = id, 
            Flujo = flujo,
            Nivel = nivel,
            Temperatura = temperatura,
            Voltaje = voltaje
        };

        // Intentamos ingresar y verificar operación
        if(datoDAL.Insertar(nuevoIngresoDato))
        {
            // si resulta OK
            Console.WriteLine($"Se ha insertado un nuevo dato");
        } 
        else
        {
            Console.WriteLine($"No se ha podido insertar el nuevo dato");
        }


    }
    catch (Exception)
    {
        Console.WriteLine("Ingrese correctamente los datos e intente otra vez");
    }
     
}