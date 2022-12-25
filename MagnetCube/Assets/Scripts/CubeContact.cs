using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeContact : MonoBehaviour
{
    Cube cube;
    private void Awake()
    {
        cube = GetComponent<Cube>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Cube othercube = collision.gameObject.GetComponent<Cube>();

        if(othercube!=null&&cube.cubeId>othercube.cubeId)
        {
            if(cube.cubeNumber==othercube.cubeNumber)
            {
                Debug.Log("HIT:" + cube.cubeNumber);
                Vector3 contactPoint = collision.contacts[0].point;

                if(othercube.cubeNumber<CubeSpawner.Instance.maxCubeNumber)
                {
                    Cube newCube = CubeSpawner.Instance.Spawn(cube.cubeNumber * 2, contactPoint + Vector3.up * 1.6f);
                    float pushForce = 2.5f;
                    newCube.cubeRb.AddForce(new Vector3(0, 0.3f, 1f) * pushForce, ForceMode.Impulse);

                    float randomValue = Random.Range(-20f, 20f);
                    Vector3 randomDirection=Vector3.one*randomValue;
                    newCube.cubeRb.AddTorque(randomDirection);
                }
                Collider[] surroundedCubes = Physics.OverlapSphere(contactPoint, 2f);
                float explosionForce = 400f;
                float explosionRadius = 1.5f;

                foreach(Collider coll in surroundedCubes)
                {
                    if (coll.attachedRigidbody != null)
                        coll.attachedRigidbody.AddExplosionForce(explosionForce, contactPoint, explosionRadius);

                }


                FX.Instance.StartExplosionFX(contactPoint, cube.cubeColor);

                CubeSpawner.Instance.DestroyCube(cube);
                CubeSpawner.Instance.DestroyCube(othercube);
            }
        }
    }
}
