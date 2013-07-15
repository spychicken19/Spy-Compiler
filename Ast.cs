public abstract class Stmt
{
}

public class DeclareVar : Stmt
{
    public string Ident;
    public Expr Expr;
}

public class Print : Stmt
{
    public Expr Expr;
}

public class Assign : Stmt
{
    public string Ident;
    public Expr Expr;
}

public class forLoop : Stmt
{
    public string Ident;
    public Expr From;
    public Expr To;
    public Stmt Body;
}

public class ReadInt : Stmt
{
    public string Ident;
}

public class Sequence : Stmt
{
    public Stmt First;
    public Stmt Second;
}

public abstract class Expr
{
}

public class StringLiteral : Expr
{
    public string Value;
}

public class IntLiteral : Expr
{
    public int Value;
}

public class BinExpr : Expr
{
    public Expr Left;
    public Expr Right;
    public BinOp Op;
}

public class Variable : Expr
{
    public string Ident;
}

public enum BinOp
{
    Add,
    Sub,
    Mul,
    Div
}

public class Pauseobj : Stmt
{
    public string Ident;
}
