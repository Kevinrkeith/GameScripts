using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boost : PowerUp
{
    [SerializeField]
    float multiplier;
    public override void UsePowerUp(int playerUsed)
    {
        GameManager.gameManager.playerBody[playerUsed].ApplyForce(GameManager.gameManager.player[playerUsed].transform.position, multiplier, ForceMode.Acceleration);
    }
}
