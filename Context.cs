using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpr
{
    public class Context
    {
        public Context upper;
        public LinkedList<IdentDescr> idents = new LinkedList<IdentDescr>();
        
        public bool if_exists(string name)
        {
            LinkedListNode<IdentDescr> k;
            for (k = idents.First; k != null; k = k.Next)
            {
                if (k.Value.name.CompareTo(name) == 0)
                    return true;
            }
                return false;
        }

        public bool find_var(string name)
        {
            LinkedListNode<IdentDescr> k;
            LinkedList<IdentDescr> tmp = idents;
            Context tmpCon = this;
            
            while(tmpCon != null)
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
    }
}
