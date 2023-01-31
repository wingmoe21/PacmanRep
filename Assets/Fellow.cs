using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using UnityEngine.SceneManagement;


public class Fellow : MonoBehaviour
{
    int score = 0;
    public int pelletsEaten = 0;
    [ SerializeField ]
    int pointsPerPellet = 100;
    float speed = 5f;

    public YellowFellowGame highscore;

    [ SerializeField ]
    float powerupDuration = 10.0f; // How long should powerups last ?
    float powerupTime = 0.0f; // How long is left on the current powerup
    private void OnTriggerEnter ( Collider other )
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            powerupTime = powerupDuration;
        }
        if ( other.gameObject.CompareTag ("Pellet")){
            pelletsEaten ++;
            score += pointsPerPellet ;
            Debug.Log ("Score is:" + score);
        }
        
    }
    public bool PowerupActive (){
        if(powerupTime!= 0.0f){
            return true;
        }
        return false;
    }
    public int PelletsEaten ()// We ’ll be using this method later on!
    {
        return pelletsEaten ;}
    
    
    public int fellowLives = 2;
    void OnCollisionEnter ( Collision collision ){
        if ( collision . gameObject . CompareTag ("Ghost")){
            if(PowerupActive()){
                collision.gameObject.transform.position = new Vector3(7.5f,0,7.25f);
            }else{
                if(fellowLives>=0){
                    Debug.Log("You have "+fellowLives.ToString()+" lives left!");
                    collision.gameObject.transform.position = new Vector3(7.48792f,0.800001f,7.97f);
                    gameObject.transform.position = new Vector3(7.46f,0.409f,4f);
                    fellowLives--;
                }else{
                    Debug.Log ("You died!");
                    gameObject.SetActive ( false );
                    if(score>highscore.HighScore){
                        StreamWriter file = new StreamWriter("scores.txt", true);
                        file.WriteLine("Player " + score);
                        file.Close();
                    }
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    }
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

        powerupTime = Mathf .Max (0.0f, powerupTime - Time . deltaTime );

        /* Vector3 pos = transform . position ;
        if ( Input . GetKey ( KeyCode .A))
        {
            pos .x -= speed ;
        }
        if ( Input . GetKey ( KeyCode .D)) 
        {
            pos .x += speed ;
            }
        if ( Input . GetKey ( KeyCode .W)){ 
            pos .z += speed ;
            }
        if ( Input . GetKey ( KeyCode .S)){
            pos .z -= speed ;}
        transform . position = pos ; */
        
    }
    void FixedUpdate (){
        Rigidbody b = GetComponent < Rigidbody >();
        Vector3 velocity = b. velocity ;
        if ( Input . GetKey ( KeyCode .A)){
            velocity .x = -speed ;}
        if ( Input . GetKey ( KeyCode .D)){
            velocity .x = speed ;}
        if ( Input . GetKey ( KeyCode .W))
        {
            velocity .z = speed ;}
        if ( Input . GetKey ( KeyCode .S)){
            velocity .z = -speed ;}
        b. velocity = velocity ;
    }
}
