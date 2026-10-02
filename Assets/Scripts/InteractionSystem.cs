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
    /*
    [SerializeField]
    private float _castDistance = 5f;
    [SerializeField]
    private Vector3 _raycastOffset = new Vector3(0, 1f, 0);
    */

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

            // if press e {current.Interact();}
        }
        else
        {
            Clear();
        }
    }

    void Clear()
    {
        if (current != null) current.OnHover();
        if (r) r.material.color = originalColor;
        current = null;
        r = null;
    }
    /*
    private bool DoInteractionTest(out IInteractable interactable)
    {
        interactable = null;
        Ray ray = new Ray(transform.position + _raycastOffset, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _castDistance))
        {
            interactable = hitInfo.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                return true;
            }
        }
        return false;
    }
    */
}
