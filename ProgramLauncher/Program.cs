using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL;
using System.IO;
using DAL;
using BL;

namespace ProgramLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            DALI DAL = new DALManager();
            BL_interface BL = new BL_manager(DAL);
            IPL PL = new PL_CLI(BL);
            PL.run();

        }
    }
}
