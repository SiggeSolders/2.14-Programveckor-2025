using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public ParticleSystem MuzzleFlash;
    public int maxAmmo = 3;
    public int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    [SerializeField] AudioSource gunShot;
    [SerializeField] GameObject Blodd;

    // Update is called once per frame
    void Start()
    {
        currentAmmo = maxAmmo;
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

    }
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
    void Shoot ()
    {
        MuzzleFlash.Play();
        gunShot.Play();

        currentAmmo--;
        GameObject.Find("PlayerCamera").GetComponent<PlayerCamera>().shake = 1f;
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            AnimalMovement target = hit.transform.GetComponent<AnimalMovement>();
            if (target != null)
            {
                Vector3 pointOfImpact = hit.point;
                Instantiate(Blodd, pointOfImpact, Quaternion.identity);
                target.TakeDamage(damage, pointOfImpact);
            }
                print(target + "träff");
        }

    }

    
}
