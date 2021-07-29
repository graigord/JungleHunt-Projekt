using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class RGpos : MonoBehaviour
{
    public GameObject otherObject;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        otherObject.transform.position = transform.TransformPoint(-5.56f, 0.30f,0f);
        transform.position = transform.position + new Vector3(-.007f, 0, 0);
    }
}
