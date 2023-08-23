using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform playerCharacter;

    private void LateUpdate()
    {
        Vector3 newPosition = playerCharacter.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
