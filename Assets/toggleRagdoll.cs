using UnityEngine;

public class toggleRagdoll : MonoBehaviour
{
    protected Rigidbody rB;
    protected BoxCollider boxCollider;

    protected Collider[] childernCollider;
    protected Rigidbody[] childernRb;


    private void Awake()
    {
        rB = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();

        childernCollider = GetComponentsInChildren<Collider>();
        childernRb = GetComponentsInChildren<Rigidbody>();
    }
    void Start()
    {
        ragdollActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ragdollActive(true);
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
    }
}
