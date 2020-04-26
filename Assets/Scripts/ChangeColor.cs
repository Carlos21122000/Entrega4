using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color defaultcolor;
    public Color newColor;
    public RenderBuffer render;

    public void OnMouseOver()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    private void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material.color = Color.yellow;
    }
}
