using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Powerup
{
    float timer;
    public override Powerup GetPowerup()
    {
        return this;
    }

    public override void usePowerUp(GameObject player)
    {
        player.GetComponent<PlayerBody>().setMesh(true);
        for (float time = 0f; time<timer;time+=Time.deltaTime)
        {
            player.GetComponent <PlayerBody>().setMesh(false);
        }
    }
    //Used an abstract class to better manage everything and so that we can make it easier to randomize certain elements
}
