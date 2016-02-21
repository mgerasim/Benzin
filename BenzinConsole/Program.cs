using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenzinConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            UpdateSchema();
        }
        static void UpdateSchema()
        {
            Benzin.Common.NHibernateHelper.UpdateSchema();
        }
    }
}
