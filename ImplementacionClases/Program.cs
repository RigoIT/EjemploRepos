// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using ImplementacionClases.Utils;
using ImplementacionClases.DTO; // Import para usar clases desde DTO
using ImplementacionClases.DAL; // Import para usar clases desde DAL

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
    Console.WriteLine("3) Actualizar datos");
    Console.WriteLine("4) Eliminar datos");
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
            Console.WriteLine("Insertar un nuevo dato");
            OpcionInsertar();
            break;
        case "3":
            Console.WriteLine("Actualizar un dato existente");
            OpcionActualizar();
            break;
        case "4":
            Console.WriteLine("Eliminar un dato existente");
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

static void OpcionActualizar()
{
    DatoDAL datoDAL = new DatoDAL();

    // Tarea 1: Consultar por el ID a buscar
    Console.WriteLine("Ingrese un ID a buscar");
    string opcion = Console.ReadLine().Trim(); // " A " => "A"

    try
    {
        // Tarea 2: Buscar el ID ingresado
        DatoDTO resultado = datoDAL.BuscarPorId(int.Parse(opcion));

        if (resultado != null) // si encontró efectivamente
        {
            // Tarea 3: Consultar al usuario qué se desea actualizar
            Console.WriteLine("¿Desea actualizar la temperatura? (Y/N)");
            string opcionTemperatura = Console.ReadLine().Trim();
            if (opcionTemperatura.ToUpper() == "Y")
            {
                Console.WriteLine($"Ingrese temperatura nueva: (actual: {resultado.Temperatura})");
                string nuevaTemperatura = Console.ReadLine().Trim();
                resultado.Temperatura = float.Parse(nuevaTemperatura);
            }

            Console.WriteLine("¿Desea actualizar el flujo? (Y/N)");
            string opcionFlujo = Console.ReadLine().Trim();
            bool editarFlujo = opcionFlujo.ToUpper() == "Y";
            if (opcionFlujo.ToUpper() == "Y")
            {
                Console.WriteLine($"Ingrese flujo nuevo: (actual: {resultado.Flujo})");
                string nuevoFlujo = Console.ReadLine().Trim();
                resultado.Flujo = float.Parse(nuevoFlujo);
            }

            Console.WriteLine("¿Desea actualizar el nivel? (Y/N)");
            string opcionNivel = Console.ReadLine().Trim();
            bool editarNivel = opcionNivel.ToUpper() == "Y";
            if (opcionNivel.ToUpper() == "Y")
            {
                Console.WriteLine($"Ingrese nivel nuevo: (actual: {resultado.Nivel})");
                string nuevoNivel = Console.ReadLine().Trim();
                resultado.Nivel = float.Parse(nuevoNivel);
            }

            Console.WriteLine("¿Desea actualizar el voltaje? (Y/N)");
            string opcionVoltaje = Console.ReadLine().Trim();
            bool editarVoltaje = opcionVoltaje.ToUpper() == "Y";
            if (opcionVoltaje.ToUpper() == "Y")
            {
                Console.WriteLine($"Ingrese voltaje nuevo: (actual: {resultado.Voltaje})");
                string nuevoVoltaje = Console.ReadLine().Trim();
                resultado.Voltaje = float.Parse(nuevoVoltaje);
            }

            // Tarea 4: Publicar objeto de cambio
        } 
        else // si no encontró elementos con ese ID
        {

        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Debe escribir un número válido");        
    }
    finally
    {
        Console.WriteLine("Opción de actualizar terminada");
    }
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