using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float enemyHealth = 10;
    public float  enemyMovementSpeed = 10;
        
    private void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        gameObject.transform.Translate( new Vector3(-enemyMovementSpeed * Time.deltaTime, 0, 0));
    }

    private void EnemyTakeDamage()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("LightCone"))
        {
            EnemyTakeDamage();
        }
    }
}
