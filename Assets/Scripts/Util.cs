using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Deck_Manage 
{
    [System.Serializable]
    public class PRS
    {
        public Vector3 pos;
        public Quaternion rot;
        public Vector3 scale;

        public PRS(Vector3 pos, Quaternion rot, Vector3 scale)
        {
            this.pos = pos;
            this.rot = rot;
            this.scale = scale;
        }
    }

    public class Util : MonoBehaviour
    {
        public static Quaternion QI => Quaternion.identity;
    }
}
