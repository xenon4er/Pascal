using System;
using System.Globalization;

using Antlr.Runtime;
using Antlr.Runtime.Tree;


namespace MathExpr
{
  public class Program
  {
    // "культуронезависимый" формат для чисел (с разделителем точкой)
    public static readonly NumberFormatInfo NFI = new NumberFormatInfo();
    public static Context mainContext = new Context();

    public static void Main(string[] args) {  
     try {
         mainContext.f_p_name = "print";
         IdentDescr iden = new IdentDescr();
         iden.name = "print";
         iden.varType = VarDescr.VarType.proc;
         mainContext.idents.AddLast(iden);
         mainContext.upper = null;
         /*необходимо заполнить контекст стандартными данными*/
        
        // в зависимости от наличия параметров командной строки разбираем
        // либо файл с именем, переданным первым параметром, либо стандартный ввод
        ICharStream input = args.Length == 1 ? (ICharStream)new ANTLRFileStream(args[0])
                                             : (ICharStream)new ANTLRReaderStream(Console.In);
        MathExprLexer lexer = new MathExprLexer(input);
        CommonTokenStream tokens = new CommonTokenStream(lexer);
        MathExprParser parser = new MathExprParser(tokens);
        ITree program = (ITree)parser.execute().Tree;
        AstNodePrinter.Print(program);
        Console.WriteLine();
        MathExprIntepreter.Execute(program, mainContext);
        AstNodePrinter.Print(program);
        
        string msil = MSIL.GenerateMSIL(program,mainContext);
        Console.WriteLine(msil);
        
      }
      catch (Exception e) {
        Console.WriteLine("Error: {0}", e);
      }
    }
  }
}
