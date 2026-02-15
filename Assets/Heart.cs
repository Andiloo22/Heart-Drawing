using UnityEngine;

public class Heart : MonoBehaviour
{
    GameObject[] spheres;
    static int numSphere = 200; 
    float time = 0f;
    Vector3[] startPosition, endPosition;
    public float speedMult = 10f;
    public Material ball;
    
    void Start()
    {
        spheres = new GameObject[numSphere];
        startPosition = new Vector3[numSphere]; 
        endPosition = new Vector3[numSphere];
        
        for (int i =0; i < numSphere; i++){
            float r = 30f;
            startPosition[i] = new Vector3(
                -3 * (Mathf.Sqrt(2f) * Mathf.Pow(Mathf.Sin(i * 2 * Mathf.PI / numSphere), 3)),
                -3 * (-Mathf.Pow(Mathf.Cos(i * 2 * Mathf.PI / numSphere), 3) - Mathf.Pow(Mathf.Cos(i * 2 * Mathf.PI / numSphere), 2) + (2 * Mathf.Cos(i * 2 * Mathf.PI / numSphere))),
                -3f + i / Random.Range(2f, 4f));

            r = 6f;
            endPosition[i] = new Vector3(
                r * (Mathf.Sqrt(2f) * Mathf.Pow(Mathf.Sin(i * 2 * Mathf.PI / numSphere), 3)),
                r * (-Mathf.Pow(Mathf.Cos(i * 2 * Mathf.PI / numSphere), 3) - Mathf.Pow(Mathf.Cos(i * 2 * Mathf.PI / numSphere), 2) + (2 * Mathf.Cos(i * 2 * Mathf.PI / numSphere))),
                -3f + i / Random.Range(2f, 4f));
        }
        for (int i =0; i < numSphere; i++){
            spheres[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere); 

            spheres[i].transform.position = startPosition[i];

            Renderer sphereRenderer = spheres[i].GetComponent<Renderer>();
            float hue = (float)i / numSphere;
            Color color = Color.HSVToRGB(hue, 1f, 1f);

            sphereRenderer.material.color = color;
            sphereRenderer.material = ball;
        }
    }

    void Update()
    {
        time += Time.deltaTime * speedMult;
        for (int i =0; i < numSphere; i++){
            float lerpFraction = Mathf.Sin(time) * 0.5f + 0.5f;
            spheres[i].transform.position = Vector3.Lerp(startPosition[i], endPosition[i], lerpFraction);

            Renderer sphereRenderer = spheres[i].GetComponent<Renderer>();
            float hue = (float)i / numSphere;
            Color color = Color.HSVToRGB(Mathf.Abs(Mathf.Sin(time)), 1f, 1f);
            sphereRenderer.material.color = color;
        }
    }
}
