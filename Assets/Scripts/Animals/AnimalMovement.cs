
using UnityEngine;
using UnityEngine.AI;


public class AnimalMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] GameObject player;
    [SerializeField] AudioSource walkingAudio;
    [SerializeField] AudioSource runningAudio;
    [SerializeField] Animator animation;

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
            animation.enabled = false;
        }
        else
        {
            if (isAlive && isRunning == false)
            {
                NaturalState();
            }
        }
    }
    
    // g�r l�ngsamt till slumpm�ssiga positioner innom den satta rangen.
    void NaturalState()
    {
        //g�r att hjorten �r snabbare �n f�ret
        if (isDeer)
        {
            agent.speed = 4;
        }
        if(isDeer == false)
        {
            agent.speed = 2;
        }
        animation.SetTrigger("Walk");
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
        //spela ljudet om den g�r
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

        //Kollar om destinationen �r innom navmeshens gr�nser
        if(Physics.Raycast(destinationPoint,Vector3.down, groundLayer))
        {
            isWalking = true;
        }
    }
    //springer ifr�n spelaren snabbt i en 35-graders vinkel
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
        animation.SetTrigger("Run");
        //Springer �t motsatt h�ll fr�n spelaren
        runDirection = (player.transform.position - transform.position).normalized;
        //G�r att den springer i en 35-graders vinkel
        runDirection = Quaternion.AngleAxis(35, Vector3.up) * runDirection;
        //avrundar direction till 1
        magnitude = runDirection.magnitude; 
        agent.SetDestination(transform.position - (runDirection * 5));
        if (!runningAudio.isPlaying)
        {
            runningAudio.Play();
        }
    }

    //kollar om det �r en deer
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

    //N�r spelaren �r innom triggern flyr djuret
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isRunning = true;
        }
    }
    //N�r spelaren inte l�ngre �r n�ra g�r den tillbaka till natural state
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

    //minskar hp och d�r vid noll hp
    public void TakeDamage(float amount, Vector3 pointOfImpact)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    //slutar spela ljud och blir en ragdoll
    void Die()
    {
        isAlive = false;
        walkingAudio.Stop();
        runningAudio.Stop();
        toggleRagdoll.ragdollActive(true);
    }

}
