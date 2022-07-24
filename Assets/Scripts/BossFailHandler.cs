using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFailHandler : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // RestartSecene
            print("restart scene here fail handler");
        }
    }
}
