using UnityEngine;

public class RegulatorColor : MonoBehaviour
{
    private Outline outline;

    private void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }
    private void OnMouseEnter()
    {
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}
