using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_test : MonoBehaviour
{

    private float h = 0.0f;
    private float v = 0.0f;

    private Transform tr;

    public float movespeed = 10.0f;
    public float rotspeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 moveDir = (-Vector3.forward * v) + (-Vector3.right * h);

        //Debug.Log("H = " + h.ToString());
        //Debug.Log("V = " + v.ToString());

        tr.Translate(moveDir.normalized * movespeed * Time.deltaTime, Space.Self);
        tr.Rotate(Vector3.up * Time.deltaTime * rotspeed * Input.GetAxis("Mouse X"));
        
    }

}
