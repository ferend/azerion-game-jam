using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DieCause { enemy,barrier};
public class PlayerStatusController : MonoBehaviour
{
    private int health = 3;
    private DieCause cause;
    private bool didDie;
    public ParticleSystem nukeParticle;
    public GameObject[] playerHealths;

    public static PlayerStatusController Instance;
    private void Awake()
    {
        health = 3;
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        switch (health)
        {
            case 2:
                playerHealths[0].SetActive(false);
                break;
            case 1:
                playerHealths[1].SetActive(false);
                break;
            case 0:
                playerHealths[2].SetActive(false);
                break;
        }
    }

    public void Die(DieCause cause)
    {
        didDie = true;
        this.cause = cause;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        
            for (int i = 3; i < 7; i++)
            {
                transform.parent.gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
            }
            
        Instantiate(nukeParticle, transform.position, Quaternion.identity );
        nukeParticle.transform.position = gameObject.transform.position;
        StartCoroutine(EndGamePopupWaiter());
    }

    public IEnumerator EndGamePopupWaiter()
    {
        yield return new WaitForSeconds(1);
        UIManager.Instance.OpenGameOverPopup();
        transform.parent.gameObject.SetActive(false);
    }
    
    public bool IsAlive()
    {
        return !didDie;
    }
    public DieCause GetCause()
    {
        return cause;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health--;
       
            Destroy(other.gameObject);
            if(health<=0) Die(DieCause.enemy);
        }
        if (other.gameObject.CompareTag("Barrier"))
        {            
            health--;
            if(health<=0) Die(DieCause.barrier);
            print("bariyer");
        }

    }
}
