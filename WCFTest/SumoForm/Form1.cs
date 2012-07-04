using System;
using System.Windows.Forms;
using SumoForm.ServiceReference1;

namespace SumoForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SumoForm.ServiceReference1.IService1 x = new Service1Client();

            MessageBox.Show(x.Echo("Hello my name is Sally!"));


        }

        private void button2_Click(object sender, EventArgs e)
        {

            SumoForm.ServiceReference1.IService1 x = new Service1Client();

            MessageBox.Show(x.Ping());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string messageBoxText = "";
            string mathInputOperator = "";
            int subStringBegin = 0;
            int subStringLength = 3;
            int openParenthesisCheck = 3;
            int closeParenthesisCheck = -1;
            int minimumLengthPosition = 7;              //minimum length for argument is 8 
            int inputLength = -1;
            string inputRawText = mathInput.Text.Trim();
            int positionOfComma = -1;
            int lengthOfX = -1; 
            int lengthOfY = -1;
            string xAsString ="";
            string yAsString = "";
            int x = -1;
            int y = -1;

            SumoForm.ServiceReference1.IService1 Service1Client = new Service1Client();

            inputLength = inputRawText.Length;
            if (inputLength < minimumLengthPosition || inputRawText == "" || inputRawText == null)
            {
                messageBoxText = "Please enter a Valid argument \r\n eg:'add(0,1)' \r\n failed because of length";
            }
            else
            {
                mathInputOperator = inputRawText.Substring(subStringBegin, subStringLength).ToLower();
                if (mathInputOperator != "add" &&
                     mathInputOperator != "mul" &&
                     mathInputOperator != "div" &&
                     mathInputOperator != "sub" &&
                     mathInputOperator != "pow" &&
                     mathInputOperator != "srt" &&
                     mathInputOperator != "bin" &&
                     mathInputOperator != "hex")
                {
                    messageBoxText = "Please Enter a valid 3 charachter operator. \r\n (ie: add, mul, div, sub, pow, srt, bin, hex)\r\n ** Not case Sensitive \r\n first three chars must represent operator";
                }
                else
                    if (inputRawText[openParenthesisCheck] != '(')
                {
                    messageBoxText = "Please enter a Valid argument \r\n eg:'add(0,1)'\r\nYour ( must be the 4th character";
                }
                else
                {
                    closeParenthesisCheck = inputRawText.Length - 1;
                    if (inputRawText[closeParenthesisCheck] != ')')
                    {
                        messageBoxText = "Please enter a Valid argument \r\n eg:'add(0,1)'\r\nYour ) must be the last character";
                    }
                    else
                    {
                        positionOfComma = inputRawText.IndexOf(',');
                        if (positionOfComma < openParenthesisCheck + 2 || positionOfComma > closeParenthesisCheck - 2)
                        {
                            messageBoxText = "Please enter a Valid argument \r\n eg:'add(0,1)'\r\nYour , must be between the two operands";
                        }
                        else
                        {
                            //later check for a '-' char in positon after comma or after open parenthesis then have neg flags and convert to int32 then multiply by -1
                            lengthOfX = (positionOfComma - 1) - openParenthesisCheck;
                            lengthOfY = closeParenthesisCheck - (positionOfComma + 1);
                            xAsString = inputRawText.Substring(openParenthesisCheck+1,lengthOfX);
                            yAsString = inputRawText.Substring(positionOfComma + 1, lengthOfY);
                            try
                            {
                                x = Convert.ToInt32(xAsString);
                                y = Convert.ToInt32(yAsString);
                            }
                            catch (FormatException Exception)
                            {
                                messageBoxText = "Please enter a Valid argument \r\n eg:'add(0,1)'\r\nYour operands did not seem to be integers\r\n\r\n\r\n" + Exception.ToString();
                            }
                            catch (OverflowException Exception)
                            {
                                messageBoxText = "Please enter a Valid argument \r\n eg:'add(2147483647,2147483647) is the max\r\n\r\n\r\n" + Exception.ToString();
                            }
                            finally
                            {
                                if (messageBoxText == "")
                                {
                                    messageBoxText = "success!";
                                }
                            }
                        }
                        messageBoxText = Service1Client.mathOperations(mathInputOperator, x ,y); 
                    }
                }
            }
          MessageBox.Show(messageBoxText);
        }
    }
}