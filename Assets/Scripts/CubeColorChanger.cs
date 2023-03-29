using UnityEngine;

public class CubeColorChanger : MonoBehaviour
{
    public float colorChangeSpeed = 0.5f; // Speed of color change
    private Renderer cubeRenderer; // Renderer component of the Cube

    private Color targetColor; // Target color to change to
    private Color currentColor; // Current color of the Cube

    void Start()
    {
        // Get the Renderer component of the Cube
        cubeRenderer = GetComponent<Renderer>();

        // Set the target color to a random color
        targetColor = Random.ColorHSV();

        // Set the current color to the initial color of the Cube
        currentColor = cubeRenderer.material.color;
    }

    void Update()
    {
        // Lerp the current color towards the target color
        currentColor = Color.Lerp(currentColor, targetColor, colorChangeSpeed * Time.deltaTime);

        // Update the color of the Cube
        cubeRenderer.material.color = currentColor;

        // If the current color is close enough to the target color, choose a new target color
        if (ColorDistance(currentColor, targetColor) < 0.05f)
        {
            targetColor = Random.ColorHSV();
        }
    }

    // Helper method to calculate the distance between two colors
    private float ColorDistance(Color a, Color b)
    {
        return Mathf.Sqrt(Mathf.Pow(a.r - b.r, 2) + Mathf.Pow(a.g - b.g, 2) + Mathf.Pow(a.b - b.b, 2));
    }
}