using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject[] list;

    private GameObject enemy;

    public Transform leftTran, rightTran;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy(){


        while(true){

            yield return new WaitForSeconds(Random.Range(1,5));

            int randomindex = Random.Range(0,2);
            int randomPos = Random.Range(0,2);

            enemy = Instantiate(list[randomindex]);

            if(randomindex == 0){
                
                if(randomPos == 0){
                    enemy.GetComponent<Security>().speed = -5f;
                    enemy.transform.position = new Vector3(leftTran.position.x,leftTran.position.y,0);
                    enemy.transform.localScale = new Vector3(-1f,1f,1f);
                }
                else{
                    enemy.GetComponent<Security>().speed = 5f;
                    enemy.transform.position = new Vector3(rightTran.position.x,rightTran.position.y,0);
                }

            }
            else{

                if(randomPos == 1){
                    enemy.GetComponent<Student>().speed = -4f;
                    enemy.transform.position = new Vector3(rightTran.position.x,rightTran.position.y,0);
                    enemy.transform.localScale = new Vector3(-1f,1f,1f);
                }
                else{
                    enemy.GetComponent<Student>().speed = 4f;
                    enemy.transform.position = new Vector3(leftTran.position.x,leftTran.position.y,0);
                }


            }
        }

        

    }

    
}
