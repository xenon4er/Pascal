using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

using Antlr.Runtime.Tree;

using AstNodeType = MathExpr.MathExprParser;


namespace MathExpr
{
    public class MSIL
    {
        private ITree programNode = null;
        private Dictionary<string, int> vars = new Dictionary<string, int>();
        private StringBuilder msil = new StringBuilder();
        private int labIndex = 0;
        private Context programContext = null; 

        public MSIL(ITree programNode, Context proCo)
        {
            if (programNode.Type != AstNodeType.PROGRAM)
                throw new IntepreterException("AST-дерево не является программой");

            this.programNode = programNode;
            this.programContext = proCo;
        }


        private void NumVariables(ITree node)
        {
            switch (node.Type)
            {
                case AstNodeType.UNKNOWN:
                    throw new IntepreterException("Неопределенный тип узла AST-дерева");

                case AstNodeType.IDENT:
                    string varName = node.Text;
                    if (!vars.ContainsKey(varName))
                        vars[varName] = vars.Count;
                    break;

                default:
                    for (int i = node.Type == AstNodeType.FUNC_CALL ? 1 : 0; i < node.ChildCount; i++)
                        NumVariables(node.GetChild(i));
                    break;
            }
        }

        private void NumVariables()
        {
            vars = new Dictionary<string, int>();
            NumVariables(programNode);
        }

        ITree child = null;
        private void Generate(ITree node, Context context)
        {
            int tempLabIndex;
            switch (node.Type)
            {
                case AstNodeType.ASSIGN:
                    Generate(node.GetChild(1),context);
                    msil.Append(string.Format("    stloc.s {0}\n", context.get_var(node.GetChild(0).Text).countVar));
                    break;

                case AstNodeType.IDENT:
                    msil.Append(string.Format("    ldloc.s {0}\n", context.get_var(node.Text).countVar));
                    break;
                
               
                
                case AstNodeType.FUNC_CALL:


                    child = node.GetChild(0);
                    if (child.Text == "print")
                    {
                        child = node.GetChild(1).GetChild(0);
                        Generate(child, context);
                        int t = child.Type;
                        if (t == AstNodeType.IDENT)
                        {
                            IdentDescr ident = context.find_var(child.Text);
                            if (ident.dataType.type == DataType.Type.my_integer)
                                t = AstNodeType.INTEGER;
                            if (ident.dataType.type == DataType.Type.my_real)
                                t = AstNodeType.REAL;
                            if (ident.dataType.type == DataType.Type.my_string)
                                t = AstNodeType.STRING;

                        }
                        if (t == AstNodeType.INTEGER)
                            msil.Append(string.Format("    call void [mscorlib]System.Console::WriteLine(int32)\n"));
                        if (t == AstNodeType.STRING)
                            msil.Append(string.Format("    call void [mscorlib]System.Console::WriteLine(string)\n"));
                        if (t == AstNodeType.REAL)
                            msil.Append(string.Format("    call void [mscorlib]System.Console::WriteLine(float32)\n"));

                    }
                    else
                    {
                        
                        Generate(node.GetChild(1).GetChild(0), context);
                        msil.Append(string.Format("    call void [mscorlib]System.Console::WriteLine(int32)\n"));
                    }
                    break;

                case AstNodeType.ADD:
                case AstNodeType.SUB:
                case AstNodeType.MUL:
                case AstNodeType.DIV:
                    string oper = node.Type == AstNodeType.ADD ? "add" :
                                  node.Type == AstNodeType.SUB ? "sub" :
                                  node.Type == AstNodeType.MUL ? "mul" :
                                  node.Type == AstNodeType.DIV ? "div" :
                                  "unknown";

                    Generate(node.GetChild(0),context);
                    Generate(node.GetChild(1),context);
                    msil.Append(string.Format("    {0}\n", oper));
                    break;

                case AstNodeType.IF:
                    tempLabIndex = labIndex;
                    labIndex += 2;
                    Generate(node.GetChild(0),context); 
                    Generate(node.GetChild(1), context);
                    msil.Append(string.Format("    br.s L_{0:X4}\n", tempLabIndex + 2));
                    msil.Append(string.Format("  L_{0:X4}:\n", tempLabIndex + 1));
                    if (node.ChildCount > 2)
                        Generate(node.GetChild(2), context);
                    msil.Append(string.Format("  L_{0:X4}:\n", tempLabIndex + 2));
                    break;

                case AstNodeType.WHILE:
                    tempLabIndex = labIndex;
                    labIndex += 2;
                    msil.Append(string.Format("  L_{0:X4}:\n", tempLabIndex + 1));
                    Generate(node.GetChild(0), context);
                    Generate(node.GetChild(1), context);
                    msil.Append(string.Format("    br.s L_{0:X4}\n", tempLabIndex + 1));
                    msil.Append(string.Format("  L_{0:X4}:\n", tempLabIndex + 2));
                    break;

                case AstNodeType.FOR:
                    tempLabIndex = labIndex;
                    labIndex += 2;
                    Generate(node.GetChild(1), context);
                    msil.Append(string.Format("    stloc.s {0}\n", context.get_var(node.GetChild(0).Text).countVar));
                    msil.Append(string.Format("  L_{0:X4}:\n", tempLabIndex + 1));
                    msil.Append(string.Format("    ldloc.s {0}\n", context.get_var(node.GetChild(0).Text).countVar));
                    Generate(node.GetChild(2), context);
                    msil.Append(string.Format("    sub\n"));
                    msil.Append(string.Format("    ldc.i4.s {0}\n", 1));
                    msil.Append(string.Format("    sub\n"));
                    msil.Append(string.Format("    brfalse.s L_{0:X4}\n", tempLabIndex + 2));
                    Generate(node.GetChild(3), context);
                    msil.Append(string.Format("    ldloc.s {0}\n", context.get_var(node.GetChild(0).Text).countVar));
                    msil.Append(string.Format("    ldc.i4.s {0}\n", 1));
                    msil.Append(string.Format("    add\n"));
                    msil.Append(string.Format("    stloc.s {0}\n", context.get_var(node.GetChild(0).Text).countVar));
                    msil.Append(string.Format("    br.s L_{0:X4}\n", tempLabIndex + 1));
                    msil.Append(string.Format("  L_{0:X4}:\n", tempLabIndex + 2));
                    break;


                case AstNodeType.INTEGER:
                    msil.Append(string.Format("    ldc.i4.s {0}\n", node.Text));
                    break;
                case AstNodeType.REAL:
                    msil.Append(string.Format("    ldc.r4 {0}\n", node.Text)); 
                    break;
                case AstNodeType.STRING:
                    msil.Append(string.Format("    ldstr {0}\n", node.Text));
                    break;

                case AstNodeType.REPEAT:
                    tempLabIndex = labIndex;
                    labIndex += 2;
                    msil.Append(string.Format("  L_{0:X4}:\n", tempLabIndex + 1));
                    for (int i = 0; i < node.ChildCount - 1; i++)
                        Generate(node.GetChild(i), context);

                    Generate(node.GetChild(node.ChildCount - 1), context);
                    msil.Append(string.Format("    br.s L_{0:X4}\n", tempLabIndex + 1));
                    msil.Append(string.Format("  L_{0:X4}:\n", tempLabIndex + 2));
                    
                        break;

                case AstNodeType.VAR:
                    Context tmp = context;
                    LinkedListNode<IdentDescr> identif;
                    msil.Append("    .locals init (\n");
                    //int count = 0;
                    for (identif = context.idents.First; identif != null; identif = identif.Next)
                    {
                        if (identif.Value.varType == VarDescr.VarType.var)
                        {
                            if(identif.Value.dataType.type==DataType.Type.my_integer)
                                msil.Append(string.Format("      [{0}] int32 {1}{2}\n", identif.Value.countVar,identif.Value.name, identif.Next!=null ? ",":""));
                            if (identif.Value.dataType.type == DataType.Type.my_real)
                                msil.Append(string.Format("      [{0}] float32 {1}{2}\n", identif.Value.countVar, identif.Value.name, identif.Next != null ? "," : ""));
                            if (identif.Value.dataType.type == DataType.Type.my_string)
                                msil.Append(string.Format("      [{0}] string {1}{2}\n", identif.Value.countVar, identif.Value.name, identif.Next != null ? "," : ""));
                            //count++;
                        }
                    }
                    msil.Append("    )\n");
                        //msil.Append(string.Format("      [{0}] int32 {1}{2}\n", kv.Value, kv.Key, ++index < vars.Count ? "," : ""));
                    break;
                case AstNodeType.PARAMS:
                    break;

                case AstNodeType.FUNCTION:
                    break;

                case AstNodeType.PROCEDURE:
                    break;

                case AstNodeType.COMPARE:
                    tempLabIndex = labIndex;
                    labIndex += 2;

                    Generate(node.GetChild(0), context);
                    Generate(node.GetChild(1), context);
                    switch (node.Text)
                    {
                        case ">":
                            msil.Append(string.Format("    bgt L_{0:X4}\n", tempLabIndex + 1));
                            //bgt
                            break;
                        case ">=":
                            msil.Append(string.Format("    bge L_{0:X4}\n", tempLabIndex + 1));
                            //bge
                            break;
                        case "<":
                            msil.Append(string.Format("    blt L_{0:X4}\n", tempLabIndex + 1));
                            //blt
                            break;
                        case "<=":
                            msil.Append(string.Format("    ble L_{0:X4}\n", tempLabIndex + 1));
                            //ble
                            break;
                        case "=":
                            msil.Append(string.Format("    beq L_{0:X4}\n", tempLabIndex + 1));
                            //beq
                            break;
                        case "<>":
                            msil.Append(string.Format("    bne.un L_{0:X4}\n", tempLabIndex + 1));
                            //bne.un
                            break;
                    }
                    msil.Append(string.Format("    br.s L_{0:X4}\n", tempLabIndex));
                    msil.Append(string.Format("  L_{0:X4}:\n", tempLabIndex + 1));
                    break;
                // '>' | '>=' | '<' | '<=' | '=' | '<>' ;
                case AstNodeType.CONVERT:
                    break;

                case AstNodeType.AND://?
                    break;

                case AstNodeType.OR://?
                    break;

                case AstNodeType.BLOCK:
                case AstNodeType.PROGRAM:
                    for (int i = 0; i < node.ChildCount; i++)
                        Generate(node.GetChild(i), context);
                    break;

                default:
                    throw new IntepreterException("Not implemented!");
            }
        }


        private void Generate()
        {
            msil = new StringBuilder();
            labIndex = 0;

            msil.Append(@"
.assembly program
{
}

.class public Program
{
  .method public static void Main() cil managed
  {
    .entrypoint
");         /*
            if (vars.Count > 0)
            {
                msil.Append("    .locals init (\n");
                int index = 0;
                foreach (var kv in vars)
                    msil.Append(string.Format("      [{0}] int32 {1}{2}\n", kv.Value, kv.Key, ++index < vars.Count ? "," : ""));

                msil.Append("    )\n");
            }
             */
            Generate(programNode,Program.mainContext);
            msil.Append(string.Format("    ret"));
            msil.Append(@"
  }
}
");
        }


        public static string GenerateMSIL(ITree programNode, Context context)
        {
            MSIL g = new MSIL(programNode,context);
            g.NumVariables();
            g.Generate();
            return g.msil.ToString();
        }
    }
}
