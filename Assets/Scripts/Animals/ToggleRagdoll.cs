using UnityEngine;
using UnityEngine.AI;

public class ToggleRagdoll : MonoBehaviour
{
    protected Rigidbody rB;
    protected BoxCollider boxCollider;
    protected NavMeshAgent navMesh;

    protected Collider[] childernCollider;
    protected Rigidbody[] childernRb;
    protected SphereCollider sphereCollider;


    private void Awake()
    {
        rB = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        sphereCollider = GetComponent<SphereCollider>();
        navMesh = GetComponent<NavMeshAgent>();

        childernCollider = GetComponentsInChildren<Collider>();
        childernRb = GetComponentsInChildren<Rigidbody>();
        boxCollider.enabled = true;
        sphereCollider.enabled = true;
    }
    void Start()
    {
        ragdollActive(false);
        rB.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        sphereCollider.enabled = true;
        //if (Input.GetKeyDown(KeyCode.R))
        {
            //ragdollActive(true);
        }
    }
    public void ragdollActive(bool active)
    {
        foreach (var collider in childernCollider)
        {
            collider.enabled = active;
        }
        foreach ( var rB in childernRb)
        {
            rB.detectCollisions = active;
            rB.isKinematic = !active;
        }
        
        rB.detectCollisions = !active;
        rB.isKinematic = active;
        boxCollider.enabled = !active;
        navMesh.enabled = !active;
    }
}
