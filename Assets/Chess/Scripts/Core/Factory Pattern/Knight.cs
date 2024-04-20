using Chess.Scripts.Core;
using UnityEngine;

public class Knight : IChessPiece
{
    public void HighlightPossibleMoves(ChessPlayerPlacementHandler placementHandler)
    {
        //Size of the board
        int boardSize = 8;

        // Define the possible moves relative to the knight's position
        int[] rowOffsets = { 2, 2, -2, -2, 1, 1, -1, -1 };
        int[] colOffsets = { 1, -1, 1, -1, 2, -2, 2, -2 };

        for (int i = 0; i < rowOffsets.Length; i++)
        {
            int newRow = placementHandler.row + rowOffsets[i];
            int newCol = placementHandler.column + colOffsets[i];

            // Check if the new position is within the bounds of the chessboard
            if (IsWithinBounds(newRow, newCol, boardSize))
            {
               
                // Check if there is a player at the target position
                GameObject targetTile = ChessBoardPlacementHandler.Instance.GetTile(newRow, newCol);
                if (targetTile != null)
                {
                    Cell cell = targetTile.GetComponent<Cell>();
                    if (cell.IsOccupied == true)
                    {
                        // Check if the player at the target position is the same color (black or white)
                        if (cell.Color == placementHandler.playerColor)
                        {
                            // Same color player, no need to highlight
                            continue;
                        }
                        else
                        {
                            // Enemy player, highlight as red
                            ChessBoardPlacementHandler.Instance.Highlight(newRow, newCol, Color.red);
                        }
                    }
                }
                else
                {
                    // Empty tile, highlight as default color
                    ChessBoardPlacementHandler.Instance.Highlight(newRow, newCol, Color.green);
                }

            }
        }
    }
        private bool IsWithinBounds(int row, int col, int boardSize)
        {
            // Check if the position is within the bounds of the chessboard
            return row >= 0 && row < boardSize && col >= 0 && col < boardSize;
        }

    } 
