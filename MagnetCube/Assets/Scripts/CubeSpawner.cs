using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeSpawner : MonoBehaviour
{
    public static CubeSpawner Instance;
    Queue<Cube> cubesQueue = new Queue<Cube>();
    [SerializeField] private int cubesQueueCapacity = 20;
    [SerializeField] private bool autoQueueGrow = true;

    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Color[] cubeColor;

    [HideInInspector] public int maxCubeNumber;

    private int maxPower = 12;
    private Vector3 defaultSpawnPosition;
    private void Awake()
    {

        Instance = this;
        defaultSpawnPosition = transform.position;
        maxCubeNumber = (int)Mathf.Pow(2, maxPower);

        InitializeCubesQueue();

    }
    private void InitializeCubesQueue()
    {
        for (int i = 0; i < cubesQueueCapacity; i++)
            AddCubeToQueue();

        
    }

    private void AddCubeToQueue()
    {
        Cube cube = Instantiate(cubePrefab,defaultSpawnPosition,Quaternion.identity,transform).GetComponent<Cube>();


        cube.gameObject.SetActive(false);
        cube.isMainCube = false;
        cubesQueue.Enqueue(cube);
    }

    public int GenerateRandomNumber()
    {

        return (int)Mathf.Pow(2, Random.Range(1, 6));

    }
    public Cube Spawn(int number,Vector3 position)
    {
        if(cubesQueue.Count==0)
        {
            if(autoQueueGrow)
            {
                cubesQueueCapacity++;
                AddCubeToQueue();
            }
            else
            {
                Debug.LogError("[CubesQueue]:erorr");
                return null;
            }
        }
        Cube cube = cubesQueue.Dequeue();
        cube.transform.position = position;
        cube.SetNumber(number);
        cube.SetColor(GetColor(number));
        cube.gameObject.SetActive(true);


        return cube;

    }

    public Cube SpawnRandom()
    {
        return Spawn(GenerateRandomNumber(), defaultSpawnPosition);

    }
    public void DestroyCube(Cube cube)
    {
        cube.cubeRb.velocity = Vector3.zero;
        cube.cubeRb.angularVelocity = Vector3.zero;
        cube.transform.rotation = Quaternion.identity;
        cube.isMainCube = false;
        cube.gameObject.SetActive(false);
        cubesQueue.Enqueue(cube);
    }
    private Color GetColor(int number)
    {
        return cubeColor[(int)(Mathf.Log(number)/Mathf.Log(2))-1];
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
