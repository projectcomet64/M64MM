using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M64MM2
{
    class UpdateCounterEveryFrame : Updatable
    {
        public static int framenumber;
        public override void Update()
        {
            framenumber++;
        }
        public override void Reset()
        {
            framenumber = 0;
        }
    }
}
