using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    float distance = 10f;

    Vector3 mousePosition, targetPosition;

    //Used to instantiate an object at mouse position
    public Transform tempObject;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            // place a tower at mouse point
            PlaceTower(UnityEngine.Random.Range(0, 3));
        }
    }

    

    void PlaceTower(int typeId)
    {
        
        // get the current mouse position
        mousePosition = Input.mousePosition;

        // convert the mousePosition to in game 'world' position
        targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, distance));

        //create a new tower of typeId
        Tower newTower = TowerData.CreateTower(typeId);

        //Set the position of targetObject
        tempObject.transform.position = targetPosition;

        //Place the tower
        Instantiate(newTower.MeshName, tempObject.position, tempObject.transform.rotation);
        

    }
}
