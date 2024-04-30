using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class MouseManager : MonoBehaviour
{
    public Texture2D centerIcon;
    public Texture2D outerIcon;
    public bool _isClicked;
    private GameObject _zone = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_isClicked);

        if (_isClicked && _zone!=null)
        {
            Debug.Log($"je dois deplacer {_zone.name}");
        }
    }

    public void PointerMove( InputAction.CallbackContext context )
    {
        //Position en pixel du pointer dans l'ecran
        Vector2 pointerPosition = context.ReadValue<Vector2>();

        _ray = Camera.main.ScreenPointToRay( pointerPosition );

        RaycastHit2D hit = Physics2D.GetRayIntersection(_ray);

        //converti un point de l'ecran dans le world
        //!\ Attention au Z avec cette méthode
        //Camera.main.ScreenToWorldPoint()

        //si j'ai touché quelques chose
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("CenterZone"))
                {
                // j'ai touché la fleche
                Debug.Log("dedans");
                Cursor.SetCursor(centerIcon, new Vector2(256, 256), CursorMode.Auto);
                _zone = hit.collider.transform.parent.gameObject;
                }
                else if (hit.collider.CompareTag("OuterZone"))
                {
                    // j'ai touché le cercle
                    Debug.Log("dehors");
                Cursor.SetCursor(outerIcon, new Vector2(256, 256), CursorMode.Auto);
            }            
        }
        else
        {
           //notre pointer survole rien, on remet le curseur a sa forme par defaut
           Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            _zone = null;
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
    private Ray _ray;

    public void onClick()
    {

    }
   
}
