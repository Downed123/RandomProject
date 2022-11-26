using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Globals
{
    [Serializable]
    public struct EnemyStats
    {
        public GameObject obj;
        public int quantity;
        public Vector3 center;
        public float range;
        public float spawnTime;
        public AlignmentMode alignmentMode;
    }

    public enum AlignmentMode
    {
        Horizontal,
        Circular
    }
}
