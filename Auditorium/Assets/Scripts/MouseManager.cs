using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class MouseManager : MonoBehaviour
{
    public Texture2D centerIcon;
    public Texture2D outerIcon;
    public bool _isClicked;
    private GameObject _zone = null;
    private Vector3 _worldPoint;
    private Ray _ray;
    private CircleShape _zoneToResize = null;
    private bool isInteracting = false;
    private AreaEffector2D _zoneEffector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_isClicked);

        if (_isClicked && _zone!=null)
        {
            //Debug.Log($"je dois deplacer {_zone.name}");
            _zone.transform.position = _worldPoint;
            isInteracting = true;
        }
        if(_isClicked && _zoneToResize!=null)
        {
            //Calcul de la distance entre le pointer et le centre de l'objet avec Vector2.Distance
            float radius =Vector2.Distance(_zoneToResize.transform.position, _worldPoint);
            _zoneToResize.Radius = Mathf.Clamp(radius, 1f, 10f);
            _zoneEffector.forceMagnitude = _zoneToResize.Radius * 3;
            isInteracting = true;

        }
        if (!_isClicked)
        {
            _zone = null;
            _zoneToResize=null;
            isInteracting = false;
        }
    }

    public void PointerMove( InputAction.CallbackContext context )
    {
        //Position en pixel du pointer dans l'ecran
        Vector2 pointerPosition = context.ReadValue<Vector2>();
        //Debug.Log(pointerPosition);

        _ray = Camera.main.ScreenPointToRay( pointerPosition );

        RaycastHit2D hit = Physics2D.GetRayIntersection(_ray);
        _worldPoint = Camera.main.ScreenToWorldPoint(pointerPosition);
        _worldPoint.z = 0;

        //si j'ai touché quelques chose
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("CenterZone"))
                {
                // j'ai touché la fleche
                //Debug.Log("dedans");
                Cursor.SetCursor(centerIcon, new Vector2(64, 64), CursorMode.Auto);
                _zone = hit.collider.transform.parent.gameObject;

            }
                else if (hit.collider.CompareTag("OuterZone"))
                {
                    // j'ai touché le cercle
                    //Debug.Log("dehors");
                Cursor.SetCursor(outerIcon, new Vector2(64, 64), CursorMode.Auto);
                _zoneToResize = hit.collider.GetComponent<CircleShape>();
                _zoneEffector = hit.collider.GetComponent<AreaEffector2D>();

            }            
        }
        else
        {
           //notre pointer survole rien, on remet le curseur a sa forme par defaut
           Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    public void PointerPress(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                //Action qui débute
                break;
            case InputActionPhase.Performed:
                //Action qui est effectuée
                //Le click est actif
                _isClicked = true;
                break;
            case InputActionPhase.Canceled:
                //Action qui est annulée
                //Le click est inactif
                _isClicked = false;
                break;
            default:
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay( _ray.origin, _ray.direction * 1000f);

    }
    

    public void onClick()
    {

    }
   
}
