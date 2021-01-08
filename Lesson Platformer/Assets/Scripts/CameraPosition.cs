using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _cameraFollowSpeed;

    private void Update()
    {
        Vector3 target = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
        Vector3 currentPosition = Vector3.Lerp(transform.position, target, _cameraFollowSpeed * Time.deltaTime);
        transform.position = currentPosition;    
    }
}
