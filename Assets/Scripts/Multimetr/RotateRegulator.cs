using System;
using UnityEngine;

public class RotateRegulator : MonoBehaviour
{
    [SerializeField] private GameObject[] regulators;
    private int[] angles;

    void Start()
    {
        angles = new int[] { 90, 135, 225, 315, 45};
        Debug.Log($"Local - {regulators[0].transform.localRotation.x}");
        Debug.Log($"Global - {regulators[0].transform.rotation.x}");
        Debug.Log($"Euler - {regulators[0].transform.localEulerAngles.x}");

    }

    public void RotateRegulators(int IDstate)
    {

        foreach (var part in regulators)
        {
            //Debug.Log($"rotate");

            ////Vector3 newRotate = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, angles[IDstate]);

            //var old = regulators[0].transform.rotation.x;
            //Vector3 newRotate = new Vector3(0, 0, angles[IDstate]);
            //var newf = regulators[0].transform.rotation.x;

            //Debug.Log($"new - old= {newf - old}");
            ////Debug.Log($"Euler - {regulators[0].transform.localEulerAngles.x}");



            ////part.transform.localRotation = Quaternion.Euler(newRotate);

            //part.transform.eulerAngles = newRotate;
        }
    }
}
