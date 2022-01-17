using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;


namespace romanConverter
{
    [Serializable]
    public partial class entry
    {
        public string roman;
        public string arabic;

      
        public static void RemoveFromFile()
        {
            
            //Remove the entry at the chose index 
       string FilePath = Error.FileExists(@"..\entries.xml");
            Console.WriteLine("Choose index");
            var input = Console.ReadLine();
            var entries = LoadFile();
            int index = Error.checkDeleteIndex(input, entries.Count);
            
            entries.RemoveAt(index - 1);
            
            
            using (Stream fs = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer DeleteSerializer = new XmlSerializer(typeof(List<entry>));
                DeleteSerializer.Serialize(fs, entries);

            }
            Console.Clear();
            ReadFile();


        }  
   public static void UpdateFile(string roman, string arabic )
        {

            entry inputObj = new entry();
            var entries = LoadFile();

           

            inputObj.arabic = arabic;

            inputObj.roman = roman;

         

            //Check if the object properties are empty
            if (string.IsNullOrEmpty(inputObj.arabic) || string.IsNullOrEmpty(inputObj.roman))
            {
                Console.WriteLine("Error: missing data");
                Console.WriteLine("Press any key to try again");
                Console.ReadKey();
              
            }

            else
            {

                //Put the object in the list and serialize it
                entries.Add(inputObj);
                string FilePath = Error.FileExists(@"..\entries.xml");

               


                using (Stream fs = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer WriteSerializer = new XmlSerializer(typeof(List<entry>));
                    WriteSerializer.Serialize(fs, entries);

                }

            }





        }
        public static List<entry> LoadFile()
        {
            //Grab the file from the path and deserialize it 
            XmlSerializer LoadSerializer = new XmlSerializer(typeof(List<entry>), new XmlRootAttribute("ArrayOfEntry"));
            string FilePath = Error.FileExists(@"..\entries.xml");
            List<entry> entries = new List<entry>();

            
            
            using (FileStream fs2 = File.OpenRead(FilePath))
            {
                entries = (List<entry>)LoadSerializer.Deserialize(fs2);

            }

            return entries;
        }    
        public static void ReadFile()
        {

            //Store the list in a variable and loop through it
             var entries = LoadFile();
            int i = 1;
            
            foreach (var entry in entries)
            {

                Console.WriteLine($"[{i}] {entry.arabic} - {entry.roman}");
                i++;
            }
            Console.WriteLine("Press X to delete entries");
            string selection = Console.ReadLine().ToUpper();
            if( selection =="X")
            {
                RemoveFromFile();

            }

        }
       






    }
}
