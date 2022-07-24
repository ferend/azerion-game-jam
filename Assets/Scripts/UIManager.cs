using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static UIManager Instance;
    public GameObject[] bossDialouge;
    public GameObject battleUI;
    public GameObject gameOverPopup;
    
    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
        }else{
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }
    }

    public void OpenBossTalkPopup(int bossNumber)
    {
        print("openpoup and stop Game" + bossNumber);
        GameFlowManager.Instance.StopGameFlow();
        // open dialogue popup and freeze game 
        bossDialouge[bossNumber].SetActive(true);
        bossDialouge[bossNumber].transform.DOScale(new Vector3(1, 1, 1), 0.4F).SetEase(Ease.InOutElastic);
    }

    public void CloseBossTalkPopup(int bossNumber)
    {
        if (bossNumber == 1)
        {
            bossDialouge[0].transform.DOScale(new Vector3(0, 0, 0), 0.4F).SetEase(Ease.InOutElastic).OnComplete( () => battleUI.SetActive(true) );
        }
    }

    public void OpenGameOverPopup()
    {
       gameOverPopup.SetActive(true);
       gameOverPopup.transform.DOScale(new Vector3(1, 1, 1), 0.4F).SetEase(Ease.InOutElastic);
    }

    public void CloseGameOverPopup()
    {
        gameOverPopup.transform.DOScale(new Vector3(1, 1, 1), 0.4F).SetEase(Ease.InOutElastic).OnComplete((() =>  gameOverPopup.SetActive(false)));
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        CloseGameOverPopup();
    }
}
