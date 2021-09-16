using UnityEngine;

namespace Gann4Games.Thirdym.Utility
{
    public class LaserGuide : MonoBehaviour {

        LineRenderer _lineRenderer;
        Vector3 _linePos;

        public Transform hitPoint;
        public float rayLenght;

        void Start() {
            _lineRenderer = GetComponent<LineRenderer>();
        }
        void Update()
        {
            RaycastHit hit;
            rayLenght = Vector3.Distance(transform.position, hitPoint.position);
            _linePos.z = rayLenght;
            if(_lineRenderer != null)
                _lineRenderer.SetPosition(1, _linePos);
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                hitPoint.position = hit.point;
                hitPoint.gameObject.SetActive(true);
            }
            else 
            {
                hitPoint.gameObject.SetActive(false);
            }
        }
    }
}
