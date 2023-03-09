using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using DataProvider;

namespace InClassTest
{
    public class FileManager 
    {
        public int id { get; set; }
        public Thread th { get; set; }
        public IProgressReporter pr;
        static object locker = new object();
        public FileManager(IProgressReporter _pr)
        {
            th = new Thread(ReadAndSave);
            pr = _pr;
        }
        public void ReadAndSave()
        {
            Client<DJI> client = Client<DJI>.GetInstance(DataType.DJI);
            List<string> list = client.Get(th.ManagedThreadId);

            Monitor.Enter(locker);
            try
            {
                foreach(string item in list)
                {
                    client.Save(th.ManagedThreadId, item);
                }
                pr.Save(list, th.ManagedThreadId);
            }
            finally
            {
                Monitor.Exit(locker);
            }
        }
    }
}
