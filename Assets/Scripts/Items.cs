using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Items")]
public class Items : ScriptableObject
{

    public string itemName;

    public int itemPrice;

    public Image itemImage;

    public string itemText;

}
