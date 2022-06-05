using System;
using System.Collections;
using DG.Tweening;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Camera
{
    public class SceneCameraAnimator : MonoBehaviour
    {
        [SerializeField] private Ease ease;
        [SerializeField] private float duration;
        [SerializeField] private Vector3 cameraAnimPos;
        [SerializeField] private Vector3 cameraStartPos;

        private PlayerControls playerControls;
        private UnityEngine.Camera _camera;

        public static bool isAnimated;
        

        private void Awake()
        {
            _camera = UnityEngine.Camera.main;
            _camera.transform.position = cameraAnimPos;
        }

        private void Start()
        {
            Animate();
        }

        private void Animate()
        {
            isAnimated = true;
            
            _camera.transform.DOMove(cameraStartPos, duration).SetEase(ease);
            StartCoroutine(EnableCameraFollowerScriptRoutine());

        }

        //корутина которая по истечению времени анимации полета камеры включает скрипт следования камеры
        //чтобы не было конфликтов между скриптами
        public IEnumerator EnableCameraFollowerScriptRoutine()
        {
            yield return new WaitForSeconds(duration);
            gameObject.GetComponent<PlayerCameraFollower>().enabled = true;
            
            isAnimated = false;
        }
    }
}