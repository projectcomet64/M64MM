using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace M64MM.Utils
{
    public class SettingsGroup
    {
        // Expose the otherwise private entries property so the JSON parser can write and read.
        [JsonProperty(PropertyName = "settings")]
        static Dictionary<string, object> entries = null;

        /// <summary>
        /// Constructor for a Settings Group
        /// </summary>
        public SettingsGroup()
        {
            entries = new Dictionary<string, object>();
        }
        /// <summary>
        /// Constructor for a Settings Group, adds entries immediatly.
        /// </summary>
        /// <param name="presetEntries">A Dictionary with already written entries (for the JSON parser)</param>
        // We * WILL * use this one for JSON
        [JsonConstructor]
        public SettingsGroup(Dictionary<string, object> settings)
        {
            entries = settings;
        }

        /// <summary>
        /// Makes sure the setting exists. If it doesn't, it will set it to the default value of the variable.
        /// </summary>
        /// <typeparam name="T">The type of the setting to ensure.</typeparam>
        /// <param name="settingName">The name of the setting in this group to ensure.</param>
        /// <returns>The same that GetSettingValue would return.</returns>
        public T EnsureSettingValue<T>(string settingName)
        {
            if ((entries != null && entries.ContainsKey(settingName)) == false)
            {
                SetSettingValue<T>(settingName, default(T), true);
            }
            if (typeof(T) == null)
            {
                throw new ArgumentException("The requested type is null.");
            }
            return GetSettingValue<T>(settingName);
        }

        /// <summary>
        /// Gets a setting from this SettingsGroup. If it doesn't exist, an ArgumentException is raised.
        /// </summary>
        /// <typeparam name="T">Type of the setting value.</typeparam>
        /// <param name="settingName">Name of the setting to find from this group.</param>
        /// <returns>The setting as type T. null if the read value cannot be casted</returns>
        public T GetSettingValue<T>(string settingName)
        {
            if ((entries != null && entries.ContainsKey(settingName)) == false)
            {
                throw new ArgumentException($"Cannot find the setting {settingName} in this group.");
            }
            if (typeof(T) == null)
            {
                throw new ArgumentException("The requested type is null.");
            }
            return (T)Convert.ChangeType(entries[settingName], typeof(T));
        }

        /// <summary>
        /// Sets a setting in this SettingGroup. To save memory, the Dictionary is NULL until it gets at least one setting.
        /// </summary>
        /// <typeparam name="T">Type of the setting to set.</typeparam>
        /// <param name="settingName">Name of the setting to set. Will update the setting if it's already present.</param>
        /// <param name="value">Value of the setting to set.</param>
        /// <param name="force"><para>Forces the rewriting of the parameter type for the setting value.</para><para>Useful if setting for the first time to avoid any clashes in the future or if configuration types are incorrect and need fixing.</para></param>
        public void SetSettingValue<T>(string settingName, T value, bool force = false)
        {
            object valueObject = Convert.ChangeType(value, typeof(T));
            //If there aren't any entry declarations for this particular group
            if (entries == null)
            {
                entries = new Dictionary<string, object>();
            }
            //If the key already exists...
            if (entries.ContainsKey(settingName))
            {
                if (!force)
                {
                    /* Do some basic type checking beforehand.
                     * It'll throw a FormatException if the type that is
                     * saved doesn't match with the type to write.
                     * 
                     * I have changed the value part of the Dicionary to be Object
                     * this way the JSON will be serialized however the JsonSerializer
                     * wants to, and I don't have to do any wacky weird stuffy stupido
                     * string conversion thingamajig that would've actually become a problem
                     * in the future
                     * 
                     * (thanks Super)
                     */
                        Convert.ChangeType(entries[settingName], typeof(T));
                        entries[settingName] = valueObject;
                }
                else
                {
                    //To hell with it. Throw it all in.
                    entries[settingName] = valueObject;
                }
            }
            else
            {
                entries.Add(settingName, valueObject);
            }
        }
    }
}
