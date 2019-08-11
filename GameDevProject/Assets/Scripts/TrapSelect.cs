using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrapSelect : MonoBehaviour
{
    public PlayerControl playerControl;
    public GameObject[] traps;
    public Text txt;

    int i = 0;//Player count

    EventSystem evSys;
    StandaloneInputModule inputModule;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        evSys = EventSystem.current;
        inputModule = evSys.gameObject.GetComponent<StandaloneInputModule>();
        int numOfPlayers =1;
        playerControl = PlayerControl.instance;
        if (playerControl.players[1])
        {
            numOfPlayers++;
        }

        if (playerControl.players[2])
        {
            numOfPlayers++;
        }

        if (playerControl.players[3])
        {
            numOfPlayers++;
        }


        traps = new GameObject[numOfPlayers];
    }

    public void addTrap(GameObject trap) {
        Debug.Log("Player " + (i+1) + " Select a trap plz");
        Debug.Log("Traps Length :" + traps.Length);
        traps[i] = trap;
        if ((i + 1) == traps.Length) {
            //All players have choosen trap
            Debug.Log("do this");
            gameObject.SetActive(false);
            inputModule.submitButton = "Jump_P1";
            inputModule.horizontalAxis = "Horizontal_P1";
            inputModule.verticalAxis = "Vertical_P1";
            return;
        }
        i++;
        //Change input
        
        inputModule.submitButton = "Jump_P" + (i + 1);
        inputModule.horizontalAxis = "Horizontal_P" + (i + 1);
        inputModule.verticalAxis = "Vertical_P" + (i + 1);

        //Load trap selec again for next player
        //Change player text
        txt.text = "Player " + (i + 1) + ": Trap Select";

     }
}
