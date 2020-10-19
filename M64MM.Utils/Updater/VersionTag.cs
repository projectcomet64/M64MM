using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace M64MM.Utils
{
    public class VersionTagManager
    {
        public static VersionTag GetVersionFromTag(string Tag)
        {
            VersionTag vTag = new VersionTag();
            int[] verNumber = new int[4];
            string[] trimmedverString = Tag.TrimStart('v').Split('-')[0].Split('.');
            for (int i = 0; i < trimmedverString.Length; i++)
            {
                verNumber[i] = int.Parse(trimmedverString[i]);
            }
            string finalTagNumber = String.Join(".", verNumber);
            vTag.FormalVersionNumber = new Version(finalTagNumber);
            if (Tag.Split('-').Length > 1)
            {
                vTag.ReleaseChannel = Regex.Match(Tag.Split('-')[1], "([A-z]+)").Result("$1");
                vTag.SuffixVersion = int.Parse(Regex.Match(Tag.Split('-')[1], @"(\d)").Result("$1"));
            }
            else
            {
                vTag.ReleaseChannel = "release";
                vTag.SuffixVersion = 0;
            }
            return vTag;
        }

        public class VersionTag
        {
            public Version FormalVersionNumber;
            public string ReleaseChannel;
            public int SuffixVersion;

            public string ToString(bool verbose = false)
            {
                string suffix = "";
                if (ReleaseChannel == "release")
                {
                    if (verbose)
                        suffix = ReleaseChannel + SuffixVersion.ToString();
                }
                else
                {
                    suffix = ReleaseChannel + SuffixVersion.ToString();
                }
                return string.Format(@"{0}-{1}", FormalVersionNumber, suffix);
            }
        }

    }
}
