using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BattleManager : MonoBehaviour
{
    public GameObject battleObject;
    public Image playerBar;
    public float IncreaseAmount;
    private float barAmount = 0.5f;
    private bool didLost = false;
    private bool didWon = false;
    public bool canStart = false;
    public bool didTutorial;
    public Image fighText;
    public DialogManager dialogManager;

    private void Start()
    {
        //OpenBattle();
    }

    void Update()
    {
        if (!canStart) return;
        if (didLost) return;
        if (didWon) return;
        barAmount -= Time.deltaTime/6;
        playerBar.fillAmount = barAmount;
        if (barAmount <= 0)
        {
            didLost = true;
            PlayerStatusController.Instance.Die(DieCause.enemy);
        }
        if (barAmount >= 1)
        {
            didWon = true;
            if (SceneManager.GetActiveScene().buildIndex != 5)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
            canStart = false;
            didTutorial = false;
        }
    }
    public void OpenBattle()
    {
        battleObject.SetActive(true);
        if (!didTutorial)
        {
            print("*****1");
            TutorialManager.Instance.OpenBattleTut();
        }
        else
        {
            print("*****1");
            ShowFightText();
        }
    }
    public bool DidWonGame()
    {
        return didWon;
    }
    public bool DidLoseGame()
    {
        return didLost;
    }
    public void Increase()
    {
        barAmount += Time.deltaTime * IncreaseAmount;
    }
    
    public void ShowFightText()
    {
        if (!didTutorial)
        {
            TutorialManager.Instance.battleTut.SetActive(false);

        }
        fighText.DOFade(1, 1f).OnComplete(CloseFightText);
        
        print("*****4");
    }

    private void CloseFightText()
    {
        fighText.DOFade(0, 0.4f) .OnComplete(OpenFightScene);
        print("*****5");
        canStart = true;
    }

    private void OpenFightScene()
    {
        print("*****6");
        if (!didTutorial)
        {
            TutorialManager.Instance.battleTut.SetActive(false);

        }
        OpenBattle();
        dialogManager.dialogBack.SetActive(false);
        OpenBattle();
    }

    private void onImageClose()
    {
        canStart = true;
    }
}
