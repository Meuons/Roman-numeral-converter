using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Linq;


namespace romanConverter
{
    class Error
    {
        public static string checkRoman(string num)
        {

            //Keep on looping until the input is in the correct format 
            Regex rx = new Regex(@"^(?=[MDCLXVI])M*(C[MD]|D?C{0,3})(X[CL]|L?X{0,3})(I[XV]|V?I{0,3})$");
       

            while (rx.IsMatch(num) == false)
            {
                Console.Clear();

                Console.WriteLine("Error: Invalid number. The value must be between 1 and 4999. Try again");
                Console.WriteLine("Convert to Arabic numbers");
                num =Console.ReadLine().ToUpper();
            }

                return num;

        }

        public static string checkArabic( string num)
        {


            int numericValue;

             
            while (int.TryParse(num, out numericValue) == false || int.Parse(num) > 4999 || int.Parse(num) < 1)
            {
                Console.Clear(); 
       
                Console.WriteLine("Error: Invalid number. The value must be between 1 and 4999. Try again");
                Console.WriteLine("Convert to Roman numerals");
            num=Console.ReadLine();
                
            }
           

            return num;
   


        }
        
        public static int checkSelection(string num)
        {


            int numericValue;

         


            while (int.TryParse(num, out numericValue) == false || int.Parse(num) > 4 || int.Parse(num) < 1)
            {
                Console.Clear();
                Console.WriteLine("Select option: ");
                Console.WriteLine("1. Arabic to Roman numbers");
                Console.WriteLine("2. Roman to Arabic numbers");
                Console.WriteLine("3. Previous entries");
                Console.WriteLine("4. Quit");
                Console.WriteLine("Error: Invalid number. The value must be between 1 and 4. Try again");
                num = Console.ReadLine();

            }


            return int.Parse(num);

        }

        public static int checkDeleteIndex(string num, int length)
        {


            int numericValue;

            //The index has to be withing the range of the amount of entries


            while (int.TryParse(num, out numericValue) == false || int.Parse(num) > length )
            {
                Console.Clear();
                Console.WriteLine("Error: Invalid index. Try again");
                num = Console.ReadLine();

            }


            return int.Parse(num);

        }

        public static string FileExists(string FilePath)
        {

            //If the file is missing create a new one
            if (File.Exists(FilePath))
            {
                return FilePath;
            }
            else
            {
                XNamespace xlmns = "http://m.xyz.com/rss/";
                XDocument xDoc = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                       new XElement("ArrayOfEntry", new XAttribute(xlmns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                    new XAttribute(xlmns + "xsd", "http://www.w3.org/2001/XMLSchema")

                    )
                );
                //save the document
                xDoc.Save(@"..\entries.xml");
                return FilePath;
            }

        }


    }
}
