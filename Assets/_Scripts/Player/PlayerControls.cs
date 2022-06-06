using System;
using _Scripts.Camera;
using DG.Tweening;
using UnityEngine;

namespace Player
{
    public abstract class PlayerControls : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float speed = 7;
        private Camera _camera;
        private Animator _playerAnim;

        private void Awake()
        {
            _camera = Camera.main;
            _playerAnim = GetComponent<Animator>();
        }

        private void Update()
        {
            EditorControls();
        }

        private void EditorControls()
        {
            if (Input.GetMouseButton(0) 
                && !PlayerData.IsDead 
                && !SceneCameraAnimator.IsAnimated 
                && !SaveZoneTriggerPlane.isAnimated)
            {
                #region Movement
                var ray = _camera.ScreenPointToRay(Input.mousePosition);

                var x = Physics.Raycast(ray, out var hit) ? Time.deltaTime * (hit.point.x - transform.position.x) : 0;
                
                transform.DOMove(new Vector3(x, 0, Time.deltaTime * speed),Time.deltaTime)
                    .SetRelative().SetEase(Ease.Linear);
                
                #endregion
                
                #region Animation
                
                _playerAnim.SetFloat("speed_f", speed);
                
                #endregion
            }
            else
            {
                #region
                
                if (!PlayerData.IsDead)
                {
                    _playerAnim.SetFloat("speed_f", 0);
                }
                else
                {
                    _playerAnim.SetBool("isDead", true);
                }
                
                #endregion
            }   
        }
    }
}
