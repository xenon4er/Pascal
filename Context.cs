using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpr
{
    public class Context
    {
        public Context upper;
        public LinkedList<Context> childs = new LinkedList<Context>();
        public LinkedList<IdentDescr> idents = new LinkedList<IdentDescr>();
        public LinkedList<Parametr> parametrs = new LinkedList<Parametr>();
        public string f_p_name = "";

        public bool if_exists(string name, VarDescr.VarType t1, VarDescr.VarType t2)
        {
            LinkedListNode<IdentDescr> k;
            for (k = idents.First; k != null; k = k.Next)
            {
                if (k.Value.name.CompareTo(name) == 0)
                    if((k.Value.varType==t1)||(k.Value.varType==t2))
                        return true;
                
            }
            return false;
        }

        public bool if_exists_everywhere(string name)
        {
            LinkedListNode<IdentDescr> k;
            LinkedList<IdentDescr> tmp = idents;
            Context tmpCon = this;

            while (tmpCon != null)
            {
                for (k = tmp.First; k != null; k = k.Next)
                {
                    if (k.Value.name.CompareTo(name) == 0)
                        return true;

                }
                tmpCon = tmpCon.upper;
                if (tmpCon != null)
                    tmp = tmpCon.idents;
            }
            return false;
        }

        public IdentDescr get_var(string name)
        {
            LinkedListNode<IdentDescr> k;
            LinkedList<IdentDescr> tmp = idents;
            for (k = tmp.First; k != null; k = k.Next)
            {
                if (k.Value.name.CompareTo(name) == 0)
                    if ((k.Value.varType == VarDescr.VarType.var))
                        return k.Value;
            }
            return null;
        }

        public IdentDescr find_var(string name)
        {
            LinkedListNode<IdentDescr> k;
            LinkedList<IdentDescr> tmp = idents;
            LinkedList<Parametr> tmpPar = parametrs;
            
            Context tmpCon = this;
            
            while(tmpCon != null)
            {
                for (k = tmp.First; k != null; k = k.Next)
                {
                    if (k.Value.name.CompareTo(name) == 0)
                        if((k.Value.varType==VarDescr.VarType.var)||(k.Value.varType==VarDescr.VarType.parametr))
                            return k.Value;
                }
                tmpCon = tmpCon.upper;
                if (tmpCon != null)
                    tmp = tmpCon.idents;
            }
            return null;
        }

        public bool find_parametr(int pos, DataType.Type t)
        {
            LinkedListNode<IdentDescr> k;
            LinkedList<IdentDescr> tmp = idents;
            for(k = tmp.First; k != null; k = k.Next)
            {
                if (k.Value.varType == VarDescr.VarType.parametr)
                    if (k.Value.pos == pos)
                        if (k.Value.dataType.type == t)
                            return true;

            }
            return false;
        }

        public Context find_context(string name)
        {
            LinkedListNode<IdentDescr> k;
            LinkedList<IdentDescr> tmp = idents;
            LinkedList<Parametr> tmpPar = parametrs;
            LinkedListNode<Context> i;
            Context tmpCon = this;

            //if (name == "print")
                //return Program.mainContext;

            while (tmpCon != null)
            {
                for (k = tmp.First; k != null; k = k.Next)
                {
                    if (k.Value.name.CompareTo(name) == 0)
                    {
                        for (i = tmpCon.childs.First; i != null; i = i.Next)
                        {
                            if (i.Value.f_p_name.CompareTo(name) == 0)
                                return i.Value;
                        }
                    }
                }
                tmpCon = tmpCon.upper;
                if (tmpCon != null)
                    tmp = tmpCon.idents;
            }
            return null;
        }

        public Parametr find_par(string name)
        {
            LinkedListNode<Parametr> k;
            LinkedList<Parametr> tmpPar = parametrs;
            for (k = tmpPar.First; k != null; k = k.Next)
            {
                if (k.Value.name.CompareTo(name) == 0)
                    return k.Value;
            }
            return null;
        }
    }
}
