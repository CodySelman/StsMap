using System.Collections.Generic;
using UnityEngine;

namespace StsMap
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Map/MapConfig", order = 1)]
    public class MapConfig : ScriptableObject
    {
        public List<NodeBlueprint> nodeBlueprints;
        public int GridWidth => Mathf.Max(numOfPreBossNodes.max, numOfStartingNodes.max);

        public IntMinMax numOfPreBossNodes;
        public IntMinMax numOfStartingNodes;
        public List<MapLayer> layers;

        [System.Serializable]
        public class ListOfMapLayers : List<MapLayer>
        {
        }
    }
}