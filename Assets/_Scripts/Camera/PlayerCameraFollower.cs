using UnityEngine;

public class PlayerCameraFollower : MonoBehaviour
{
    [SerializeField] private GameObject objToFollow;
    [SerializeField] private float _zOffset;
    [SerializeField] private float _yOffset;
    

    private void Start()
    {
        /*_zOffset = objToFollow.transform.position.z - 
            transform.position.z;
        _yOffset = objToFollow.transform.position.y -
                   transform.position.y;*/
        
        print(_zOffset);
        print(_yOffset);
    }

    private void Update()
    {
        var position = objToFollow.transform.position;
        var newPos = new Vector3(position.x, position.y + _yOffset, 
            position.z - _zOffset);
        
        transform.position = newPos;
    }
}
