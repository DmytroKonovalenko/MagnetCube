using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZone : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        Cube cube = other.GetComponent<Cube>();
        if(cube!=null)
        {
            if(!cube.isMainCube&&cube.cubeRb.velocity.magnitude<.1f)
            {
                Debug.Log("Game Over");
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
