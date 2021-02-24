using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookOnCam : MonoBehaviour
{
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
