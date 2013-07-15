using Collections = System.Collections.Generic;
using IO = System.IO;
using Text = System.Text;

public sealed class Scanner
{
    private readonly Collections.IList<object> result;

    public Scanner(IO.TextReader input)
    {
        this.result = new Collections.List<object>();
        this.Scan(input);
    }

    public Collections.IList<object> Tokens
    {
        get { return this.result; }
    }

    #region ArithmiticConstants

    public static readonly object Add = new object();
    public static readonly object Sub = new object();
    public static readonly object Mul = new object();
    public static readonly object Div = new object();
    public static readonly object Semi = new object();
    public static readonly object Equal = new object();
    #endregion

    private void Scan(IO.TextReader input)
    {
        while (input.Peek() != -1)
        {
            char ch = (char)input.Peek();

            if (char.IsWhiteSpace(ch))
            {
                input.Read();
            }
            else if (char.IsLetter(ch) || ch == '_')
            {
                Text.StringBuilder accum = new Text.StringBuilder();

                while (char.IsLetter(ch) || ch == '_')
                {
                    accum.Append(ch);
                    input.Read();

                    if (input.Peek() == -1)
                    {
                        break;
                    }
                    else
                    {
                        ch = (char) input.Peek();
                    }
                }
                this.result.Add(accum.ToString());
            }
            else if (ch == '"')
            {
                Text.StringBuilder accum = new Text.StringBuilder();

                input.Read();

                if (input.Peek() == -1)
                {
                    throw new System.Exception("Unterminated String Literal");
                }
                while ((ch = (char)input.Peek()) != '"')
                {
                    accum.Append(ch);
                    input.Read();
                    if (input.Peek() == -1)
                    {
                        throw new System.Exception("Unterminated String Literal");
                    }
                }
                input.Read();
                this.result.Add(accum);
            }
            else if (char.IsDigit(ch))
            {
                Text.StringBuilder accum = new Text.StringBuilder();

                while (char.IsDigit (ch))
                {
                    accum.Append(ch);
                    input.Read();

                    if (input.Peek() == -1)
                    {
                        break;
                    }
                    else
                    {
                        ch = (char)input.Peek();
                    }
                }
                this.result.Add(int.Parse(accum.ToString()));
            }
            else switch (ch)
            {
                case '+':
                    input.Read();
                    this.result.Add(Scanner.Add);
                    break;
                case '-':
                    input.Read();
                    this.result.Add(Scanner.Sub);
                    break;
                case '*':
                    input.Read();
                    this.result.Add(Scanner.Mul);
                    break;
                case '/':
                    input.Read();
                    this.result.Add(Scanner.Div);
                    break;
                case ';':
                    input.Read();
                    this.result.Add(Scanner.Semi);
                    break;
                case '=':
                    input.Read();
                    this.result.Add(Scanner.Equal);
                    break;
            }
        }
    }
}
