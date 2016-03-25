using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sharedClasses;

namespace BL
{
    public interface BL_interface
    {
        bool connect(String username, string password);
        string SetRandomPass();
        void disconnect();
        void ChangePass(String newpass1, String newpass2);
        bool verification(string pass);
        User getuser();
        bool legalPass(string Password1);
    }
}
