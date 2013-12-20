using System.Collections.Generic;
namespace MathExpr
{
  public class IdentDescr
  {
      //public const int VAR = 1;

      public enum VarType { var, parametr, ret_value, proc }; // var or parametr
      public bool init = false;
      public string name
      {
          get;
          set;
      }
      public DataType dataType = new DataType();
      public int countVar = 0;
      public VarType varType;
      public LinkedList<Parametr> parametrs; // list of parametrs
      
      //вообще, скорее всего нам будет достаточно хранить заначение в string
      public string value;
      public string stringValue = "";
      public int intValue = 0;
      public double realValue = 0;

      //public string name = "";
      public int pos = 0;
      //public DataType.Type type;
      
      /*
    public int Type {
      get;
    }
       */

      
  }
}
