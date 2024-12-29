namespace KomodoWagon;

public class Piece {
    public const byte White = 0b1000;
    public const byte Black = 0b10000;
    public const byte None = 0b0;
    public const byte Pawn = 0b1;
    public const byte Knight = 0b10;
    public const byte Bishop = 0b11;
    public const byte Rook = 0b100;
    public const byte Queen = 0b101;
    public const byte King = 0b110;

    public static byte getPieceType(byte piece) {
        piece = (byte) (piece | (3 << 3));
        return (byte) (piece ^ (3 << 3));;
    }
    public static byte getPieceColor(byte piece) {
        piece = (byte) (piece >> 3);
        return (byte) (piece << 3);;
    }
    public static bool isColor(byte piece, byte color) {
        return (piece >> 3) == (color >> 3);
    }
    public static bool isType(byte piece, byte type) {
        return getPieceType(piece) == type;
    }
    public static char toChar(byte piece) {
        bool uppercase = isColor(piece, White);
        piece = getPieceType(piece);
        switch (piece) {
            case None:
                return ' ';
            case Pawn:
                return (uppercase) ? 'P' : 'p';
            case Knight:
                return (uppercase) ? 'N' : 'n';
            case Bishop:
                return (uppercase) ? 'B' : 'b';
            case Rook:
                return (uppercase) ? 'R' : 'r';
            case Queen:
                return (uppercase) ? 'Q' : 'q';
            case King:
                return (uppercase) ? 'K' : 'k';
            default:
                return ' ';
        }
    }
    public static byte toPiece(char value) {
        bool uppercase = Char.IsUpper(value);
        switch (Char.ToUpper(value)) {
            case ' ':
                return None;
            case 'P':
                return (byte) (((uppercase) ? White : Black) | Pawn);
            case 'N':
                return (byte) (((uppercase) ? White : Black) | Knight);
            case 'B':
                return (byte) (((uppercase) ? White : Black) | Bishop);
            case 'R':
                return (byte) (((uppercase) ? White : Black) | Rook);
            case 'Q':
                return (byte) (((uppercase) ? White : Black) | Queen);
            case 'K':
                return (byte) (((uppercase) ? White : Black) | King);
            default:
                return None;
        }
    }
}