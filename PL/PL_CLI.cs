using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace PL
{
    public class PL_CLI: IPL
    {
        BL_interface BL;

        public PL_CLI(BL_interface BL)
        {
            this.BL = BL;

        }

        public void run()
        {
           
            new connection_frame(BL);
        }
    }
}
