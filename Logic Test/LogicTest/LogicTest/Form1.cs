using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calcular()
        {
            try
            {
                List<string> gridsList = txtInput.Text.Split(',').ToList();
                int testCases = gridsList.Count;
                int N = 0;
                int M = 0;
                string Output = "";
                for (int i = 0; i < testCases; i++)
                {
                    string grid = gridsList[i].Replace('(',' ').Replace(')',' ').Trim();
                    N = Convert.ToInt32(grid.Split('-').ToList()[0]);
                    M = Convert.ToInt32(grid.Split('-').ToList()[1]);

                    if (N == M && N > 1)
                    {
                        if (N % 2 == 0)
                            Output += "L,";
                        else
                            Output += "R,";
                    }
                    else if (N > M && M > 1)
                    {
                        if (M % 2 == 0)
                            Output += "U,";
                        else
                            Output += "D,";
                    }
                    else if (M > N)
                    {
                        if (N % 2 == 0)
                            Output += "L,";
                        else
                            Output += "R,";
                    }
                    else if (M == 1)
                    {
                        if (N == 1)
                            Output += "R,";
                        else
                            Output += "D,";
                    }
                }
                txtOutput.Text = Output.TrimEnd(',');
            }
            catch (Exception ex)
            { }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            calcular();
        }
    }
}
