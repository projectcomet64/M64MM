using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace M64MM.Utils
{
    public class GitHubRelease
    {

        [JsonProperty(PropertyName = "tag_name")]
        public string TagName { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string ReleaseName { get; set; }
        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }
        [JsonProperty(PropertyName = "html_url")]
        public string ReleaseLink { get; set; }

    }
}
