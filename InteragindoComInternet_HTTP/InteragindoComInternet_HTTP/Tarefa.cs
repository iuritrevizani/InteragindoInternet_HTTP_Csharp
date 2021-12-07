using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteragindoComInternet_HTTP
{
    class Tarefa
    {
        public int userId;
        public int id;
        public string title;
        public bool completed;


        public void Exibir()
        {
            Console.WriteLine("");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Objeto Tarefa");
            Console.WriteLine($"User id: {userId}");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Finalizou? {completed}");
            Console.WriteLine("");
            Console.WriteLine("-------------------------");
        }
    }
}
