using Keyshift.Core.Classes;

namespace M64MM.Utils.TimelineTools {
    /// <summary>
    /// Wrapper for Timeline to add more information to it unless I decide to add it to the Keyshift Timeline itself
    /// </summary>
    public class TimelineInfo {
        public string Name { get; set; }
        public Timeline Timeline { get; }
        public TimelineInfo(string name, Timeline timeline) {
            Name = name;
            Timeline = timeline;
        }
    }
}