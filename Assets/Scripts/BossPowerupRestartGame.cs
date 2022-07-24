using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossPowerupRestartGame : MonoBehaviour
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
            RestartPlayer();
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

    private void RestartPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
