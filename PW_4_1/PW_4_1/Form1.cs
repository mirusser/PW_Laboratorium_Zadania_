using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PW_4_1
{
    public partial class Form1 : Form
    {
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        bool DisplayArray(ref int[] array)
        {
            int zmienna;
            textBox.Clear();
            for (int i = 0; i < array.Length; i++)
            {
                zmienna = array[i];
                textBox.Invoke(new Action(delegate ()
                {
                    textBox.AppendText(zmienna + " ");
                    Thread.Sleep(100);
                }));
            }
            return true;
        }
        public int Factorial(int n)
        {
            int result = 1;
            if (n == 0 || n == 1)
            {
                return result;
            }
            else
            {
                for (int i = 2; i <= n; i++)
                {
                    result *= i;
                }
                return result;
            }
        }

        public void GeneratePermutation(int n)
        {
            int factorialOfN = Factorial(n);
            textBoxPermutations.Invoke(new Action(delegate ()
            {
                textBox.Clear();
                textBox.AppendText("Liczba wszystkich permutacji:" + factorialOfN);
            }));

            int[] tabofnumberstopermutate = new int[n]; //this table contains all numbers that will be permutate

            for (int i = 0; i < n; i++)
            {
                tabofnumberstopermutate[i] = i+1;
            }
            DisplayArray(ref tabofnumberstopermutate);
            Thread.Sleep(100);
            PermutationAlgorithm(ref tabofnumberstopermutate, n);
        }

        public void PermutationAlgorithm(ref int[] tabofnumberstopermutate, int n)
        {
            /*
             *Algorytm ten, zaczerpnięty z wykładu R. Sedgewicka na Uniwersytecie w Princeton 
            * wymaga 2N! zamian i jest przykładem algorytmu z powrotami.
            */
            if (n==1)
            {
                DisplayArray(ref tabofnumberstopermutate);
            }
            else
            {
                for (int i = 0; i < tabofnumberstopermutate.Length; i++)
                {
                    if(n>=0)
                    {
                        Swap<int>(ref tabofnumberstopermutate[i], ref tabofnumberstopermutate[n - 1]);
                        DisplayArray(ref tabofnumberstopermutate);
                        PermutationAlgorithm(ref tabofnumberstopermutate, (n - 1));
                        Swap<int>(ref tabofnumberstopermutate[i], ref tabofnumberstopermutate[n - 1]);
                    }
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            GeneratePermutation(Convert.ToInt32(numericUpDown1.Value));

        }
    }
}
