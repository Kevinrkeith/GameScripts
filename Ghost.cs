using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : PowerUp
{
    public void Awake()
    {
        type = PowerUpTypes.GHOST;

    }

    public override void UsePowerUp(int playerUsed)
    {
        GameManager.gameManager.playerBody[playerUsed].SetMaterial(true);
    }
    //Used an abstract class to better manage everything and so that we can make it easier to randomize certain elements
}