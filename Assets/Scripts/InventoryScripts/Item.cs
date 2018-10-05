using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    public string stringItemName;
    public Sprite Icon = null;
    public string ItemDescription;
    //public int ItemAmount;


}
