using UnityEngine;

public class SpawnInARow : MonoBehaviour
{
    public Vector3 firstPosition;
    public float gap = 0.625f;
    public GameObject objectToCreate;
    void Start()
    {
        Vector3 position = firstPosition;
        for (int i = 0; i < 500; i++)
        {
            Instantiate(objectToCreate, position, Quaternion.identity);
            position.x = 0; // or add += gap + 0.005f;
            position.y += gap;
            position.z = 5;
        }
    }
}