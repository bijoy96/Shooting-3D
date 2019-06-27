using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float RotateSpeed;
    Rigidbody rb;


    //forshooting
    public GameObject bullet;
    public Transform SpawnPoint;
    float nextFire;
    public float fireRate;
    //public GameObject enemy;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       

    }
    
    // Update is called once per frame
    void Update()
    {


        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);

        transform.Rotate(0f, Input.GetAxis("Horizontal") * RotateSpeed* Time.deltaTime, 0f);







        if (Input.GetButton("Jump") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, SpawnPoint.position, SpawnPoint.rotation);
        }
    }
}
