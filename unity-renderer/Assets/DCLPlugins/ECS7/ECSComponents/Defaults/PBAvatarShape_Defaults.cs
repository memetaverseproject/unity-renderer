using Decentraland.Common;
using System;
using Google.Protobuf.Collections;

namespace DCL.ECSComponents
{
    public static class PBAvatarShape_Defaults
    {
        private const string avatarDefaultBodyShape = "urn:memetaverse:off-chain:base-avatars:BaseFemale";

        private static readonly Color3 neutralColor = new Color3()
        {
            R = 0.6f, G = 0.462f, B = 0.356f
        };

        private static readonly Color3 hairDefaultColor = new Color3()
        {
            R = 0.283f, G = 0.142f, B = 0f
        };

        private static readonly RepeatedField<string> defaultWearables = new RepeatedField<string>()
        {
            "urn:memetaverse:off-chain:base-avatars:f_eyes_00",
            // "urn:memetaverse:off-chain:base-avatars:f_eyebrows_00",
            "urn:memetaverse:off-chain:base-avatars:f_mouth_00",
            // "urn:memetaverse:off-chain:base-avatars:standard_hair",
            // "urn:memetaverse:off-chain:base-avatars:light_green_jennie_short_dress",
            // "urn:memetaverse:off-chain:base-avatars:purple_pants",
            // "urn:memetaverse:off-chain:base-avatars:black_while_shoes"
        };

        public static long GetExpressionTriggerTimestamp(this PBAvatarShape self)
        {
            return self.HasExpressionTriggerTimestamp ? self.ExpressionTriggerTimestamp : DateTime.Now.ToFileTimeUtc();
        }

        public static string GetBodyShape(this PBAvatarShape self)
        {
            return self.HasBodyShape ? self.BodyShape : avatarDefaultBodyShape;
        }

        public static Color3 GetEyeColor(this PBAvatarShape self)
        {
            return self.EyeColor ?? new Color3(neutralColor);
        }

        public static Color3 GetHairColor(this PBAvatarShape self)
        {
            return self.HairColor ?? new Color3(hairDefaultColor);
        }

        public static Color3 GetSkinColor(this PBAvatarShape self)
        {
            return self.SkinColor ?? new Color3(neutralColor);
        }

        public static string GetName(this PBAvatarShape self)
        {
            return self.HasName ? self.Name : "NPC";
        }

        public static RepeatedField<string> GetWereables(this PBAvatarShape self)
        {
            return self.Wearables.Count != 0 ? self.Wearables : defaultWearables;
        }
    }
}
