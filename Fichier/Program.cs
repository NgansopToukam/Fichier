using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fichier
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo file = new FileInfo("data/fichier.json");
            if (!file.Directory.Exists)
            {
                file.Directory.Create();
                Console.WriteLine("Dossier cree");
            }
            if(!file.Exists)
            {
                file.Create().Close();// tjrs fermer le fichier apres creation
                Console.WriteLine("Fichier cree");
            }
            string text;
            using (StreamWriter sw = new StreamWriter(file.FullName, true))
            {
                do
                {
                    Console.Write("votre text :");
                    text = Console.ReadLine();
                    if (!string.IsNullOrEmpty(text))
                    {
                        sw.WriteLine(text);
                    }
                }
                while (!string.IsNullOrEmpty(text));
            }
           // sw.Close();
            Console.Write("End \n \n \n ");
            Console.Write("*******************Contenu du fichier******************* \n");
            using(StreamReader sr=new StreamReader(file.FullName))
            {
                while(!sr.EndOfStream)
                {
                    string l = sr.ReadLine();
                    Console.WriteLine(l);
                }
            }
            Console.ReadKey();
        }
    }
}
