using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelsMasterMindsConsole
{
    public abstract class MasterMindsBase
    {
        protected MasterMindsNumber ComputerNumber = new MasterMindsNumber();

        public abstract void Play();
    }
}
