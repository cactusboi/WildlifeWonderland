using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Animal", menuName = "Animal")]
public class Animals : ScriptableObject
{

    public Animals animal;

    public int ID;
    public string stringAnimalName;
    public Sprite Icon = null;
    public string AnimalSpecies;
    public string AnimalDescription;

}
