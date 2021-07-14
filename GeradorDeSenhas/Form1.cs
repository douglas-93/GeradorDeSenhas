using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorDeSenhas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txbPassword.Text))
            {
                MessageBox.Show("Gere uma senha primeiro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                System.Windows.Forms.Clipboard.SetText(txbPassword.Text);
                MessageBox.Show("Copiado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            List<string> lowerCase = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            List<string> upperCase = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            List<string> symbols = new List<string>() { "!", "\"", "#", "$", "%", "&", "'", "(", ")", "*", "+", ",", "-", ".", "/", ":", ";", "<", "=", ">", "?", "@", "[", "\\", "]", "_", "`", "{", "|", "}", "~" };
            List<string> numbers = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", };

            List<string> passwordOptions = new List<string>();

            foreach (var option in clbOptions.CheckedItems)
            {
                switch (option.ToString())
                {
                    case "Letras maiúsculas":
                        passwordOptions.AddRange(upperCase);
                        break;
                    case "Letras minúsculas":
                        passwordOptions.AddRange(lowerCase);
                        break;
                    case "Números":
                        passwordOptions.AddRange(numbers);
                        break;
                    case "Simbolos":
                        passwordOptions.AddRange(symbols);
                        break;
                    default:
                        break;
                }
            }
            Random random = new Random();
            string temp = "";
            for (int i = 0; i < nupLength.Value; i++)
            {
                int randomIndex = random.Next(passwordOptions.Count);
                temp += passwordOptions[randomIndex];
            }
            txbPassword.Text = temp;
        }
    }
}
