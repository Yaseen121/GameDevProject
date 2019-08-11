

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersController : MonoBehaviour
{

    public GameObject Player2Image;
    public GameObject Player3Image;
    public GameObject Player4Image;
    public Text Player2Text;
    public Text Player3Text;
    public Text Player4Text;
    private bool player2Added;
    private bool player3Added;
    private bool player4Added;

    public PlayerControl playerControl;

    // Start is called before the first frame update
    void Start()
    {
        playerControl = PlayerControl.instance;
        if (!playerControl.players[1]) {
            Player2Image.SetActive(false);
            Player2Text.text = "Press A to join";
            Player2Text.fontSize = 35;
        }

        if (!playerControl.players[2])
        {
            Player3Image.SetActive(false);
            Player3Text.text = "Press A to join";
            Player3Text.fontSize = 35;
        }

        if (!playerControl.players[3])
        {
            Player4Image.SetActive(false);
            Player4Text.text = "Press A to join";
            Player4Text.fontSize = 35;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!player2Added) {
            if (Input.GetButtonDown("Jump_P2"))
            {
                //Add Player 2
                Player2Image.SetActive(true);
                Player2Text.text = "Player2";
                Player2Text.fontSize = 50;
                player2Added = true;
                playerControl.addPlayer(2);
            }
        }

        if (!player3Added)
        {
            if (Input.GetButtonDown("Jump_P3"))
            {
                //Add Player 3
                Player3Image.SetActive(true);
                Player3Text.text = "Player3";
                Player3Text.fontSize = 50;
                player3Added = true;
                playerControl.addPlayer(3);
            }
        }

        if (!player4Added)
        {
            if (Input.GetButtonDown("Jump_P4"))
            {
                //Add Player 4
                Player4Image.SetActive(true);
                Player4Text.text = "Player4";
                Player4Text.fontSize = 50;
                player4Added = true;
                playerControl.addPlayer(4);
            }
        }
    }
}
