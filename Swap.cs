using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : Powerup
{
    public void Awake()
    {
        
    }
    public override Powerup GetPowerup()
    {
        return this;
    }

    public override void usePowerUp(GameObject player)
    {

        GameObject[] otherPlayers = player.GetComponent<PlayerBody>().getOthers();
        int random = Random.Range(0, 3);
        Vector3 otherPosition = otherPlayers[random].transform.position;
        otherPlayers[random].transform.position = transform.position;
        transform.position = otherPosition;
    }
}
