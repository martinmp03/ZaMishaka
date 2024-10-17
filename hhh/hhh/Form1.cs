using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace hhh
{
    public partial class Form1 : Form
    {
        List<Contestant> contestants = new List<Contestant>();
        int count = 0;
        int gradeCount = 0;
        int judgeCount = 1;
        
        public class Contestant
        {
            private string name;
            private List<int> grades;
            private int maxGrade;
            public Contestant(string name)
            {
                this.name = name;
                grades=new List<int>();
            }

            public string Name { get => name; set => name = value; }
            public List<int> Grades { get => grades; set => grades = value; }
            public int MaxGrade { get => maxGrade; set => maxGrade = value; }
        }
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int grade = 11;
            if (textBox1.Text != string.Empty) { 
                grade = int.Parse(textBox1.Text); 
            }
           
            
            if(grade>=1 && grade <=10)
            {   contestants[count].Grades.Add(grade);
                textBox1.Clear();
                gradeCount++;
                judgeCount++;
                label2.Text = ("Judge" + judgeCount).ToString();

            }
            else
            {
                label2.Text = "Incorrect Points";
            }
            if(gradeCount==10)
            {
                int max = contestants[count].Grades[0];
                int min = contestants[count].Grades[0];
                int sum = 0;
                int index = 0;
                for (int i = 1; i < gradeCount; i++)
                {
                    int current = contestants[count].Grades[i];
                    if(current > max)
                    { max = current;
                        index = i;
                    }
                       

                }
                int temp = contestants[count].Grades[index];
                contestants[count].Grades[index] = contestants[count].Grades[gradeCount-1];
                contestants[count].Grades[gradeCount - 1] = temp;
                index = 0;
                for (int i = 0; i < gradeCount-1; i++)
                {
                    int current = contestants[count].Grades[i];
                   
                    if (current < min)
                    {
                        min = current;
                        index = i;
                    }


                }
                temp = contestants[count].Grades[index];
                contestants[count].Grades[index] = contestants[count].Grades[gradeCount - 2];
                contestants[count].Grades[gradeCount - 2] = temp;
            
                for (int i = 0; i < gradeCount - 2; i++)
                {
                    
                    sum += contestants[count].Grades[i];
                }
                contestants[count].MaxGrade = sum;
                listBox1.Items[count] = (contestants[count].Name + "            " + contestants[count].MaxGrade).ToString();
                gradeCount = 0;
                judgeCount = 1;
                label3.Visible = false;
                textBox1.Visible = false;
                button1.Visible = true;
                button2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;

            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            listBox1.Visible = true;
            textBox1.Visible = true;
            button3.Visible = false;
            button4.Visible = true;
            label3.Visible = true;

            
            
          
          

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (count == 10)
            {
                count = 0;
                textBox1.Clear();
                button4.Visible = false;
                button2.Visible = true;
                listBox1.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                textBox1.Visible = true;
                label2.Text = ("Judge" + judgeCount).ToString();
                label1.Text = listBox1.Items[count].ToString();
               
                label3.Text = "Enter Points";
            }
            else if(textBox1.Text!=string.Empty)
            {  count++;
            string text = textBox1.Text;
            Contestant contestant = new Contestant(text);
            contestants.Add(contestant);
            listBox1.Items.Add(text);
            textBox1.Clear();
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Visible = false;
            listBox1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            button1.Visible = false;
            button4.Visible = false;
            label3.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(count==9)
            {
                int max = contestants[0].MaxGrade;
                int index = 0;
                for (int i = 1; i < listBox1.Items.Count; i++)
                {
                    int current = contestants[i].MaxGrade;
                    if (current > max)
                    {
                        max = current;
                        index = i;
                    }
                }
                label2.Text = contestants[index].Name;
                label1.Text = "Winner";
                label2.Visible = true;
                label1.Visible = true;
            }
            else
            {
                count++;
                label1.Text = listBox1.Items[count].ToString();

                textBox1.Visible = true;
                button1.Visible = false;
                button2.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label2.Text = ("Judge" + judgeCount).ToString();
            }
           
        }
    }
}
