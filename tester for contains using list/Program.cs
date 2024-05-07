using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tester_for_contains_using_list
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<List<string>> Books = new List<List<string>>();
            string FileName = "Book.csv";
            string line = "";

            string uInput = "";


            string[] bookRow = new string[] { };
            int rows = 0;

            //READ CSV FILE
            using (StreamReader sr = new StreamReader(FileName))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length > 0)
                    {
                        if (rows > 0)
                        {
                            bookRow = line.Split(',');
                            Books.Add(new List<string> { bookRow[0], bookRow[1], bookRow[2] });
                        }
                    }
                    rows++;
                }
            }



            //SEARH     
            Console.Write("Search for: ");
            uInput = Console.ReadLine();

            string[] temp = new string[] { };
            temp = uInput.Split(',');

            List<string> filters = new List<string>();



            //transfer the filter values to a list
            for (int i = 0; i < temp.Length; i++)
            {
                filters.Add(temp[i]);
            }


            

            for (int x = 0; x < filters.Count; x++) //filters list index
            {
                for (int y = 0; y < Books.Count; y++) //books index
                {
                    if (!Books[y].Contains(filters[x])) //if books[y] list does not have the certain filter
                    {
                        Books.RemoveAt(y); //remove the book based on it's index
                        y--; //refresh the index
                    }
                }
            }




            //DISPLAY
            Console.WriteLine();
            Console.WriteLine("The ff books satisfy your filters: ");

            for (int i = 0; i < Books.Count; i++)
            {            
                Console.WriteLine("\t" + Books[i][0]);
            }

            Console.ReadKey();
        }
    }
}
