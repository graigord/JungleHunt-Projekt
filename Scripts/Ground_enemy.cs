using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Ground_enemy : MonoBehaviour
{
    public int x = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (x == 80 || x == 160)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        if (x <= 80)
        {
            x++;
            transform.position = transform.position + new Vector3(-.005f, 0, 0);
        }
        else if (x >= 80 && x <= 160)
        {
            transform.position = transform.position + new Vector3(.005f, 0, 0);
            x++;
        }
        else
        {
            x = 0;
        }
    }
}
