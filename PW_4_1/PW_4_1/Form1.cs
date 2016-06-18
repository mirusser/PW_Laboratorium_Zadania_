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
using System.Diagnostics;

namespace PW_4_1
{
    public partial class Form1 : Form
    {
        #region Variables
        Thread PermutationThread;
        Thread TimeThread;
        volatile int[] tabofnumberstopermutate;
        volatile int numberOfSwaps;
        Stopwatch stoper;
        #endregion

        #region Time Thread Method
        void TimeThreadMethod()
        {
            stoper.Start();
            while (true)
            {
                MethodInvoker action = delegate { labelPassedTime.Text = "Passed: " + (stoper.ElapsedMilliseconds) + " ms"; };
                labelPassedTime.Invoke(action);
                if(progressBar1.Value == numberOfSwaps)
                {
                    stoper.Stop();
                }
            }
        }
        #endregion

        #region Swap methods
        void QuantityOfSwaps(int number) //number of swaps to be done to fully permutate number
        {
            numberOfSwaps = Factorial(number) * 2;
        }
        void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        #endregion

        #region Display Swaps and Update Progress Bar
        void DisplayArrayAndUpdateProgrssBar()
        {
            int zmienna;

            textBox.Invoke(new Action(delegate ()
            {
                textBox.Clear();
            }));

            if(tabofnumberstopermutate!=null)
            {
                for (int i = 0; i < tabofnumberstopermutate.Length; i++)
                {
                    zmienna = tabofnumberstopermutate[i];

                    MethodInvoker action = delegate { textBox.AppendText(zmienna + " "); };
                    progressBar1.Invoke(action);
                }
            }
            if (progressBar1.Value < numberOfSwaps)
            {
                MethodInvoker action1 = delegate { progressBar1.Value++; };
                progressBar1.Invoke(action1);
            }
        }
        #endregion

        #region What is the Factorial?
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
        #endregion

        #region Permutation
        public void GeneratePermutation(object integerN)
        {
            int n = Convert.ToInt32(integerN); ;
            int factorialOfN = Factorial(n);
            textBoxPermutations.Invoke(new Action(delegate ()
            {
                textBoxPermutations.Clear();
                textBoxPermutations.AppendText(factorialOfN.ToString());
            }));

            tabofnumberstopermutate = new int[n]; //this tab contains all numbers that will be permutate

            for (int i = 0; i < n; i++)
            {
                tabofnumberstopermutate[i] = i+1;
            }
            DisplayArrayAndUpdateProgrssBar();
            Thread.Sleep(10);
            PermutationAlgorithm(n);
        }

        public void PermutationAlgorithm(int n)
        {
            /*
             *Algorytm ten, zaczerpnięty z wykładu R. Sedgewicka na Uniwersytecie w Princeton 
            * wymaga 2N! zamian i jest przykładem algorytmu z powrotami.
            */
            if (n==1)
            {
                DisplayArrayAndUpdateProgrssBar();
            }
            else
            {
                for (int i = 0; i < tabofnumberstopermutate.Length; i++)
                {
                    if (n>=0)
                    {
                        Swap<int>(ref tabofnumberstopermutate[i], ref tabofnumberstopermutate[n - 1]);

                        DisplayArrayAndUpdateProgrssBar();

                        PermutationAlgorithm((n - 1));

                        Swap<int>(ref tabofnumberstopermutate[i], ref tabofnumberstopermutate[n - 1]);
                    }
                }
                DisplayArrayAndUpdateProgrssBar();
            }
        }
        #endregion

        #region Constructor
        public Form1()
        {
            InitializeComponent();
            stoper = new Stopwatch();
        }
        #endregion

        #region Buttons
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if(numericUpDown1.Value<=0)
            {
                MessageBox.Show("This number is wrong!\nDon't be silly!","Error");
            }
            else
            {
                //secure if someone click more than one "buttonStart", during permutation
                if(TimeThread!=null)
                {
                    TimeThread.Abort();
                    TimeThread = null;
                    stoper.Reset();
                }
                if(PermutationThread!=null)
                {
                    PermutationThread.Abort();
                    PermutationThread = null;
                }

                numberOfSwaps = 0;
                QuantityOfSwaps((Convert.ToInt32(numericUpDown1.Value)));
                textBoxNumberOfSwaps.Text = numberOfSwaps.ToString();
                progressBar1.Maximum = numberOfSwaps;
                progressBar1.Visible = true;
                progressBar1.Value = 0;

                TimeThread = new Thread(new ThreadStart(TimeThreadMethod));

                PermutationThread = new Thread(new ParameterizedThreadStart(GeneratePermutation));

                PermutationThread.Priority = ThreadPriority.AboveNormal;
                PermutationThread.Start((Convert.ToInt32(numericUpDown1.Value)));
                TimeThread.Start();
            }
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (PermutationThread != null)
            {
                if (PermutationThread.ThreadState == System.Threading.ThreadState.Suspended)
                {
                    PermutationThread.Resume();
                    stoper.Start();
                }
                else
                {
                    PermutationThread.Suspend();
                    stoper.Stop();
                }
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if(PermutationThread!=null && TimeThread!=null) 
            {
                TimeThread.Abort();
                PermutationThread.Abort();
                textBox.Clear();
                progressBar1.Value = 0;
                progressBar1.Update();
                stoper.Reset();
                labelPassedTime.Text = "Passed:";
            }
        }
        #endregion

        #region Closing the Program
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (PermutationThread != null)
            {
                PermutationThread.Abort();
            }
            if(TimeThread!=null)
            {
                TimeThread.Abort();
            }
        }
        #endregion
    }
}
