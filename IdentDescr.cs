using System.Collections.Generic;
namespace MathExpr
{
  public class IdentDescr
  {
      //public const int VAR = 1;

      public enum VarType { var, parametr, ret_value }; // var or parametr
      
      public string name
      {
          get;
          set;
      }
      public DataType dataType = new DataType();

      public VarType varType;
      public LinkedList<Parametr> parametrs; // list of parametrs
      
      public string stringValue = "";
      public int intValue = 0;
      public float realValue = 0;
      /*
    public int Type {
      get;
    }
       */

      
  }
}
