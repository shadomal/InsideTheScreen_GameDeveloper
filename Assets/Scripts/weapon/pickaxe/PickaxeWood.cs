using UnityEngine;

public class PickaxeWood : MonoBehaviour, Pickaxe
{

    public int getID(){
        return 2;
    }

    public string getName()
    {
        return "";
    }

    public int getDamage()
    {
        return 0;
    }
    
    public GameObject getPickaxeSkin()
    {
        return null;
    }

}