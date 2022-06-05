using System;
using System.Globalization;
using DG.Tweening;
using Player;
using TMPro;
using UnityEngine;

namespace _Scripts
{
    public class ScaleGate : MonoBehaviour
    {
        [RangeEx(1, 5, 0.25f)] [SerializeField]
        private float scaleFactor;

        [Min(0)] [SerializeField] private float duration = 1;

        [SerializeField] private ScaleType scaleType;
        [SerializeField] private TextMeshProUGUI textUI;
        

        private enum ScaleType
        {
            Upscale = 1,
            Downscale = -1
        }

        private void Awake()
        {
            
        }

        private void Start()
        {
            //Придумать отображение
            //textUI.SetText("x" + _overallScale.ToString(CultureInfo.InvariantCulture));
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.transform.root.TryGetComponent<PlayerData>(out var obj)) return;

            var calculatedScale = Mathf.Pow(scaleFactor, (float) scaleType);
            var endValue = obj.transform.localScale * calculatedScale;
            obj.transform.DOScale(endValue, duration);



            Destroy(gameObject);
        }
        
    }
}
