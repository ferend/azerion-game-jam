using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public static GameFlowManager Instance;
    public PlayerController PlayerController;
    public EnemySpawner[] EnemySpawner;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
        }else{
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }
    }

    public void StopGameFlow()
    {
        PlayerController.freezeController = true;
        for (int i = 0; i < EnemySpawner.Length; i++)
        {
            EnemySpawner[i].freezeenemySpawner = true;
            EnemySpawner[i].DestroyEnemies();

        }
    }

    public void ContinueGameFlow()
    {
        PlayerController.freezeController = false;
        for (int i = 0; i < EnemySpawner.Length; i++)
        {
            EnemySpawner[i].freezeenemySpawner = false;

        }
    }

    public void OnPauseButtonClicked()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    

}
