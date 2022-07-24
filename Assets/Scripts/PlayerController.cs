using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public GameObject playerObject;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float forwardSpeed;
    private float tempSpeed;

    public float min, max;

    private Touch touch;
    private Vector3 touchUp;
    private Vector3 touchDown;

    private bool dragStarted;
    private bool isMoving;
    private Vector3 tempPos;
    public bool freezeController;
    void Update()
    {
        if (!PlayerStatusController.Instance.IsAlive()) return;
        if (freezeController) return;
        gameObject.transform.Translate(new Vector3(forwardSpeed * Time.deltaTime, 0, 0));
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                dragStarted = true;
                isMoving = true;
                touchUp = touch.position;
                touchDown = touch.position;
            }
        }
        if (dragStarted)
        {
            if (touch.phase == TouchPhase.Moved)
            {
                touchDown = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                touchDown = touch.position;
                isMoving = false;
                dragStarted = false;
            }
            gameObject.transform.Translate(new Vector3(0,0,  CalculateDirection().z* Time.deltaTime*movementSpeed));
            tempPos = transform.position;
            tempPos.z = Mathf.Clamp(transform.position.z, min, max);
            transform.position = tempPos;
        }

    }
    public void UnfreezePlayer()
    {
        StartCoroutine(UnfreezePlayerRoutine());
    }

    public void RemovePowerup()
    {
        StartCoroutine(RemovePowerupEnumerator());
    }

    private IEnumerator UnfreezePlayerRoutine()
    {
        yield return new WaitForSeconds(3);
        freezeController = false;
    }

    public IEnumerator RemovePowerupEnumerator()
    {
        yield return new WaitForSeconds(3);
        var cone = transform.GetChild(1).transform.GetChild(0);
        cone.transform.DOScaleZ(1, 1);
            
        var cone2 = transform.GetChild(1).transform.GetChild(1);
        cone.transform.DOScaleZ(1, 1);

    }
    public void DoWheelie()
    {
        playerObject.transform.DOMoveY(0.4f, 1);
        playerObject.transform.DORotate(new Vector3(0, 0, 40), 1);
        tempSpeed = forwardSpeed;
        forwardSpeed += 2;
    }
    public void CancelWheelie()
    {
        playerObject.transform.DOMoveY(0, 1);
        playerObject.transform.DORotate(new Vector3(0, 0, 0), 1);
        forwardSpeed = tempSpeed;
    }
    private Vector3 CalculateDirection()
    {
        Vector3 temp = (touchDown - touchUp).normalized;
        temp.z = temp.y;
        temp.y = 0;
        return temp;
    }
}
