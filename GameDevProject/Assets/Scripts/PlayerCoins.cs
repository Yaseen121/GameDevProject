using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCoins : MonoBehaviour
{
    private int numCoins = 0;
    private int tempCoins = 0;
    public Text coinsText;
    public int playerNum;//1-4

    private void Start()
    {
        numCoins = PlayerControl.instance.getCoins(playerNum);
        coinsText.text = "x0" + numCoins;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("GameObject2 collided with " + other.name);

        //If colliding with a pickup object, deactivate it.
        if (other.gameObject.tag == "Collectable")
        {

            other.gameObject.SetActive(false);
            tempCoins++;
            coinsText.text = "x0" + (numCoins+tempCoins);
            //Debug.Log("Coin collected");
        }
    }

    //Drop temp coins on death
    public void dropTempCoins() {
        tempCoins = 0;
        //Lose one coin cause of death
        if (numCoins > 0)
        {
            numCoins--;
        }
        coinsText.text = "x0" + (numCoins + tempCoins);
        //Maybe spawn coin again somewhere
    }

    //Add coins when level finished
    public void addBonusCoins(int nC) {
        numCoins = numCoins + nC;
        PlayerControl.instance.addCoins(playerNum, nC);
    }

    //Add temp coins on level finish
    public void finishLevel() {
        numCoins = numCoins + tempCoins;
        PlayerControl.instance.addCoins(playerNum, tempCoins);
    }

    public int getTempCoins() {
        return tempCoins;
    }
}
