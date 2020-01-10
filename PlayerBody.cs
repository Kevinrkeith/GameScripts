using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBody : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float turnSpeed;
    [SerializeField]
    private float collisionExplosionStrength;
    [SerializeField]
    private float collisionExplosionLift;
    [SerializeField]
    private float collisionExplosionRadius;
    [SerializeField]
    private float collisionLossMultiplyer;
    [SerializeField]
    private float collisionWinMultiplyer;
    [SerializeField]
    private float powerupGhostDuration;

    //[SerializeField]
    //private bool[] powerups;
    Powerup powerUp;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private GameObject[] otherPlayers;

    [SerializeField]
    private Material ghostMaterial;
    [SerializeField]
    private Material normalMaterial;

    [SerializeField]
    private MeshRenderer meshRenderer;

    [SerializeField]
    private Text powerupText;
    [SerializeField]
    private Transform cameraTransform;

    private Vector3 direction;
    private Vector3 lastPosition;
    private bool cameraChange;

    public bool isFiring = false;

    private float ghostCount = -1;


    //Update is called once per frame
    private void Update()
    {
        if (isFiring)
        {
            try
            {
                powerUp.usePowerUp(gameObject);
            }
            catch (NullReferenceException ex) { }
        }
        if (ghostCount >= 0) ghostCount += Time.deltaTime;
        if (ghostCount >= powerupGhostDuration)
        {
            meshRenderer.material = normalMaterial;
            ghostCount = -1;
            tag = "Player";
        }
        //if (powerups[1]) powerupText.text = "Powerup: Ghost";
        //else if (powerups[2]) powerupText.text = "Powerup: Swap";
        //else powerupText.text = "Powerup: None";
    }

    void FixedUpdate()
    {
        if (cameraChange)
        {
            rb.AddForce(new Vector3(direction.x * Time.fixedDeltaTime * speed,0,0), ForceMode.Acceleration);
            rb.AddForce(new Vector3(0,0,direction.z * Time.fixedDeltaTime * turnSpeed), ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(direction.x * Time.fixedDeltaTime * speed * cameraTransform.right, ForceMode.Acceleration);
            rb.AddForce(direction.z * Time.fixedDeltaTime * turnSpeed * cameraTransform.forward, ForceMode.Acceleration);
        }        
        lastPosition = transform.position; //for camera
    }

    //controller changes this
    public void SetMovement(Vector3 value, bool cameraChange)
    {
        this.cameraChange = cameraChange;
        direction = value;
    }

    public void SetFire(bool value)
    {
        isFiring = value;
    }

    //for camera
    public float GetLookDirection()
    {
        if (Mathf.Atan2(transform.position.x - lastPosition.x,transform.position.z - lastPosition.z) * (180 / Mathf.PI) != 0) return Mathf.Atan2(transform.position.x - lastPosition.x, transform.position.z - lastPosition.z) * (180 / Mathf.PI);
        else return transform.rotation.eulerAngles.y;
    }

    //used to determine win on collision and the effects of collisions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && tag != "Ghost")
        {
            Vector3 collisionLocation = collision.GetContact(0).point;
            Rigidbody otherRB = collision.gameObject.GetComponent<Rigidbody>();

            if (otherRB.velocity.magnitude >= rb.velocity.magnitude) rb.AddExplosionForce(collisionExplosionStrength * collisionWinMultiplyer, collisionLocation, collisionExplosionRadius, collisionExplosionLift * collisionWinMultiplyer);
            else if (otherRB.velocity.magnitude < rb.velocity.magnitude) rb.AddExplosionForce(collisionExplosionStrength * collisionLossMultiplyer, collisionLocation, collisionExplosionRadius, collisionExplosionLift * collisionLossMultiplyer);
        }
        else if(collision.gameObject.tag == "Ghost")
        {
            Vector3 collisionLocation = collision.GetContact(0).point;
            Rigidbody otherRB = collision.gameObject.GetComponent<Rigidbody>();
            transform.position = (transform.position + ((collisionLocation - transform.position) * 5f));
        }
    }
    public GameObject[] getOthers()
    {
        return otherPlayers;
    }
    public void setMesh(Boolean isActive)
    {
        if (isActive)
        {
            meshRenderer.material = ghostMaterial;
            tag = "Ghost";
            ghostCount = 0;
        } else
        {
            meshRenderer.material = normalMaterial;
            tag = "Player";
        }
    }
    public void GeneratePowerup(Powerup powerUp)
    {
        this.powerUp = powerUp;
    }

    private void PowerupActivate(int value)
    {
        //switch (value)
        //{
        //    //case 1: //Ghost
        //    //    meshRenderer.material = ghostMaterial;
        //    //    tag = "Ghost";
        //    //    ghostCount = 0;
        //    //    powerups[0] = false;
        //    //    powerups[1] = false;
        //    //    break;
        //    //case 2: //Swap Players
        //    //    powerups[0] = false;
        //    //    powerups[2] = false;
        //    //    int random = Random.Range(0, 3);
        //    //    Vector3 otherPosition = otherPlayers[random].transform.position;
        //    //    otherPlayers[random].transform.position = transform.position;
        //    //    transform.position = otherPosition;
        //    //    break;
        //}
    }
}