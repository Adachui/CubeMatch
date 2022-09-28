using UnityEngine;


public class CubeController : MonoBehaviour
{
    public float smoothSpeed = 2;
    private Vector3 PressVector;
    private Vector3 updateVector;
    private Vector3 lastVector;
    Camera mCamr;

    private void Start()
    {
        mCamr = Camera.main;
    }


    void Update()
    {
        var mosuePos = Input.mousePosition;
        Vector3 p = mCamr.WorldToScreenPoint(transform.position);
        mosuePos.z = p.z;
        mosuePos = mCamr.ScreenToWorldPoint(mosuePos);
        mosuePos = transform.InverseTransformDirection(mosuePos);

        Debug.DrawRay(transform.position, mosuePos.normalized, Color.red);
    }


}
