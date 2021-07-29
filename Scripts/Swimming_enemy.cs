using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimming_enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(.005f, 0, 0);
    }
}
