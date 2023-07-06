using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour

{
    public Transform Top;
    public Vector3 Ofset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Top.position);
        transform.position = Top.position + Ofset;
    }
}