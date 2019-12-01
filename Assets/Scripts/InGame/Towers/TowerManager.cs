using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public float distance = 25f;

    Vector3 mousePosition, targetPosition;

    //Used to instantiate an object at mouse position
    public Transform tempObject;
    private GameObject linehandler;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            // place a tower at mouse point
            PlaceTower2(UnityEngine.Random.Range(0, 4));
            //PlaceTower(UnityEngine.Random.Range(0, 3));
            //PlaceTower1(UnityEngine.Random.Range(0, 3));
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


    void PlaceTower1(int typeId)
    {
        //create a new tower of typeId
        Tower newTower = TowerData.CreateTower(typeId);
        Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
        linehandler = Instantiate(newTower.MeshName, rayCast.GetPoint(10), Quaternion.identity) as GameObject;
        
    }

    void PlaceTower2(int typeId)
    {
        
        Debug.Log("Left mouse clicked");
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Tower newTower = TowerData.CreateTower(typeId);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.parent.name == "Maze_1")
            {
                hit.point.Set(hit.point.x, hit.point.y + 10f, hit.point.z);

                Instantiate(newTower.MeshName, hit.point, Quaternion.identity);

                print("My object is clicked by mouse");
            }
        }
        
    }
}
