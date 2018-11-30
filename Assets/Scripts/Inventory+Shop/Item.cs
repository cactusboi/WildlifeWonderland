using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject {

    public string stringItemName;
    public Sprite Icon = null;
    public string ItemDescription;
    public int ItemPrice;

   void Start()
    {

    }
}
