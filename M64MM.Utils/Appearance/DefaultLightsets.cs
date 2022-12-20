using System.Drawing;

namespace M64MM.Utils
{
    public static class DefaultLightsets
    {

        public static Lightset ClassicLightset = new Lightset();
        public static Lightset SparkLightset = new Lightset();
        public static Lightset X3SLightset = new Lightset();
        public static Lightset PeachGrass = new Lightset();

        static DefaultLightsets()
        {
            InitClassic();
            InitSpark();
            InitX3S();
            InitPeachGrass();
        }

        static void InitClassic()
        {
            ColorPart hatShirt = new ColorPart
            {
                Name = "Hat & Shirt",
                Offset88 = 0x18,
                Offset86 = 0x20,
                DefaultLightColor = Color.FromArgb(255, 0, 0),
                DefaultDarkColor = Color.FromArgb(128, 0, 0)
            };
            ColorPart hair = new ColorPart
            {
                Name = "Hair",
                Offset88 = 0x78,
                Offset86 = 0x80,
                DefaultLightColor = Color.FromArgb(115, 6, 0),
                DefaultDarkColor = Color.FromArgb(57, 3, 0)
            };
            ColorPart skin = new ColorPart
            {
                Name = "Skin",
                Offset88 = 0x60,
                Offset86 = 0x68,
                DefaultLightColor = Color.FromArgb(254, 193, 121),
                DefaultDarkColor = Color.FromArgb(127, 96, 60)
            };
            ColorPart gloves = new ColorPart
            {
                Name = "Gloves",
                Offset88 = 0x30,
                Offset86 = 0x38,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            };
            ColorPart overalls = new ColorPart
            {
                Name = "Overalls",
                Offset88 = 0x0,
                Offset86 = 0x8,
                DefaultLightColor = Color.FromArgb(0, 0, 255),
                DefaultDarkColor = Color.FromArgb(0, 0, 128)
            };
            ColorPart shoes = new ColorPart
            {
                Name = "Shoes",
                Offset88 = 0x48,
                Offset86 = 0x50,
                DefaultLightColor = Color.FromArgb(115, 6, 0),
                DefaultDarkColor = Color.FromArgb(57, 3, 0)
            };

            ClassicLightset.SetPart("hat", hatShirt)
                .SetPart("hair", hair)
                .SetPart("skin", skin)
                .SetPart("gloves", gloves)
                .SetPart("overalls", overalls)
                .SetPart("shoes", shoes)
                .SetPartMapping(CCStandardPart.HAT, "hat")
                .SetPartMapping(CCStandardPart.HAIR, "hair")
                .SetPartMapping(CCStandardPart.SKIN, "skin")
                .SetPartMapping(CCStandardPart.GLOVES, "gloves")
                .SetPartMapping(CCStandardPart.OVERALLS_TOP, "overalls")
                .SetPartMapping(CCStandardPart.SHOES, "shoes");
        }

        static void InitSpark()
        {
            ColorPart hat = new ColorPart
            {
                Name = "Hat",
                Offset88 = 0x18,
                Offset86 = 0x20,
                DefaultLightColor = Color.FromArgb(255, 0, 0),
                DefaultDarkColor = Color.FromArgb(128, 0, 0)
            };
            ColorPart hair = new ColorPart
            {
                Name = "Hair",
                Offset88 = 0x78,
                Offset86 = 0x80,
                DefaultLightColor = Color.FromArgb(115, 6, 0),
                DefaultDarkColor = Color.FromArgb(57, 3, 0)
            };
            ColorPart skin = new ColorPart
            {
                Name = "Skin",
                Offset88 = 0x60,
                Offset86 = 0x68,
                DefaultLightColor = Color.FromArgb(254, 193, 121),
                DefaultDarkColor = Color.FromArgb(127, 96, 60)
            };
            ColorPart shirt = new ColorPart
            {
                Name = "Shirt",
                Offset88 = 0x90,
                Offset86 = 0x98,
                DefaultLightColor = Color.FromArgb(255, 0, 0),
                DefaultDarkColor = Color.FromArgb(128, 0, 0)
            };
            ColorPart shoulders = new ColorPart
            {
                Name = "Shoulders",
                Offset88 = 0xA8,
                Offset86 = 0xB0,
                DefaultLightColor = Color.FromArgb(255, 0, 0),
                DefaultDarkColor = Color.FromArgb(128, 0, 0)
            };
            ColorPart arms = new ColorPart
            {
                Name = "Arms",
                Offset88 = 0xC0,
                Offset86 = 0xC8,
                DefaultLightColor = Color.FromArgb(255, 0, 0),
                DefaultDarkColor = Color.FromArgb(128, 0, 0)
            };
            ColorPart gloves = new ColorPart
            {
                Name = "Gloves",
                Offset88 = 0x30,
                Offset86 = 0x38,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            };
            ColorPart overalls1 = new ColorPart
            {
                Name = "Overalls Top",
                Offset88 = 0x0,
                Offset86 = 0x8,
                DefaultLightColor = Color.FromArgb(0, 0, 255),
                DefaultDarkColor = Color.FromArgb(0, 0, 128)
            };
            ColorPart overalls2 = new ColorPart
            {
                Name = "Overalls Bottom",
                Offset88 = 0xD8,
                Offset86 = 0xE0,
                DefaultLightColor = Color.FromArgb(0, 0, 255),
                DefaultDarkColor = Color.FromArgb(0, 0, 128)
            };
            ColorPart leg1 = new ColorPart
            {
                Name = "Leg Top",
                Offset88 = 0xF0,
                Offset86 = 0xF8,
                DefaultLightColor = Color.FromArgb(0, 0, 255),
                DefaultDarkColor = Color.FromArgb(0, 0, 128)
            };
            ColorPart leg2 = new ColorPart
            {
                Name = "Leg Bottom",
                Offset88 = 0x108,
                Offset86 = 0x110,
                DefaultLightColor = Color.FromArgb(0, 0, 255),
                DefaultDarkColor = Color.FromArgb(0, 0, 128)
            };
            ColorPart shoe = new ColorPart
            {
                Name = "Shoes",
                Offset88 = 0x48,
                Offset86 = 0x50,
                DefaultLightColor = Color.FromArgb(115, 6, 0),
                DefaultDarkColor = Color.FromArgb(57, 3, 0)
            };
            ColorPart custom1 = new ColorPart
            {
                Name = "Custom 1",
                Offset88 = 0x120,
                Offset86 = 0x128,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            };
            ColorPart custom2 = new ColorPart
            {
                Name = "Custom 2",
                Offset88 = 0x138,
                Offset86 = 0x140,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            };
            ColorPart custom3 = new ColorPart
            {
                Name = "Custom 3",
                Offset88 = 0x150,
                Offset86 = 0x158,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            };
            ColorPart custom4 = new ColorPart
            {
                Name = "Custom 4",
                Offset88 = 0x168,
                Offset86 = 0x170,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            };
            ColorPart custom5 = new ColorPart
            {
                Name = "Custom 5",
                Offset88 = 0x180,
                Offset86 = 0x188,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            };
            ColorPart custom6 = new ColorPart
            {
                Name = "Custom 6",
                Offset88 = 0x198,
                Offset86 = 0x1A0,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            };
            ColorPart custom7 = new ColorPart
            {
                Name = "Custom 7",
                Offset88 = 0x1B0,
                Offset86 = 0x1B8,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            };
            ColorPart custom8 = new ColorPart
            {
                Name = "Custom 8",
                Offset88 = 0x1C8,
                Offset86 = 0x1D0,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            };

            SparkLightset.SetPart("hat", hat)
                .SetPart("shirt", shirt)
                .SetPart("shoulders", shoulders)
                .SetPart("arms", arms)
                .SetPart("hair", hair)
                .SetPart("skin", skin)
                .SetPart("gloves", gloves)
                .SetPart("overalls", overalls1)
                .SetPart("pants", overalls2)
                .SetPart("thigh", leg1)
                .SetPart("shin", leg2)
                .SetPart("shoes", shoe)
                .SetPart("c1", custom1)
                .SetPart("c2", custom2)
                .SetPart("c3", custom3)
                .SetPart("c4", custom4)
                .SetPart("c5", custom5)
                .SetPart("c6", custom6)
                .SetPart("c7", custom7)
                .SetPart("c8", custom8)
                .SetPartMapping(CCStandardPart.HAT, "hat")
                .SetPartMapping(CCStandardPart.SHIRT, "shirt")
                .SetPartMapping(CCStandardPart.SHIRT_SHOULDER, "shoulders")
                .SetPartMapping(CCStandardPart.SHIRT_ARM, "arms")
                .SetPartMapping(CCStandardPart.HAIR, "hair")
                .SetPartMapping(CCStandardPart.SKIN, "skin")
                .SetPartMapping(CCStandardPart.GLOVES, "gloves")
                .SetPartMapping(CCStandardPart.OVERALLS_TOP, "overalls")
                .SetPartMapping(CCStandardPart.OVERALLS_BOTTOM, "pants")
                .SetPartMapping(CCStandardPart.LEGS_TOP, "thigh")
                .SetPartMapping(CCStandardPart.LEGS_BOTTOM, "shin")
                .SetPartMapping(CCStandardPart.SHOES, "shoes")
                .SetPartMapping(CCStandardPart.CUSTOM1, "c1")
                .SetPartMapping(CCStandardPart.CUSTOM2, "c2")
                .SetPartMapping(CCStandardPart.CUSTOM3, "c3")
                .SetPartMapping(CCStandardPart.CUSTOM4, "c4")
                .SetPartMapping(CCStandardPart.CUSTOM5, "c5")
                .SetPartMapping(CCStandardPart.CUSTOM6, "c6")
                .SetPartMapping(CCStandardPart.CUSTOM7, "c7")
                .SetPartMapping(CCStandardPart.CUSTOM8, "c8");
        }

        static void InitX3S() {
            ColorPart tint = new ColorPart {
                Name = "X3S Tint",
                Offset88 = 0x1C800,
                Offset86 = 0x1C808,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            };
            X3SLightset.SetPart("tint", tint)
                .SetPartMapping(CCStandardPart.LEGACY_CHARA_TINT, "tint");
        }

        static void InitPeachGrass() {
            // Attribution: sm64rise
            // I however dislike this specific method so it may get deprecated really quickly
            ColorPart tint1 = new ColorPart
            {
                Name = "Grass, sand, bridge",
                Offset88 = 0x07006ED8,
                Offset86 = 0x07006EE0,
                IsAddressSegmented = true,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            };
            ColorPart tint2 = new ColorPart
            {
                Name = "Unsure.",
                Offset88 = 0x07006EF0,
                Offset86 = 0x07006EF8,
                IsAddressSegmented = true,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            };

            ColorPart tint7 = new ColorPart
            {
                Name = "Shade07",
                Offset86 = 0x07006F28,
                Offset88 = 0x07006F20,
                IsAddressSegmented = true,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            };
            ColorPart tint4 = new ColorPart
            {
                Name = "Wet sands & bricks",
                Offset88 = 0x07006F08,
                Offset86 = 0x07006F10,
                IsAddressSegmented = true,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            };
            ColorPart tint9 = new ColorPart
            {
                Name = "SOME moat walls",
                Offset86 = 0x07006F40,
                Offset88 = 0x07006F38,
                IsAddressSegmented = true,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            };
            ColorPart tint10 = new ColorPart
            {
                Name = "Cliff Near Waterfall",
                Offset86 = 0x07006F58,
                Offset88 = 0x07006F50,
                IsAddressSegmented = true,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            };
            ColorPart tint12 = new ColorPart
            {
                Name = "Unsure.",
                Offset86 = 0x07006F70,
                Offset88 = 0x07006F68,
                IsAddressSegmented = true,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            };
            ColorPart tint15 = new ColorPart
            {
                Name = "Outer Hill Grass",
                Offset86 = 0x07006F88,
                Offset88 = 0x07006F80,
                IsAddressSegmented = true,
                DefaultLightColor = Color.FromArgb(255, 255, 255),
                DefaultDarkColor = Color.FromArgb(128, 128, 128)
            };

            PeachGrass.SetPart("pl1", tint1)
                .SetPart("pl2", tint2)
                .SetPart("pl4", tint7)
                .SetPart("pl3", tint4)
                .SetPart("pl5", tint9)
                .SetPart("pl6", tint10)
                .SetPart("pl7", tint12)
                .SetPart("pl8", tint15)
                .SetPartMapping(CCStandardPart.LEVEL_TINT1, "pl1");
        }
    }
}