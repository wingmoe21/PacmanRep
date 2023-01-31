using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent ;
    [ SerializeField ]
    Fellow player;
    [ SerializeField ]
    Material scaredMaterial ;
    Material normalMaterial ;
    // Start is called before the first frame update
    void Start ()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = PickRandomPosition();
        normalMaterial = GetComponent < Renderer >(). material ;
    }
    Vector3 PickHidingPlace (){
        Vector3 directionToPlayer = ( player . transform . position -
            transform . position ). normalized ;
        UnityEngine.AI.NavMeshHit navHit ;
        UnityEngine.AI.NavMesh . SamplePosition ( transform . position -
            ( directionToPlayer * 8.0f), out navHit , 8.0f, UnityEngine.AI.NavMesh . AllAreas );
        return navHit . position ;
}
    Vector3 PickRandomPosition () {

        Vector3 destination = transform.position ;
        Vector2 randomDirection = UnityEngine.Random.insideUnitCircle * 8.0f;
        destination.x += randomDirection.x;
        destination.z += randomDirection.y;
        UnityEngine.AI.NavMeshHit navHit ;
        UnityEngine.AI.NavMesh . SamplePosition ( destination ,out navHit ,8.0f, UnityEngine.AI.NavMesh . AllAreas );
        return navHit . position ;
}
    
    bool CanSeePlayer(){
        Vector3 rayPos = transform.position;
        Vector3 rayDir = (player.transform.position - rayPos).normalized;
    
        RaycastHit info;
        if (Physics.Raycast(rayPos, rayDir, out info)){
            if(info.transform.CompareTag("Fellow")){
                // the ghost can see the player !
                return true ;
            }
        }
            
        return false;

        }
  
    
    bool hiding = false ; //A new member variable !
    // Update is called once per frame
    void Update()
    {
        if( CanSeePlayer ()){
            //Debug.Log ("I can see you !");
            agent. destination = player.transform.position ;}
        else{
                 if (player.PowerupActive()){
                    //Debug .Log ("Hiding from Player!");
                    if (! hiding || agent . remainingDistance < 0.5f){
                        hiding = true;
                        agent . destination = PickHidingPlace ();
                        GetComponent < Renderer >(). material = scaredMaterial ;
                    }
                }
                else{
                    //Debug .Log ("Chasing Player!");
                    if (hiding)
                    {
                        GetComponent < Renderer >(). material = normalMaterial ;
                        hiding = false ;
                    }
                    if ( agent . remainingDistance < 0.5f) {
                        agent.destination = PickRandomPosition ();
                        hiding = false ;
                        GetComponent<Renderer>().material = normalMaterial ;
                    }
                    }        
    
        }       
}
}
