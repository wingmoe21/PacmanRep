using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{

    [ SerializeField ]
    Font scoreFont ;

    public YellowFellowGame table;
    

    void CreateHighScoreText (){
        for (int i = 0; i < table.allScores . Count ; ++i){
            GameObject o = new GameObject ();
            o. transform . parent = transform ;
            Text t = o. AddComponent <Text >();
            t. text = table.allScores[i].name + "\t\t" + table.allScores[i].score ;
            t. font = scoreFont ;
            t. fontSize = 50;
            t.color = Color.black;
            
            o. transform . localPosition = new Vector3 (0, -(i) * 6, 0);

            o. transform . localRotation = Quaternion . identity ;
            o. transform . localScale = new Vector3 (0.1f, 0.1f, 0.1f);

            o. GetComponent < RectTransform >(). sizeDelta = new Vector2 (400 , 100);   
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateHighScoreText ();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}