grammar MathExpr;

options {
  language=CSharp2;
  output=AST;

  backtrack=true;
  memoize=true;
}


tokens {
  UNKNOWN             ;
  VAR  = 'var'        ;
  BLOCK               ;
 
  PROGRAM             ;
  FUNC_CALL           ;
  PARAMS              ;
  INC = 'inc'		  ;
  DEC = 'dec'		  ;
  FUNCTION = 'function'	  ;
  PROCEDURE = 'procedure' ;
  FOR  = 'for'        ;
  REPEAT  = 'repeat'  ;
  UNTIL  = 'until'    ;
  TO = 'to'           ;
  DO = 'do'           ;
  WHILE = 'while'     ;
  IF = 'if'           ;
  THEN = 'then'       ;
  ELSE = 'else'       ;
  DIV_INT = 'div'     ;
  MOD_INT = 'mod'     ;
  AND     = 'and'     ;
  OR      = 'or'      ;
  XOR     = 'xor'     ;
  DDD = ':';
  TTT = ';';
}


@lexer::namespace { MathExpr }
@parser::namespace { MathExpr }

@header {
  using System.Collections.Generic;
  using System.Globalization;
}

@members {
  // number format with decimal separator - '.'
  public static readonly NumberFormatInfo NFI = new NumberFormatInfo();
  
  // identifier values
  private Dictionary<string, IdentDescr> identTable = new Dictionary<string, IdentDescr>();
}


WS:
  ( ' ' | '\t' | '\f' | '\r' | '\n' )+ {
    $channel=HIDDEN;
  }
;

ML_COMMENT:
  '/*' ( options { greedy=false; } : . )* '*/' {
    $channel=HIDDEN;
  }
; 

INTEGER: (('0'..'9')+);

REAL: ('0'..'9')+ ('.' ('0'..'9')+);

STRING : '"' ( 'a'..'z' | 'A'..'Z' | '_' | '0'..'9' )+ '"';


IDENT:  ( 'a'..'z' | 'A'..'Z' | '_' )
        ( 'a'..'z' | 'A'..'Z' | '_' | '0'..'9' )*
;
ADD:    '+'     ;
SUB:    '-'     ;
MUL:    '*'     ;
DIV:    '/'     ;
ASSIGN: ':='    ;
COMPARE: '>' | '>=' | '<' | '<=' | '=' | '<>' ;


group:
  '('! term ')'!
| REAL -> REAL<NumAstNode>[double.Parse($REAL.text, NFI)]
| INTEGER
| STRING
| func_call
| IDENT
;


mult: group ( ( MUL | DIV | DIV_INT | MOD_INT | AND )^ group )*  ;
add:  mult  ( ( ADD | SUB | OR )^ mult  )*  ;
logic: add ( COMPARE^ add  )*  ;

term: logic  ;

params_: ( term (','! term)* )? ;

func_call:
  IDENT ( '(' params_ ')' )  ->
    ^(FUNC_CALL IDENT ^(PARAMS params_?))
	
;
	
func_descr:
	FUNCTION IDENT  '(' var_list? ')' ':' type ';' (var)? expr  ->
    ^(FUNCTION type IDENT  ^(PARAMS var_list)? ^(var)? ^( expr))
;

proc_descr:
	PROCEDURE IDENT  '(' var_list? ')' ';' (var)? expr ->
    ^(PROCEDURE  IDENT  ^(PARAMS var_list)? ^(var)? ^(expr))
;	

var:
	'var' var_list -> ^(VAR var_list)
	;

var_list: 
	exprvar (';'!)+ (exprvar (';'!)+)* 
	| exprvar (';'!)* (exprvar (';'!)*)*
	;

exprvar:
	ident_list (':' type) (';')? -> ^(':' type ident_list)
	|IDENT ':' 'array' '[' INTEGER '..' INTEGER  ']' 'of' type (';')? -> ^('array' type IDENT INTEGER INTEGER)
	;


type:
	'real' -> REAL
	| 'integer' -> INTEGER
	| 'string' -> STRING
	;

ident_list:
	IDENT (','! IDENT)*
	;

expr:
	 IDENT ASSIGN^ term
	| IDENT -> ^(FUNC_CALL IDENT PARAMS)
	| 'begin' expr_list 'end' -> ^(BLOCK expr_list)
	| FOR^ IDENT ASSIGN! term TO! term DO! expr
	| WHILE^ logic DO! expr
	| REPEAT^ expr_list UNTIL! logic  
	| IF^ logic THEN! expr ( ELSE! expr)?
	| INC^ '('! IDENT ')'!
	| DEC^ '('! IDENT ')'!
	| func_call 
	| func_descr
	| proc_descr
	;

expr_list:
	 (';'!)* var? expr ((';'!)+ expr)* (';'!)*  
	;


program:
	expr_list;

result: program -> ^(PROGRAM program);

execute:
  result
;
