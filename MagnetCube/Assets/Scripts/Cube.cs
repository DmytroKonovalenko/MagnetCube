using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cube : MonoBehaviour
{
    [SerializeField] private TMP_Text[] numbersText;
    [HideInInspector] public Color cubeColor;
    [HideInInspector] public int cubeNumber;
    [HideInInspector] public Rigidbody cubeRb;
    [HideInInspector] public bool isMainCube;

    private MeshRenderer cubeMeshRenderer;
    private void Awake()
    {
        cubeMeshRenderer = GetComponent<MeshRenderer>();
        cubeRb = GetComponent<Rigidbody>();

    }

    public void SetColor(Color color)
    {
        cubeColor = color;
        cubeMeshRenderer.material.color = color;
    }
    public void SetNumber(int number)
    {
        cubeNumber = number;
        for (int i = 0; i <6; i++)
        {
            numbersText[i].text = number.ToString();
        }
    }


    
    
    
}
