using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace M64MM.Utils {
    public static class Updater {
        public static async Task<GitHubRelease> FindNewUpdate(VersionTagManager.VersionTag currentVersion, string[] lookingFor = null) {
            if (lookingFor == null) {
                lookingFor = new[] { currentVersion.ReleaseChannel };
            }

            Tuple<HttpStatusCode, GitHubRelease> requestLatest = await Task.Run(() => CheckUpdate(currentVersion, lookingFor));
            if (requestLatest.Item1 == HttpStatusCode.OK) {
                return requestLatest.Item2;
            }
            else {
                throw new HttpListenerException((int)requestLatest.Item1, "Could not check for updates; network error.");
            }
        }

        public static async Task<Tuple<HttpStatusCode, GitHubRelease>> CheckUpdate(VersionTagManager.VersionTag currentVer, string[] lookingFor = null) {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "M64MM/3.0 (.NET 4.7)");
            HttpResponseMessage latestReleases =
         await Task.Run(() => client.GetAsync("https://api.github.com/repos/projectcomet64/M64MM/releases"));


            if (!latestReleases.IsSuccessStatusCode) {
                return new Tuple<HttpStatusCode, GitHubRelease>(latestReleases.StatusCode, null);
            }

            // TODO: Allow updating from different URLs
            // for example: for addons

            JArray parsedReleases = JArray.Parse(await latestReleases.Content.ReadAsStringAsync());
            List<GitHubRelease> releasesList = parsedReleases.ToObject<List<GitHubRelease>>();

            IEnumerable<GitHubRelease> matchingList =
                releasesList.Where(x => lookingFor.Contains(x.VersionTag.ReleaseChannel));

            int matchingLatestNumber = releasesList.Count(x => CheckVersion(x.VersionTag, currentVer, lookingFor));

            // lol LINQ moment
            IEnumerable<GitHubRelease> matchingLatestList = releasesList
                .Where(x => CheckVersion(x.VersionTag, currentVer, lookingFor)).Reverse().Skip(matchingLatestNumber)
                .Reverse();


            if (!matchingLatestList.Any()) {
                return new Tuple<HttpStatusCode, GitHubRelease>(HttpStatusCode.OK, matchingList.First());
            }
                

            return new Tuple<HttpStatusCode, GitHubRelease>(HttpStatusCode.OK, matchingLatestList.First());

        }

        public static bool CheckVersion(VersionTagManager.VersionTag latest, VersionTagManager.VersionTag current, string[] lookingFor = null) {
            if (lookingFor == null) {
                lookingFor = new[] { current.ReleaseChannel };
            }

            if (latest.FormalVersionNumber >= current.FormalVersionNumber
                && lookingFor.Contains(latest.ReleaseChannel)) {
                if (latest.ReleaseChannel == current.ReleaseChannel) {
                    return (latest.SuffixVersion > current.SuffixVersion);
                }

                return true;

            }
            else {
                return false;
            }
        }
    }
}
