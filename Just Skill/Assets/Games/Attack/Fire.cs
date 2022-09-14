using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [Header("Bullet")]
    public GameObject bullet;
    public float shootForce;
    public bool canAutoFire = false;
    private bool readyToShoot;
    public float timeToShootAgain;

    //reference
    public Camera myCamera;
    public Transform firePoint;
    public AudioSource fireSource;
    public AudioClip fireSong;


    // Start is called before the first frame update
    void Start()
    {
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
    }

    public void MyInput()
    {
        if(Input.GetKey(KeyCode.Mouse0) && canAutoFire && readyToShoot)
        {
            callFire();
        }else if (Input.GetKeyDown(KeyCode.Mouse0) && readyToShoot)
        {
            callFire();
        }
    }

    private void playSong()
    {
        fireSource.PlayOneShot(fireSong);

    }

    public void callFire()
    {
        playSong();
        readyToShoot = false;
        //create raycast
        Ray ray = myCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        //check if raycast hit something
        if(Physics.Raycast(ray,out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }

        //get shootdirection
        Vector3 shootDirection = targetPoint - firePoint.position;
        //create bullet
        GameObject currentBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
        //set initial bullet direction
        currentBullet.transform.forward = shootDirection.normalized;
        //apply force to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(shootDirection.normalized * shootForce, ForceMode.Impulse);

        Invoke("resetShoot", timeToShootAgain);

    }

    private void resetShoot()
    {
        readyToShoot = true;
    }
}
