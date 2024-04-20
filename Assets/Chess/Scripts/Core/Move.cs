using Chess.Scripts.Core;
using UnityEngine;
using UnityEngine.InputSystem;
public class Move : MonoBehaviour
{
    private Camera _mainCamera;
    private ChessPlayerPlacementHandler _placementHandler;

    private void Awake()
    {
        _mainCamera = Camera.main;  
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        //Return if the input context is not started
        if (!context.started) return;

        //Get the information about the game object that cliked in to the hit variable
        var hit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
    
        if(!hit.collider) return;
        
        Debug.Log(hit.collider.gameObject.name);
       _placementHandler= hit.collider.transform.GetComponent<ChessPlayerPlacementHandler>();

        IChessPiece chessPiece = ChessPieceFactory.GetChessPiece(hit.collider.gameObject.name);
        if (chessPiece != null)
        {
            chessPiece.HighlightPossibleMoves(_placementHandler);
        }

    }



}
