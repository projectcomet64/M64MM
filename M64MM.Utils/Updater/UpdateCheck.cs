using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace M64MM.Utils
{
    public static class Updater
    {
        public static async Task<Tuple<HttpStatusCode, GitHubRelease>> CheckUpdate()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("User-Agent", "M64MM/3.0 (.NET 4.6)");

            HttpResponseMessage latestReleases = await client.GetAsync("https://api.github.com/repos/projectcomet64/M64MM/releases");

            if (!latestReleases.IsSuccessStatusCode)
            {
                return new Tuple<HttpStatusCode, GitHubRelease>(latestReleases.StatusCode, null);
            }

            JArray parsedReleases = JArray.Parse(await latestReleases.Content.ReadAsStringAsync());
            List<JToken> releasesList = parsedReleases.ToList();

            GitHubRelease latestReleaseObject = releasesList[0].ToObject<GitHubRelease>();

            return new Tuple<HttpStatusCode, GitHubRelease>(HttpStatusCode.OK, latestReleaseObject);
        }

        public static bool GotNewVersion(VersionTagManager.VersionTag latest, VersionTagManager.VersionTag current)
        {
            if (latest.FormalVersionNumber >= current.FormalVersionNumber
                && latest.ReleaseChannel == current.ReleaseChannel
                && latest.SuffixVersion > current.SuffixVersion)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
