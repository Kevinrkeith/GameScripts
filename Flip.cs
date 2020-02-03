using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : PowerUp
{
    public override void UsePowerUp(int playerUsed)
    {
        for (int i = 0; i < GameManager.gameManager.numberOfPlayers; i++)
        {
            if (i != playerUsed)
            {
                GameManager.gameManager.cameras[i].transform.Rotate(0, 0*Time.deltaTime,180);
                GameManager.gameManager.playerBody[i].flip = true;
            }
        }
    }
}
