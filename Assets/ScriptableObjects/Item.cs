using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public new string name;
    public int ID;

    public Sprite icon;
    public float amount;

    public GameObject gameObject;

}
