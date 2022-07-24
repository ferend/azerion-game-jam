using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject moveTut, battleTut;
    public static TutorialManager Instance;
    public BattleManager battleManager;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        moveTut.SetActive(false);
        StartCoroutine(ShowMoveTut());
    }

    private IEnumerator ShowMoveTut()
    {
        yield return new WaitForSeconds(0.5f);
        moveTut.SetActive(true);
        moveTut.transform.DOScale(new Vector3(1, 1, 1), 0.4F).SetEase(Ease.InOutElastic);
        GameFlowManager.Instance.StopGameFlow();
    }
    public void CloseMoveTut()
    {
        moveTut.transform.DOScale(new Vector3(1, 1, 1), 0.4F).SetEase(Ease.InOutElastic).OnComplete((() => moveTut.SetActive(false)));
        GameFlowManager.Instance.ContinueGameFlow();
    }
    public void OpenBattleTut()
    {
        print("*****2");
        battleTut.SetActive(true);
        battleTut.transform.DOScale(new Vector3(1, 1, 1), 0.4F).SetEase(Ease.InOutElastic);
        GameFlowManager.Instance.StopGameFlow();
    }
    public void CloseBattleTut()
    {
        battleManager.didTutorial = true;
        battleTut.transform.DOScale(new Vector3(0,0, 0), 0.4F).SetEase(Ease.InOutElastic)
            .OnComplete((() => battleManager.ShowFightText()));
        print("*****3");

    }
    
}
