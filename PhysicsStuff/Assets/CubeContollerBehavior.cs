using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeContollerBehavior : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    Ray ray;
    RaycastHit hit;
    private Vector3 velocity;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(ray, out hit)) {
            Transform objectHit = hit.transform;
            
            text.text = hit.collider.gameObject.name;
            // Do something with the object that was hit by the raycast.
        }
            
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       
       
        velocity = new Vector3(ray.direction.x, ray.direction.y,0);
        velocity.z = 0;
        velocity *= speed;

        velocity = transform.TransformDirection(velocity);
        transform.localPosition += velocity * Time.fixedDeltaTime;

    }
}
