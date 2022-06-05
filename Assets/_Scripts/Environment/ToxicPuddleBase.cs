using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ToxicPuddleBase : MonoBehaviour
{
    [SerializeField] private float slipDuration;
    [SerializeField] private ForceMode forceMode;
    [SerializeField] private float power;

    private Rigidbody _playerRb;
    private float xDirection;


    private void Awake()
    {
        _playerRb = GameObject.FindObjectOfType<PlayerData>().GetComponent<Rigidbody>();
    }

    private void Start()
    {
        xDirection = Random.Range(-2, 2);
    }

    /* private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.root.TryGetComponent<PlayerData>(out var obj)) return;

        var position = new Vector3(Random.Range(-2f, 2f), 0, 2);
        //other.transform.DOLocalMove(position, slipDuration).SetRelative().SetEase(Ease.Linear);
        _playerRb.AddRelativeForce(position * power, forceMode);
    } */

    private void OnTriggerStay(Collider other)
    {
        if (!other.transform.root.TryGetComponent<PlayerData>(out var obj)) return;

        var position = new Vector3(xDirection, 0, 2);
        _playerRb.AddRelativeForce(position * power, forceMode);
    }
}
