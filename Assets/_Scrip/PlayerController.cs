using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float distancceX;
    public GameObject bulletStart;
    public float speed;
    public float tilt; //độ nghiêng
    
    private AudioSource _audioSource ;
    public float fireRate;//tốc độ bắn
    private float _timeRate;//thời gian bắn(countDown)
    private Rigidbody _rg;
    

    

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
       
        _rg = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > _timeRate)
        {
            _audioSource.Play();
            _timeRate = Time.time + fireRate;
           // Instantiate(bullet, bulletStart.transform.position, bulletStart.transform.rotation);
           GameObject bullet = ObjectPool.instance.GetPooledObject();
           if (bullet != null)
           {
               bullet.transform.position = bulletStart.transform.position;
               bullet.SetActive(true);
           }
        }
    }
    public void FixedUpdate()
    {
        var hor = Input.GetAxis("Horizontal");
        var ver = Input.GetAxis("Vertical");
        _rg.velocity = new Vector3(hor, 0, ver)*speed;

        var position = transform.position;
        position = new Vector3(Mathf.Clamp(position.x,-distancceX,distancceX),0,Mathf.Clamp(position.z,-1f,14f));
        transform.position = position;
        
        transform.rotation = Quaternion.Euler(new Vector3(0,0,_rg.velocity.x*-tilt));
    }
   
}
