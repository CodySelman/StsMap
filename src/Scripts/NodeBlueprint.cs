using UnityEngine;

namespace StsMap
{
    public enum NodeType
    {
        MinorEnemy,
        EliteEnemy,
        RestSite,
        Treasure,
        Store,
        Boss,
        Mystery
    }
}

namespace StsMap
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Map/NodeBlueprint", order = 2)]
    public class NodeBlueprint : ScriptableObject
    {
        public Sprite sprite;
        public NodeType nodeType;
    }
}