using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities {

    public static class Math {
        static float randomBinomial() {
            return Random.Range(-1f, 1f) - Random.Range(-1f, 1f);
        }

    }
}
