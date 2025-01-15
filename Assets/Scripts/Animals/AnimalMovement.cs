using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class AnimalMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] GameObject player;
    [SerializeField] AudioSource walkingAudio;
    [SerializeField] AudioSource runningAudio;

    //movement
    Vector3 destinationPoint;
    bool isWalking;
    [SerializeField] float walkingRange;
    Vector3 runDirection;
    float magnitude;
    bool isRunning;
    public float health = 50f;
    public bool isAlive = true;
    public bool isDeer;

    //ragdoll
    [HideInInspector]
    public ToggleRagdoll toggleRagdoll;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        CheckForSpecificChild();
        toggleRagdoll = GetComponent<ToggleRagdoll>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (isRunning && isAlive)
        {
            Run();
        }
        if(isAlive == false)
        {
            agent.enabled = false;
        }
        else
        {
            if (isAlive && isRunning == false)
            {
                NaturalState();
            }
        }
    }
    
    // går långsamt till slumpmässiga positioner innom den satta rangen
    void NaturalState()
    {
        if (isDeer)
        {
            agent.speed = 4;
        }
        if(isDeer == false)
        {
            agent.speed = 2;
        }

        if (!isWalking)
        {
            FindDestination();
        }
        else
        {
            agent.SetDestination(destinationPoint);
        }
        if(Vector3.Distance(transform.position, destinationPoint) < 10)
        {
            isWalking = false;
        }
        if (!walkingAudio.isPlaying)
        {
            walkingAudio.Play();
        }
    }

    //Slumpar fram en destination innom range och innom navmeshen
    void FindDestination()
    {
        float z = Random.Range(-walkingRange, walkingRange);
        float x = Random.Range(-walkingRange, walkingRange);

        
        destinationPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        //Kollar om destinationen är innom navmeshens gränser
        if(Physics.Raycast(destinationPoint,Vector3.down, groundLayer))
        {
            isWalking = true;
        }
    }
    //springer ifrån spelaren snabbt i en 35-graders vinkel
    void Run()
    {

        if (gameObject.tag == "Deer")
        {
            agent.speed = 7;
        }
        if (gameObject.tag == "Sheep")
        {
            agent.speed = 5;
        }
        //Springer åt motsatt håll från spelaren
        runDirection = (player.transform.position - transform.position).normalized;
        //Gör att den springer i en 35-graders vinkel
        runDirection = Quaternion.AngleAxis(35, Vector3.up) * runDirection;
        //avrundar direction till 1
        magnitude = runDirection.magnitude; 
        agent.SetDestination(transform.position - (runDirection * 5));
        if (!runningAudio.isPlaying)
        {
            runningAudio.Play();
        }
    }

    void CheckForSpecificChild()
    {
        if (transform.gameObject.tag == "Deer")
        {
            isDeer = true;
        }
        else
        {
            isDeer = false;

        }
    }

    //När spelaren är innom triggern flyr djuret
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isRunning = true;
        }
    }
    //När spelaren inte längre är nära går den tillbaka till natural state
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isRunning = false;
            if (isDeer)
            {
                agent.speed = 4;
            }
            if (isDeer == false)
            {
                agent.speed = 2;
            }
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        isAlive = false;
        walkingAudio.Stop();
        runningAudio.Stop();
        toggleRagdoll.ragdollActive(true);
    }
}
