using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;


    Vector3 LeftSide = new Vector3(1.03f, 0f, 7f);
    Vector3 rightSide = new Vector3(13.70021f, 0f, 7f);


    private void OnTriggerEnter ( Collider other ){
        if (other.gameObject.CompareTag ("Fellow")||other.gameObject.CompareTag ("Ghost")){
            if(gameObject.tag == "Right"){
                other.gameObject.transform.position = LeftSide;
            }
            if(gameObject.tag == "Left"){
                other.gameObject.transform.position = rightSide;
            }  
        }   
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
