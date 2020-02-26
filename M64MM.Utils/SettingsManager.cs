using System.Collections.Generic;

namespace M64MM.Utils
{
    public static class SettingsManager
    {
        static Dictionary<string, SettingsGroup> _settings = new Dictionary<string, SettingsGroup>();

        /// <summary>
        /// Returns the SettingsGroup provided by its Key string.
        /// </summary>
        /// <param name="key">The Key string of the group.</param>
        /// /// <param name="ensure">If true, creates the SettingsGroup with this key if it doesn't exist.</param>
        /// <returns>The SettingsGroup that corresponds to this key</returns>
        public static SettingsGroup GetSettingsGroup(string key, bool ensure = false)
        {
            if (_settings.ContainsKey(key))
            {
                return _settings[key];
            }
            else
            {
                if (!ensure)
                {
                    return null;
                }
                else
                {
                    _settings.Add(key, new SettingsGroup());
                    return _settings[key];
                }
                
            }
        }

        /// <summary>
        /// Adds a SettingsGroup identified by its name.
        /// Mostly to be used by the JSON parser.
        /// </summary>
        /// <param name="name">The name of the SettingGroup</param>
        /// <param name="group">The group itself.</param>
        public static void AddSettingsGroup(string name, SettingsGroup group)
        {
            _settings.Add(name, group);
        }

    }
}
