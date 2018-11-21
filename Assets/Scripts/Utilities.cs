using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities {

    public static class Math {
        public static float MapToRange(float rotation) {
            rotation %= 360.0f;
            if(Mathf.Abs(rotation) > 180.0f) {
                if(rotation < 0.0f) {
                    rotation += 360.0f;
                } else {
                    rotation -= 360.0f;
                }
            }
            return rotation;
        }

        public static Vector3 GetOrientationAsVector(float orientation) {
            Vector3 vector = Vector3.zero;
            vector.x = Mathf.Sin(orientation * Mathf.Deg2Rad) * 1.0f;
            vector.z = Mathf.Cos(orientation * Mathf.Deg2Rad) * 1.0f;
            return vector.normalized;
        }

    }
}
