using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour
{
    public float distance = 25f;

    //public Tower[] towers = new Tower[] { TowerData.CreateTower(0), TowerData.CreateTower(1), TowerData.CreateTower(2), TowerData.CreateTower(3) };

    //Used to instantiate an object at mouse position
    //public Transform tempObject;

    

    public GameObject toggleGroup;
    private Toggle[] towerSelections;
    private Tower selectedTower = null;


    private void Start()
    {
        towerSelections = toggleGroup.GetComponentsInChildren<Toggle>();
    }
    
    /*
     * Function to expand on automation by creating buttons dynamically
     * If I forget to sort this out see BaseTower.cs for array usage
    void MakeTowerSelectorButtons()
    {
        for (int i = 0; i < towers.Length - 1; i++)
        {

        }
    }*/


    void Update()
    {
        // if player has selected a tower type
        if (selectedTower != null)
        {
            // if mouse button clicked and player has the gold for selected tower
            if (Input.GetMouseButtonUp(0) && PlayerHandler.playerGold >= selectedTower.Value)
            {
                // place a tower at mouse point
                PlaceTower(selectedTower);
            }
        }        
    }

    
    public void SetSelectedTower()
    {
        for (int i = 0; i < towerSelections.Length; i++)
        {
            if (towerSelections[i].isOn)
            {
                selectedTower = TowerData.CreateTower(i);
            }
        }
    }    


    //Function to place a Tower at the place the mouse hits using a ray cast and checking to make sure the thing it hits is a placeble area
    void PlaceTower(Tower newTower)
    {
        
        Debug.Log("Left mouse clicked");
        // raycast to hold click point
        RaycastHit click;
        // creat a ray to mouse point
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                
        ///initiate and get resuts or ray
        if (Physics.Raycast(ray, out click))
        {
            //if the click was on the maze
            if (click.transform.parent.name == "Maze_1")
            {
                // move the position up
                click.point.Set(click.point.x, click.point.y + distance, click.point.z);
                
                // Create tower at click point
                GameObject tower = Instantiate(newTower.MeshName, click.point, Quaternion.identity);
                // get the baseTower script from the new tower
                BaseTower baseTower = tower.GetComponent<BaseTower>();

                // set fire rate depending on selected tower
                baseTower.fireRate = selectedTower.FireRate;
                // set damage of selected tower
                baseTower.damage = selectedTower.Damage;

                //reduce player's gold by the cost of the tower
                PlayerHandler.playerGold -= selectedTower.Value;
            }
        }
        
    }
}
