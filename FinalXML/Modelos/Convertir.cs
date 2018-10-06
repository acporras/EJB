using System;


namespace FinalXML
{
    public class ConvertThis
    {
        public String changeCurrencyToWords(String numb)
        {
            return changeToWords(numb);
        }
        private String changeToWords(String numb)
        {
            int decimalPlace = 0;
            String result = "";
            int c = numb.Length;
            if (numb.Contains(".") == true)
            {
                decimalPlace = numb.IndexOf(".");
            }
            else
            {
                numb = numb + ".00";
                decimalPlace = numb.IndexOf(".");
            }
            if (decimalPlace == c)
            {
                numb = numb + "00";
            }
            String wn = numb.Substring(0, decimalPlace);
            int wn_1 = wn.Length;
            String cents = numb.Substring(decimalPlace + 1);
            switch (wn_1)
            {
                //ones 
                case 1:
                    result = ones(numb.Substring(0, wn_1)) + " dollars " + cents + "/100";
                    break;
                //tens 
                case 2:
                    result = tens(numb.Substring(0, wn_1)) + " dollars " + cents + "/100";
                    break;
                //hundreds 
                case 3:
                    result = ones(numb.Substring(0, 1)) + " hundred " + tens(numb.Substring(1, 2)) + " dollars " + cents + "/100";
                    break;
                //thousands 
                case 4:
                    result = ones(numb.Substring(0, 1)) + " thousand " + ones(numb.Substring(1, 1)) + " hundred " + tens(numb.Substring(2, 2)) + " dollars " + cents + "/100";
                    break;
                //ten thousands 
                case 5:
                    result = tens(numb.Substring(0, 2)) + " thousand " + ones(numb.Substring(2, 1)) + " hundred " + tens(numb.Substring(3, 2)) + " dollars " + cents + "/100";
                    break;
                //hundred thousands 
                case 6:
                    result = ones(numb.Substring(0, 1)) + " hundred " + tens(numb.Substring(1, 2)) + " thousand " + ones(numb.Substring(3, 1)) + " hundred " + tens(numb.Substring(4, 2)) + " dollars " + cents + "/100";
                    break;
                // million 
                case 7:
                    result = ones(numb.Substring(0, 1)) + " million " + ones(numb.Substring(1, 1)) + " hundred " + tens(numb.Substring(2, 2)) + " thousand " + ones(numb.Substring(4, 1)) + " hundred " + tens(numb.Substring(5, 2)) + " dollars " + cents + "/100";
                    break;
                // ten millions 
                case 8:
                    result = tens(numb.Substring(0, 2)) + " million " + ones(numb.Substring(2, 1)) + " hundred " + tens(numb.Substring(3, 2)) + " thousand " + ones(numb.Substring(5, 1)) + " hundred " + tens(numb.Substring(6, 2)) + " dollars " + cents + "/100";
                    break;
                case 9:
                    result = ones(numb.Substring(0, 1)) + " hundred " + tens(numb.Substring(1, 2)) + " million " + ones(numb.Substring(3, 1)) + " hundred " + tens(numb.Substring(4, 2)) + " thousand " + ones(numb.Substring(6, 1)) + " hundred " + tens(numb.Substring(7, 2)) + " dollars " + cents + "/100";
                    break;
                case 10:
                    result = " this is a lot of money contact IT for a fix ";
                    break;
                case 11:
                    result = " this is a lot of money contact IT for a fix ";
                    break;
                case 12:
                    result = " this is a lot of money contact IT for a fix ";
                    break;
            }
            return result;
        }
        private String tens(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = null;
            switch (digt)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Forty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (digt > 0)
                    {
                        name = tens(digit.Substring(0, 1) + "0" + ones(digit.Substring(1)));
                    }
                    break;
            }
            return name;
        }
        private String ones(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = "";
            switch (digt)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
                case 0:
                    name = "Zero";
                    break;
            }
            return name;
        }
    }
}
