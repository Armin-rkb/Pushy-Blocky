using UnityEngine;
using ObstacleTypes;

public class ObstacleBase : MonoBehaviour
{
    [SerializeField]
    private ObstacleType obstacleType;

    [SerializeField]
    private Rigidbody rb;

    private Renderer objRenderer;
    private MaterialPropertyBlock propertBlock;

    private void Awake()
    {
        propertBlock = new MaterialPropertyBlock();
        objRenderer = GetComponent<Renderer>();

        SetObstacleType(obstacleType);
    }

    public void SetObstacleType(ObstacleType newObstacleType)
    {
        obstacleType = newObstacleType;
        SetCurrentObstacleTypeColor();
    }

    private void SetCurrentObstacleTypeColor()
    {
        switch (obstacleType)
        {
            case ObstacleType.Neutral:
                ChangeColor(Color.white);
                break;
            case ObstacleType.Positive:
                ChangeColor(Color.blue);
                break;
            case ObstacleType.Hazardous:
                ChangeColor(Color.red);
                break;
            case ObstacleType.Fixed:
                ChangeColor(Color.grey);
                break;
            default:
                ChangeColor(Color.cyan);
                break;
        }
    }

    private void ChangeColor(Color newColor)
    {
        // Get the current value of the material properties in the renderer.
        objRenderer.GetPropertyBlock(propertBlock);
        // Assign the new color.
        propertBlock.SetColor("_Color", newColor);
        // Apply the edited values to the renderer.
        objRenderer.SetPropertyBlock(propertBlock);
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (!coll.gameObject.CompareTag("Player")) return;

        switch (obstacleType)
        {
            case ObstacleType.Neutral:
                Debug.Log("Nothing!");
                break;
            case ObstacleType.Positive:
                Debug.Log("Push!");
                break;
            case ObstacleType.Hazardous:
                Debug.LogError("Player Dead!");
                break;
            case ObstacleType.Fixed:
                Debug.LogWarning("Immovable!");
                break;
            default:
                ChangeColor(Color.cyan);
                break;
        }
    }
}
