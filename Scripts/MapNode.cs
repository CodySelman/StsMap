using System;
using DG.Tweening;
using UnityEngine;

namespace StsMap
{
    public enum NodeStates
    {
        Locked,
        Visited,
        Attainable
    }
}

namespace StsMap
{
    public class MapNode : MonoBehaviour
    {
        public SpriteRenderer sr;
        public SpriteRenderer visitedCircle;

        public Node Node { get; private set; }
        public NodeBlueprint Blueprint { get; private set; }

        private float initialScale;
        private const float HoverScaleFactor = 1.2f;
        private float mouseDownTime;
        private NodeStates state;

        private const float MaxClickDuration = 0.5f;

        public void SetUp(Node node, NodeBlueprint blueprint)
        {
            Node = node;
            Blueprint = blueprint;
            sr.sprite = blueprint.sprite;
            if (node.nodeType == NodeType.Boss) transform.localScale *= 1.5f;
            initialScale = sr.transform.localScale.x;
            visitedCircle.color = MapView.Instance.visitedColor;
            visitedCircle.gameObject.SetActive(false);
            SetState(NodeStates.Locked);
        }

        public void SetState(NodeStates _state)
        {
            state = _state;
            visitedCircle.gameObject.SetActive(false);
            switch (state)
            {
                case NodeStates.Locked:
                    sr.DOKill();
                    sr.color = MapView.Instance.lockedColor;
                    break;
                case NodeStates.Visited:
                    sr.DOKill();
                    sr.color = MapView.Instance.visitedColor;
                    visitedCircle.gameObject.SetActive(true);
                    break;
                case NodeStates.Attainable:
                    // start pulsating from visited to locked color:
                    sr.color = MapView.Instance.lockedColor;
                    sr.DOKill();
                    sr.DOColor(MapView.Instance.visitedColor, 0.5f).SetLoops(-1, LoopType.Yoyo);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private void OnMouseEnter()
        {
            if (state == NodeStates.Attainable) {
                sr.transform.DOKill();
                sr.transform.DOScale(initialScale * HoverScaleFactor, 0.3f);
            }
        }

        private void OnMouseExit()
        {
            if (state == NodeStates.Attainable) {
                sr.transform.DOKill();
                sr.transform.DOScale(initialScale, 0.3f);
            }
        }

        private void OnMouseDown()
        {
            mouseDownTime = Time.time;
        }

        private void OnMouseUp()
        {
            if (Time.time - mouseDownTime < MaxClickDuration)
            {
                // user clicked on this node:
                MapPlayerTracker.Instance.SelectNode(this);
            }
        }

        public void ShowSelectionAnimation()
        {
            const float fillDuration = 0.3f;
            visitedCircle.gameObject.SetActive(true);
            visitedCircle.color = new Color(255, 255, 255, 0);
            visitedCircle.DOColor(Color.white, fillDuration);
        }
    }
}
