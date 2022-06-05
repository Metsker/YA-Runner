using System;
using System.Collections;
using _Scripts;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerData : PlayerControls
    {
        public static bool isDead;

        [SerializeField] private ParticleSystem deathExplosionParticle;
        

        
        private void Start()
        {
            isDead = false;
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
            isDead = f;

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