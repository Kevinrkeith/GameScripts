using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : PowerUp
{
    public void Awake()
    {
        type = PowerUpTypes.FLIP;
    }

    protected override PowerUp GetPowerUp()
    {
        return this;
    }

    protected override PowerUpTypes GetType()
    {
        return type;
    }

    public override void UsePowerUp()
    {
        for (int i = 0; i < 3; i++)
        {
            if (player.GetComponent<PlayerBody>().otherPlayers[i].GetComponent<PlayerBody>().flip)
            {
                player.GetComponent<PlayerBody>().otherPlayers[i].GetComponent<PlayerBody>().playerCamera.transform.Rotate(0, 0 * Time.deltaTime, 180);
                player.GetComponent<PlayerBody>().otherPlayers[i].GetComponent<PlayerBody>().flip = true;
            }
        }
    }
}
