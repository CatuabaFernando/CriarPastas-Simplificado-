using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


/***********************************************PROPRIEDADE DE SAÍDA DO PROJETO FOI ALTERADA DE CONSOLE PARA WINDOWS FORMS PARA EXECULTAR SEM ABRIR TELA PRETA***************************************/

namespace TesteDeListas
{
    class Program
    {
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

            string[] _3D = { ".ipt", ".stp", ".step", ".STEP", ".igs", ".iges", ".iam" };

            string[] _2D = {".idw", ".dwg", ".dxf"};

            try
            {
                string[] arquivos = Directory.GetFiles(desktop, "*.*")

                    //Where(arquivos que terminam com alguma dessas estensões)
                    .Where(s => s.EndsWith(".ipt")
                    || s.EndsWith(".stp")
                    || s.EndsWith(".step")
                    || s.EndsWith(".STEP")
                    || s.EndsWith(".igs")
                    || s.EndsWith(".iges")
                    || s.EndsWith(".idw")
                    || s.EndsWith(".dwg")
                    || s.EndsWith(".dxf")
                    || s.EndsWith(".art")
                    || s.EndsWith(".iam")).ToArray();

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
                        string caminho = Path.GetFileNameWithoutExtension(obj).Replace(" ", String.Empty);// O caminho da pasta não pode ter espaço em branco.

                        bool arquivo3D = Array.Exists(_3D, x => x == Path.GetExtension(obj));// Verifica se a extensão pertense alguma extensão do array arquivo3D.

                        bool arquivo2D = Array.Exists(_2D, x => x == Path.GetExtension(obj));// Verifica se a extensão pertense alguma extensão do array arquivo2D.

                        if (arquivo3D == true)
                        {
                            File.Move(obj, desktop + @"\PEÇAS_PARA_USINAGEM\" + caminho + @"\DESENHO\3D\" + Path.GetFileName(obj));// Move o arquivos.  
                        }
                        if (arquivo2D == true)
                        {
                            File.Move(obj, desktop + @"\PEÇAS_PARA_USINAGEM\" + caminho + @"\DESENHO\" + Path.GetFileName(obj));// Move o arquivos.  
                        }
                        if(Path.GetExtension(obj) == ".art")
                        {
                            File.Move(obj, desktop + @"\PEÇAS_PARA_USINAGEM\" + caminho + @"\PROGRAMA\" + Path.GetFileName(obj));// Move o arquivos.
                        }
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
