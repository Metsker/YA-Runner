using System;
using DG.Tweening;
using Player;
using UnityEngine;


public class LaserBase : MonoBehaviour
{
    public static event Action<bool> DeathEvent; 
    public ParticleSystem laserSparksParticle;
    
    [SerializeField] private Ease ease;
    [SerializeField] private float scaleChange; //0.9
    [SerializeField] private float endScale; //1
    [SerializeField] private float duration;

    private void Start()
    {
        if (laserSparksParticle == null)
        {
            laserSparksParticle = transform.parent.GetChild(0).GetComponent<LaserBase>().laserSparksParticle;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.root.TryGetComponent<PlayerData>(out var obj)) return;
        
        var endValue = obj.transform.localScale * scaleChange;
        if (endValue.x >= endScale)
        { 
            obj.transform.DOScale(endValue, duration).SetEase(ease);
            laserSparksParticle.Play();
        }

        else 
        {
            DeathEvent?.Invoke(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.transform.root.TryGetComponent<PlayerData>(out var obj)) return;
        laserSparksParticle.Stop();
    }
}
