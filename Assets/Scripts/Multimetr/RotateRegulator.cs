using UnityEngine;

public class RotateRegulator : MonoBehaviour
{
    [SerializeField] private GameObject[] regulators;
    private int[] angles;

    void Start()
    {
        angles = new int[] { 90, 135, 225, 315, 45};
    }

    public void RotateRegulators(int IDstate)
    {
        foreach (var part in regulators)
        {
            Vector3 rotate = transform.eulerAngles;
            rotate.z = angles[IDstate];
            part.transform.rotation = Quaternion.Euler(rotate);
        }
    }
}
