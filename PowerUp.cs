using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PowerUp : MonoBehaviour
{
    [SerializeField]
    protected PowerUpTypes type;
    public PowerUpTypes GetPowerUpTypes()
    {
        return type;
    }
    public abstract void UsePowerUp(int playerUsed);
}
public enum PowerUpTypes
{
    BACKHAND,
    BOOST,
    BOUNCE,
    FLIP,
    GHOST,
    LANDMINE,
    MASK,
    MINE,
    SPIKE,
    STICKY,
    SWAP
}
