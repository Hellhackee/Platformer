using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundChecker : MonoBehaviour
{
    public UnityAction GroundIsNotFound;

    private void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 2);

        if (ray.collider == null)
        {
            transform.localPosition = new Vector3(-transform.localPosition.x, transform.localPosition.y);
            GroundIsNotFound?.Invoke();
        }
    }
}
