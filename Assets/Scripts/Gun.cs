using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public ParticleSystem MuzzleFlash;
    public int maxAmmo = 3;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    private Ammo ammo_;
    [SerializeField] AudioSource gunShot;
    [SerializeField] GameObject gunAmmo;

    // Update is called once per frame
    void Start()
    {
        if(currentAmmo == -1)
        currentAmmo = maxAmmo;
        ammo_ = gunAmmo.GetComponent<Ammo>();
    }
    void OnEnable()
    {
        isReloading = false;

    }
    void Update()
    {
        if (isReloading)
            return;
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

        if (gameObject.transform.parent.gameObject.activeSelf == true)
        {
            gunAmmo.SetActive(true);
        }
        else 
        {
            gunAmmo.SetActive(false);
        }

    }
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
        ammo_.ShowAmmo(currentAmmo);
    }
    void Shoot ()
    {
        MuzzleFlash.Play();
        gunShot.Play();
        ammo_.ShowAmmo(currentAmmo);

        currentAmmo--;

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            AnimalMovement target = hit.transform.GetComponent<AnimalMovement>();
            print(target + "träff");
            if (target != null)
            {
                target.TakeDamage(damage);
                print("ta skada");
            }
        }

    }

    
}
