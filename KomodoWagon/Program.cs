namespace KomodoWagon;

class Program {
    static void Main(string[] args) {
        Board.reset("rnbqkbnr/pp4p1/2pP3p/3Ppp2/8/8/PPP2PPP/RNBQKBNR w KQkq e6 0 6");
        Board.printInfo();
    }
}
