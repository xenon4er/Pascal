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
        private StringBuilder Mfunction = new StringBuilder();

        private LinkedList<StringBuilder> list_functions = new LinkedList<StringBuilder>();

        private int labIndex = 0;
        private Context programContext = null;

        private string f_p_name;
        private string list_params;
        private string f_p_type;

        private IdentDescr tmpIdent = new IdentDescr();

        private Context tmpContext = new Context();

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
        private void Generate(ITree node, Context context, StringBuilder s)
        {
            int tempLabIndex;
            switch (node.Type)
            {
                case AstNodeType.ASSIGN:
                    Generate(node.GetChild(1),context,s);
                    s.Append(string.Format("    stloc.s {0}\n", context.find_var(node.GetChild(0).Text).countVar));
                    break;

                case AstNodeType.IDENT:
                    tmpIdent = context.find_var(node.Text);
                    if(tmpIdent.varType == VarDescr.VarType.var)
                        s.Append(string.Format("    ldloc.s {0}\n", tmpIdent.countVar));
                    if (tmpIdent.varType == VarDescr.VarType.parametr)
                        s.Append(string.Format("    ldarg.{0}\n", tmpIdent.pos-1));

                    if (tmpIdent.dataType.type == DataType.Type.my_integer)
                        list_params += "int32, ";
                    if (tmpIdent.dataType.type == DataType.Type.my_real)
                        list_params += "float32, ";
                    if (tmpIdent.dataType.type == DataType.Type.my_string)
                        list_params += "string, ";
                    //list_params += "";
                    break;
                
               
                
                case AstNodeType.FUNC_CALL:


                    child = node.GetChild(0);
                    if (child.Text == "print")
                    {
                        child = node.GetChild(1).GetChild(0);
                        Generate(child, context,s);
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
                            s.Append(string.Format("    call void [mscorlib]System.Console::WriteLine(int32)\n"));
                        if (t == AstNodeType.STRING)
                            s.Append(string.Format("    call void [mscorlib]System.Console::WriteLine(string)\n"));
                        if (t == AstNodeType.REAL)
                            s.Append(string.Format("    call void [mscorlib]System.Console::WriteLine(float32)\n"));

                    }
                    else
                    {
                        child = node.GetChild(0);
                        f_p_name = child.Text;
                        
                        IdentDescr if_finc = new IdentDescr();
                        if_finc = context.find_func(f_p_name);
                        if(if_finc.varType==VarDescr.VarType.proc)
                        {
                            f_p_type = "void";
                        }
                        else
                        {
                            if (if_finc.dataType.type == DataType.Type.my_integer)
                                f_p_type = "int32";
                            if (if_finc.dataType.type == DataType.Type.my_real)
                                f_p_type = "float32";
                            if (if_finc.dataType.type == DataType.Type.my_string)
                                f_p_type = "string";

                        }

                        list_params = "";
                        child = node.GetChild(1);
                        for (int i = 0; i < child.ChildCount; i++)
                        {
                            Generate(child.GetChild(i), context.find_context(f_p_name),s);
                            //ITree c = child.GetChild(i);
                            switch (child.GetChild(i).Type)
                            {
                                case AstNodeType.REAL:
                                    list_params += "float32, ";
                                    break;
                                case AstNodeType.INTEGER:
                                    list_params += "int32, ";
                                    break;
                                case AstNodeType.STRING:
                                    list_params += "string, ";
                                    break;
                                case AstNodeType.IDENT:
                                    break;
                            }
                        }
                        if(list_params.Length > 2)
                            list_params = list_params.Substring(0, list_params.Length - 2);
                        s.Append(string.Format("    call {0} Program::{1}({2})\n", f_p_type ,f_p_name, list_params));
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

                    Generate(node.GetChild(0),context,s);
                    Generate(node.GetChild(1),context,s);
                    s.Append(string.Format("    {0}\n", oper));
                    break;

                case AstNodeType.IF:
                    tempLabIndex = labIndex;
                    labIndex += 2;
                    Generate(node.GetChild(0),context,s); 
                    Generate(node.GetChild(1), context,s);
                    s.Append(string.Format("    br.s L_{0:X4}\n", tempLabIndex + 2));
                    s.Append(string.Format("  L_{0:X4}:\n", tempLabIndex + 1));
                    if (node.ChildCount > 2)
                        Generate(node.GetChild(2), context,s);
                    s.Append(string.Format("  L_{0:X4}:\n", tempLabIndex + 2));
                    break;

                case AstNodeType.WHILE:
                    tempLabIndex = labIndex;
                    labIndex += 2;
                    s.Append(string.Format("  L_{0:X4}:\n", tempLabIndex + 1));
                    Generate(node.GetChild(0), context, s);
                    Generate(node.GetChild(1), context, s);
                    s.Append(string.Format("    br.s L_{0:X4}\n", tempLabIndex + 1));
                    s.Append(string.Format("  L_{0:X4}:\n", tempLabIndex + 2));
                    break;

                case AstNodeType.FOR:
                    tempLabIndex = labIndex;
                    labIndex += 2;
                    Generate(node.GetChild(1), context, s);
                    s.Append(string.Format("    stloc.s {0}\n", context.get_var(node.GetChild(0).Text).countVar));
                    s.Append(string.Format("  L_{0:X4}:\n", tempLabIndex + 1));
                    s.Append(string.Format("    ldloc.s {0}\n", context.get_var(node.GetChild(0).Text).countVar));
                    Generate(node.GetChild(2), context, s);
                    s.Append(string.Format("    sub\n"));
                    s.Append(string.Format("    ldc.i4.s {0}\n", 1));
                    s.Append(string.Format("    sub\n"));
                    s.Append(string.Format("    brfalse.s L_{0:X4}\n", tempLabIndex + 2));
                    Generate(node.GetChild(3), context, s);
                    s.Append(string.Format("    ldloc.s {0}\n", context.get_var(node.GetChild(0).Text).countVar));
                    s.Append(string.Format("    ldc.i4.s {0}\n", 1));
                    s.Append(string.Format("    add\n"));
                    s.Append(string.Format("    stloc.s {0}\n", context.get_var(node.GetChild(0).Text).countVar));
                    s.Append(string.Format("    br.s L_{0:X4}\n", tempLabIndex + 1));
                    s.Append(string.Format("  L_{0:X4}:\n", tempLabIndex + 2));
                    break;


                case AstNodeType.INTEGER:
                    s.Append(string.Format("    ldc.i4.s {0}\n", node.Text));
                    break;
                case AstNodeType.REAL:
                    s.Append(string.Format("    ldc.r4 {0}\n", node.Text)); 
                    break;
                case AstNodeType.STRING:
                    s.Append(string.Format("    ldstr {0}\n", node.Text));
                    break;

                case AstNodeType.REPEAT:
                    tempLabIndex = labIndex;
                    labIndex += 2;
                    s.Append(string.Format("  L_{0:X4}:\n", tempLabIndex + 1));
                    for (int i = 0; i < node.ChildCount - 1; i++)
                        Generate(node.GetChild(i), context, s);

                    Generate(node.GetChild(node.ChildCount - 1), context, s);
                    s.Append(string.Format("    br.s L_{0:X4}\n", tempLabIndex + 1));
                    s.Append(string.Format("  L_{0:X4}:\n", tempLabIndex + 2));
                    
                        break;

                case AstNodeType.VAR:
                    Context tmp = context;
                    LinkedListNode<IdentDescr> identif;
                    s.Append("    .locals init (\n");
                    //int count = 0;
                    for (identif = context.idents.First; identif != null; identif = identif.Next)
                    {
                        if (identif.Value.varType == VarDescr.VarType.var)
                        {
                            if(identif.Value.dataType.type==DataType.Type.my_integer)
                                s.Append(string.Format("      [{0}] int32 {1}{2}\n", identif.Value.countVar,identif.Value.name, (identif.Next!=null)&&(identif.Next.Value.varType==VarDescr.VarType.var) ? ",":""));
                            if (identif.Value.dataType.type == DataType.Type.my_real)
                                s.Append(string.Format("      [{0}] float32 {1}{2}\n", identif.Value.countVar, identif.Value.name, (identif.Next != null) && (identif.Next.Value.varType == VarDescr.VarType.var) ? "," : ""));
                            if (identif.Value.dataType.type == DataType.Type.my_string)
                                s.Append(string.Format("      [{0}] string {1}{2}\n", identif.Value.countVar, identif.Value.name, (identif.Next != null) && (identif.Next.Value.varType == VarDescr.VarType.var) ? "," : ""));
                            //count++;
                        }
                    }
                    s.Append("    )\n");
                        //msil.Append(string.Format("      [{0}] int32 {1}{2}\n", kv.Value, kv.Key, ++index < vars.Count ? "," : ""));
                    break;
                case AstNodeType.PARAMS:
                    list_params = "";
                    for (int i = 0; i < node.ChildCount; i++)
                    {
                        CommonTree childNode = (CommonTree)node.GetChild(i);
                        DataType.Type type = DataType.Type.None;
                        CommonTree childType = (CommonTree)childNode.GetChild(0);
                        switch (childType.Type)
                        {
                            case AstNodeType.STRING:
                                type = DataType.Type.my_string;
                                break;
                            case AstNodeType.INTEGER:
                                type = DataType.Type.my_integer;
                                break;
                            case AstNodeType.REAL:
                                type = DataType.Type.my_real;
                                break;

                        }
                        for (int j = 1; j < childNode.ChildCount; j++)
                        {
                            if (type == DataType.Type.my_integer)
                                list_params += "int32, ";
                            if (type == DataType.Type.my_real)
                                list_params += "float32, ";
                            if (type == DataType.Type.my_string)
                                list_params += "string, ";
                        }
                    }

                    break;

                case AstNodeType.FUNCTION:
                    StringBuilder function2 = new StringBuilder();
                    child = node.GetChild(0);
                    string type_func = "";
                    if (child.Type == AstNodeType.REAL)
                        type_func = "float32";
                    else
                        if (child.Type == AstNodeType.INTEGER)
                            type_func = "int32";
                        else
                            if (child.Type == AstNodeType.STRING)
                                type_func = "string";
                    
                    child = node.GetChild(1);// get child with func name
                    string func_name = child.Text;

                    tmpContext = context.find_context(func_name);
                    
                    list_params = "";
                    
                    child = node.GetChild(2);
                    if (child.Type==AstNodeType.PARAMS)
                        Generate(child, context.find_context(func_name), function2);
                    if (list_params.Length > 2)
                        list_params = list_params.Substring(0, list_params.Length - 2);

                    function2.Append(string.Format("\n  .method public static {0} {1}({2}) cil managed\n",type_func, func_name, list_params));
                    function2.Append("  {\n");
                    if (child.Type == AstNodeType.BLOCK)
                    {
                       Generate(child, tmpContext, function2);    
                    }
                    else 
                    {
                        for (int i = 2; i < node.ChildCount; i++)
                        {
                            child = node.GetChild(i);
                            if (child.Type == AstNodeType.PARAMS) continue;
                            Generate(child, tmpContext, function2);
                        }
                    }
                    function2.Append("  }\n");
                    list_functions.AddLast(function2);
                    break;
                
                case AstNodeType.RETURN:
                    Generate(node.GetChild(0), context, s);
                    s.Append("    ret\n");
                    break;

                case AstNodeType.PROCEDURE:
                    StringBuilder function = new StringBuilder();
                    child = node.GetChild(0);// get child with proc name
                    string proc_name = child.Text;
                    
                    tmpContext = context.find_context(proc_name);
                    
                    list_params = "";
                    
                    child = node.GetChild(1);
                    if (child.Type==AstNodeType.PARAMS)
                        Generate(child, context.find_context(proc_name), function);
                    if (list_params.Length > 2)
                        list_params = list_params.Substring(0, list_params.Length - 2);
                    
                    function.Append(string.Format("\n  .method public static void {0}({1}) cil managed\n", proc_name,list_params));
                    function.Append("  {\n");
                    if (child.Type == AstNodeType.BLOCK)
                    {
                        Generate(child, tmpContext, function);    
                    }
                    else 
                    {
                        for (int i = 1; i < node.ChildCount; i++)
                        {
                            child = node.GetChild(i);
                            if (child.Type == AstNodeType.PARAMS) continue;
                            Generate(child, tmpContext, function);
                        }
                    }
                    function.Append("  }\n");
                    list_functions.AddLast(function);
                    break;

                case AstNodeType.COMPARE:
                    tempLabIndex = labIndex;
                    labIndex += 2;

                    Generate(node.GetChild(0), context, s);
                    Generate(node.GetChild(1), context, s);
                    switch (node.Text)
                    {
                        case ">":
                            s.Append(string.Format("    bgt L_{0:X4}\n", tempLabIndex + 1));
                            //bgt
                            break;
                        case ">=":
                            s.Append(string.Format("    bge L_{0:X4}\n", tempLabIndex + 1));
                            //bge
                            break;
                        case "<":
                            s.Append(string.Format("    blt L_{0:X4}\n", tempLabIndex + 1));
                            //blt
                            break;
                        case "<=":
                            s.Append(string.Format("    ble L_{0:X4}\n", tempLabIndex + 1));
                            //ble
                            break;
                        case "=":
                            s.Append(string.Format("    beq L_{0:X4}\n", tempLabIndex + 1));
                            //beq
                            break;
                        case "<>":
                            s.Append(string.Format("    bne.un L_{0:X4}\n", tempLabIndex + 1));
                            //bne.un
                            break;
                    }
                    s.Append(string.Format("    br.s L_{0:X4}\n", tempLabIndex));
                    s.Append(string.Format("  L_{0:X4}:\n", tempLabIndex + 1));
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
                        Generate(node.GetChild(i), context, s);
                    break;

                default:
                    throw new IntepreterException("Not implemented!");
            }
        }


        private void Generate()
        {
            msil = new StringBuilder();
            Mfunction = new StringBuilder();
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
");         
            Generate(programNode,Program.mainContext,Mfunction);
            //msil.Append(string.Format("    ret"));
            msil.Append(Mfunction);
            msil.Append(@"
  }
");
            LinkedListNode<StringBuilder> l;
            for (l = list_functions.First; l != null; l=l.Next)
                msil.Append(l.Value);
msil.Append(@"
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
