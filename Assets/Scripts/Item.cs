using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item")]
public class Item : ScriptableObject
{
    public enum ItemEnum
    {
        Undeclared,
        Carrot,
        Apple,
        Pear
    }

    public ItemEnum itemEnum;
    public Sprite itemImage;
    public int itemPrice;
    public string itemText;

}
