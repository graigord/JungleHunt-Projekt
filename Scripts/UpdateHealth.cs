using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UpdateHealth : MonoBehaviour
{
    public TextMeshProUGUI healthText = null;


    public void updateHealthText()
    {
        healthText.text = "Health: " + Health.life;
    }

     private void Awake()
    {
        healthText.text = "Health: " + Health.life;
    }

}
