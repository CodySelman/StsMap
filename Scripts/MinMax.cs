using UnityEngine;

namespace StsMap
{
    [System.Serializable]
    public class FloatMinMax
    {
        public float min;
        public float max;

        public float GetValue()
        {
            return Random.Range(min, max);
        }
    }
}

namespace StsMap
{
    [System.Serializable]
    public class IntMinMax
    {
        public int min;
        public int max;

        public int GetValue()
        {
            return Random.Range(min, max + 1);
        }
    }
}
