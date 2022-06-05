using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using DG.Tweening;

public class SaveZoneTriggerPlane : MonoBehaviour
{
    [SerializeField] private float duration;
    
    private Animator _playerAnim;
    private float _saveZoneSizeZ;
    
    public static bool isAnimated;

    private void Awake()
    {
        _playerAnim = GameObject.FindObjectOfType<PlayerData>().GetComponent<Animator>();
        _saveZoneSizeZ = GetComponent<MeshCollider>().bounds.size.z;
    }

    private void Start()
    {
        //SetPosition();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.root.TryGetComponent<PlayerData>(out var obj)) return;
        
        _playerAnim.SetTrigger("saveZoneTrigger");
        isAnimated = true;
        
        other.transform.DOMoveX(0, duration); 
        other.transform.DOMoveZ(_saveZoneSizeZ + other.transform.localScale.z, duration).SetRelative().SetEase(Ease.Linear);
    }

    private void OnTriggerExit(Collider other)
    {
        _playerAnim.SetTrigger("frightenTrigger");
    }

   /* private void SetPosition()
    {
        var laserLine = GameObject.Find("LaserLine");
        var lasersCount = laserLine.transform.parent.childCount;
        var p = transform.position;
        p.z = laserLine.transform.position.z + lasersCount * (2 + laserLine.GetComponent<BoxCollider>().size.z);
        transform.position = p;
    } */
}
