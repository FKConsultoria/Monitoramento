using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoMonitoramento
{
    class Program
    {
        static void Main(string[] args)
        {
            //Processador CPU
            var processadorCategory = PerformanceCounterCategory.GetCategories()
                .FirstOrDefault(cat => cat.CategoryName == "Processor");
            var contadorProcessadorCategoria = processadorCategory.GetCounters("_Total");

            VisualizarDados(contadorProcessadorCategoria.First(cnt => cnt.CounterName == "% Processor Time"));

            //Memoria 
            var memoriaCategory = PerformanceCounterCategory.GetCategories()
                .FirstOrDefault(cat => cat.CategoryName == "Memory");
            var contadorMemoriaCategoria = memoriaCategory.GetCounters("");//Não contem instância.

            VisualizarDados(contadorMemoriaCategoria.First(cnt => cnt.CounterName == "% Committed Bytes In Use"));

            //HD
            var harddiskcategory = PerformanceCounterCategory.GetCategories()
                .FirstOrDefault(cat => cat.CategoryName == "LogicalDisk");
            var contadorHardDiskCategoria = harddiskcategory.GetCounters("E:"); //Unidade do disco

            VisualizarDados(contadorHardDiskCategoria.First(cnt => cnt.CounterName == "% Disk Time"));

        }

        private static void VisualizarDados(PerformanceCounter performanceCounter)
        {
            while (!Console.KeyAvailable)
            {
                Console.WriteLine("{0}\t{1} = {2}",
                    performanceCounter.CategoryName, performanceCounter.CounterName, performanceCounter.NextValue());

                System.Threading.Thread.Sleep(1000);
            }
        }   

    }
}
