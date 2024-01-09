using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkylator
{
    public partial class Kalkylator : Form
    {
        // Variables used during calculations
        float num1 = 0;
        float num2 = 0;
        char sign = ' ';
        float result = 0;

        // Bools to determine what phase the program is in
        bool firstInput = false;
        bool secondInput = false;
        bool showsResult = false;
        bool showsHistory = false;

        // A list that contains previous calculations
        List<string> history = new List<string>();

        public Kalkylator()
        {
            InitializeComponent();
            RunCalc();
        }

        private void RunCalc()
        {
            // Hard resets all values at start of calculator
            Reset("hard");
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            // Checks to make sure you can't do new operations while calculator is showing history or a result has been calculated
            if (showsHistory)
                return;
            else if (showsResult)
            {
                consoleLog.Text = "Clear the window to keep making further calculations.";
                return;
            }
            // Checks to make sure calculation is valid and if it's the first variable
            if (firstInput && !showsResult)
            {
                sign = '+';
                UpdateCurrentCalculation("new");
            }
            // Continues calculation if there already is a first variable declared
            else if (secondInput)
                UpdateCurrentCalculation("plus");
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            // Checks to make sure you can't do new operations while calculator is showing history or a result has been calculated
            if (showsHistory)
                return;
            else if (showsResult)
            {
                consoleLog.Text = "Clear the window to keep making further calculations.";
                return;
            }
            // Checks to make sure calculation is valid and if it's the first variable
            if (firstInput && !showsResult)
            {
                sign = '-';
                UpdateCurrentCalculation("new");
            }
            // Continues calculation if there already is a first variable declared
            else if (secondInput)
                UpdateCurrentCalculation("minus");
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            // Checks to make sure you can't do new operations while calculator is showing history or a result has been calculated
            if (showsHistory)
                return;
            else if (showsResult)
            {
                consoleLog.Text = "Clear the window to keep making further calculations.";
                return;
            }
            // Checks to make sure calculation is valid and if it's the first variable
            if (firstInput && !showsResult)
            {
                sign = '*';
                UpdateCurrentCalculation("new");
            }
            // Continues calculation if there already is a first variable declared
            else if (secondInput)
                UpdateCurrentCalculation("multiply");
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            // Checks to make sure you can't do new operations while calculator is showing history or a result has been calculated
            if (showsHistory)
                return;
            else if (showsResult)
            {
                consoleLog.Text = "Clear the window to keep making further calculations.";
                return;
            }
            // Checks to make sure calculation is valid and if it's the first variable
            if (firstInput && !showsResult)
            {
                sign = '/';
                UpdateCurrentCalculation("new");
            }
            // Continues calculation if there already is a first variable declared
            else if (secondInput)
                UpdateCurrentCalculation("divide");
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            // Checks to make sure you can't do new operations while calculator is showing history or a result has been calculated
            if (showsHistory)
                return;
            else if (showsResult)
            {
                consoleLog.Text = "Clear the window to keep making further calculations.";
                return;
            }
            // Checks to see if there is a second variable that is valid else it won't calculate
            if (secondInput && inputBox.Text != "")
                Calculate();
        }

        private void UpdateCurrentCalculation(string input)
        {
            // Updates current calculation text after operand has been clicked and there is a valid first variable
            if (input == "new")
                currentCalculation.Text = $"{num1} {sign}";

            // Is used when doing further calculatiions on the first numerical
            if (inputBox.Text != "")
            {
                if (input == "plus")
                {
                    // Calculates based on previous sign value and assigns new value based upon which button is clicked
                    // Also Updates the current calculation text
                    MakeAdditionalCalculations();
                    sign = '+';
                    currentCalculation.Text = $"{num1} {sign}";
                }
                else if (input == "minus")
                {
                    // Calculates based on previous sign value and assigns new value based upon which button is clicked
                    // Also Updates the current calculation text
                    MakeAdditionalCalculations();
                    sign = '-';
                    currentCalculation.Text = $"{num1} {sign}";
                }
                else if (input == "multiply")
                {
                    // Calculates based on previous sign value and assigns new value based upon which button is clicked
                    // Also Updates the current calculation text
                    MakeAdditionalCalculations();
                    sign = '*';
                    currentCalculation.Text = $"{num1} {sign}";
                }
                else if (input == "divide")
                {
                    // Calculates based on previous sign value and assigns new value based upon which button is clicked
                    // Also Updates the current calculation text
                    MakeAdditionalCalculations();
                    sign = '/';
                    currentCalculation.Text = $"{num1} {sign}";
                }
            }
            // Resets the textbox and continues Second Input phase
            inputBox.Text = "";
            firstInput = false;
            secondInput = true;
        }

        private void MakeAdditionalCalculations()
        {
            // Checks to make sure what calculation to make before assigning the new sign value in updateCurrentCalculation()
            if (sign == '+')
            {
                num1 += num2;
            }
            else if (sign == '-')
            {
                num1 -= num2;
            }
            else if (sign == '*')
            {
                num1 *= num2;
            }
            else if (sign == '/')
            {
                num1 /= num2;
            }
        }

        private void Calculate()
        {
            // Finishes the calculation and assigns a result
            switch (sign)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    result = num1 / num2;
                    break;
                default:
                    break;
            }

            // Checks for calculation and adds to history
            // Also showsResult which disables further operations
            if (result.ToString() == "\u221E" || result.ToString() == "NaN")
            {
                // If the result is ∞ it will return an error instead of the calculation
                history.Add("Ogiltig Inmatning");
                consoleLog.Text = "Ogiltig Inmatning";
                currentCalculation.Text = "Ogiltig Inmatning";
                inputBox.Clear();
                showsResult = true;
            }
            else
            {
                // Shows current calculation
                currentCalculation.Text = $"{num1} {sign} {num2} = {result}";
                history.Add($"{num1} {sign} {num2} = {result}");
                inputBox.Text = $"{result}";
                showsResult = true;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            // Full reset of calculator
            Reset("hard");
        }

        private void Reset(string input)
        {
            // Reset function with a "hard" and "soft" reset
            if (input == "hard")
            {
                history.Clear();

                num1 = 0;
                num2 = 0;
                sign = ' ';
                result = 0;

                firstInput = true;
                secondInput = false;
                showsResult = false;
                showsHistory = false;

                inputBox.Text = "";
                currentCalculation.Text = "";
                consoleLog.Text = "Hello and welcome to the calculator!";

                GreenButtons();
            }
            else if (input == "soft")
            {
                // Soft reset is used whenever the user has gotten a result and starts a a new calculation
                num1 = 0;
                num2 = 0;
                sign = ' ';
                result = 0;

                firstInput = true;
                secondInput = false;
                showsResult = false;

                inputBox.Text = "";
                consoleLog.Text = "Hello and welcome to the calculator!";
                currentCalculation.Clear();
            }
        }

        private void commaButton_Click(object sender, EventArgs e)
        {
            // Checks to make sure you can't do new operations while calculator is showing history or a result has been calculated
            if (showsHistory)
                return;
            else if (showsResult)
            {
                consoleLog.Text = "Clear the window to keep making further calculations.";
                return;
            }
            // Another check that disables inputting comma as the first sign
            if (inputBox.Text == "")
                inputBox.Text += "0,";
            // Makes sure there can only be one comma
            else if (!inputBox.Text.Contains(','))
                inputBox.Text += ",";
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            // Reverses list to show latest calculations first
            history.Reverse();

            if (!showsHistory)
            {
                // Shows history
                GreyButtons();
                consoleLog.Clear();
                consoleLog.Text = "Press History again to continue calculating" + Environment.NewLine;
                for (int i = 0; i < history.Count; i++)
                {
                    consoleLog.Text += $"{history[i]} {Environment.NewLine}";
                }
                showsHistory = true;
            }
            else
            {
                // Hides history
                GreenButtons();
                consoleLog.Clear();
                consoleLog.Text = "Hello and welcome to the calculator!";
                showsHistory = false;
            }

            // Reverses back the list so it adds to last next calculation
            history.Reverse();
        }

        private void inputBox_TextChanged(object sender, EventArgs e)
        {
            // Checks if in first phase and that the inputbox isn't empty
            if (firstInput && inputBox.Text != "")
                // Gets number 1
                num1 = float.Parse(inputBox.Text);
            // Checks if in second phase and that the inputbox isn't empty
            else if (secondInput && inputBox.Text != "")
                // Gets number 1
                num2 = float.Parse(inputBox.Text);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Check to make sure calculator isn't showing history
            if (!showsHistory)
            {
                // Clears inputBox if there is text in it & calculator isn't showing results
                if (inputBox.Text != "" && !showsResult)
                    inputBox.Clear();
                // Does a soft reset when calculator is showing reuslts
                else if (showsResult)
                    Reset("soft");
            }
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            // Checks if user is viewing history before inputting number
            if (showsHistory)
                return;
            if (!showsResult)
            {
                // Check to make sure you don't input 0 as first sign (use comma instead if you want to us 0. value)
                // Check to make sure you don't input 0 as first sign (use comma instead if you want to use 0. value)
                if (inputBox.Text == "")
                    inputBox.Text += "0";
                else if (inputBox.Text == "0")
                    return;
                else
                    inputBox.Text += "0";
            }

            if (showsResult)
            {
                Reset("soft");
                inputBox.Text += "0";
                if (inputBox.Text == "")
                    inputBox.Text += "0";
                else if (inputBox.Text == "0")
                    return;
                else
                    inputBox.Text += "0";
            }
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            // Checks if user is viewing history before inputting number
            if (showsHistory)
                return;
            if (!showsResult)
                inputBox.Text += "1";

            // Starts a new calculation if the calculator is showing result
            if (showsResult)
            {
                Reset("soft");
                inputBox.Text += "1";
            }
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            // Checks if user is viewing history before inputting number
            if (showsHistory)
                return;
            if (!showsResult)
                inputBox.Text += "2";

            // Starts a new calculation if the calculator is showing result
            if (showsResult)
            {
                Reset("soft");
                inputBox.Text += "2";
            }
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            // Checks if user is viewing history before inputting number
            if (showsHistory)
                return;
            if (!showsResult)
                inputBox.Text += "3";

            // Starts a new calculation if the calculator is showing result
            if (showsResult)
            {
                Reset("soft");
                inputBox.Text += "3";
            }
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            // Checks if user is viewing history before inputting number
            if (showsHistory)
                return;
            if (!showsResult)
                inputBox.Text += "4";

            // Starts a new calculation if the calculator is showing result
            if (showsResult)
            {
                Reset("soft");
                inputBox.Text += "4";
            }
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            // Checks if user is viewing history before inputting number
            if (showsHistory)
                return;
            if (!showsResult)
                inputBox.Text += "5";

            // Starts a new calculation if the calculator is showing result
            if (showsResult)
            {
                Reset("soft");
                inputBox.Text += "5";
            }
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            // Checks if user is viewing history before inputting number
            if (showsHistory)
                return;
            if (!showsResult)
                inputBox.Text += "6";

            // Starts a new calculation if the calculator is showing result
            if (showsResult)
            {
                Reset("soft");
                inputBox.Text += "6";
            }
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            // Checks if user is viewing history before inputting number
            if (showsHistory)
                return;
            if (!showsResult)
                inputBox.Text += "7";

            // Starts a new calculation if the calculator is showing result
            if (showsResult)
            {
                Reset("soft");
                inputBox.Text += "7";
            }
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            // Checks if user is viewing history before inputting number
            if (showsHistory)
                return;
            if (!showsResult)
                inputBox.Text += "8";

            // Starts a new calculation if the calculator is showing result
            if (showsResult)
            {
                Reset("soft");
                inputBox.Text += "8";
            }
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            // Checks if user is viewing history before inputting number
            if (showsHistory)
                return;
            if (!showsResult)
                inputBox.Text += "9";

            // Starts a new calculation if the calculator is showing result
            if (showsResult)
            {
                Reset("soft");
                inputBox.Text += "9";
            }
        }

        // Applies visual elements to let you know you can't use certain buttons while showing history
        private void GreyButtons()
        {
            clearButton.BackColor = SystemColors.ControlDarkDark;
            divideButton.BackColor = SystemColors.ControlDarkDark;
            multiplyButton.BackColor = SystemColors.ControlDarkDark;
            minusButton.BackColor = SystemColors.ControlDarkDark;
            plusButton.BackColor = SystemColors.ControlDarkDark;
            equalsButton.BackColor = SystemColors.ControlDarkDark;
            commaButton.BackColor = SystemColors.ControlDarkDark;
            zeroButton.BackColor = SystemColors.ControlDarkDark;
            oneButton.BackColor = SystemColors.ControlDarkDark;
            twoButton.BackColor = SystemColors.ControlDarkDark;
            threeButton.BackColor = SystemColors.ControlDarkDark;
            fourButton.BackColor = SystemColors.ControlDarkDark;
            fiveButton.BackColor = SystemColors.ControlDarkDark;
            sixButton.BackColor = SystemColors.ControlDarkDark;
            sevenButton.BackColor = SystemColors.ControlDarkDark;
            eightButton.BackColor = SystemColors.ControlDarkDark;
            nineButton.BackColor = SystemColors.ControlDarkDark;
            historyButton.BackColor = Color.Green;
        }

        // Reverts visual elements to default styling when not showing history
        private void GreenButtons()
        {
            clearButton.BackColor = Color.Fuchsia;
            divideButton.BackColor = Color.Blue;
            multiplyButton.BackColor = Color.Blue;
            minusButton.BackColor = Color.Blue;
            plusButton.BackColor = Color.Blue;
            equalsButton.BackColor = Color.MediumVioletRed;
            commaButton.BackColor = Color.MediumSlateBlue;
            zeroButton.BackColor = Color.Green;
            oneButton.BackColor = Color.Green;
            twoButton.BackColor = Color.Green;
            threeButton.BackColor = Color.Green;
            fourButton.BackColor = Color.Green;
            fiveButton.BackColor = Color.Green;
            sixButton.BackColor = Color.Green;
            sevenButton.BackColor = Color.Green;
            eightButton.BackColor = Color.Green;
            nineButton.BackColor = Color.Green;
            historyButton.BackColor = Color.BlueViolet;
        }
    }
}