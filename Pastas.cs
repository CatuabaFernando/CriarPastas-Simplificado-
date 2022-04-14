using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TesteDeListas
{
    class Pastas
    {
        public static void CriarPastas(List<string> pathFile)
        {
            if (pathFile.Count > 0)
            {
                if (Directory.Exists(pathFile[0]))
                {
                    foreach (string s in pathFile)
                    {
                        string caminho = s.Replace(" ", String.Empty);// O caminho da pasta não pode ter espaço em branco.

                        if (!Directory.Exists(caminho))
                        {
                            try
                            {
                                Directory.CreateDirectory(caminho);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Erro ao tentar criar a pasta com o caminho: " + caminho);
                                Console.ReadKey();
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Caminho não existe.");
                    Console.ReadKey();
                }
            }
        }
    }
}
