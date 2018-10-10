using System;
using System.Threading.Tasks;
using static System.Console;
namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            WriteLine("Acessando a Web API, Aguarde um momento...");

            var repositorio = new UsuarioRepositorio();

            var usuarioTask = repositorio.getUsuariosAsync();

            usuarioTask.ContinueWith(task =>
            {
                var usuarios = task.Result;
                foreach (var u in usuarios)
                
                    WriteLine(u.ToString());
                ReadLine();

                Environment.Exit(0);
                },
                TaskContinuationOptions.OnlyOnRanToCompletion);
            ReadLine();

        }

    }
}
