using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject target = null;

	void Update ()
    {
        if(target != null)
        {
            Vector3 targetPosition = target.transform.position;
            targetPosition.z = -10;

            var scrollWheelAmount = Input.GetAxis("Mouse ScrollWheel");
            Camera cam = gameObject.GetComponent<Camera>();
            if (scrollWheelAmount > 0)
            {
                if (cam.orthographicSize > 3.0f)
                {
                    cam.orthographicSize -= 1.0f;
                }
            }
            else if (scrollWheelAmount < 0)
            {
                cam.orthographicSize += 1.0f;
            }
            
            transform.position = targetPosition;
        }
        
	}

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }
}
