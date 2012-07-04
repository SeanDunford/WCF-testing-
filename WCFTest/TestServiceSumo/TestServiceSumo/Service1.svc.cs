using System;

namespace TestServiceSumo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {
        public string Ping()
        {
            return string.Format("Bong: " + DateTime.Today.ToString());

        }

        public string Echo(string inEcho)
        {
            return string.Format(DateTime.Today.ToString() +"  " + inEcho);
        }

        public string mathOperations(string mathInputOperator, int x , int y)
        {

            string result = "";

               if (mathInputOperator == "add"){ result =add(x,y);} 
               if (mathInputOperator == "mul"){ result =mul(x,y);} 
               if (mathInputOperator == "div"){ result =div(x,y);} 
               if (mathInputOperator == "sub"){ result =sub(x,y);} 
               if (mathInputOperator == "pow"){ result =pow(x,y);} 
               if (mathInputOperator == "srt"){ result =srt(x,y);} 
               if (mathInputOperator == "bin"){ result =bin(x,y);} 
               if (mathInputOperator == "hex"){ result =hex(x,y);} 
            return string.Format(DateTime.Today.ToString() + "  " + result);


        }
        private string add(int x, int y) {return (x + y).ToString();}
        private string mul(int x, int y) {return (x * y).ToString();}
        private string div(int x, int y) {return (x / y).ToString();}
        private string sub(int x, int y) {return (x - y).ToString();}
        private string pow(int x, int y) {return (Math.Pow(x,y)).ToString();}
        private string srt(int x, int y) {return (Math.Sqrt(x).ToString());}
        private string bin(int x, int y) { return Convert.ToString(x, 2);}
        private string hex(int x, int y) { return Convert.ToString(x, 16);}

       

    }
}
