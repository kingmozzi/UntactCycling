using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class follow_cam : MonoBehaviour
{
    public Transform targetTr;
    public float dist = 7.0f;
    public float height = 1.0f;
    public float dampTrace = 20.0f;

    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        tr.position = Vector3.Lerp(tr.position, targetTr.position + (targetTr.forward * dist) + (Vector3.up * height), Time.deltaTime *dampTrace);
        //tr.position = Vector3.Lerp(tr.position, targetTr.position - (targetTr.forward * dist) + (Vector3.up * height), Time.deltaTime *dampTrace);
        tr.LookAt(targetTr.position);
    }
}
