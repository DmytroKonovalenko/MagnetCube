using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cube : MonoBehaviour
{
    static int staticID = 0;
    [SerializeField] private TMP_Text[] numbersText;
    [HideInInspector] public int cubeId;
    [HideInInspector] public Color cubeColor;
    [HideInInspector] public int cubeNumber;
    [HideInInspector] public Rigidbody cubeRb;
    [HideInInspector] public bool isMainCube;

    private MeshRenderer cubeMeshRenderer;
    private void Awake()
    {
        cubeId = staticID++;
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
