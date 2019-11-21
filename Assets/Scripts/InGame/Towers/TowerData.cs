
using UnityEngine;

public static class TowerData
{
    public static Tower CreateTower(int itemId)
    { 
        string name = "";
        string description = "";
        int value = 0;
        int damage = 0;
        string iconName = "";
        string meshName = "";
        int upgradeDmgPercent = 0;
        int upgradeCostPercent = 0;
        TowerTypes type = TowerTypes.Red;

        switch(itemId)
        {
            case 0:
                name = "Red Dragon";
                description = "A Red Dragon that Breaths Fire";                
                value = 50;
                damage = 1;                
                iconName = "Towers/RedDragonIcon";
                meshName = "Towers/RedDragon";                
                type = TowerTypes.Red;
                upgradeDmgPercent = 1;
                upgradeCostPercent = 1;
                break;
            case 1:
                name = "Blue Dragon";
                description = "A blue Frost Dragon that Breaths Ice";
                value = 60;
                damage = 0;
                iconName = "Towers/BlueDragonIcon";
                meshName = "Towers/BlueDragon";
                type = TowerTypes.Blue;
                upgradeDmgPercent = 1;
                upgradeCostPercent = 1;
                break;
            case 2:
                name = "Green Dragon";
                description = "A Green Dragon that Breaths Poison";
                value = 70;
                damage = 0;
                iconName = "Towers/GreenDragonIcon";
                meshName = "Towers/GreenDragon";
                upgradeDmgPercent = 1;
                upgradeCostPercent = 1;
                break;
            case 3:
                name = "Black Dragon";
                description = "A Black Dragon that Shoots Lasers!!!";
                value = 100;
                damage = 0;
                iconName = "Towers/BlackDragonIcon";
                meshName = "Towers/BlackDragon";
                upgradeDmgPercent = 1;
                upgradeCostPercent = 1;
                break;
        }

        Tower temp = new Tower
        {
            ID = itemId,
            Name = name,
            Description = description,
            Value = value,
            Damage = damage,
            IconName = Resources.Load("Icons/" + iconName) as Texture2D,
            MeshName = Resources.Load("Prefabs/" + meshName) as GameObject,
            ItemType = type,
            UpgradeCostPercent = upgradeCostPercent,
            UpgradeDmgPercent = upgradeDmgPercent

        };

        return temp;
    }


}
