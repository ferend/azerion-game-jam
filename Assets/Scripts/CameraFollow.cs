using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    public Transform target;
    private Vector3 temp;
    void Update()
    {
        temp = target.position;
        temp.z = 0;
        temp.y = 0;
        transform.position = Vector3.Lerp(transform.position, temp+offset, 5*Time.deltaTime);
    }
}
