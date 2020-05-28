using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
 
    // the camera distance (z position)
    public float distance = -10f;
 
    // the height the camera should be above the target (AKA player)
    public float height = 0f;
 
    // damping is the amount of time the camera should take to go to the target
    public float damping = 5f;
 
    // map maximum X and Y coordinates. (the final boundaries of your map/level)
    public float mapX = 15f;
    public float mapY = 25f;
 
    // just private var for the map boundaries
    private float _minX;
    private float _maxX;
    private float _minY;
    private float _maxY;
  
    void Start () {
        // the map MinX and MinY are the position that the camera STARTS
        var tp = transform.position;
        _minX = tp.x;
        _minY = tp.y;
        // the desired max boundaries
        _maxX = mapX;
        _maxY = mapY;
    }
 
    void FixedUpdate () {
 
        // get the position of the target (AKA player)
        var wantedPosition = target.TransformPoint(0, height, distance);
 
        // check if it's inside the boundaries on the X position
        wantedPosition.x = (wantedPosition.x < _minX) ? _minX : wantedPosition.x;
        wantedPosition.x = (wantedPosition.x > _maxX) ? _maxX : wantedPosition.x;
 
        // check if it's inside the boundaries on the Y position
        wantedPosition.y = (wantedPosition.y < _minY) ? _minY : wantedPosition.y;
        wantedPosition.y = (wantedPosition.y > _maxY) ? _maxY : wantedPosition.y;

        // set the camera to go to the wanted position in a certain amount of time
        transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);
    }
}
