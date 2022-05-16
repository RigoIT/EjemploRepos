// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using ImplementacionClases.Utils;

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
            Console.WriteLine("Escogió la opción 1");
            break;
        case "2":
            Console.WriteLine("Escogió la opción 2");
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

static void OpcionInsertar()
{
    /*
     *  int id
        float flujo
        float nivel
        float temperatura
        float voltaje
     */
    Console.WriteLine("bla bla");
    string respuesta = Console.ReadLine();

    // EJEMPLOS DE CONVERSION
    // 1) Cualquier cosa a string
    int i = 5;
    i.ToString();
    0xfb00.ToString(); // hexadecimal a string

    // Utilizando la clase Convert (sirve a varios tipos)
    int convertido = Convert.ToInt32("-100");

    // Conversión explícita
    int test = 12345;
    float conDecimales = (float) test;

    // Conversión implícita
    int otroTest = 123456;
    float otroDecimal = otroTest; //123456.0
   
}