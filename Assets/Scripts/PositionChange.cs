using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChange : MonoBehaviour
{



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != null)
        {
            var colTrans = collision.transform;
            var localPos = transform.InverseTransformPoint(collision.transform.position);
            Debug.Log(localPos);
        }        
    }

    IEnumerator wai()
    {
        yield return new WaitForSeconds(.3f);
    }

}
