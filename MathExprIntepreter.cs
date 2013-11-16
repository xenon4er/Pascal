using System;
using System.Globalization;
using Antlr.Runtime.Tree;
using System.Collections.Generic;
using AstNodeType = MathExpr.MathExprParser;


namespace MathExpr
{
  public class MathExprIntepreter
  {
    // "�������������������" ������ ��� ����� (� ������������ ������)
    public static readonly NumberFormatInfo NFI = new NumberFormatInfo();

    private ITree programNode = null;
    private Context context = null;

    

    public MathExprIntepreter(ITree programNode, Context context) {
      if (programNode.Type != AstNodeType.PROGRAM)
        throw new IntepreterException("AST-������ �� �������� ����������");

      this.programNode = programNode;
      this.context = context;
    }


    private double ExecuteNode(ITree node, Context context)
    {
        switch (node.Type)
        {
            case AstNodeType.UNKNOWN:
                throw new IntepreterException("�������������� ��� ���� AST-������ " + node.Line);

           

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
                            throw new IntepreterException("���������� ��� �������: ������ " + childIdent.Line); //add string where was exception
                        
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
                newIdentFunc.dataType.type = type_return; // �������� ������������ ��� �������

                CommonTree childName = (CommonTree)node.GetChild(1);
                newIdentFunc.name = childName.Text; //�������� ��� �������
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
                    throw new IntepreterException("������� ��� �������: ������ " +  childName.Line);
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
                                        throw new IntepreterException("�� ������ ��������: ������ " + childIdent.Line);

                                    context.idents.AddLast(newIdent);
                                }

                            }
                            break;
            
                    }
                }

                if (context.if_exists(newIdentProc.name))
                    throw new IntepreterException("��������� ��� �������: ������ " +  childName_p.Line);
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
                                        throw new IntepreterException("�� ������ ��������: ������ " + childIdent.Line);

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
                //������� find_var ������ ���� ����, �� ���������� ident, ���� ��� - null
                if (null == ident)
                {
                    throw new IntepreterException("���������� �� �������: ������ " + nodeAssign0.Line);
                }
                CommonTree nodeAssign1 = (CommonTree)node.GetChild(1);
                
            // ����� ��� ����������� ���������� � ������ ���������� ��������������
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
                break;

            case AstNodeType.FOR:
                //���������� ���������, ��� ���������� �� ������� ���� ���� �������, ����� ��� ����� ���� ������?
                break;
            case AstNodeType.WHILE:
                break;

            case AstNodeType.IF:
                break;
            
                // ��������, ���������� ����� �� �����. ��� �� ������ ��������� ����� ������
            case AstNodeType.COMPARE:
                break;

            case AstNodeType.ADD:
                //���, ��� � �����, ������������ ������ ��� childs
                ITree parent = node.Parent;
                //���� ����������, � ������� ����������, ����� ������ �� ���
                while (parent.Type != AstNodeType.ASSIGN)
                    parent = parent.Parent;
                IdentDescr ident1 = context.find_var(parent.GetChild(0).Text);
                
                CommonTree nodeAdd0 = (CommonTree)node.GetChild(0);
                if (nodeAdd0.Type == AstNodeType.ADD)
                    ExecuteNode(node.GetChild(0), context);
                CommonTree nodeAdd1 = (CommonTree)node.GetChild(1);
                
                validate_convert(nodeAdd0, ident1);
                validate_convert(nodeAdd1, ident1);
                mass_convert(ident1, 0, nodeAdd0);
                mass_convert(ident1, 1, nodeAdd1);

                break;
            case AstNodeType.MUL:
                //������ ����������� ������, ��� �� ��� � ������ �� ����� (��-�����) ��� ��� �� ������ ������ �� ��� ��������
                // ������ ����� ��(�����) ��� � �� ������ ����
                break;

            case AstNodeType.DIV:
                //����� ������ ����� �� ������ ����
                break;
            case AstNodeType.SUB:
                //����� ������ ����� �� ������ ����
            break;


            case AstNodeType.BLOCK:
                case AstNodeType.PROGRAM:
                    for (int i = 0; i < node.ChildCount; i++)
                        ExecuteNode(node.GetChild(i),context);
                    break;
             
            default:
                throw new IntepreterException("����������� ��� ���� AST-������ " + node.Line);
        }
        return 0;
    }

    public void Execute() {
        ExecuteNode(programNode, context);
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
                    throw new SemException("���������� ������������� real � integer " + node.Parent.Line);
                }
                break;
            case AstNodeType.STRING:
                if (ident.dataType.type != DataType.Type.my_string)
                {
                    throw new SemException("���������� ������������� string � ����� " + node.Parent.Line);
                }
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
    public static void Execute(ITree programNode, Context context) {
        MathExprIntepreter mei=new MathExprIntepreter(programNode, context);
        mei.Execute();
    }
  }
}
