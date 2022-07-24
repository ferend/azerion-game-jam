using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FinalLevelController : MonoBehaviour
{
    public GameObject holyMusab;
    public GameObject musabTesbih;

    private void Start()
    {
        holyMusab.transform.DOMoveY(1.5F,1).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        musabTesbih.transform.DORotate(new Vector3(0,0,360),1 , RotateMode.FastBeyond360 )
            .SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }
}
