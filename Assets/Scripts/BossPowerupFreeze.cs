using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPowerupFreeze : MonoBehaviour
{
    
    private void Update()
    {
        PowerupMovement();
    }

    private void PowerupMovement()
    {
        gameObject.transform.Translate( new Vector3(-4 * Time.deltaTime, 0, 0));
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FreezePlayerController(other.transform.parent.gameObject.GetComponent<PlayerController>(), true);
            other.transform.parent.gameObject.GetComponent<PlayerController>().UnfreezePlayer();
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("LightCone"))
        {
            EnemyTakeDamage();
        }
    }
    
    
    private void EnemyTakeDamage()
    {
        Destroy(this.gameObject);
    }


    private void FreezePlayerController(PlayerController playerController, bool freezePlayer)
    {
        if (freezePlayer)
        {
            playerController.freezeController = true;
        }
        else
        {
            playerController.freezeController = false;
        }

    }
    
}
