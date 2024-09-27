using Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lists;

namespace Group4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateLabel1();
        }
        // Collection C = new ArrayCollection(10);
        //Collection C = new LinkedCollection();
        //Collection C = new LinkedHeaderCollection();
        //Collection c = new ArraySet(10);
        //Collection c = new LinkedSet(10);

        List C = new ArrayList(10);
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                C.add(textBox1.Text);
                MessageBox.Show("เพิ่มข้อมูล: " + textBox1.Text + " สำเร็จ!");
                textBox1.Clear();
                UpdateLabel1(); // อย่าลืมใช้ชื่อ method ที่ถูกต้อง (Updatelabel1)
                
            }
            else
            {
                MessageBox.Show("กรุณาใส่ข้อมูล");
            }
        }

            private void button2_Click(object sender, EventArgs e)
        {
            
            if (C.contains(textBox1.Text))
            {
                MessageBox.Show("มีข้อมูล: " + textBox1.Text);
            }
            else MessageBox.Show("ไม่มีข้อมูล: " + textBox1.Text);
            
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                C.remove(textBox1.Text);
                MessageBox.Show("นำออกข้อมูล: " + textBox1.Text + " สำเร็จ!");
                textBox1.Clear();
                UpdateLabel1();
            }
            else
            {
                MessageBox.Show("ไม่มีข้อมูลให้นำออก");
            }
           
        }
        private void button4_Click(object sender, EventArgs e)
        {

            string Order = textBox2.Text;

            if (string.IsNullOrWhiteSpace(Order)) { MessageBox.Show( "กรุณาใส่ลำดับ"); textBox2.Clear();
                textBox3.Clear(); return; }

            int toInt;

            if (!int.TryParse(Order, out toInt) || toInt < 1)
            {
                MessageBox.Show("กรุณาใส่ค่ามากกว่าหรือเท่ากับ 1");
                textBox2.Clear();
                textBox3.Clear();
                return; 
            }

            toInt -= 1; 

            // ตรวจสอบว่าค่าที่ป้อนได้อยู่ในช่วงที่ถูกต้อง
            if (toInt >= 0 && toInt < C.size())
            {
                textBox3.Text = (string)C.get(toInt);
            }
            else
            {
                MessageBox.Show("กรุณาใส่ลำดับที่ 1 ถึง " + C.size());
                textBox2.Clear();
                textBox3.Clear();
            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            string myString = textBox2.Text; 
            object newText = textBox3.Text;  

            if (!string.IsNullOrEmpty(myString))
            {
                int index;
                if (int.TryParse(myString, out index))
                {
                    index -= 1; // เนื่องจาก index ของ ArrayList เริ่มต้นที่ 0

                    if (index >= 0 && index < C.size())  
                    {
                        C.remove(index);  
                        C.add(index, newText); 
                        UpdateLabel1();    // อัปเดต listBox เพื่อแสดงข้อมูลใหม่
                        MessageBox.Show("แก้ไขข้อมูลสำเร็จ");
                        textBox2.Clear();
                        textBox3.Clear();
                    }
                    else
                    {
                        MessageBox.Show("ไม่มีข้อมูลในตำแหน่งที่ระบุ");
                        textBox2.Clear();
                        textBox3.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("กรุณาใส่ค่าตัวเลขที่ถูกต้อง");
                    textBox2.Clear();
                    textBox3.Clear();
                }
            }
            else
            {
                MessageBox.Show("กรุณาใส่ตำแหน่งที่ต้องการแก้ไข");
                textBox2.Clear();
                textBox3.Clear();
            }

        }
        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            for (int i = 0; i < C.size(); i++)
            {
                object item = C.get(i);
                if (item != null)
                listBox1.Items.Add("ลำดับที่ " + (i + 1) + " = " + item);
            }

            if (listBox1.Items.Count == 0)
            {
                listBox1.Items.Add("The list is empty.");
            }
        }
        private void UpdateLabel1()
        {
            int Size = C.size();
            label1.Text = "จำนวน " + Size.ToString() + " คน";
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
