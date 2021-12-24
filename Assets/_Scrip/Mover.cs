using System;
using System.Collections;
using System.Collections.Generic;
using _Scrip;
using TMPro;
using UnityEngine;

public class Mover : MonoBehaviour
{
   public float speed;
   public GameObject explosion;
   public GameObject dead;
  [SerializeField] private Rigidbody _rg;
  
   private void Awake()
   {
       _rg = GetComponent<Rigidbody>();
       
   }

   private void Start()
   {
       _rg.velocity = transform.forward * speed;
      
       

   }

   // private void OnCollisionEnter(Collision collision)
   // {
   //     if (collision.gameObject.CompareTag("Wall"))
   //     {
   //         Debug.Log("1");
   //         gameObject.SetActive(false);
   //     }
   // }
   private void OnTriggerEnter(Collider other)
   {
       if (other.CompareTag("Wall"))
       {
          gameObject.SetActive(false);
       }
       else if (other.CompareTag("Enemy"))
       {
          other.gameObject.SetActive(false);
          // Instantiate(explosion, transform.position, transform.rotation);
           explosion = ObjectPool.instance.GetExPooledObject();
           if (explosion != null)
           {
               explosion.transform.position = other.transform.position;
               explosion.SetActive(true);
           }
           GameController.instance.AddScore(1);
            
       }
       else if (other.CompareTag("Player") && gameObject.tag.Equals("Enemy"))
       {
           other.gameObject.SetActive(false); 
           Instantiate(dead, transform.position, transform.rotation);
           GameController.instance._restart = true;
           GameController.instance.GameOver();
       }
   }

 
}
