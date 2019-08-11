using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int activePlayerCount;

    public static PlayerControl instance;
    public bool[] players = new bool[4];
    public int[] coins = new int[4];

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
            activePlayerCount = 1;
            players[0] = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void addPlayer(int playerNum) {
        activePlayerCount++;
        players[playerNum - 1] = true;
    }

    public void removePlayer(int playerNum)
    {
        activePlayerCount--;
        players[playerNum - 1] = true;
    }

    public void addCoins(int playerNum, int coinNums) {
        coins[playerNum - 1] = coins[playerNum - 1] + coinNums;
    }

    public int getCoins(int PlayerNum) {
        return coins[PlayerNum - 1];
    }
}
