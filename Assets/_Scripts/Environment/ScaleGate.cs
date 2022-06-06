using System;
using System.Collections.Generic;
using DG.Tweening;
using Player;
using TMPro;
using UnityEngine;

namespace _Scripts.Environment
{
    public class ScaleGate : MonoBehaviour
    {
        [HideInInspector] public TextMeshProUGUI textUI;
        [HideInInspector] public GateInfo gateInfo;
        private readonly List<BoxCollider> _colliders = new ();
        
        private const float Duration = 1;
        private static bool _isOnCooldown;

        private void Start()
        {
            foreach (Transform t in transform.parent)
            {
                _colliders.Add(t.GetComponent<BoxCollider>());
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.transform.root.TryGetComponent<PlayerData>(out var obj) || _isOnCooldown) return;

            var calculatedScale = Mathf.Pow((float)gateInfo.scaleFactor * 0.01f, (float)gateInfo.scaleType);
            var endValue = obj.transform.localScale * calculatedScale;
            obj.transform.DOScale(endValue, Duration);

            foreach (var c in _colliders)
            {
                c.enabled = false;
            }
            textUI.enabled = false;
        }
    }
    
    [Serializable]
    public class GateInfo
    {
        [HideInInspector]
        public string name;
        public ScaleFactor scaleFactor;
        public ScaleType scaleType;
        public ScaleGate scaleGate;
        
        public enum ScaleFactor
        {
            X125 = 125,
            X150 = 150,
            X175 = 175,
            X200 = 200,
            X225 = 225,
            X250 = 250,
            X275 = 275,
            X300 = 300
        }
        public enum ScaleType
        {
            Upscale = 1,
            Downscale = -1
        }
    }
}
