using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkylator
{
    public partial class Kalkylator : Form
    {
        public Kalkylator()
        {
            InitializeComponent();

            RunCalc(); 
        }

        private void RunCalc()
        {
            consoleLog.Text = "Hej och välkommen till kalkylatorn!";

            List<string> tidigareKalkuleringar = new List<string>();

            float num1 = 0;
            float num2 = 0;
            char sign = ' ';

            // Välkomnande meddelande
            // En lista för att spara historik för räkningar
            // Användaren matar in tal och matematiska operation
            // OBS! Användaren måsta mata in ett tal för att kunna ta sig vidare i programmet!
            // Ifall användaren skulle dela med 0 visa Ogiltig inmatning!
            // Lägga resultat till listan
            // Visa resultat
            // Fråga användaren om den vill visa tidigare resultat.
            // Visa tidigare resultat
            // Fråga användaren om den vill avsluta eller fortsätta.
        }

        private void plusButton_Click(object sender, EventArgs e)
        {

        }

        private void resetButton_Click(object sender, EventArgs e)
        {

        }

        private void commaButton_Click(object sender, EventArgs e)
        {

        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {

        }

        private void historyButton_Click(object sender, EventArgs e)
        {

        }

        private void divideButton_Click(object sender, EventArgs e)
        {

        }

        private void inputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void clearButton_Click(object sender, EventArgs e)
        {

        }
        private void zeroButton_Click(object sender, EventArgs e)
        {

        }

        private void oneButton_Click(object sender, EventArgs e)
        {

        }

        private void twoButton_Click(object sender, EventArgs e)
        {

        }

        private void threeButton_Click(object sender, EventArgs e)
        {

        }

        private void fourButton_Click(object sender, EventArgs e)
        {

        }

        private void fiveButton_Click(object sender, EventArgs e)
        {

        }

        private void sixButton_Click(object sender, EventArgs e)
        {

        }

        private void sevenButton_Click(object sender, EventArgs e)
        {

        }

        private void eightButton_Click(object sender, EventArgs e)
        {

        }

        private void nineButton_Click(object sender, EventArgs e)
        {

        }

        private void minusButton_Click(object sender, EventArgs e)
        {

        }

        private void equalsButton_Click(object sender, EventArgs e)
        {

        }

        private void consoleLog_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
