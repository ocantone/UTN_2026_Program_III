/*===============================================================================
PROGRAMACIÓN III Conexión Lineal a MySQL 
 
 ⚠️ Antes de correr el proyecto, se debe instalar el driver de MySQL.
 En VSCode ejecutar este comando por terminal:
 dotnet add package MySql.Data --source https://api.nuget.org/v3/index.json
En Visual Studio (Comunity, etc):
Ir a: Herramientas > Administrador de Paquetes NuGet > Administrar paquetes NuGet > MyDql.Data
===============================================================================*/
using System;
// Importamos los componentes del driver de MySQL.
using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;
using MySqlCommand = MySql.Data.MySqlClient.MySqlCommand;
using MySqlDataReader = MySql.Data.MySqlClient.MySqlDataReader;
using System.Diagnostics;

namespace ListaBDAlumnos
{
    class Conexion
    {   
        public static MySqlConnection Conectar()
        {   string  connectionString  = "Server=127.0.0.1;";
                    connectionString += "Port=3306;";
                    connectionString += "Database=prog3n3;";
                    connectionString += "Uid=root;";
                    connectionString += "Pwd=root;";
            Console.WriteLine("Intentando conectar a la base de datos MySQL...");
           return new MySqlConnection(connectionString);
        }
    }
    class Menu
    {
        
    }
    class Consulta
    {
        
    }

    class Program
    {   
        static string MuestraMenu()
        {   string opcion;
            Console.WriteLine("CONSULTA DE ALUMNOS:");
            Console.WriteLine("1. Ver Alumnos Turno Mañana");
            Console.WriteLine("2. Ver Alumnos Turno Noche");
            Console.WriteLine("\n3.SALIR");

            return opcion = Console.ReadLine()??"";
        }
        static void ConsultaYMuestra(string consulta, MySqlConnection conn)
        {
                    using (MySqlCommand comando = new MySqlCommand(consulta, conn))
                    {
                        using (MySqlDataReader lector = comando.ExecuteReader())
                        {
                            Console.WriteLine("==========================================================================================================");
                            Console.WriteLine("                                           LISTADO DE ALUMNOS (LINEAL)                                    ");
                            Console.WriteLine("==========================================================================================================");
                            Console.WriteLine(string.Format("{0,-10} | {1,-12} | {2,-12} | {3,-32} | {4,-22} | {5,-8}", 
                                "Legajo", "Nombre", "Apellido", "Email", "Carrera", "Turno"));
                            Console.WriteLine("----------------------------------------------------------------------------------------------------------");

                            // Bloque iterativo: leemos fila por fila mientras el lector tenga datos
                            while (lector.Read())
                            {
                                string legajo = lector["legajo"].ToString()??"";
                                string nombre = lector["nombre"].ToString()??"";
                                string apellido = lector["apellido"].ToString()??"";
                                string email = lector["email"].ToString()??"";
                                string carrera = lector["carrera"].ToString()??"";
                                string turno = lector["turno"].ToString()??"";

                                Console.WriteLine(string.Format("{0,-10} | {1,-12} | {2,-12} | {3,-32} | {4,-22} | {5,-8}", 
                                    legajo, nombre, apellido, email, carrera, turno));
                                //paro la app al leer cada registro para ver la conexión abierta.
                                //Console.ReadLine();
                            }
                            Console.WriteLine("==========================================================================================================\n");
                            
                        }
                    }
        }
        static void Main(string[] args)
        {
            bool salir = false;
            string consulta = "SELECT legajo, nombre, apellido, email, carrera, turno FROM alumnos";

            // Cadena de conexión.
            MySqlConnection conn = Conexion.Conectar();
            // Abrimos la conexión asegurando el cierre de recursos con 'using'.
            using (conn)
            { //conexion es un OJETO que prepara el canal TCP para conectar al servidor MySql.
                try
                {
                    conn.Open(); //Aquí es dónde la conexión se abre. (Se cierra gracias a using)
                    // Biri Biri
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("¡Conexión exitosa al servidor de MySQL!\n");
                    Console.ResetColor();

                    ConsultaYMuestra(consulta, conn);
        
                    while (!salir)
                    {
                        switch ( MuestraMenu() )
                        {
                            case "1": consulta = "SELECT legajo, nombre, apellido, email, carrera, turno FROM alumnos WHERE turno = 'mañana'"; break;
                            case "2": consulta = "SELECT legajo, nombre, apellido, email, carrera, turno FROM alumnos WHERE turno = 'noche'"; break;
                            case "3": salir = true; break;
                        }
                        if(!salir) ConsultaYMuestra(consulta, conn);
                    
                    }
            
                }
                catch (Exception ex)
                {
                    // Control de errores ante fallas de red, credenciales o servidor apagado
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ocurrió un error al intentar operar con la base de datos:");
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }  //cierra conexión.

            
        

            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}