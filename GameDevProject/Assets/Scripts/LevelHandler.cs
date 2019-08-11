//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;

//public class LevelHandler : MonoBehaviour {

//    public GameObject LeaderBoard;
//    public GameObject TrapSelect;
//    public Button loseButton;
//    public Button continueButton;
//    public Text timer;
//    private float time;

//    public GameObject[] players;
//    public GameObject Player1;
//    public GameObject Player2;
//    public GameObject Player3;
//    public GameObject Player4;
//    public GameObject Player2HUD;
//    public GameObject Player3HUD;
//    public GameObject Player4HUD;
//    public PlayerControl playerControl;

//    private GameObject[] traps;
//    public GameObject[] trapsInstantaited;
//    private int count;
//    public bool trapsPlaced;
//    private bool placeTrapsOnce;
//    //Dont start paushe handler till trap select done
//    PauseHandler pH;

//    private List<GameObject> playersFin;

//    public GameObject FadeSceneObject;
//    private Fade FadeScript;
    
//    void Start()
//    {
//        Debug.Log("HOW MANY TIMES DOES THIS HAPPEN");
//        playersFin = new List<GameObject>();
//        FadeScript = FadeSceneObject.GetComponent<Fade>();
//        count = 0;
//        trapsPlaced = false;
//        placeTrapsOnce = false;
//        TrapSelect.SetActive(true);
//        pH = gameObject.GetComponent<PauseHandler>();
//        pH.start = false;


//        LeaderBoard.SetActive(false);
//        time = 120;
//        playerControl = PlayerControl.instance;
//        if (!playerControl.players[1])
//        {
//            Player2.SetActive(false);
//            Player2HUD.SetActive(false);
//        }

//        if (!playerControl.players[2])
//        {
//            Player3.SetActive(false);
//            Player3HUD.SetActive(false);
//        }

//        if (!playerControl.players[3])
//        {
//            Player4.SetActive(false);
//            Player4HUD.SetActive(false);
//        }

//        players = GameObject.FindGameObjectsWithTag("Player");
//        for (int i = 0; i < players.Length; i++) {
//            players[i].GetComponent<PlayerMovement>().enabled = false;
//        }

//        loseButton.gameObject.SetActive(false);
//    }

//    public void placeTraps() {
//        traps = TrapSelect.GetComponent<TrapSelect>().traps;
//        trapsInstantaited = new GameObject[traps.Length];

//        for (int count = 0; count < traps.Length;count++) {
//            GameObject trap = traps[count];
//            GameObject t = Instantiate(trap, new Vector3(0, 0, 0), transform.rotation);
//            t.AddComponent<TrapMovement>();
//            if (count == 1)
//            {
//                t.GetComponent<TrapMovement>().verticalCtrl = "Vertical_P2";
//                t.GetComponent<TrapMovement>().horizontalCtrl = "Horizontal_P2";
//                t.GetComponent<TrapMovement>().submitButton = "Jump_P2";
//            }
//            else if (count == 2)
//            {
//                t.GetComponent<TrapMovement>().verticalCtrl = "Vertical_P3";
//                t.GetComponent<TrapMovement>().horizontalCtrl = "Horizontal_P3";
//                t.GetComponent<TrapMovement>().submitButton = "Jump_P3";
//            }
//            else if (count == 3)
//            {
//                t.GetComponent<TrapMovement>().verticalCtrl = "Vertical_P4";
//                t.GetComponent<TrapMovement>().horizontalCtrl = "Horizontal_P4";
//                t.GetComponent<TrapMovement>().submitButton = "Jump_P4";
//            }
//            trapsInstantaited[count] = t;
//        }
//    }

//    public bool checkIfALlTrapsSubmitted() {
//        for (int i = 0; i < trapsInstantaited.Length; i++) {
//            //Debug.Log("Couter is on  " + i + " of  " + trapsInstantaited.Length);
//            //Debug.Log(trapsInstantaited[i].GetComponent<TrapMovement>().move);
//            if (trapsInstantaited[i].GetComponent<TrapMovement>().move) {
//                return false;
//            }
//        }
//        for (int i = 0; i < players.Length; i++)
//        {
//            players[i].GetComponent<PlayerMovement>().enabled = true;
//        }
//        cam.GetComponent<ControlCamera>().setCameraBackToPlayers();
//        return true;
//    }


//    public Camera cam;

//    void Update()
//    {
//        cam = GameObject.FindObjectOfType<Camera>();


//        if (TrapSelect.activeSelf == false && trapsPlaced)
//        {
//            //Debug.Log("FINALLY HERE");
//            pH.start = true;
//        }
//        else if (TrapSelect.activeSelf == false && !placeTrapsOnce)
//        {
//            //Debug.Log("HERE");
//            placeTrapsOnce = true;
//            placeTraps();
//            cam.GetComponent<ControlCamera>().setCameraToTraps(trapsInstantaited);
//        } else if ((TrapSelect.activeSelf == false)){
//            //Debug.Log("THEN HERE UNTILL ALL TRAPS SUBMITTED");
//            trapsPlaced = checkIfALlTrapsSubmitted();
//        }

//        if (time > 0) {
//            time -= (Time.deltaTime);
//        }
//        timer.text = Mathf.Round(time).ToString();
//        if (time <= 0) {
//            timer.text = "0";
//            //kill all players
//            foreach (GameObject player in players) {
//                player.SetActive(false);
//            }
//        } 
//        checkPlayerStatus();
//    }

//    bool[] escapedAlready = new bool[4]; //Dont add again
//    private void checkPlayerStatus()
//    {
//        int deadCount = 0;
//        for (int i = 0; i < players.Length; i++) {
//            if (!(players[i].activeSelf)) {
//                deadCount++;
//            }
//        }

//        int finCount =0;
//        if (Player1.GetComponent<PlayerEscaped>().escaped) {
//            if (!escapedAlready[0]) { 
//                playersFin.Add(Player1);
//                escapedAlready[0] = true;
//                finCount++;
//            }
//        }
//        if (Player2.GetComponent<PlayerEscaped>().escaped)
//        {
//            //playersFin.Add(Player2);
//            //finCount++;
//            if (!escapedAlready[1])
//            {
//                playersFin.Add(Player2);
//                escapedAlready[1] = true;
//                finCount++;
//            }
//        }
//        if (Player3.GetComponent<PlayerEscaped>().escaped)
//        {
//            //playersFin.Add(Player3);
//            //finCount++;
//            if (!escapedAlready[2])
//            {
//                playersFin.Add(Player3);
//                escapedAlready[2] = true;
//                finCount++;
//            }
//        }
//        if (Player4.GetComponent<PlayerEscaped>().escaped)
//        {
//            //playersFin.Add(Player4);
//            //finCount++;
//            if (!escapedAlready[3])
//            {
//                playersFin.Add(Player4);
//                escapedAlready[3] = true;
//                finCount++;
//            }
//        }
//        if (deadCount == players.Length) {
//            //Cant pause when finished
//            pH.enabled = false;
//            if (finCount == 0)
//            {
//                loseButton.gameObject.SetActive(true);
//                loseButton.Select();
//            }
//            else {
//                //Add coins to live players = to Dead count
//                foreach (GameObject player in playersFin) {
//                    player.GetComponent<PlayerCoins>().addBonusCoins(deadCount-finCount);
//                    Debug.Log("This player gets " + (deadCount - finCount) + " Coins for finishing level" );
//                }
//                //For all alive players add Players>length - (position Finished-1)
//                showLeaderboardAttempt2();
//            }
           
//        }
//    }


//    public GameObject[] deActivateSliders;
//    public Slider[] playerSliers;
//    public int[] playerCoins;
//    public int[] playerCoinsGainedThisRound;
//    public float FillTime = 1f;

//    public void showLeaderboardAttempt2()
//    {
//        deActivateNonPlayers();
//        playerCoins = new int[players.Length];
//        playerCoinsGainedThisRound = new int[players.Length];

//        LeaderBoard.SetActive(true);

//        //Get coins and get highest
//        int highestCoins = PlayerControl.instance.getCoins(1);//Player ones coins
//        for (int i = 0; i < players.Length; i++)
//        {
//            playerCoins[i] = PlayerControl.instance.getCoins(i + 1);
//            playerCoinsGainedThisRound[i] = players[i].GetComponent<PlayerCoins>().getTempCoins();
//            if (PlayerControl.instance.getCoins(i + 1) > highestCoins) {
//                highestCoins = PlayerControl.instance.getCoins(i + 1);
//            }
//            //playerCoinsThisRound.Add(Player1.GetComponent<PlayerCoins>().getTempCoins(), (i + 1));
//        }

//        //Adjust sliders with higest
//        for (int i = 0; i < players.Length; i++) {
//            playerSliers[i].maxValue = highestCoins;
//            //Start value (change to previous coin value), End value(current coin value), and fraction to interpolate
//            playerSliers[i].value = Mathf.Lerp(playerCoinsGainedThisRound[i], playerCoins[i], 1f);

//        }

//        continueButton.Select();
//    }

//    public void deActivateNonPlayers() {
//        if (players.Length <= 3) {
//            deActivateSliders[3].SetActive(false);
//        }
//        if (players.Length <= 2)
//        {
//            deActivateSliders[2].SetActive(false);
//        }
//        if (players.Length <= 1)
//        {
//            deActivateSliders[1].SetActive(false);
//        }
//    }

//    public void startAgain() {
//        Debug.Log(SceneManager.GetActiveScene().buildIndex);
//        FadeScript.FadeToLevel(SceneManager.GetActiveScene().buildIndex);
//        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//    }

//    //Unlock next level if not already unlocked and return to level select
//    public void UnlokckAndLevelSelect() {
//        ///Two extra scenes at start so scenes offset by 2
//        int currentLevel = SceneManager.GetActiveScene().buildIndex -2;
//        if (currentLevel != 2) {
//            LevelController.control.levelsUnlocked[currentLevel + 1] = true;
//        }
        
//        LevelController.control.Save();

//        FadeScript.FadeToLevel(1);
//        //SceneManager.LoadScene(1);
//    }

//}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{

    public GameObject LeaderBoard;
    public GameObject TrapSelect;
    public Button loseButton;
    public Button continueButton;
    public Text timer;
    private float time;

    public GameObject[] players;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    public GameObject Player2HUD;
    public GameObject Player3HUD;
    public GameObject Player4HUD;
    public PlayerControl playerControl;

    private GameObject[] traps;
    public GameObject[] trapsInstantaited;
    private int count;
    public bool trapsPlaced;
    private bool placeTrapsOnce;
    //Dont start paushe handler till trap select done
    PauseHandler pH;

    private List<GameObject> playersFin;

    public GameObject FadeSceneObject;
    private Fade FadeScript;

    void Start()
    {
        playersFin = new List<GameObject>();
        FadeScript = FadeSceneObject.GetComponent<Fade>();
        count = 0;
        trapsPlaced = false;
        placeTrapsOnce = false;
        TrapSelect.SetActive(true);
        pH = gameObject.GetComponent<PauseHandler>();
        pH.start = false;


        LeaderBoard.SetActive(false);
        time = 120;
        playerControl = PlayerControl.instance;
        if (!playerControl.players[1])
        {
            Player2.SetActive(false);
            Player2HUD.SetActive(false);
        }

        if (!playerControl.players[2])
        {
            Player3.SetActive(false);
            Player3HUD.SetActive(false);
        }

        if (!playerControl.players[3])
        {
            Player4.SetActive(false);
            Player4HUD.SetActive(false);
        }

        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<PlayerMovement>().enabled = false;
        }

        loseButton.gameObject.SetActive(false);
    }

    public void placeTraps()
    {
        traps = TrapSelect.GetComponent<TrapSelect>().traps;
        trapsInstantaited = new GameObject[traps.Length];

        for (int count = 0; count < traps.Length; count++)
        {
            GameObject trap = traps[count];
            GameObject t = Instantiate(trap, new Vector3(0, 0, 0), transform.rotation);
            t.AddComponent<TrapMovement>();
            if (count == 1)
            {
                t.GetComponent<TrapMovement>().verticalCtrl = "Vertical_P2";
                t.GetComponent<TrapMovement>().horizontalCtrl = "Horizontal_P2";
                t.GetComponent<TrapMovement>().submitButton = "Jump_P2";
            }
            else if (count == 2)
            {
                t.GetComponent<TrapMovement>().verticalCtrl = "Vertical_P3";
                t.GetComponent<TrapMovement>().horizontalCtrl = "Horizontal_P3";
                t.GetComponent<TrapMovement>().submitButton = "Jump_P3";
            }
            else if (count == 3)
            {
                t.GetComponent<TrapMovement>().verticalCtrl = "Vertical_P4";
                t.GetComponent<TrapMovement>().horizontalCtrl = "Horizontal_P4";
                t.GetComponent<TrapMovement>().submitButton = "Jump_P4";
            }
            trapsInstantaited[count] = t;
        }
    }

    public bool checkIfALlTrapsSubmitted()
    {
        for (int i = 0; i < trapsInstantaited.Length; i++)
        {
            //Debug.Log("Couter is on  " + i + " of  " + trapsInstantaited.Length);
            //Debug.Log(trapsInstantaited[i].GetComponent<TrapMovement>().move);
            if (trapsInstantaited[i].GetComponent<TrapMovement>().move)
            {
                return false;
            }
        }
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<PlayerMovement>().enabled = true;
        }
        cam.GetComponent<ControlCamera>().setCameraBackToPlayers();
        return true;
    }


    public Camera cam;

    void Update()
    {
        cam = GameObject.FindObjectOfType<Camera>();


        if (TrapSelect.activeSelf == false && trapsPlaced)
        {
            //Debug.Log("FINALLY HERE");
            pH.start = true;
        }
        else if (TrapSelect.activeSelf == false && !placeTrapsOnce)
        {
            //Debug.Log("HERE");
            placeTrapsOnce = true;
            placeTraps();
            cam.GetComponent<ControlCamera>().setCameraToTraps(trapsInstantaited);
        }
        else if ((TrapSelect.activeSelf == false))
        {
            //Debug.Log("THEN HERE UNTILL ALL TRAPS SUBMITTED");
            trapsPlaced = checkIfALlTrapsSubmitted();
        }

        if (time > 0)
        {
            time -= (Time.deltaTime);
        }
        timer.text = Mathf.Round(time).ToString();
        if (time <= 0)
        {
            timer.text = "0";
            //kill all players
            foreach (GameObject player in players)
            {
                player.SetActive(false);
            }
        }
        checkPlayerStatus();
    }

    private void checkPlayerStatus()
    {
        int deadCount = 0;
        for (int i = 0; i < players.Length; i++)
        {
            if (!(players[i].activeSelf))
            {
                deadCount++;
            }
        }

        int finCount = 0;
        if (Player1.GetComponent<PlayerEscaped>().escaped)
        {
            playersFin.Add(Player1);
            finCount++;
        }
        if (Player2.GetComponent<PlayerEscaped>().escaped)
        {
            playersFin.Add(Player2);
            finCount++;
        }
        if (Player3.GetComponent<PlayerEscaped>().escaped)
        {
            playersFin.Add(Player3);
            finCount++;
        }
        if (Player4.GetComponent<PlayerEscaped>().escaped)
        {
            playersFin.Add(Player4);
            finCount++;
        }
        if (deadCount == players.Length)
        {
            //Cant pause when finished
            pH.enabled = false;
            if (finCount == 0)
            {
                loseButton.gameObject.SetActive(true);
                loseButton.Select();
            }
            else
            {
                //Add coins to live players = to Dead count
                //For all alive players add Players>length - (position Finished-1)
                showLeaderboardAttempt2();
            }

        }
    }


    public GameObject[] deActivateSliders;
    public Slider[] playerSliers;
    public int[] playerCoins;
    public int[] playerCoinsGainedThisRound;
    public float FillTime = 1f;

    public void showLeaderboardAttempt2()
    {
        deActivateNonPlayers();
        playerCoins = new int[players.Length];
        playerCoinsGainedThisRound = new int[players.Length];

        LeaderBoard.SetActive(true);

        //Get coins and get highest
        int highestCoins = PlayerControl.instance.getCoins(1);//Player ones coins
        for (int i = 0; i < players.Length; i++)
        {
            playerCoins[i] = PlayerControl.instance.getCoins(i + 1);
            playerCoinsGainedThisRound[i] = players[i].GetComponent<PlayerCoins>().getTempCoins();
            if (PlayerControl.instance.getCoins(i + 1) > highestCoins)
            {
                highestCoins = PlayerControl.instance.getCoins(i + 1);
            }
            //playerCoinsThisRound.Add(Player1.GetComponent<PlayerCoins>().getTempCoins(), (i + 1));
        }

        //Adjust sliders with higest
        for (int i = 0; i < players.Length; i++)
        {
            playerSliers[i].maxValue = highestCoins;
            //Start value (change to previous coin value), End value(current coin value), and fraction to interpolate
            playerSliers[i].value = Mathf.Lerp(playerCoinsGainedThisRound[i], playerCoins[i], 1f);

        }

        continueButton.Select();
    }

    public void deActivateNonPlayers()
    {
        if (players.Length <= 3)
        {
            deActivateSliders[3].SetActive(false);
        }
        if (players.Length <= 2)
        {
            deActivateSliders[2].SetActive(false);
        }
        if (players.Length <= 1)
        {
            deActivateSliders[1].SetActive(false);
        }
    }

    public void startAgain()
    {
        //Debug.Log(SceneManager.GetActiveScene().buildIndex);
        FadeScript.FadeToLevel(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Unlock next level if not already unlocked and return to level select
    public void UnlokckAndLevelSelect()
    {
        ///Two extra scenes at start so scenes offset by 2
        int currentLevel = SceneManager.GetActiveScene().buildIndex - 2;
        if (currentLevel != 2)
        {
            LevelController.control.levelsUnlocked[currentLevel + 1] = true;
        }

        LevelController.control.Save();

        FadeScript.FadeToLevel(1);
        //SceneManager.LoadScene(1);
    }

}
