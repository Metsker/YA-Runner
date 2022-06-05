using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesEditor : MonoBehaviour
{
    //Чтобы партикли не ебали мозги в эдиторе
    private void Start()
    {
        foreach (Transform t in transform)
        {
            t.gameObject.SetActive(true);
        }
    }
}
