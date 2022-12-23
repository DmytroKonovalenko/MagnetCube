using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float pushPower;
    [SerializeField] private float cubeMaxPosX;

    [SerializeField] private TouchSlider touchSlider;
     private Cube mainCube;

    private bool IsPointerDown;
    private Vector3 cubePosition;


    // Start is called before the first frame update
    void Start()
    {
        SpawnCube();

        touchSlider.OnPointerDownAction += OnPointerDown; 
        touchSlider.OnPointerDragAction += OnPointerDrag; 
        touchSlider.OnPointerUpAction += OnPointerUp;   
    }
    private void Update()
    {
        if (IsPointerDown)
            mainCube.transform.position = Vector3.Lerp(mainCube.transform.position, cubePosition, moveSpeed * Time.deltaTime);
    }
    private void OnPointerDown()
    {
        IsPointerDown = true;
    }
    private void OnPointerDrag(float xMovement)
    {
        if(IsPointerDown)
        {
            cubePosition = mainCube.transform.position;
            cubePosition.x = xMovement * cubeMaxPosX;

        }
    }
    private void OnPointerUp()
    {
        if(IsPointerDown)
        {
            IsPointerDown = false;
            mainCube.cubeRb.AddForce(Vector3.forward * pushPower, ForceMode.Impulse);

            Invoke("SpawnNewCube",0.3f);

        }
    }
    private void SpawnNewCube()
    {
        mainCube.isMainCube = false;
        SpawnCube();
    }

    private void SpawnCube()
    {
        mainCube = CubeSpawner.Instance.SpawnRandom();
        mainCube.isMainCube = true;


        cubePosition = mainCube.transform.position;
    }
    private void OnDestroy()
    {
        touchSlider.OnPointerDownAction -= OnPointerDown;
        touchSlider.OnPointerDragAction -= OnPointerDrag;
        touchSlider.OnPointerUpAction -= OnPointerUp;
    }

    
    
    
        
    
}
