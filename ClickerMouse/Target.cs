using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
   // public ParticleSystem explosionParticle;
    public int pointValue;
    private float minspeed = 12;
    private float maxspeed = 16;
    private float maxtorque = 10;
    private float xrange = 4;
    private float yspawnpos = -6;
    private Rigidbody targetRb;
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    //
    //
    {
       
        targetRb =GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetRb.AddForce(RandomForce(),ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(),ForceMode.Impulse);
        transform.position = RandomSpawnPos();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            // Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

            gameManager.UpdateScore(pointValue);
        }
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minspeed, maxspeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxtorque, maxtorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xrange, xrange), yspawnpos);
    }
  
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
        
    }
}
