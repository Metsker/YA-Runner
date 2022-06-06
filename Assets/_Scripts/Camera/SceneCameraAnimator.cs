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
        [SerializeField] private Transform cameraAnimPoint;
        
        private PlayerControls _playerControls;
        private PlayerCameraFollower _playerCameraFollower;
        private UnityEngine.Camera _camera;
        private Vector3 _cameraStartPos;
        
        public static bool IsAnimated;
        

        private void Awake()
        {
            _camera = UnityEngine.Camera.main;
            _playerCameraFollower = GetComponent<PlayerCameraFollower>();
        }

        private void Start()
        {
            _cameraStartPos = _camera.transform.position;
            Animate();
        }
        
        private void Animate()
        {
            _camera.transform.position = cameraAnimPoint.position;
            IsAnimated = true;
            
            _camera.transform.DOMove(_cameraStartPos, duration).SetEase(ease);
            StartCoroutine(EnableCameraFollowerScriptRoutine());

        }

        //корутина которая по истечению времени анимации полета камеры включает скрипт следования камеры
        //чтобы не было конфликтов между скриптами
        public IEnumerator EnableCameraFollowerScriptRoutine()
        {
            yield return new WaitForSeconds(duration);
            _playerCameraFollower.enabled = true;
            
            IsAnimated = false;
        }
    }
}