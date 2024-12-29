using System.Resources;

namespace KomodoWagon;

public class Board {
    public static byte[] Square = new byte[64];
    public static bool[] CastleRights = new bool[4];
    public static bool WhiteToMove = true;
    public static Move? lastMove;
    public static int HalfMoves, FullMoves; 
    
    public static void reset() {
        reset("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
    }
    public static void reset(string fen) {
        Square = new byte[64];
        CastleRights = new bool[4];
        char c;
        int s = 0;
        int last = 0;
        for (int i = 0; i < fen.Length; i++) {
            c = fen.ElementAt(i);
            if (c < 58 && c > 47) {
                s += int.Parse(c.ToString());
            } else if (c == '/') {
                s += (s % 8 == 0) ? 0 : 8 - (s % 8);
            } else {
                Square[s] = Piece.toPiece(c);
                s++;
            }
            if (s > 63) {
                last = i;
                break;
            }
        }
        last += 2;
        c = fen.ElementAt(last);
        WhiteToMove = (c == 'w');
        last += 2;
        string castle = fen.Substring(last, fen.IndexOf(' ', last) - last);
        if (castle.Length > 0) {
            last = fen.IndexOf(' ', last);
            for (int i = 0; i < castle.Length; i++) {
                c = castle.ElementAt(i);
                switch (c) {
                    case 'K':
                        CastleRights[0] = true;
                        break;
                    case 'Q':
                        CastleRights[1] = true;
                        break;
                    case 'k':
                        CastleRights[2] = true;
                        break;
                    case 'q':
                        CastleRights[3] = true;
                        break;
                }
            }
        }
        last++;
        c = fen.ElementAt(last);
        if (c != '-') {
            string en = fen.Substring(last, fen.IndexOf(' ', last) - last);
            lastMove = Move.fromEnPassantTargetSquare(en);
        } else {
            lastMove = null;
        }
        last = fen.IndexOf(' ', last) + 1;
        string hm = fen.Substring(last, fen.IndexOf(' ', last) - last);
        HalfMoves = int.Parse(hm);
        last = fen.IndexOf(' ', last) + 1;
        string fm = fen.Substring(last);
        FullMoves = int.Parse(fm);
    }
    
    public static void print() {
        Console.WriteLine("+---+---+---+---+---+---+---+---+");
        Console.Write("|");
        for (int i = 0; i < 64; i++) {
            Console.Write(" " + Piece.toChar(Square[i]) + " |");
            if ((i + 1) % 8 == 0) {
                Console.WriteLine(" " + (9 - (int) ((i + 1) / 8)));
                Console.WriteLine("+---+---+---+---+---+---+---+---+");
                if (i == 63) {
                    break;
                }
                Console.Write("|");
            }
        }
        Console.WriteLine("  a   b   c   d   e   f   g   h  ");
    }
    public static void printInfo() {
        Console.WriteLine("Castle Rights:");
        Console.WriteLine("  White King-Side: " + CastleRights[0]);
        Console.WriteLine("  White Queen-Side: " + CastleRights[1]);
        Console.WriteLine("  Black King-Side: " + CastleRights[2]);
        Console.WriteLine("  Black Queen-Side: " + CastleRights[3]);
        Console.WriteLine(WhiteToMove ? "White to move" : "Black to move");
        Console.WriteLine("Last move: " + ((lastMove == null) ? "-" : lastMove.ToString()));
        Console.WriteLine("Half moves: " + HalfMoves + "  Full moves: " + FullMoves);
        print();
    }
}