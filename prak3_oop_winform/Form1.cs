using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace prak3_oop_winform
{
    public partial class Form1 : Form
    {
        int B = 49;
        int b = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Маштаб по осі х
            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, 50);
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            //Маштаб по осі у
            chart1.ChartAreas[0].AxisY.ScaleView.Zoom(-1, 1);
            chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;

            for (int i = 0; i < 50; i++)
            {
                chart1.Series[0].Points.AddXY(i, Math.Cos(i));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            B++;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, B);
            chart1.Series[0].Points.RemoveAt(0);
            chart1.Series[0].Points.AddXY(B, Math.Cos(B));
            chart1.ChartAreas[0].AxisX.Minimum = B - 50;
            chart1.ChartAreas[0].AxisX.Maximum = B;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                button1.Text = "Старт";
            } 
            else
            {
                timer1.Enabled = true;
                button1.Text = "Зупинити";
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            timer1.Interval = hScrollBar1.Value;
        }

        private void chart2_Click(object sender, EventArgs e)
        {
            if (b == 0)
            {
                chart2.Series[0].Points.AddXY(b, 3);
                chart2.Series[0].Points[b].LegendText = "Awesome";
            } if (b == 1)
            {
                chart2.Series[0].Points.AddXY(b, 10);
                chart2.Series[0].Points[b].LegendText = "Good";
            } if (b == 2)
            {
                chart2.Series[0].Points.AddXY(b, 5);
                chart2.Series[0].Points[b].LegendText = "Normal";
            } if (b == 3)
            {
                chart2.Series[0].Points.AddXY(b, 2);
                chart2.Series[0].Points[b].LegendText = "Bad";
            }
            b++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
                int X = 0;
                while (!streamReader.EndOfStream) 
                {
                    int y = Convert.ToInt16(streamReader.ReadLine());
                    chart3.Series[0].Points.AddXY(X, y);
                    X++;
                }
                streamReader.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
                for (int i = 0; i < chart3.Series[0].Points.Count; i++)
                {
                    streamWriter.WriteLine(chart3.Series[0].Points[i].YValues[0]);
                }
                streamWriter.Close();
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
