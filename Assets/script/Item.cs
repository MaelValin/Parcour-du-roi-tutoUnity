using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string name;
    public string description;
    public Sprite img;
    public int hpGiven;
    public float speedGiven;
    public float speedDuration;
    public int price;
    public int Jumpforce;
    public float Gravity;
    public int flotduration;
}
