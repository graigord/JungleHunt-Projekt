using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BTMS : MonoBehaviour
{
 public void BackToMenu(){
     SceneManager.LoadScene(0);
     Health.life = 3;
 }
}
