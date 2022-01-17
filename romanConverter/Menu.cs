using System;
using System.Collections.Generic;
using System.Text;

namespace romanConverter
{
    public class Menu
    {

        public static void SelectionMenu()
        {
            Console.Clear();
            Console.WriteLine("Select option: ");
            Console.WriteLine("1. Arabic to Roman numbers");
            Console.WriteLine("2. Roman to Arabic numbers");
            Console.WriteLine("3. Previous entries");
            Console.WriteLine("4. Quit");
            //Select a different option depending on the input
            int selection = Error.checkSelection(Console.ReadLine());
           
            switch (selection)
            {
                
                case 1:
                    Console.Clear();
                    
                    Console.WriteLine(Converter.ToRoman());
                 //Go back to the main menu after every option
                    Console.ReadKey();
                    SelectionMenu();
                    break;

                case 2:
                    Console.Clear();
                    
                    Console.WriteLine(Converter.ToArabic());
                  
                    Console.ReadKey();
                    SelectionMenu();
                    break;

                case 3:
                    Console.Clear();
                    
                    entry.ReadFile();
            
                    Console.ReadKey();
                    SelectionMenu();
                    break;

                case 4:

                  

                    break;





            }
        }
     
    }
}
