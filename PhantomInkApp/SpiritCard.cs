using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhantomInkApp
{
    public class SpiritCard
    {
        public SpiritCard(string[] things) 
        {
            if (things == null)
                throw new Exception("SpiritCard must contain 6 things, not null");
            if (things.Length != 6)
                throw new Exception("SpiritCard must contain 6 things");
            this.things = things;   
        }
        private string[] things = new string[] { };
        public string[] Things { get { return things; } }
    }
}
