using UnityEngine;
using UnityEngine.UI;

public class AnimalSlot : MonoBehaviour
{

    public int index = 0;

    public Animals animalInstance = null;
   
    public int ID;

    public Text stringAnimalName;
    public Image Icon;
    public Text AnimalSpecies;
    public Text AnimalDescription;

    public void SetAnimal(Animals instance)
    {
        this.animalInstance = instance;


        Icon.sprite = instance.Icon;
        Icon.enabled = true;
        stringAnimalName.enabled = true;
        AnimalDescription.enabled = true;
        AnimalSpecies.enabled = true;

        stringAnimalName.text = instance.stringAnimalName;
        AnimalDescription.text = instance.AnimalDescription;
        AnimalSpecies.text = instance.AnimalSpecies;

    }

    public void RemoveAnimal()
    {
        this.animalInstance = null;

        Icon.sprite = null;
        Icon.enabled = false;
        stringAnimalName.enabled = false;
        AnimalDescription.enabled = false;
        AnimalSpecies.enabled = false;
    }
}