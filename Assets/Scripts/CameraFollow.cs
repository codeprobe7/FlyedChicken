using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject targetObj;
    public float chaseSpeed = 10f;

    private Vector3 originPos;


    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = Vector3.Lerp(transform.position, targetObj.transform.position + originPos, chaseSpeed * Time.deltaTime);
        transform.position = targetPos;

    }
}
