using System;
using System.Data;
using System.Windows.Forms;

namespace Laba111
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int Check = 0;
        private void btTap()
        {
            value.Select();
            value.SelectionLength = 0;
        }
        private bool lastSymbol()
        {
            if (value.Text.EndsWith("/") || value.Text.EndsWith("*") || value.Text.EndsWith("-") || value.Text.EndsWith("+"))
                 return true;
            
            return false;
            
        }
        private void result()
        {
            string symbol = "";
            if (lastSymbol())
            {
                symbol = value.Text[value.Text.Length - 1].ToString();
                value.Text = value.Text.Substring(0, value.Text.Length - 1);
            }
            try
            {
                value.Text = new DataTable().Compute(value.Text, null).ToString() + symbol;
                btTap();
                value.SelectionStart = value.Text.Length;
                if (symbol != "")
                {
                    Check += 1;
                }
            }
            catch (Exception)
            {
                btTap();
            }
        }
        private void btNum_Click(object sender, EventArgs e)
        {
            value.Text += (sender as Button).Text;
            btTap();
            value.SelectionStart = value.Text.Length;
        }
        private void btClear_Click(object sender, EventArgs e)
        {
            value.Clear();
            btTap();
        }
        private void btBackspace_Click(object sender, EventArgs e)
        {
            if (value.Text.Length > 0)
            {
                value.Text = value.Text.Substring(0, value.Text.Length - 1);
                btTap();
                value.SelectionStart = value.Text.Length;
            }
        }
        private void btEqual_Click(object sender, EventArgs e)
        {
            result();
        }
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyValue == 187)
            {
                result();
            }
        }
        private string keyboard_Click()
        {
            string str = "";
            string[] mass = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "/", "*", "-", "+", ",", "." };
            for (int i = 0; i < value.Text.Length; ++i)
            {
                foreach (string j in mass)
                {
                    if (value.Text[i].ToString() == j)
                    {
                        str += value.Text[i];
                        break;
                    }
                }
                if (value.Text[i] == '.' || value.Text[i] == ',')
                {
                    string s = value.Text;
                    value.Clear();
                    str = "";
                    btTap();
                    break;
                }
            }
            return str;
        }
        private void txt_TextChanged(object sender, EventArgs e)
        {
            if (value.Text.Length > 0 && (value.Text[value.Text.Length - 1] == '.' || value.Text[value.Text.Length - 1] == ','))
            {
                MessageBox.Show("Калькулятор предназначен\nисключительно для\nцелочисленных операций!!!\nСимвол будет удален!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                value.Text = value.Text.Substring(0, value.Text.Length - 1);
                value.SelectionStart = value.Text.Length;
            }
            if (value.Text.Length == 1 && lastSymbol() && value.Text[value.Text.Length-1]!='-')
            {
                value.Text = "0" + value.Text[value.Text.Length-1];
            }
            if (lastSymbol() && value.Text.Length > 1)
            {
                if (value.Text[value.Text.Length - 1] != '-' && (value.Text[value.Text.Length - 2] == '/' || value.Text[value.Text.Length - 2] == '+' || value.Text[value.Text.Length - 2] == '-' || value.Text[value.Text.Length - 2] == '*'))
                {
                    string last = value.Text[value.Text.Length - 1].ToString();
                    value.Text = value.Text.Substring(0, value.Text.Length - 2) + last;
                }   
            }
            string str = keyboard_Click();
            int cursor = value.SelectionStart;
            value.Text = str;
            value.SelectionStart = cursor;
            if (lastSymbol())
            {
                if (!(int.TryParse(value.Text[value.Text.Length - 2].ToString(), out int h)) && value.Text[value.Text.Length - 2] != '-' && value.Text[value.Text.Length - 1] == '-')
                    Check = 1;
                else
                    Check += 1;
                if (Check >= 2)
                {
                    Check = 0;
                    result();
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btTap();
        }
    }
}
