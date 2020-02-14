using UnityEngine;

public class PickaxeIron : MonoBehaviour, Pickaxe
{

    public int getID(){
        return 1;
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