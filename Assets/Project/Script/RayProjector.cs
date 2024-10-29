using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayProjector : MonoBehaviour
{
    private new Camera camera;
    [SerializeField] private LayerMask layerMask; // Target layer needs to be selected 

    void Start()
    {
        camera = Camera.main;
    }

    private RaycastHit hit;
    private float rayDistance = 2f;
    private Vector3 mousePos;
    private Ray ray;

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 1f;
        mousePos = camera.ScreenToWorldPoint(mousePos);

        ray = new Ray(transform.position, mousePos - transform.position);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance);

        if (Physics.Raycast(ray, out hit, rayDistance, layerMask))
        {

            if(Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.tag != null){

                // Debug.Log($"Mouse 0 Click Hits Object : {hit.collider.name} || Texture Coordinate : {hit.textureCoord}");

                // Sending texture coordinate to Target to calculate score
                Target targetHit = hit.collider.GetComponent<Target>();
                targetHit.CalculateScore(hit.textureCoord);
            }

        }

    }
}
