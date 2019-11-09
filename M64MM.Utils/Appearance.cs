using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static M64MM.Utils.Core;
namespace M64MM.Utils
{
    public class Looks
    {

        static readonly int[] shadowAddresses = {
            0x07EC30,
            0x07EC48,
            0x07EC60,
            0x07EC78,
            0x07EC90,
            0x07ECA8
        };

        public enum ShadowParts
        {
            X,
            Y,
            Z
        }

        public static void changeShadow(int amount, ShadowParts part)
        {
            byte[] data = new byte[1];
            data[0] = (byte)amount;

            foreach (int address in shadowAddresses)
            {
                switch (part)
                {
                    case ShadowParts.X:
                        WriteBytes(BaseAddress + address + 3, data);
                        break;
                    case ShadowParts.Y:
                        WriteBytes(BaseAddress + address + 2, data);
                        break;
                    case ShadowParts.Z:
                        WriteBytes(BaseAddress + address + 1, data);
                        break;
                }
            }
        }
    }
}