using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClassTest
{
    public interface IProgressReporter
    {
        void Read();
        void Save(List<string> list, int id);
    }
}
