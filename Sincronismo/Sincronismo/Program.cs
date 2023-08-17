using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncBreakfast
{    
    internal class Bacon { }
    internal class Coffee { }
    internal class Egg { }
    internal class Juice { }
    internal class Toast { }

    class Program
    {
        static async Task Main(string[] args)
        {
            Coffee cup = ServirCafe();
            Console.WriteLine("El café está listo");

            var huevosTask = CocinarHuevosAsync(2);
            var pancetaTask = CocinarPancetaAsync(3);
            var tostadaTask = HacerTostadaAsync(2);

            var desayunoTasks = new List<Task> { huevosTask, pancetaTask, tostadaTask };
            while (desayunoTasks.Count > 0)
            {
                Task finalizadaTask = await Task.WhenAny(desayunoTasks);
                if (finalizadaTask == huevosTask)
                {
                    Console.WriteLine();
                    Console.WriteLine("Los huevos están listos !!!");
                    Console.WriteLine();
                }
                else if (finalizadaTask == pancetaTask)
                {
                    Console.WriteLine();
                    Console.WriteLine("La panceta está lista !!!");
                    Console.WriteLine();
                }
                else if (finalizadaTask == tostadaTask)
                {
                    Console.WriteLine();
                    Console.WriteLine("La tostada está lista !!!");
                    Console.WriteLine();
                }
                desayunoTasks.Remove(finalizadaTask);
            }

            Juice oj = ServirJugo();
            Console.WriteLine("Jugo de naranja está listo");

            Console.WriteLine();
            Console.WriteLine("El desayuno está listo !!");
        }

        static async Task<Toast> HacerTostadaAsync(int number)
        {
            var toast = await TostarPanAsync(number);
            PonerManteca(toast);
            PonerMermelada(toast);

            return toast;
        }

        private static Juice ServirJugo()
        {
            Console.WriteLine("Sirviendo Jugo de Naranja");
            return new Juice();
        }

        private static void PonerMermelada(Toast toast) =>
            Console.WriteLine("Poniendo mermelada en la tostada");

        private static void PonerManteca(Toast toast) =>
            Console.WriteLine("Poniendo manteca en la tostada");

        private static async Task<Toast> TostarPanAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Poniendo una rodaja de pan en la tostadora");
            }
            Console.WriteLine("Tostando el pan...");
            await Task.Delay(3000);
            Console.WriteLine("Retirar tostada de la tostadora");

            return new Toast();
        }

        private static async Task<Bacon> CocinarPancetaAsync(int slices)
        {
            Console.WriteLine($"Agregando {slices} fetas de panceta a la sartén");
            Console.WriteLine("Cocinando un lado de la panceta...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Dando vuelta la feta de panceta");
            }
            Console.WriteLine("Cocinando el otro lado de la panceta...");
            await Task.Delay(3000);
            Console.WriteLine("Servir panceta");

            return new Bacon();
        }

        private static async Task<Egg> CocinarHuevosAsync(int howMany)
        {
            Console.WriteLine("Calentar el agua para los huevos...");
            await Task.Delay(1000);
            Console.WriteLine($"Rompiendo {howMany} huevos");
            Console.WriteLine("Cocinando huevos ...");
            await Task.Delay(7000);
            Console.WriteLine("Servir huevos");

            return new Egg();
        }

        private static Coffee ServirCafe()
        {
            Console.WriteLine("Sirviendo Café");
            return new Coffee();
        }
    }
}