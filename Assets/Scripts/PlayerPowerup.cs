using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerPowerup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("give palyer powerup");
            var parent = other.transform.parent.gameObject;
            var cone = parent.transform.GetChild(1).transform.GetChild(0);
            cone.transform.DOScaleZ(7, 1);
            
            var cone2 = parent.transform.GetChild(1).transform.GetChild(1);
            cone2.transform.DOScaleZ(7, 1);

            parent.GetComponent<PlayerController>().RemovePowerup();

        }
    }
}
