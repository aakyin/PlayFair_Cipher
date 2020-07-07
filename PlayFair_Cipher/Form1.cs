using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayFair_Cipher
{
    //Alvin Akyin
    //CSCI 1630
    //03/26/2020
    //The purpose of this project is to encrypt and decrypt text.
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int row = 5, col = 5;
        private void btnTranslate_Click(object sender, EventArgs e)
        {
            char[,] table = new char[row, col];
            string secretWord, input_Word, output_Word;
            output_Word = "";
            secretWord = txtSecretWord.Text;
            table = populateTable(secretWord);
            input_Word = txtInput.Text;
            output_Word = txtOutput.Text;

            if (input_Word != "" && output_Word == "")
                txtOutput.Text = cipherText(table, input_Word);
           }
        
            public string cipherText(char[,] myArray, string plaintext)
            {
                string cText = "";
                int r = new int();
                int c = new int();
                for (int i = 0; i < plaintext.Length; i++)
                {
                    if (Char.IsLetter(plaintext[i]))
                    {
                        findLocation(myArray, Char.ToUpper(plaintext[i]), ref r, ref c);
                        cText += myArray[c, r];
                    }
                    else
                        cText += plaintext[i];
                }

                return cText;
            }
            public void findLocation(char[,] table, char ch, ref int r, ref int c)
            {
                if (ch == 'J')
                    ch = 'I';

                for (int i = 0; i < row; i++)
                    for (int j = 0; j < col; j++)
                    {
                        if (table[i, j] == ch)
                        {
                            r = i;
                            c = j;
                            break;
            }
            }
            }
        public char[,] populateTable(string word)
        {
            char[,] table = new char[row, col];
            string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            string wordWithoutDubplicate;
            int i, j, k, l, m;
            i = j = k = l = m = 0;
            wordWithoutDubplicate = RemoveDuplicateChars(word);

            wordWithoutDubplicate = wordWithoutDubplicate.ToUpper();

            for (i = 0; i < wordWithoutDubplicate.Length; i++)
            {
                char c = wordWithoutDubplicate[i];
                if (c == 'J')
                    c = 'I';
                if (k == 5)
                {
                    k = 0;
                    j += 1;
                }
                table[j, k] = c;
                k += 1;
            }
            l = k;

            for (m = 0; m < alphabet.Length; m++)
            {
                if (l == 5)
                {
                    l = 0;
                    j = j + 1;
                }

                if (findCharInTable(table, alphabet[m]) == false)
                {
                    table[j, l] = alphabet[m];
                    l += 1;
                }

            }
            return table;
        }

        public Boolean findCharInTable(Char[,] myArray, char c)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (myArray[i, j] == c)
                        return true;
                }
            }
            return false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
            txtOutput.Text = "";
            txtSecretWord.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string RemoveDuplicateChars(string s)
        {
            string newString = string.Empty;
            List<char> found = new List<char>();
            foreach (char c in s)
            {
                if (found.Contains(c))
                    continue;

                newString += c.ToString();
                found.Add(c);
            }
            return newString;
        }
    }
    }

