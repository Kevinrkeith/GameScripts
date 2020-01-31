using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMask : PowerUp
{
    public override void UsePowerUp()
    {
        for (int i = 0; i < 3; i++)
        {
            player.GetComponent<PlayerBody>().otherPlayers[i].GetComponent<PlayerBody>().playerCamera.transform.Rotate(0, 0 * Time.deltaTime, 180);
            player.GetComponent<PlayerBody>().otherPlayers[i].GetComponent<PlayerBody>().flip = true;
        }
    }

    protected override PowerUp GetPowerUp()
    {
        return this;
    }

    protected override PowerUpTypes GetType()
    {
        return type;
    }

    // Start is called before the first frame update
    void Awake()
    {
        type = PowerUpTypes.MASK;
    }
}
