using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace InteragindoComInternet_HTTP
{
    class Program
    {
        struct Requisicao
        {
            public int userId;
            public int id;
            public string title;
            public bool completed;
        }
        enum Menu { RequisicaoUnica = 1, RequisicaoCompleta, Sair}
        
        static void Main(string[] args)
        {
            bool escolheuSair = false;
            while (!escolheuSair)
            {
                Console.WriteLine("Requisições");
                Console.WriteLine("1-Requisição Única\n2-Requisição Completa\n3-Sair");
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);
                

                if(opInt > 0 && opInt < 4)
                {
                    Menu escolha = (Menu)opInt;
                    switch (escolha)
                    {
                        case Menu.RequisicaoUnica:
                            ReqUnica();
                            break;
                        case Menu.RequisicaoCompleta:
                            ReqList();
                            break;
                        case Menu.Sair:
                            escolheuSair = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção invalida, aperte ENTER e tente novamente.");
                    Console.ReadLine();
                }

                

                Console.Clear();
            }                     
        }

        static void ReqList()
        {

            var requisicao = WebRequest.Create("https://jsonplaceholder.typicode.com/todos");
            requisicao.Method = "GET";
            var resposta = requisicao.GetResponse();
            using (resposta)
            {
                var stream = resposta.GetResponseStream();
                StreamReader leitor = new StreamReader(stream);
                object dados = leitor.ReadToEnd();

                List<Tarefa> tarefas = JsonConvert.DeserializeObject<List<Tarefa>>(dados.ToString());

                foreach (Tarefa tarefa in tarefas)
                {

                    tarefa.Exibir();
                    
                }
                Console.ReadLine();


                stream.Close();
                resposta.Close();
            }
        }
        static void ReqUnica()
        {
            Console.WriteLine("Digite o numero da requisição que deseja ver:");
            int id = int.Parse(Console.ReadLine());
            var requisicao = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/" +id);
            requisicao.Method = "GET";
            var resposta = requisicao.GetResponse();
            using (resposta)
            {
                var stream = resposta.GetResponseStream();
                StreamReader leitor = new StreamReader(stream);
                object dados = leitor.ReadToEnd();

                Tarefa tarefa = JsonConvert.DeserializeObject<Tarefa>(dados.ToString());

               
                tarefa.Exibir();
                



                stream.Close();
                resposta.Close();
                Console.ReadLine();
            }
            
        }


    }
}
