using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*public class ItensAndWeapons : MonoBehaviour
{
    private Dictionary<int, Sword> swords;
    private Dictionary<int, Pickaxe> pickaxes;

    private Itens[] itemList;
    // Start is called before the first frame update
    void Start()
    {
        // load swords
        List<Sword> swordConvert = new List<Sword>();
        swordConvert.Add(new SwordIron());
        

        this.swords = new Dictionary<int, Sword>();
        foreach (Sword swrd in swordConvert){
            swords.Add(swrd.getID(), swrd);
        }

        // load pickaxes
        List<Pickaxe> pickaxeConvert = new List<Pickaxe>();
        pickaxeConvert.Add(new PickaxeIron());
        pickaxeConvert.Add(new PickaxeWood());

        this.pickaxes = new Dictionary<int, Pickaxe>();
        foreach (Pickaxe pik in pickaxeConvert){
            pickaxes.Add(pik.getID, pik);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}*/

[System.Serializable]
public class Itens
{
    private string description;
    private GameObject ItemSkin;

    public string getDescription()
    {
        return description;
    }
    public void setDescription(string itemDescription)
    {
        this.description = itemDescription;
    }
    public GameObject getItemSkin()
    {
        return ItemSkin;
    }

}
