using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject projectilePrefab;

    public float shootRate;
    public float projectileSpeed;
    public float lastShootTime;

    private Camera cam;

    public static Shooting instance;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            if(Time.time - lastShootTime >= shootRate)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        lastShootTime = Time.time;

        GameObject proj = Instantiate(projectilePrefab, cam.transform.position, Quaternion.identity);

        proj.GetComponent<Rigidbody>().velocity = cam.transform.forward * projectileSpeed;

        Destroy(proj, 3.0f);
    }
}
