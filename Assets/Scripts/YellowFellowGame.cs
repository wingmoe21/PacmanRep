using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;



public class YellowFellowGame : MonoBehaviour
{
    [SerializeField]
    GameObject highScoreUI;

    [SerializeField]
    GameObject mainMenuUI;

    [SerializeField]
    GameObject gameUI;

    [SerializeField]
    GameObject winUI;

    [SerializeField]
    Fellow playerObject;


    string highscoreFile = "scores.txt";
    public int HighScore;
    public int levelNo = 1;

    public struct HighScoreEntry
    {
        public int score ;
        public string name ;
    }
    public List < HighScoreEntry > allScores = new List < HighScoreEntry >();

    GameObject[] pellets;

    enum GameMode
    {
        InGame,
        MainMenu,
        HighScores
    }

    GameMode gameMode = GameMode.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        StartMainMenu();
        pellets = GameObject . FindGameObjectsWithTag ("Pellet");
        playerObject = GameObject.Find("Fellow").GetComponent<Fellow>();
        LoadHighScoreTable ();
        SortHighScoreEntries();

    }

    // Update is called once per frame
    void Update()
    {
        if( playerObject.PelletsEaten() == pellets.Length )
        {           
            Debug .Log (" Level Completed !");
            StreamWriter file = new StreamWriter("scores.txt", true);
            file.WriteLine("Player 11800");
            file.Close();
            levelNo++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        switch(gameMode)
        {
            case GameMode.MainMenu:     UpdateMainMenu(); break;
            case GameMode.HighScores:   UpdateHighScores(); break;
            case GameMode.InGame:       UpdateMainGame(); break;
        }
    }

    void UpdateMainMenu()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            StartHighScores();
        }
    }

    void UpdateHighScores()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartMainMenu();
        }
    }

    void UpdateMainGame()
    {
       // playerObject
    }

    void StartMainMenu()
    {
        gameMode = GameMode.MainMenu;
        mainMenuUI.gameObject.SetActive(true);
        highScoreUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(false);
    }


    void StartHighScores()
    {
        gameMode                = GameMode.HighScores;
        mainMenuUI.gameObject.SetActive(false);
        highScoreUI.gameObject.SetActive(true);
        gameUI.gameObject.SetActive(false);
    }

    void StartGame()
    {
        gameMode = GameMode.InGame;
        mainMenuUI.gameObject.SetActive(false);
        highScoreUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(true);
    }
    public void LoadHighScoreTable (){
        using ( TextReader file = File.OpenText(highscoreFile))
        {
            string text = null ;
            while (( text = file.ReadLine ()) != null )
            {
                string [] splits = text.Split(' ');
                HighScoreEntry entry;
                entry.name = splits[0];
                entry.score = int.Parse ( splits [1]);
                allScores.Add ( entry );
            }
        }
    }
    public void SortHighScoreEntries (){
        allScores.Sort ((x,y) => y.score.CompareTo(x.score));
        HighScore = allScores[0].score;

    }   
}
