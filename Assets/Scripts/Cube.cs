using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float orbitSpeed = 1.5f; // Speed of the Cube's orbit
    public Vector3 orbitCenter; // Center point of the Cube's orbit
    public float scaleSpeed = 0.5f; // Speed of the Cube's scaling
    public float maxScale = 6f; // Maximum scale of the Cube
    public float minScale = 1f; // Minimum scale of the Cube
    public float rotationSpeed = 50f; // Speed of the Cube's rotation
    public float minOpacity = 0.3f; // Minimum opacity of the Cube
    private bool isGrowing = true; // Is the Cube currently growing or shrinking?
    private Color originalColor; // Original color of the Cube

    void Start()
    {
        // Set the initial position and scale of the Cube
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one;

        // Save the original color of the Cube
        originalColor = Renderer.material.color;
    }

    void Update()
    {
        // Rotate the Cube around its own axis at the specified rotation speed
        transform.Rotate(rotationSpeed * Time.deltaTime, 0f, 0f);

        // Calculate the position of the Cube around the orbit
        Vector3 orbitPosition = new Vector3(Mathf.Sin(Time.time * orbitSpeed), 0f, Mathf.Cos(Time.time * orbitSpeed)) * 3f;

        // Set the position of the Cube to the orbit position relative to the orbit center
        transform.position = orbitCenter + orbitPosition;

        // Determine whether the Cube is growing or shrinking
        if (isGrowing)
        {
            // If the Cube is growing, scale it towards the maximum scale
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * maxScale, scaleSpeed * Time.deltaTime);

            // If the Cube has reached the maximum scale, start shrinking
            if (transform.localScale.magnitude >= maxScale - 0.1f)
            {
                isGrowing = false;
            }
        }
        else
        {
            // If the Cube is shrinking, scale it towards the minimum scale
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * -minScale, scaleSpeed * Time.deltaTime);

            // If the Cube is shrinking, check if it has reached the minimum scale
            if (transform.localScale.magnitude <= minScale + 0.1f)
            {
                // If the Cube has reached the minimum scale, start growing again
                isGrowing = true;
            }
  
        }

        // Calculate the opacity of the Cube based on its current scale
        float opacity = Mathf.Lerp(1f, minOpacity, (transform.localScale.magnitude - minScale) / (maxScale - minScale));

     
    }

}
