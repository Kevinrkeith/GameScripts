using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Swap : PowerUp
{
    public void Awake()
    {
        type = PowerUpTypes.SWAP;
    }

    public override void UsePowerUp(int playerUsed)
    {
        int random = playerUsed;
        while (true)
        {
            random = Random.Range(0, GameManager.gameManager.numberOfPlayers);
            if (random != playerUsed && GameManager.gameManager.player[random].tag != "Ghost") break;
        }
        Vector3 temp = GameManager.gameManager.player[playerUsed].transform.position;
        GameManager.gameManager.player[playerUsed].transform.position = GameManager.gameManager.player[random].transform.position;
        GameManager.gameManager.player[random].transform.position = temp;
    }
}
