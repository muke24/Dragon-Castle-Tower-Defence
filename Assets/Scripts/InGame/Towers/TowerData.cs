
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
        float fireRate = 0;
        float range = 10f;
        TowerTypes type = TowerTypes.Red;

        switch(itemId)
        {
            case 0:
                name = "Red Dragon";
                description = "A Red Dragon that Breaths Fire";                
                value = 25;
                damage = 2;                
                iconName = "Towers/RedDragonIcon";
                meshName = "Towers/RedDragon";                
                type = TowerTypes.Red;
                upgradeDmgPercent = 1;
                upgradeCostPercent = 1;
                fireRate = 4;
                range = 15f;
                break;
            case 1:
                name = "Blue Dragon";
                description = "A blue Frost Dragon that Breaths Ice";
                value = 40;
                damage = 5;
                iconName = "Towers/BlueDragonIcon";
                meshName = "Towers/BlueDragon";
                type = TowerTypes.Blue;
                upgradeDmgPercent = 1;
                upgradeCostPercent = 1;
                fireRate = 2;
                range = 12f;
                break;
            case 2:
                name = "Green Dragon";
                description = "A Green Dragon that Breaths Acid";
                value = 70;
                damage = 15;
                iconName = "Towers/GreenDragonIcon";
                meshName = "Towers/GreenDragon";
                upgradeDmgPercent = 1;
                upgradeCostPercent = 1;
                fireRate = 0.9f;
                range = 10f;
                break;
            case 3:
                name = "Black Dragon";
                description = "A Black Dragon that Shoots Lasers!!!";
                value = 150;
                damage = 30;
                iconName = "Towers/BlackDragonIcon";
                meshName = "Towers/BlackDragon";
                upgradeDmgPercent = 1;
                upgradeCostPercent = 1;
                fireRate = 0.7f;
                range = 20f;
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
            UpgradeDmgPercent = upgradeDmgPercent,
            FireRate = fireRate,
            Range = range
        };

        return temp;
    }


}
