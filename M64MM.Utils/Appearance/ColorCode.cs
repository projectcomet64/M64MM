using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M64MM.Utils;
namespace M64MM.Utils
{
    class ColorCode
    {
        Dictionary<string, RoutableColorPart> ccParts;

        public ColorCode()
        {
            ccParts = new Dictionary<string, RoutableColorPart>();
        }

        virtual public void FromColorCodeGS() {
            // Nothing. Raw color code base should not have any implementation from gameshark CC
        }

        public string ToColorCodeGS()
        {
            StringBuilder ccStringBuilder = new StringBuilder();
            foreach (KeyValuePair<string, RoutableColorPart> kv in ccParts)
            {
                long ccAddrLight1 = Core.SegmentedToVirtual(0x04000000, false) + kv.Value.BankOffset86;
                long ccAddrLight2 = ccAddrLight1 + 2;
                long ccAddrShadow1 = Core.SegmentedToVirtual(0x04000000, false) + kv.Value.BankOffset88;
                long ccAddrShadow2 = ccAddrShadow1 + 2;

                // Append the relevant lines to the CC
                ccStringBuilder.AppendLine($"81{BitConverter.ToString(BitConverter.GetBytes(ccAddrLight1).Reverse().ToArray())} {kv.Value.CurrentLightColor.R.ToString("X2")}{kv.Value.CurrentLightColor.G.ToString("X2")}");
                ccStringBuilder.AppendLine($"81{BitConverter.ToString(BitConverter.GetBytes(ccAddrLight2).Reverse().ToArray())} {kv.Value.CurrentLightColor.B.ToString("X2")}00");
                ccStringBuilder.AppendLine($"81{BitConverter.ToString(BitConverter.GetBytes(ccAddrShadow1).Reverse().ToArray())} {kv.Value.CurrentShadowColor.R.ToString("X2")}{kv.Value.CurrentShadowColor.G.ToString("X2")}");
                ccStringBuilder.AppendLine($"81{BitConverter.ToString(BitConverter.GetBytes(ccAddrShadow2).Reverse().ToArray())} {kv.Value.CurrentShadowColor.B.ToString("X2")}00");
            }
            return ccStringBuilder.ToString();
        }
    }
}
