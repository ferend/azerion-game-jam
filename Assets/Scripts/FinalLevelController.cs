using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class FinalLevelController : MonoBehaviour
{
    public GameObject holyMusab;
    public GameObject musabTesbih;
    public TextMeshProUGUI wasWaitingText;
    private GameObject player;
    public CameraFollow playerCamera;

    private void Start()
    {
        holyMusab.transform.DOMoveY(1.5F,1).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        musabTesbih.transform.DORotate(new Vector3(0,0,360),1 , RotateMode.FastBeyond360 )
            .SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FinalLevelAnimation();
            player = other.gameObject;
            other.gameObject.GetComponent<MeshCollider>().isTrigger = false;
            this.gameObject.GetComponent<BoxCollider>().isTrigger = false;

        }
    }

    private void FinalLevelAnimation()
    {
        GameFlowManager.Instance.StopGameFlow();
        UIManager.Instance.HideAllUIElements();
        wasWaitingText.DOFade(1, 3).OnComplete((() => wasWaitingText.DOFade(0, 3).OnComplete(GoToCutScene)));
    }


    private void GoToCutScene()
    {
        playerCamera.lockCamera = true;
        gameObject.transform.DOMoveX(gameObject.transform.position.x + 20,5);
        player.transform.transform.parent.DOMoveX(player.transform.position.x + 20, 6).OnComplete(Application.Quit);
        
    }
    
}
