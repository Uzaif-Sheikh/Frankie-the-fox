using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private Transform fox;
    [SerializeField]
    private float maxX = 105;
    [SerializeField]
    private float minX = -69; 

    // Start is called before the first frame update
    void Start()
    {
        
        fox = GameObject.FindWithTag("Fox").transform;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 temtPos = transform.position;
        temtPos.x = fox.position.x;

        if(temtPos.x > maxX){
            temtPos.x = maxX;
        }

        if(temtPos.x < minX){
            temtPos.x = minX;
        }
        transform.position = temtPos;
    }
}
