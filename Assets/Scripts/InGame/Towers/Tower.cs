using UnityEngine;
public class Tower
{
    #region Variables
    //id of the item for programmers and developers
    private int _id;
    //Desplay name and description for players
    private string _name;
    private string _description;    
    //Cost of Tower to build
    private int _value;

    //Basic Stats
    private int _damage;    
    //Display menu icon and 3d Mesh
    private Texture2D _iconName;
    private GameObject _meshName;
    //Type of tower
    private TowerTypes _type;

    //Upgrade values
    private int _upCostPercent;  // the percentage cost the tower increases each level
    private int _upDmgPercent;  // the percentage damage increases each upgrade level

    //fire rate of the Tower
    private float _fireRate;

    //make the variables accessible
    #endregion
    #region Properties
    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    
    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }
   
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    public int UpgradeCostPercent
    {
        get { return _upCostPercent; }
        set { _upCostPercent = value; }
    }

    public int UpgradeDmgPercent
    {
        get { return _upDmgPercent; }
        set { _upDmgPercent = value; }
    }

    public float FireRate
    {
        get { return _fireRate; }
        set { _fireRate = value; }
    }

    public Texture2D IconName
    {
        get { return _iconName; }
        set { _iconName = value; }
    }
    public GameObject MeshName
    {
        get { return _meshName; }
        set { _meshName = value; }
    }
    public TowerTypes ItemType
    {
        get { return _type; }
        set { _type = value; }
    }
    #endregion
}

// list of tower types
public enum TowerTypes
{
    Red,
    Blue,
    Green,
    Black
}
