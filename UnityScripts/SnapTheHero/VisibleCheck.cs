using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//karakter başka bir objenin arkasındaysa (bina, ağaç vb.) foto çekme fonksiyonu disable olmalı. Ama çalıştıramadım bütün renderları denedim yine de visible gösteriyor binanın arkasında.
public class VisibleCheck : MonoBehaviour
{
    public GameObject target;
    public Camera cam;

    private bool isVisible(Camera cam, GameObject target)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(cam);
        var point = target.transform.position;

        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
            {
                return false;
            }
        }
        return true;
    }

    private void Update() {
        var targetRender = target.GetComponent<Renderer>();

        if (isVisible(cam, target))
        {
            Debug.Log("visible");
        }else Debug.Log("not visible");
    }
}
