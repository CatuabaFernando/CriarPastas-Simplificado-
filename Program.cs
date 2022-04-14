using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TesteDeListas
{
    class Program
    {
        public void teset() { }
        static void Main(string[] args)
        {
            List<string> enderecos = new List<string>();// Cria uma lista de strings.

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);// Retorna o endereço do desktop na máquina que o programa está funcioando.
            
            string[] diretorios =
                {
                    desktop,
                    desktop + @"\PEÇAS_PARA_USINAGEM",
                    desktop + @"\PEÇAS_PARA_USINAGEM\INSIRA_O_NOME",
                    desktop + @"\PEÇAS_PARA_USINAGEM\INSIRA_O_NOME\PROGRAMA",
                    desktop + @"\PEÇAS_PARA_USINAGEM\INSIRA_O_NOME\DESENHO",
                    desktop + @"\PEÇAS_PARA_USINAGEM\INSIRA_O_NOME\DESENHO\3D",
                };

            try
            {
                string[] arquivos = Directory.GetFiles(desktop, "*.xlsx");// Retornar apenas arquivos com a extensão selecionada.           

                foreach (string obj in arquivos)
                {
                    foreach (string item in diretorios)
                    {
                        string s = item.Replace("INSIRA_O_NOME", Path.GetFileNameWithoutExtension(obj));

                        enderecos.Add(s);
                    }
                }

                Pastas.CriarPastas(enderecos);

                foreach (string obj in arquivos)
                {
                    try
                    {
                        File.Move(obj, desktop + @"\PEÇAS_PARA_USINAGEM\" + Path.GetFileNameWithoutExtension(obj) + @"\DESENHO\3D\" + Path.GetFileName(obj));// Move o arquivos  
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Falha ao tentar mover arquivo.");
                        Console.ReadKey();
                    }

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Falha ao tentar obter nome do(s) arquivo(s).");
                Console.ReadKey();
            }
        }
    }
}
