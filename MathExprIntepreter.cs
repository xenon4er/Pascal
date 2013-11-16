using System;
using System.Globalization;
using Antlr.Runtime.Tree;
using System.Collections.Generic;
using AstNodeType = MathExpr.MathExprParser;


namespace MathExpr
{
  public class MathExprIntepreter
  {
    // "культуронезависимый" формат для чисел (с разделителем точкой)
    public static readonly NumberFormatInfo NFI = new NumberFormatInfo();

    private ITree programNode = null;
    private Context context = null;

    

    public MathExprIntepreter(ITree programNode, Context context) {
      if (programNode.Type != AstNodeType.PROGRAM)
        throw new IntepreterException("AST-дерево не является программой");

      this.programNode = programNode;
      this.context = context;
    }


    private double ExecuteNode(ITree node, Context context)
    {
        switch (node.Type)
        {
            case AstNodeType.UNKNOWN:
                throw new IntepreterException("Неопределенный тип узла AST-дерева");

           

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
                            throw new IntepreterException("переменная уже описана: строка " + childIdent.Line); //add string where was exception
                        
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
                newIdentFunc.name = childName.Text; //получили имя функции
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
                    throw new IntepreterException("функция уже описана: строка " +  childName.Line);
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
                                        throw new IntepreterException("Не верный параметр: строка " + childIdent.Line);

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
                                        throw new IntepreterException("Не верный параметр: строка " + childIdent.Line);

                                    context.idents.AddLast(newIdent);
                                }

                            }
                            break;
            
                    }
                }

           
                break;

            
            case AstNodeType.REAL:              
                return ((NumAstNode)node).Value;
                break;

            case AstNodeType.INTEGER:

                break;
            
            case AstNodeType.STRING:
                break;

            case AstNodeType.ASSIGN:
                CommonTree childNodeAssign = (CommonTree)node.GetChild(0);
                if (!context.find_var(childNodeAssign.Text))
                {
                    throw new IntepreterException("Переменная не описана: строка " + childNodeAssign.Line);
                }
                //AstNodeType t = node.GetChild(1).Type;
                ExecuteNode(node.GetChild(1),context);
                break;
            
            case AstNodeType.REPEAT:
                break;

            case AstNodeType.FOR:
                break;
            case AstNodeType.WHILE:
                break;

            case AstNodeType.IF:
                break;
            
            case AstNodeType.COMPARE:
                break;

            case AstNodeType.ADD:
                for (int i = 0; i < node.ChildCount; i++)
                {
                    CommonTree childNode = (CommonTree)node.GetChild(i);
                    

                }
                break;
            case AstNodeType.BLOCK:
                case AstNodeType.PROGRAM:
                    for (int i = 0; i < node.ChildCount; i++)
                        ExecuteNode(node.GetChild(i),context);
                    break;
             
            default:
                throw new IntepreterException("Неизвестный тип узла AST-дерева");
        }
        return 0;
    }

    public void Execute() {
        ExecuteNode(programNode, context);
    }


    public static void Execute(ITree programNode, Context context) {
        MathExprIntepreter mei=new MathExprIntepreter(programNode, context);
        mei.Execute();
    }
  }
}
