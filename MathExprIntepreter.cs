using System;
using System.Globalization;
using Antlr.Runtime.Tree;
using System.Collections.Generic;
using AstNodeType = MathExpr.MathExprParser;


namespace MathExpr
{
  public class MathExprIntepreter
  {
    // "культуронезависимый" формат дл€ чисел (с разделителем точкой)
    public static readonly NumberFormatInfo NFI = new NumberFormatInfo();

    private ITree programNode = null;
    private Context context = null;

    

    public MathExprIntepreter(ITree programNode, Context context) {
      if (programNode.Type != AstNodeType.PROGRAM)
        throw new IntepreterException("AST-дерево не €вл€етс€ программой");

      this.programNode = programNode;
      this.context = context;
    }


    private double ExecuteNode(ITree node, Context context)
    {
        switch (node.Type)
        {
            case AstNodeType.UNKNOWN:
                throw new IntepreterException("Ќеопределенный тип узла AST-дерева " + node.Line);

           

            case AstNodeType.VAR:
                for (int i = 0; i < node.ChildCount; i++)
                {
                    CommonTree childNode =  (CommonTree)node.GetChild(i);
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
                        CommonTree childIdent = (CommonTree)childNode.GetChild(j);
                        IdentDescr newIdent = new IdentDescr();
                        newIdent.varType = IdentDescr.VarType.var;
                        newIdent.dataType.demention = 0;
                        newIdent.name = childIdent.Text;
                        newIdent.dataType.type = type;

                        if(context.if_exists(newIdent.name))
                            throw new IntepreterException("переменна€ уже описана: строка " + childIdent.Line); //add string where was exception
                        
                        context.idents.AddLast(newIdent);
                    }
                }
               
                break;

            case AstNodeType.FUNCTION:
                Context newContext = new Context();
                newContext.upper = this.context;
                IdentDescr newIdentFunc = new IdentDescr();
                DataType.Type type_return = DataType.Type.None;
                CommonTree childTypeReturn = (CommonTree)node.GetChild(0);
                switch (childTypeReturn.Type)
                {
                    case AstNodeType.STRING:
                        type_return = DataType.Type.my_string;
                        break;
                    case AstNodeType.INTEGER:
                        type_return = DataType.Type.my_integer;
                        break;
                    case AstNodeType.REAL:
                        type_return = DataType.Type.my_real;
                        break;

                }
                newIdentFunc.dataType.type = type_return; // получили возвращаемый тип функции

                CommonTree childName = (CommonTree)node.GetChild(1);
                newIdentFunc.name = childName.Text; //получили им€ функции
                newIdentFunc.varType = IdentDescr.VarType.ret_value;
                newIdentFunc.dataType.demention = 0;
                

                for (int i = 2; i < node.ChildCount; i++)
                {
                    CommonTree child = (CommonTree)node.GetChild(i);
                    switch(child.Type)
                    {
                        case AstNodeType.VAR:
                            ExecuteNode(child, newContext);
                            break;
                        case AstNodeType.BLOCK:
                            ExecuteNode(child, newContext);
                            break;

                        case AstNodeType.PARAMS:
                            break;
                    }
                }

                if (context.if_exists(newIdentFunc.name))
                    throw new IntepreterException("функци€ уже описана: строка " +  childName.Line);
                context.idents.AddLast(newIdentFunc);
                break;


            case AstNodeType.PROCEDURE:
                Context P_Context = new Context();
                P_Context.upper = this.context;
                IdentDescr newIdentProc = new IdentDescr();
                DataType.Type type_return_p = DataType.Type.None;
                newIdentProc.dataType.type = type_return_p;
                CommonTree childName_p = (CommonTree)node.GetChild(1);
                newIdentProc.name = childName_p.Text;
                newIdentProc.varType = IdentDescr.VarType.ret_value;
                newIdentProc.dataType.demention = 0;
                
                for (int i = 2; i < node.ChildCount; i++)
                {
                    CommonTree child = (CommonTree)node.GetChild(i);
                    switch(child.Type)
                    {
                        case AstNodeType.VAR:
                            ExecuteNode(child, P_Context);
                            break;
                        case AstNodeType.BLOCK:
                            ExecuteNode(child, P_Context);
                            break;
                        case AstNodeType.PARAMS:
                            for (int k = 0; k < node.ChildCount; k++)
                            {
                                CommonTree childNode = (CommonTree)node.GetChild(k);
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
                                    CommonTree childIdent = (CommonTree)childNode.GetChild(j);
                                    IdentDescr newIdent = new IdentDescr();
                                    newIdent.varType = IdentDescr.VarType.var;
                                    newIdent.dataType.demention = 0;
                                    newIdent.name = childIdent.Text;
                                    newIdent.dataType.type = type;

                                    if (context.if_exists(newIdent.name))
                                        throw new IntepreterException("Ќе верный параметр: строка " + childIdent.Line);

                                    context.idents.AddLast(newIdent);
                                }

                            }
                            break;
            
                    }
                }

                if (context.if_exists(newIdentProc.name))
                    throw new IntepreterException("процедура уже описана: строка " +  childName_p.Line);
                context.idents.AddLast(newIdentProc);
       
                break;

            case AstNodeType.FUNC_CALL:
                Context Func_call_Context = new Context();
                Func_call_Context.upper = this.context;
                IdentDescr newIdentFunc_call = new IdentDescr();
                CommonTree childName_func_call = (CommonTree)node.GetChild(1);
                newIdentFunc_call.name = childName_func_call.Text;
                newIdentFunc_call.varType = IdentDescr.VarType.ret_value;
                newIdentFunc_call.dataType.demention = 0;
                
                for (int i = 2; i < node.ChildCount; i++)
                {
                    CommonTree child = (CommonTree)node.GetChild(i);
                    switch(child.Type)
                    {
                        case AstNodeType.VAR:
                            ExecuteNode(child, Func_call_Context);
                            break;
                        case AstNodeType.PARAMS:
                            for (int k = 0; k < node.ChildCount; k++)
                            {
                                CommonTree childNode = (CommonTree)node.GetChild(k);
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
                                    CommonTree childIdent = (CommonTree)childNode.GetChild(j);
                                    IdentDescr newIdent = new IdentDescr();
                                    newIdent.varType = IdentDescr.VarType.var;
                                    newIdent.dataType.demention = 0;
                                    newIdent.name = childIdent.Text;
                                    newIdent.dataType.type = type;

                                    if (context.if_exists(newIdent.name))
                                        throw new IntepreterException("Ќе верный параметр: строка " + childIdent.Line);

                                    context.idents.AddLast(newIdent);
                                }

                            }
                            break;
            
                    }
                }

           
                break;

            

            case AstNodeType.ASSIGN:
                CommonTree nodeAssign0 = (CommonTree)node.GetChild(0);
                IdentDescr ident = context.find_var(nodeAssign0.Text);
                //помен€л find_var теперь если есть, то возвращает ident, если нет - null
                if (null == ident)
                {
                    throw new IntepreterException("ѕеременна€ не описана: строка " + nodeAssign0.Line);
                }
                CommonTree nodeAssign1 = (CommonTree)node.GetChild(1);
                
            // метод дл€ выкидывани€ исключений в случае невозможно преобразовани€
                validate_convert(nodeAssign1, ident);
                
            switch (nodeAssign1.Type)
                {
                    case AstNodeType.INTEGER:
                        if (ident.dataType.type == DataType.Type.my_real)
                        {
                            ConvertType(nodeAssign1, AstNodeType.REAL, 1);
                        }
                        else if (ident.dataType.type == DataType.Type.my_string)
                        {
                            ConvertType(nodeAssign1, AstNodeType.STRING, 1);
                        }
                        
                        ident.value = nodeAssign1.Text;
                        break;
                    case AstNodeType.REAL:
                        if (ident.dataType.type == DataType.Type.my_string)
                        {
                            ConvertType(nodeAssign1, AstNodeType.STRING, 1);
                        }
                        ident.value = nodeAssign1.Text;
                        break;
                    case AstNodeType.STRING:
                        ident.value = nodeAssign1.Text;
                        break;
                    default:
                        ExecuteNode(nodeAssign1, context);
                        break;

                }
               
                break;
            
            case AstNodeType.REPEAT:
                for (int i = 0; i< node.ChildCount; i ++ )
                    ExecuteNode(node.GetChild(i), context);
                break;

            case AstNodeType.FOR:
                //необходимо проверить, что переменна€ по которой идет счет описана, какие еще могут быть ошибки?
                CommonTree nodeFor0 = (CommonTree)node.GetChild(0);
                IdentDescr identFor = context.find_var(nodeFor0.Text);
                if (null == identFor)
                {
                    throw new SemException("ѕеременна€ не описана: строка " + nodeFor0.Line);
                }
                if (identFor.dataType.type != DataType.Type.my_integer)
                    throw new SemException("невозможен цикл for не по integer");
                CommonTree nodeFor1 = (CommonTree)node.GetChild(1);
                if (nodeFor1.Type != AstNodeType.INTEGER)
                    throw new SemException("узел не integer " + nodeFor1.Line);
                CommonTree nodeFor2 = (CommonTree)node.GetChild(2);
                if (nodeFor2.Type != AstNodeType.INTEGER)
                    throw new SemException("узел не integer " + nodeFor0.Line);
                ExecuteNode(node.GetChild(3), context);  


                break;
            case AstNodeType.WHILE:
                for (int i = 0; i < node.ChildCount; i++)
                    ExecuteNode(node.GetChild(i), context);
                break;

            case AstNodeType.IF:
                for (int i = 0; i < node.ChildCount; i++)
                    ExecuteNode(node.GetChild(i), context);
                break;
            
            case AstNodeType.AND:
                for (int i = 0; i < node.ChildCount; i++)
                    ExecuteNode(node.GetChild(i), context);
                break;
            
            case AstNodeType.OR:
                for (int i = 0; i < node.ChildCount; i++)
                    ExecuteNode(node.GetChild(i), context);
                break;
            
            case AstNodeType.COMPARE:
                IdentDescr tmpCmp0 = null;
                IdentDescr tmpCmp1 = null;
                CommonTree nodeCmp0 = (CommonTree)node.GetChild(0);
                if (nodeCmp0.Type != AstNodeType.STRING && nodeCmp0.Type != AstNodeType.REAL && nodeCmp0.Type != AstNodeType.INTEGER)
                {
                    tmpCmp0 = context.find_var(nodeCmp0.Text);
                    if (null == tmpCmp0)
                        throw new SemException("переменна€ не описана " + nodeCmp0.Text + " " + nodeCmp0.Line);
                }

                CommonTree nodeCmp1 = (CommonTree)node.GetChild(1);
                if (nodeCmp1.Type != AstNodeType.STRING && nodeCmp1.Type != AstNodeType.REAL && nodeCmp1.Type != AstNodeType.INTEGER)
                {
                    tmpCmp1 = context.find_var(nodeCmp1.Text);
                    if (null == tmpCmp1)
                        throw new SemException("переменна€ не описана " + nodeCmp1.Text + " " + nodeCmp1.Line);
                }

                if ((null == tmpCmp0) && (null == tmpCmp1))
                    validate_compare(nodeCmp0, nodeCmp1);
                else if ((null != tmpCmp0) && (null != tmpCmp1))
                    validate_compare(tmpCmp0, tmpCmp1);
                else if ((null != tmpCmp0) && (null == tmpCmp1))
                    validate_compare(nodeCmp1, tmpCmp0);
                else if ((null == tmpCmp0) && (null != tmpCmp1))
                    validate_compare(nodeCmp0, tmpCmp1);
                    break;

            case AstNodeType.ADD:
                //тут, как и везде, присутствуют только два childs
                ITree parent = node.Parent;
                //ищем переменную, в которую записываем, чтобы узнать ее тип
                while (parent.Type != AstNodeType.ASSIGN)
                    parent = parent.Parent;
                IdentDescr ident1 = context.find_var(parent.GetChild(0).Text);
                IdentDescr tmp;
                
                CommonTree nodeAdd0 = (CommonTree)node.GetChild(0);
                if (nodeAdd0.Type == AstNodeType.ADD || nodeAdd0.Type == AstNodeType.MUL || nodeAdd0.Type == AstNodeType.DIV || nodeAdd0.Type == AstNodeType.SUB)
                    ExecuteNode(node.GetChild(0), context);
                else if (nodeAdd0.Type != AstNodeType.STRING && nodeAdd0.Type != AstNodeType.REAL && nodeAdd0.Type != AstNodeType.INTEGER)
                {
                    tmp = context.find_var(nodeAdd0.Text);
                    if (null == tmp)
                        throw new SemException("переменна€ не описана " + nodeAdd0.Text +" "+ nodeAdd0.Line);
                    validate_convert(nodeAdd0, tmp, ident1);
                    mass_convert(ident1, 0, nodeAdd0,tmp);
                }

                CommonTree nodeAdd1 = (CommonTree)node.GetChild(1);
                if (nodeAdd1.Type == AstNodeType.ADD || nodeAdd1.Type == AstNodeType.MUL || nodeAdd1.Type == AstNodeType.DIV || nodeAdd1.Type == AstNodeType.SUB)
                    ExecuteNode(node.GetChild(1), context);
                else if (nodeAdd1.Type != AstNodeType.STRING && nodeAdd1.Type != AstNodeType.REAL && nodeAdd1.Type != AstNodeType.INTEGER)
                {
                    tmp = context.find_var(nodeAdd1.Text);
                    if (null == tmp)
                        throw new SemException("переменна€ не описана " + nodeAdd1.Text + " " + nodeAdd0.Line);
                    validate_convert(nodeAdd1, tmp, ident1);
                    mass_convert(ident1, 1, nodeAdd1, tmp);
                }

                validate_convert(nodeAdd0, ident1);
                validate_convert(nodeAdd1, ident1);
                mass_convert(ident1, 0, nodeAdd0);
                mass_convert(ident1, 1, nodeAdd1);

                break;
            case AstNodeType.MUL:
                add_div_sub(node, "умножать");
                break;

            case AstNodeType.DIV:
                add_div_sub(node, "делить");
                break;

            case AstNodeType.SUB:
                add_div_sub(node, " вычитать ");
                break;


            case AstNodeType.BLOCK:
                case AstNodeType.PROGRAM:
                    for (int i = 0; i < node.ChildCount; i++)
                        ExecuteNode(node.GetChild(i),context);
                    break;
             
            default:
                throw new IntepreterException("Ќеизвестный тип узла AST-дерева " + node.Line);
        }
        return 0;
    }

    public void Execute() {
        ExecuteNode(programNode, context);
    }


    private void add_div_sub(ITree node, string mess)
    {
        ITree parentm = node.Parent;
        while (parentm.Type != AstNodeType.ASSIGN)
            parentm = parentm.Parent;

        IdentDescr identMul = context.find_var(parentm.GetChild(0).Text);
        IdentDescr tmpMul;


        if (identMul.dataType.type == DataType.Type.my_string)
            throw new IntepreterException("Ќельз€ "+ mess +" строки " + parentm.Line);
        else
        {
            CommonTree nodeMul0 = (CommonTree)node.GetChild(0);
            if (nodeMul0.Type == AstNodeType.ADD || nodeMul0.Type == AstNodeType.MUL || nodeMul0.Type == AstNodeType.DIV || nodeMul0.Type == AstNodeType.SUB)
                ExecuteNode(node.GetChild(0), context);
            else if (nodeMul0.Type != AstNodeType.STRING && nodeMul0.Type != AstNodeType.REAL && nodeMul0.Type != AstNodeType.INTEGER)
            {
                tmpMul = context.find_var(nodeMul0.Text);
                if (null == tmpMul)
                    throw new SemException("переменна€ не описана " + nodeMul0.Text + " " + nodeMul0.Line);
                validate_convert(nodeMul0, tmpMul, identMul);
                mass_convert(identMul, 0, nodeMul0, tmpMul);
            }

            CommonTree nodeMul1 = (CommonTree)node.GetChild(1);
            if (nodeMul1.Type == AstNodeType.ADD || nodeMul1.Type == AstNodeType.MUL || nodeMul1.Type == AstNodeType.DIV || nodeMul1.Type == AstNodeType.SUB)
                ExecuteNode(node.GetChild(0), context);
            else if (nodeMul1.Type != AstNodeType.STRING && nodeMul1.Type != AstNodeType.REAL && nodeMul1.Type != AstNodeType.INTEGER)
            {
                tmpMul = context.find_var(nodeMul1.Text);
                if (null == tmpMul)
                    throw new SemException("переменна€ не описана " + nodeMul1.Text + " " + nodeMul1.Line);
                validate_convert(nodeMul1, tmpMul, identMul);
                mass_convert(identMul, 1, nodeMul1, tmpMul);
            }

            validate_convert(nodeMul0, identMul);
            validate_convert(nodeMul1, identMul);
            mass_convert(identMul, 0, nodeMul0);
            mass_convert(identMul, 1, nodeMul1);
        }
    }

    private void ConvertType(ITree node, int toType, int pos)
    {
        ITree parent = node.Parent;

        AstNode conv = new AstNode(new Antlr.Runtime.CommonToken(AstNodeType.CONVERT, "CONVERT")) { Parent = node.Parent };
        parent.SetChild(pos, conv);
        node.Parent = conv;
        switch (toType)
        {
            case AstNodeType.INTEGER:
                conv.AddChild(new AstNode(new Antlr.Runtime.CommonToken(AstNodeType.INTEGER, "INTEGER")){Parent = conv});
                break;
            case AstNodeType.REAL:
                conv.AddChild(new AstNode(new Antlr.Runtime.CommonToken(AstNodeType.REAL, "REAL")) { Parent = conv });
                break;
            case AstNodeType.STRING:
                conv.AddChild(new AstNode(new Antlr.Runtime.CommonToken(AstNodeType.STRING, "STRING")) { Parent = conv });
                break;
        }
        conv.AddChild(node);
        conv.AddChild(new AstNode());
        
    }

    private void validate_convert(CommonTree node, IdentDescr ident)
    {
        switch (node.Type)
        {
            case AstNodeType.REAL:
                if (ident.dataType.type == DataType.Type.my_integer)
                {
                    throw new SemException("Ќевозможно преобразовать real в integer " + node.Parent.Line);
                }
                break;
            case AstNodeType.STRING:
                if (ident.dataType.type != DataType.Type.my_string)
                {
                    throw new SemException("Ќевозможно преобразовать string в число " + node.Parent.Line);
                }
                break;
        }
    }
    private void validate_convert1(CommonTree node, IdentDescr ident)
    {
        switch (node.Type)
        {

            case AstNodeType.INTEGER:
                if (ident.dataType.type != DataType.Type.my_string)
                {
                    throw new SemException("ќшибка  " + node.Parent.Line);
                }
                break;

            case AstNodeType.STRING:
                if (ident.dataType.type != DataType.Type.my_integer)
                {
                    throw new SemException("ќшибка  " + node.Parent.Line);
                }
                break;
        }
    }
    private void validate_convert(CommonTree node,IdentDescr ident1, IdentDescr to_ident)
    {
        switch (ident1.dataType.type)
        {
            case DataType.Type.my_real:
                if (to_ident.dataType.type == DataType.Type.my_integer)
                {
                    throw new SemException("Ќевозможно преобразовать real в integer " + node.Parent.Line);
                }
                break;
            case DataType.Type.my_string:
                if (to_ident.dataType.type != DataType.Type.my_string)
                {
                    throw new SemException("Ќевозможно преобразовать string в число " + node.Parent.Line);
                }
                break;
        }
    }

    private void validate_compare(IdentDescr i1, IdentDescr i2)
    {
        switch (i1.dataType.type)
        {
            case DataType.Type.my_string:
                switch (i2.dataType.type)
                {
                    case DataType.Type.my_real:
                        throw new SemException("can't compare string and real");
                    case DataType.Type.my_integer:
                        throw new SemException("can't compare string and integer");
                }
                break;
            case DataType.Type.my_real:
                if (i2.dataType.type == DataType.Type.my_string)
                    throw new SemException("can't compare string and real");
                break;
            case DataType.Type.my_integer:
                if (i2.dataType.type == DataType.Type.my_string)
                    throw new SemException("can't compare string and real");
                break;
         
        }
        
        

    }

    private void validate_compare(ITree i1,  IdentDescr i2)
    {
        switch (i1.Type)
        {
            case AstNodeType.STRING:
                switch (i2.dataType.type)
                {
                    case DataType.Type.my_real:
                        throw new SemException("can't compare string and real");
                    case DataType.Type.my_integer:
                        throw new SemException("can't compare string and integer");
                }
                break;
            case AstNodeType.REAL:
                if (i2.dataType.type == DataType.Type.my_string)
                    throw new SemException("can't compare string and real");
                break;
            case AstNodeType.INTEGER:
                if (i2.dataType.type == DataType.Type.my_string)
                    throw new SemException("can't compare string and integer");
                break;
        }

    }

    private void validate_compare(ITree t1, ITree t2)
    {
        switch (t1.Type)
        {
            case AstNodeType.STRING:
                switch (t2.Type)
                {
                    case AstNodeType.REAL:
                        throw new SemException("can't compare string and real");
                    case AstNodeType.INTEGER:
                        throw new SemException("can't compare string and integer");
                }
                break;
            case AstNodeType.REAL:
                if(t2.Type == AstNodeType.STRING)
                    throw new SemException("can't compare string and real");
                break;
            case AstNodeType.INTEGER:
                if (t2.Type == AstNodeType.STRING)
                    throw new SemException("can't compare string and integer");
                break;
        }
    }

    private void mass_convert(IdentDescr ident, int pos, ITree node)
    {
        switch (node.Type)
        {
            case AstNodeType.INTEGER:
                if (ident.dataType.type == DataType.Type.my_real)
                {
                    ConvertType(node, AstNodeType.REAL, pos);
                }
                else if (ident.dataType.type == DataType.Type.my_string)
                {
                    ConvertType(node, AstNodeType.STRING, pos);
                }
                break;
            case AstNodeType.REAL:
                if (ident.dataType.type == DataType.Type.my_string)
                {
                    ConvertType(node, AstNodeType.STRING, pos);
                }
                break;


        }
    }

    private void mass_convert(IdentDescr ident, int pos, ITree node, IdentDescr from_ident)
    {
        switch (from_ident.dataType.type)
        {
            case DataType.Type.my_integer:
                if (ident.dataType.type == DataType.Type.my_real)
                {
                    ConvertType(node, AstNodeType.REAL, pos);
                }
                else if (ident.dataType.type == DataType.Type.my_string)
                {
                    ConvertType(node, AstNodeType.STRING, pos);
                }
                break;
            case DataType.Type.my_real:
                if (ident.dataType.type == DataType.Type.my_string)
                {
                    ConvertType(node, AstNodeType.STRING, pos);
                }
                break;


        }
    }
    

    public static void Execute(ITree programNode, Context context) {
        MathExprIntepreter mei=new MathExprIntepreter(programNode, context);
        mei.Execute();
    }
  }
}
