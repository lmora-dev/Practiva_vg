using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMan : MonoBehaviour
{
    Animator Myanim;
    //que tan rapido se crea las balas
    //contar las balas
    float count;
    //donde salen
    public Transform bulletSpawner;
    public GameObject bulletPrefab;
    Player_Controller pc;


    public Player DatosPlayer;
    //que tan rapido se crea las balas
    private float shootingRatio;

    void Start()
    {
        Myanim = GetComponent<Animator>();
        Myanim.SetBool("shooting", false);
        pc = GetComponent<Player_Controller>();
        shootingRatio = DatosPlayer.RatioDisparo;
    }

    // Update is called once per frame
    void Update()
    {

        if (pc.canMove) { 
            PlayerShooting();
        }
      
    }

    public void PlayerShooting()
    {

        if (Input.GetButton("Fire1"))
        {
            count += Time.deltaTime;

            if(count >= shootingRatio)
            {
                Instantiate(bulletPrefab, bulletSpawner.position, Quaternion.identity);
                count = 0f;
            }
            
            Myanim.SetBool("shooting", true);
            
        }

        else if (Input.GetButtonUp("Fire1"))
        {
            Myanim.SetBool("shooting", false);
        }
    }

}
