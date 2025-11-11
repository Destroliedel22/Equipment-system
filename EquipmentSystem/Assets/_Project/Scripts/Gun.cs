using JetBrains.Annotations;
using System.Collections;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject bulletHole;
    [SerializeField] private ParticleSystem MuzzleFlash;
    [SerializeField] private ParticleSystem Hit;
    [SerializeField] private float shootDistance;

    [SerializeField] public TextMeshProUGUI bulletCountText;

    private GameObject Camera;

    public int bullets;
    public float ItemCooldown;

    private void Awake()
    {
        Camera = FindAnyObjectByType<Camera>().gameObject;
        bullets = 17;
        bulletCountText.text = bullets.ToString();
    }

    public void Interact()
    {
        if(bullets > 0)
        {
            Shoot();
            bulletCountText.text = bullets.ToString();
        }
        else
        {
            //No bullets
        }
    }

    //Shoots a raycast out of the camera middle point and spawns a particle effect on where it hit
    private void Shoot()
    {
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

    public void Reload(int bulletsInClip)
    {
        if (bullets < 17)
        {
            bullets += bulletsInClip;
            if (bullets > 17)
                bullets = 17;
            bulletCountText.text = bullets.ToString();
        }
        else
        {
            //Gun is full
        }
    }

    //Stops the muzzle flash particle effect from playing
    public IEnumerator StopFlash()
    {
        yield return new WaitForSeconds(ItemCooldown);
        MuzzleFlash.Stop();
    }

    //Destroys the impact particle effect after half a second
    public IEnumerator DestroyImpact(ParticleSystem hit)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(hit.gameObject);
    }
}
