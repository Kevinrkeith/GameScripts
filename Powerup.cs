using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Powerup : MonoBehaviour
{
    [SerializeField]
    private Material orange;
    [SerializeField]
    private Material pink;
    [SerializeField]
    private Material  inactiveMaterial;
    [SerializeField]
    private MeshRenderer meshRenderer;

    [SerializeField]
    private NavMeshAgent powerup;

    [SerializeField]
    private GameObject[] waypoints;

    [SerializeField]
    private float timeUntilChange;
    [SerializeField]
    private float timeUntilRespawn;

    private float count = 0;

    private bool isPink = false;
    private bool isHidden = false;

    private int currentWaypoint = 0;
    public abstract void usePowerUp(GameObject player);
    public abstract Powerup GetPowerup();
    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if(count >= timeUntilChange && !isHidden)
        {
            count = 0;
            if (isPink) meshRenderer.material = orange;
            else meshRenderer.material = pink;
            isPink = !isPink;
        }
        else if (isHidden && count >= timeUntilRespawn)
        {
            count = 0;
            isHidden = false;
            if (isPink) meshRenderer.material = pink;
            else meshRenderer.material = orange;
        }
        if (powerup.remainingDistance <= 1)
        {
            powerup.SetDestination(waypoints[currentWaypoint].transform.position);
            currentWaypoint += 1;
            if (currentWaypoint >= waypoints.Length) currentWaypoint = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isHidden)
        {
            other.GetComponent<PlayerBody>().GeneratePowerup(this);
            meshRenderer.material = inactiveMaterial;
            count = 0;
            other.GetComponent<PlayerBody>().GeneratePowerup(this);
            isHidden = true;
        }
    }

}
public enum PowerUpTypes
{
    GHOST,
    SWAP
}