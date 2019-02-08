using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject {

    public Item item;

    public string stringItemName;
    public Sprite Icon = null;
    public string ItemDescription;
    public int ItemPrice;

    
}
