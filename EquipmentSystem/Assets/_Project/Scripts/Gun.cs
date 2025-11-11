using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject bulletHole;
    [SerializeField] private ParticleSystem MuzzleFlash;
    [SerializeField] private ParticleSystem Hit;
    [SerializeField] private float shootDistance;

    private GameObject Camera;

    public int bullets;
    public float ItemCooldown;
    public bool ItemOnCooldown;

    private void Awake()
    {
        Camera = FindAnyObjectByType<Camera>().gameObject;
        bullets = 17;
    }

    public void Interact()
    {
        if(!ItemOnCooldown && bullets > 0)
        {
            Shoot();
            Debug.Log(bullets);
        }
        else
        {
            //Gun on cooldown
        }
    }

    //Shoots a raycast out of the camera middle point and spawns a particle effect on where it hit
    private void Shoot()
    {
        ItemOnCooldown = true;
        MuzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, shootDistance))
        {
            ParticleSystem clone = Instantiate(Hit, hit.point, Quaternion.LookRotation(hit.normal));
            StartCoroutine(DestroyImpact(clone));
        }
        StartCoroutine(StopFlash());
        bullets--;
    }

    //Stops the muzzle flash particle effect from playing
    public IEnumerator StopFlash()
    {
        yield return new WaitForSeconds(ItemCooldown);
        MuzzleFlash.Stop();
        ItemOnCooldown = false;
    }

    //Destroys the impact particle effect after half a second
    public IEnumerator DestroyImpact(ParticleSystem hit)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(hit.gameObject);
    }
}
