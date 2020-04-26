using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour
{
    public int VidaActual =1 ;
    public float score = 0;
    public Text mitexto;
    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 30f) * Time.deltaTime);
    }
    public void Damage(int damageAmount)
    {
        
        VidaActual -= damageAmount;
        if (VidaActual <= 0)
        {
            score += 1;
            gameObject.SetActive(false);
            mitexto.text = "Score: " + score.ToString();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin")) 
        {
            Destroy(other.gameObject);
            score++;
        }
    }
}
