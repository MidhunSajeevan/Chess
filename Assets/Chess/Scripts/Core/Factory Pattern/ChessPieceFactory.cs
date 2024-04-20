public static class ChessPieceFactory
{
    public static IChessPiece GetChessPiece(string pieceName)
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();
        switch (pieceName)
        {
           //Create the Instance according to the Piece name
            case "Knight":
                return new Knight();
            case "King":
                return new King();
            case "Rook":
                return new Rook();
            case "Pawn":
                return new Pawn();
            case "Bishop":
                return new Bishop();
            case "Queen":
                return new Queen();
            default:
                return null;
        }
        return null;
    }
}
