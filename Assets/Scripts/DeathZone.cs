using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] MainManager manager;
    public MainManager Manager;

    void Start()
    {
    }
    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        Manager.GameOver();
    }
}
