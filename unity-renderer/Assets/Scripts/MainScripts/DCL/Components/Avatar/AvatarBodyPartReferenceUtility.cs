using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DCL
{
    public static class AvatarBodyPartReferenceUtility
    {
        public static Transform GetLeftHand(Transform[] bodyParts)
        {
            return GetBodyPart(bodyParts, "Wrist_L");
        }

        public static Transform GetRightHand(Transform[] bodyParts)
        {
            return GetBodyPart(bodyParts, "Wrist_R");
        }

        public static Transform GetLeftToe(Transform[] bodyParts)
        {
            return GetBodyPart(bodyParts, "Toes_L");
        }

        public static Transform GetRightToe(Transform[] bodyParts)
        {
            return GetBodyPart(bodyParts, "Toes_R");
        }

        private static Transform GetBodyPart(Transform[] bodyParts, string name)
        {
            for (int i = 0; i < bodyParts.Length; i++) {
                if (bodyParts[i].name == name)
                    return bodyParts[i];
            }
            return null;
        }
    }
}