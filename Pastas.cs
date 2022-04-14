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
                        if (!Directory.Exists(s))
                        {
                            string nomeDaPasta;

                            nomeDaPasta = s.Substring(s.LastIndexOf(@"\") + 1);// Insere o nome da ultima pasta criada na string nomeDaPasta.

                            try
                            {
                                Directory.CreateDirectory(s);
                            }
                            catch (Exception)
                            {
                                if (!s.Contains("*"))
                                {
                                    Console.WriteLine("Erro ao tentar criar a pasta com o caminho: " + s);
                                    Console.ReadKey();
                                }
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
