using System;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Camera
{
    public class PlayerCameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float lerpSpeed = 10f;

        private void Start()
        {
            offset = transform.position - target.position;
        }

        private void LateUpdate()
        {
            var desPos = target.position + offset;
            var lerpPos = Vector3.Lerp(transform.position, desPos, lerpSpeed * Time.deltaTime);
            transform.position = lerpPos;
        }
    }
}
