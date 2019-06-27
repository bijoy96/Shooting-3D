using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Startpos, Endpos;
    float distfrac;
    public int speed;
    float currentdistance;
    float distance;
    int id=0;
    // Start is called before the first frame update
    void Start()
    {
        distance = Vector3.Distance(Startpos.position,Endpos.position);
    }

    // Update is called once per frame
    void Update()
    {
        currentdistance += Time.deltaTime * speed;
        distfrac = currentdistance / distance;
        transform.position = Vector3.Lerp(Startpos.position, Endpos.position, distfrac);
        if (Vector3.Distance(transform.position, Endpos.position) == 0) {
            
                transform.position = Startpos.position;
            currentdistance = 0;
            distfrac = 0;
          id++;
            if (id == 3) {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Enemy Hit");
            transform.position = Startpos.position;
            currentdistance = 0;
            distfrac = 0;
            id++;
            if (id == 3)
            {
                Destroy(gameObject);
            }
        }
    }
}
