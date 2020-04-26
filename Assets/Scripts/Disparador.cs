using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disparador : MonoBehaviour
{
    public Camera cam;
    GameObject DisparoGo;
    GameObject ExplosionGo;

    public GameObject DisparoPrefab;
    public GameObject ExplosionPrefab;

    public Transform Cañon;

    private RaycastHit hit;

    public float hitForce = 100f;
    public int gunDamage = 1;


    void Start()
    {
        
        if (DisparoGo == null)
        {
            
            DisparoGo = (GameObject)Instantiate(DisparoPrefab);
            DisparoPrefab.SetActive(false);
            DisparoGo.transform.SetParent(Cañon);

        }
        if (ExplosionGo == null)
        {
            ExplosionGo = (GameObject)Instantiate(ExplosionPrefab);
            ExplosionPrefab.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(new Ray(cam.transform.position +cam.transform.forward * .5f, cam.transform.forward),out hit, 20))
            {
                DisparoGo.SetActive(true);
                ExplosionGo.transform.position = hit.point;
                ExplosionGo.SetActive(true);

                Invoke("ApagarEfecto", 2);
                print(hit.collider.name);
            }

            Destroyer health = hit.collider.GetComponent<Destroyer>();
            if (health != null)
            {
                health.Damage(gunDamage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * hitForce);
            }
        }
    }

    void ApagarEfecto() 
    {
        ExplosionGo.SetActive(false);
        DisparoGo.SetActive(false);
    }
}
