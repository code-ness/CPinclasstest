using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;



namespace InClassTest
{
    public partial class Form1 : Form, IProgressReporter
    {
        public List<FileManager> fms = new List<FileManager>();
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                FileManager fm = new FileManager(this);
                fms.Add(fm);
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            Read();
        }

        public void Read()
        {
            foreach (FileManager fm in fms)
            {
                fm.th.Start();
                listBox1.Items.Add(String.Format("Thread #{0} starting", fm.th.ManagedThreadId));
            }
        }
        public void Save(List<string> list, int id)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                foreach (string item in list)
                {
                    listBox2.Items.Add(String.Format("Thread #{0}: {1}", id, item));
                }
                listBox1.Items.Add(String.Format("Thread #{0} terminating", id));
            }));
        }
    }
}
