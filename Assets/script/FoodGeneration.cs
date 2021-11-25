using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneration : MonoBehaviour
{
    public GameObject FoodPrefab;

    public float Xsize = -15f;
    public float Xsize2 = 33f;
    public float Zsize = -15f;
    public float Zsize2 = 33f;

    public Vector3 curPos;

    GameObject curFood;


    void AddNewFood()
    {
       
        RandomPos();
        curFood = GameObject.Instantiate(FoodPrefab, curPos, Quaternion.identity);

    }

    void RandomPos ()
    {
        
        curPos = new Vector3(Random.Range(Xsize, Xsize2), 0.2f, Random.Range(Zsize, Zsize2));
    }

    private void Update()
    {
        if (!curFood)
        {
            AddNewFood();
        }
        else
        {
            return;
        }
    }
}
