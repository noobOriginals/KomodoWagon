namespace KomodoWagon;

public class Move {
    public int startSquare, endSquare;
    public Move(int startSquare, int endSquare) {
        this.startSquare = startSquare;
        this.endSquare = endSquare;
    }
    public Move(string move) {
        string alph = "abcdefgh";
        int rank, file;
        rank = 8 - int.Parse(move.ElementAt(1).ToString());
        file = alph.IndexOf(move.ElementAt(0));
        startSquare = rank * 8 + file;
        rank = 8 - int.Parse(move.ElementAt(3).ToString());
        file = alph.IndexOf(move.ElementAt(2));
        endSquare = rank * 8 + file;
    }
    public override string ToString() {
        string move = "";
        string alph = "abcdefgh";
        int rank, file;
        file = startSquare % 8;
        rank = 8 - (startSquare - file) / 8;
        move += "" + alph.ElementAt(file);
        move += "" + rank;
        file = endSquare % 8;
        rank = 8 - (endSquare - file) / 8;
        move += "" + alph.ElementAt(file);
        move += "" + rank;
        return move;
    }
    public static Move fromEnPassantTargetSquare(string targetSquare) {
        string file = targetSquare.ElementAt(0).ToString();
        Move move;
        if (targetSquare.ElementAt(1) == '3') {
            move = new Move(file + "2" + file + "4");
        } else {
            move = new Move(file + "7" + file + "5");
        }
        return move;
    }
}