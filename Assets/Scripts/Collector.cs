using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other) {

        if(other.CompareTag("Enemy")){
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Fox")){
            SceneManager.LoadScene("GameOver");
        }

    }

}
