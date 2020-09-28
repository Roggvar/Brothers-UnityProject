using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    public Interactable focus;
    public LayerMask movementMask; // Mask que o player ira interagir
    public static NavMeshAgent agent; // aloca navmesh

    Camera cam;
    PlayerMotor motor;
    

    void Start()
    {

        cam = Camera.main; // cam
        motor = GetComponent<PlayerMotor>(); // motor
        agent = GetComponent<NavMeshAgent>(); // agent

    }

    
    void Update()
    {

        //Botao esquerdo do mouse
        if(Input.GetMouseButton(0))
        {

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //Move o player para o ponto do click
            if(Physics.Raycast(ray, out hit, 100, movementMask))
            {

                motor.MoveToPoint(hit.point);

                RemoveFocus();

            }

        }

        //Botao direito do mouse
        if (Input.GetMouseButtonDown(1))
        {

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {

                Interactable interactable = hit.collider.GetComponent<Interactable>(); //Faz todo o foco no objeto

                if (interactable != null)
                {

                    SetFocus(interactable);

                }

            }

        }

    }

    // Gerencia Foco no objeto
    public void SetFocus(Interactable newFocus)
    {

        if(newFocus != focus)
        {

            if(focus != null)
            {

                focus.OnDefocused();

            }

            focus = newFocus;
            motor.FollowTarget(newFocus);

        }
        
        newFocus.OnFocused(transform);
        
    }

    // Gerencia o Remove o foco no objeto
    void RemoveFocus()
    {

        if (focus != null)
        {

            focus.OnDefocused();

        }

        focus = null;
        motor.StopFollowingTarget();

    }

}
