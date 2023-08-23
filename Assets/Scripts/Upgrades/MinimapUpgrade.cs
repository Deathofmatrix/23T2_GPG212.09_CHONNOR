using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject minimap;

    private void Start()
    {
        minimap.SetActive(true);
    }
}
