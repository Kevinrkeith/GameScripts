using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMask : PowerUp
{
    public override void UsePowerUp(int playerUsed)
    {
        for(int i=0; i < GameManager.gameManager.numberOfPlayers; i++)
        {
            if (i != playerUsed)
            {
                GameManager.gameManager.playerBody[i].mask.SetActive(true);
            }
        }
    }
}
