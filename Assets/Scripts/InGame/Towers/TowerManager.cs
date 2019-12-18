using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour
{

    public GameObject toggleGroup;
    private Toggle[] towerSelections;
    private Tower selectedTower = null;


    private void Start()
    {
        //get tower select buttons within toggle group
        towerSelections = toggleGroup.GetComponentsInChildren<Toggle>();
    }
    
    

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

    // select tower
    public void SetSelectedTower()
    {
        // iterat through the tower selections array
        for (int i = 0; i < towerSelections.Length; i++)
        {
            // if toggle is selected
            if (towerSelections[i].isOn)
            {
                //set selected tower
                selectedTower = TowerData.CreateTower(i);
            }
        }
    }    


    //Function to place a Tower at the place the mouse hits using a ray cast and checking to make sure the thing it hits is a placeble area
    void PlaceTower(Tower newTower)
    {
        
        //Debug.Log("Left mouse clicked");

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
                //click.point.Set(click.point.x, click.point.y, click.point.z);
                
                // Create tower at click point
                GameObject tower = Instantiate(newTower.MeshName, click.point, Quaternion.identity);
                
                // get the baseTower script from the new tower to set its attributes
                BaseTower baseTower = tower.GetComponent<BaseTower>();

                // set fire rate depending on selected tower
                baseTower.fireRate = selectedTower.FireRate;
                
                // set damage of selected tower
                baseTower.damage = selectedTower.Damage;

                //set the fireing range of the tower
                baseTower.range = selectedTower.Range;

                //reduce player's gold by the cost of the tower
                PlayerHandler.playerGold -= selectedTower.Value;
            }
        }
        
    }
}
