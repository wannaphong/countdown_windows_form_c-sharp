using System;
using System.Windows.Forms;

namespace countdown
{
    public partial class Form1 : Form
    {
        double settime = 0;
        bool run;
        DateTime time = DateTime.Now;
        DateTime t1 = DateTime.Now;
        DateTime t2 = new DateTime(2017, 12, 25, 9, 0, 0);
        
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (run != false && settime > 0) // กรณี run ไม่เป็น false และ settime มากกว่า 0
            {
                settime--; // ให้ลบค่า 1 ค่าใน settime
                countdown_time.Text= string.Format("{0:00}:{1:00}:{2:00}", settime / 3600, (settime / 60) % 60, settime % 60); // แปลงเป็น ชั่วโมง นาที วินาที
                if (settime <= 0) // กรณี settime เท่ากับ 0
                {
                    timer1.Stop(); // ให้หยุดการทำงาน timer1
                    run = false; // ให้ run เป็น false
                    timer1.Enabled = false; // ให้ปิดการใช้งาน timer1
                }
            }
            else // กรณีไม่เข้าเงื่อนไขข้างบน
            {
                countdown_time.Text = "00:00:00"; //ให้ข้อความของ label2 เป็น  "00:00:00"
                run = false; // ให้ run เป็น false
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            run = true; // ให้ run เป็น true
            double diffInSeconds = (t2 - t1).TotalSeconds; // หาความความต่างเวลาในหน่วยวินาที
            settime = diffInSeconds; //h*60*60+m*60+s;
            if (settime != 0) // ถ้า settime ไม่เป็น 0
            {
                timer1.Enabled = true; // ให้เปิดการใช้งาน timer1
                timer1.Start(); // ให้เริ่มการทำงาน timer1
            }
        }
    }
}
