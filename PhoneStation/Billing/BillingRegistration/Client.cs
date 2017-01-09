using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing
{
    public class Client
    {
        public int clientID;
        public string name;


        public Client(int clientid, string name)
        {
            clientID = clientid;
            this.name = name;

        }
        public override string ToString()
        {
            return name;
        }
    }
}
