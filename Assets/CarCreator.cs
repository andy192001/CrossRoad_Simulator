using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCreator : MonoBehaviour
{
    public List<BaseCar> myPrefab;

    void Start()
    {
        //Instantiate(myPrefab, new Vector3(60, 1, 5),Quaternion.identity);
    }
    void Update()
    {
        
    }

    void DownSpawner()
    {
        //Instantiate(myPrefab, new Vector3(60, 1, 5), transform.rotation);

    }

    void UpSpawner()
    {
        //Instantiate(myPrefab, new Vector3(60, 1, 5), transform.rotation);

    }

    void RightSpawner()
    {
        //Instantiate(myPrefab, new Vector3(60, 1, 5), transform.rotation);

    }

    void LeftSpawner()
    {
        //Instantiate(myPrefab, new Vector3(60, 1, 5), transform.rotation);

    }

    private IEnumerator SpawnDown()
    {
        yield return new WaitForSeconds(5f);
    }
}
