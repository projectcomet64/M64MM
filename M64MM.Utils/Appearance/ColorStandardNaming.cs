namespace M64MM.Utils {
    public enum CCStandardPart {
        PANTS,
        HAT,
        GLOVES,
        SHOES,
        SKIN,
        HAIR,
        SHIRT,
        SHIRT_SHOULDER,
        SHIRT_ARM,
        OVERALLS_TOP,
        OVERALLS_BOTTOM,
        LEGS_TOP,
        LEGS_BOTTOM,
        CUSTOM1,
        CUSTOM2,
        CUSTOM3,
        CUSTOM4,
        CUSTOM5,
        CUSTOM6,
        CUSTOM7,
        CUSTOM8,
        LEGACY_CHARA_TINT, // X3S and others
        LEVEL_TINT1,
        LEVEL_TINT2, // Anything beyond is futureproofing
        LEVEL_TINT3,
        LEVEL_TINT4
    }

    public static class CCStandardHelpers {
        public static readonly CCStandardPart[] SparkStandard = new CCStandardPart[] {
            CCStandardPart.SHIRT, CCStandardPart.SHIRT_ARM, CCStandardPart.SHIRT_SHOULDER,
            CCStandardPart.OVERALLS_BOTTOM, CCStandardPart.LEGS_TOP, CCStandardPart.LEGS_BOTTOM,
            CCStandardPart.CUSTOM1, CCStandardPart.CUSTOM2, CCStandardPart.CUSTOM3, CCStandardPart.CUSTOM4,
            CCStandardPart.CUSTOM5, CCStandardPart.CUSTOM6, CCStandardPart.CUSTOM7, CCStandardPart.CUSTOM8
        };

        public static readonly CCStandardPart[] ColorcodeableStandard = new CCStandardPart[] {
            CCStandardPart.SHIRT, CCStandardPart.SHIRT_ARM, CCStandardPart.SHIRT_SHOULDER,
            CCStandardPart.OVERALLS_BOTTOM, CCStandardPart.LEGS_TOP, CCStandardPart.LEGS_BOTTOM,
            CCStandardPart.CUSTOM1, CCStandardPart.CUSTOM2, CCStandardPart.CUSTOM3, CCStandardPart.CUSTOM4,
            CCStandardPart.CUSTOM5, CCStandardPart.CUSTOM6, CCStandardPart.CUSTOM7, CCStandardPart.CUSTOM8
        };
    }
}