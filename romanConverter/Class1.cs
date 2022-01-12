using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace romanConverter
{
    class Converter
    {
        public static string ToRoman()
        {
            //Store the input in an array
            Console.WriteLine("Convert to Roman numerals");
           Console.WriteLine("Write in your number: ");

            string arabicNum = Error.checkArabic(Console.ReadLine());

            char[] arr = arabicNum.ToCharArray();

            Array.Reverse(arr);
            string romanNum = "";

            //Loop through the array and match the number with the corresponding numeral
            for (int i = (arr.Length - 1); i >= 0; i--)
            {

                switch (i)
                {
                    case 0:
                        switch (int.Parse(arr[i].ToString()))
                        {
                            case 1:
                                romanNum += "I";
                                break;

                            case 2:
                                romanNum += "II";
                                break;

                            case 3:
                                romanNum += "III";
                                break;

                            case 4:
                                romanNum += "IV";
                                break;

                            case 5:
                                romanNum += "V";
                                break;

                            case 6:
                                romanNum += "VI";
                                break;


                            case 7:
                                romanNum += "VII";
                                break;

                            case 8:
                                romanNum += "VIII";
                                break;

                            case 9:
                                romanNum += "IX";
                                break;


                        }
                        break;

                    case 1:

                        switch (int.Parse(arr[i].ToString()))
                        {
                            case 1:
                                romanNum += "X";
                                break;

                            case 2:
                                romanNum += "XX";
                                break;

                            case 3:
                                romanNum += "XXX";
                                break;

                            case 4:
                                romanNum += "XL";
                                break;

                            case 5:
                                romanNum += "L";
                                break;

                            case 6:
                                romanNum += "LX";
                                break;


                            case 7:
                                romanNum += "LXX";
                                break;

                            case 8:
                                romanNum += "LXXX";
                                break;

                            case 9:
                                romanNum += "XC";
                                break;


                        }

                        break;

                    case 2:

                        switch (int.Parse(arr[i].ToString()))
                        {
                            case 1:
                                romanNum += "C";
                                break;

                            case 2:
                                romanNum += "CC";
                                break;

                            case 3:
                                romanNum += "CCC";
                                break;

                            case 4:
                                romanNum += "CD";
                                break;

                            case 5:
                                romanNum += "D";
                                break;

                            case 6:
                                romanNum += "DC";
                                break;


                            case 7:
                                romanNum += "DCC";
                                break;

                            case 8:
                                romanNum += "DCCC";
                                break;

                            case 9:
                                romanNum += "CM";
                                break;


                        }

                        break;

                    case 3:

                        switch (int.Parse(arr[i].ToString()))
                        {
                            case 1:
                                romanNum += "M";
                                break;

                            case 2:
                                romanNum += "MM";
                                break;

                            case 3:
                                romanNum += "MMM";
                                break;

                            case 4:
                                romanNum += "MMMM";
                                break;

                        }

                        break;





                }
            }
            //Store the result in a file and return it
            entry.UpdateFile(romanNum, arabicNum);
            return romanNum;


            
        }

        public static int ToArabic()
        {

            Console.WriteLine("Convert to Arabic numbers");
            Console.WriteLine("Write in your number: ");

             

          string romanNum = Error.checkRoman(Console.ReadLine().ToUpper());

            char[] arr = romanNum.ToCharArray();
            int arabicNum = 0;
            //Loop through the array and match the numeral with the corresponding number
            
            int i = 0;
            do
            {
                switch (arr[i].ToString())
                {
                    //Add different sums depending on the relationship between the neighbouring numerals
                    case "I":


                        arabicNum += 1;
                        i++;
                        if (i < arr.Length)
                        {
                            switch (arr[i].ToString())
                            {

                                case "V":


                                    arabicNum += 3;
                                    i++;
                                    break;
                                case "X":

                                    arabicNum += 8;
                                    i++;
                                    break;

                            }
                        }
                        break;

                    case "V":

                        arabicNum += 5;
                        i++;
              
                        break;

                    case "X":

                        arabicNum += 10;
                        i++;
                        if (i < arr.Length)
                        {
                            switch (arr[i].ToString())
                            {
                                case "L":

                                    arabicNum += 30;
                                    i++;
                                    break;
                                case "C":

                                    arabicNum += 80;
                                    i++;
                                    break;


                            }
                        }
                        break;
                    case "L":

                        arabicNum += 50;
                        i++;
                        break;
                    case "C":

                        arabicNum += 100;
                        i++;
                        if (i < arr.Length)
                        {
                            switch (arr[i].ToString())
                            {
                                case "D":

                                    arabicNum += 300;
                                    i++;
                                    break;

                                case "M":

                                    arabicNum += 800;
                                    i++;
                                    break;

                            }
                        }
                        break;
                    case "M":

                        arabicNum += 1000;
                        i++;
                      
                        break;

                }
            } while (i < arr.Length);
            entry.UpdateFile(romanNum, arabicNum.ToString());
            return arabicNum;
            }

            
        }
    }

    

