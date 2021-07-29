using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RockKillScript : MonoBehaviour
{
 public GameObject[] hearts;

   void OnCollisionEnter2D(Collision2D other){
       if(other.transform.CompareTag("Player")){
            Health.life -=1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log(Health.life);
            
        if(Health.life == 0){
            SceneManager.LoadScene(0); 
            Health.life=3; 
        }      
    }
    }
}
