using System;
using System.Collections.Generic;
using System.Linq;

namespace M64MM.Utils {
    public class Lightset {
        private Dictionary<string, ColorPart> _parts;
        private Dictionary<CCStandardPart, string> _partMapping;

        public bool SparkCompatible {
            get
            {
                return _partMapping.Keys.Any(x => CCStandardHelpers.SparkStandard.Contains(x));
            }
        }

        public bool NormalColorcodeCompatible
        {
            get
            {
                return _partMapping.Keys.Any(x => CCStandardHelpers.ColorcodeableStandard.Contains(x));
            }
        }

        /// <summary>
        /// Sets a ColorPart to a given ID. If the ID exists, it's overwritten. If the ColorPart is already assigned, the previous entry is erased.
        /// </summary>
        /// <param name="id">An ID to get the part by</param>
        /// <param name="part">The CC part to set</param>
        public void SetPart(string id, ColorPart part) {
            if (_parts.ContainsKey(id)) {
                _parts[id] = part;
            }
            else {
                if (_parts.Values.Contains(part)) {
                    _parts.Remove(_parts.FirstOrDefault(x => x.Value == part).Key);
                }
                _parts.Add(id, part);
            }
        }

        public void SetPartMapping(CCStandardPart source, string id) {
            if (!_parts.ContainsKey(id)) {
                throw new ArgumentException($"This Lightset has no part with ID \"{id}\".");
            }

            if (_partMapping.ContainsKey(source)) {
                _partMapping[source] = id;
            }
            else {
                _partMapping.Add(source, id);
            }
        }

        public ColorPart GetPartById(string id)
        {
            if (!_parts.ContainsKey(id)) return null;

            return _parts[id];
        }

        public ColorPart GetPart(CCStandardPart stdPart) {
            return GetPartById(_partMapping[stdPart]);
        }

    }
}