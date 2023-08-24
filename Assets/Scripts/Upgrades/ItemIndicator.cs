using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIndicator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }
    private void OnEnable()
    {
        ItemLocatorUpgrade.OnItemIndicatorUpgrade += ShowItemIndicator;
    }
    private void OnDisable()
    {
        ItemLocatorUpgrade.OnItemIndicatorUpgrade -= ShowItemIndicator;
    }

    private void ShowItemIndicator()
    {
        spriteRenderer.enabled = true;
    }
}
