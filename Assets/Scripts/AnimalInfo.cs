using UnityEngine;


[System.Serializable]
public class AnimalInfo
{

    public int id;
    public string Name;
    public string Species;
    public string Description;

    public static AnimalInfo CreateFromJSON(string AnimalList)
    {
        return JsonUtility.FromJson<AnimalInfo>(AnimalList);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}