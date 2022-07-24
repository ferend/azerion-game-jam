using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static UIManager Instance;
    public GameObject battleUI;
    public GameObject gameOverPopup;
    public GameObject upperPanel;
    
    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
        }else{
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }
    }

    public void HideAllUIElements()
    {
        upperPanel.SetActive(false);
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
