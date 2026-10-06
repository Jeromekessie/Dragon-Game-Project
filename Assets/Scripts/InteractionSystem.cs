using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public interface IInteractable
{
    void Interact();
    void OnHover();
    void OnHoverExit();
}
public class InteractionSystem : MonoBehaviour
{


    public Color hoverColor = Color.green;
    public float distance = 3f;
    private IInteractable current;
    private Renderer r;
    private Color originalColor;

    private void Update()
    {
        RaycastHit hit;
        // Ray playerRay = new Ray(transform.position + _raycastOffset, transform.forward);
        if (Physics.Raycast(transform.position, transform.forward, out hit, distance) && hit.collider.TryGetComponent(out IInteractable i))
        {
            if (current != i)
            {
                Clear();
                current = i;
                current.OnHover();

                r = hit.collider.GetComponent<Renderer>();
                if (r)
                {
                    originalColor = r.material.color;
                    r.material.color = hoverColor;
                }
            }
        }
        else
        {
            Clear();
        }
        
    }
    public void Interact()
    {

        if (current != null)
        {
            current.Interact();
        }
    }
    void Clear()
    {
        if (current != null) current.OnHoverExit();
        if (r) r.material.color = originalColor;
        current = null;
        r = null;
    }

}
