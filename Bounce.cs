using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : PowerUp
{
    [SerializeField]
    int timesToBounce;
    public override void UsePowerUp(int playerUsed)
    {
        GameManager.gameManager.playerBody[playerUsed].bouncing=true;
    }
}
