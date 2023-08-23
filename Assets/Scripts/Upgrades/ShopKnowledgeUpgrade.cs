using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKnowledgeUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject[] favItemCubes;

    void Start()
    {
        foreach (GameObject fav in favItemCubes)
        {
            fav.SetActive(true);
        }
        
        //favItemCubes[0].SetActive(true);
        //favItemCubes[1].SetActive(true);
        //favItemCubes[2].SetActive(true);
    }

}
