using System;
using System.Collections;
using _Scripts;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerData : PlayerControls
    {
        [SerializeField] private ParticleSystem deathExplosionParticle;
        
        public static bool IsDead;
        private void Start()
        {
            IsDead = false;
        }

        private void OnEnable()
        {
            LaserBase.DeathEvent += Death;
        }

        private void OnDisable()
        {
            LaserBase.DeathEvent -= Death;
        }

        private void Death(bool f)
        {
            IsDead = f;

            deathExplosionParticle.Play();
            StartCoroutine(DeathParticleStopRoutine());
        }

        private IEnumerator DeathParticleStopRoutine()
        {
            yield return new WaitForSeconds(1);
            deathExplosionParticle.Stop();
        }
    }
}