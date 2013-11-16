// $ANTLR 3.2 Sep 23, 2009 12:02:23 MathExpr.g 2013-11-05 17:58:41

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


  using System.Collections.Generic;
  using System.Globalization;


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;

using IDictionary	= System.Collections.IDictionary;
using Hashtable 	= System.Collections.Hashtable;

using Antlr.Runtime.Tree;

namespace  MathExpr 
{
public partial class MathExprParser : Parser
{
    public static readonly string[] tokenNames = new string[] 
	{
        "<invalid>", 
		"<EOR>", 
		"<DOWN>", 
		"<UP>", 
		"UNKNOWN", 
		"VAR", 
		"BLOCK", 
		"PROGRAM", 
		"FUNC_CALL", 
		"PARAMS", 
		"INC", 
		"DEC", 
		"FUNCTION", 
		"PROCEDURE", 
		"FOR", 
		"REPEAT", 
		"UNTIL", 
		"TO", 
		"DO", 
		"WHILE", 
		"IF", 
		"THEN", 
		"ELSE", 
		"DIV_INT", 
		"MOD_INT", 
		"AND", 
		"OR", 
		"XOR", 
		"DDD", 
		"TTT", 
		"WS", 
		"ML_COMMENT", 
		"INTEGER", 
		"REAL", 
		"STRING", 
		"IDENT", 
		"ADD", 
		"SUB", 
		"MUL", 
		"DIV", 
		"ASSIGN", 
		"COMPARE", 
		"'('", 
		"')'", 
		"','", 
		"'array'", 
		"'['", 
		"'..'", 
		"']'", 
		"'of'", 
		"'real'", 
		"'integer'", 
		"'string'", 
		"'begin'", 
		"'end'"
    };

    public const int FUNCTION = 12;
    public const int DEC = 11;
    public const int MOD_INT = 24;
    public const int WHILE = 19;
    public const int FOR = 14;
    public const int DO = 18;
    public const int SUB = 37;
    public const int TTT = 29;
    public const int AND = 25;
    public const int EOF = -1;
    public const int FUNC_CALL = 8;
    public const int IF = 20;
    public const int ML_COMMENT = 31;
    public const int INC = 10;
    public const int T__51 = 51;
    public const int T__52 = 52;
    public const int THEN = 21;
    public const int T__53 = 53;
    public const int DDD = 28;
    public const int UNKNOWN = 4;
    public const int T__54 = 54;
    public const int COMPARE = 41;
    public const int IDENT = 35;
    public const int VAR = 5;
    public const int T__50 = 50;
    public const int ADD = 36;
    public const int PARAMS = 9;
    public const int INTEGER = 32;
    public const int T__42 = 42;
    public const int T__43 = 43;
    public const int T__46 = 46;
    public const int XOR = 27;
    public const int T__47 = 47;
    public const int T__44 = 44;
    public const int T__45 = 45;
    public const int TO = 17;
    public const int T__48 = 48;
    public const int T__49 = 49;
    public const int DIV_INT = 23;
    public const int ELSE = 22;
    public const int MUL = 38;
    public const int PROCEDURE = 13;
    public const int REAL = 33;
    public const int WS = 30;
    public const int UNTIL = 16;
    public const int BLOCK = 6;
    public const int OR = 26;
    public const int ASSIGN = 40;
    public const int PROGRAM = 7;
    public const int REPEAT = 15;
    public const int DIV = 39;
    public const int STRING = 34;

    // delegates
    // delegators



        public MathExprParser(ITokenStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public MathExprParser(ITokenStream input, RecognizerSharedState state)
    		: base(input, state) {
            InitializeCyclicDFAs();
            this.state.ruleMemo = new Hashtable[69+1];
             
             
        }
        
    protected ITreeAdaptor adaptor = new CommonTreeAdaptor();

    public ITreeAdaptor TreeAdaptor
    {
        get { return this.adaptor; }
        set {
    	this.adaptor = value;
    	}
    }

    override public string[] TokenNames {
		get { return MathExprParser.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "MathExpr.g"; }
    }


      // number format with decimal separator - '.'
      public static readonly NumberFormatInfo NFI = new NumberFormatInfo();
      
      // identifier values
      private Dictionary<string, IdentDescr> identTable = new Dictionary<string, IdentDescr>();


    public class group_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "group"
    // MathExpr.g:90:1: group : ( '(' term ')' | REAL -> REAL[double.Parse($REAL.text, NFI)] | INTEGER | STRING | func_call | IDENT );
    public MathExprParser.group_return group() // throws RecognitionException [1]
    {   
        MathExprParser.group_return retval = new MathExprParser.group_return();
        retval.Start = input.LT(1);
        int group_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal1 = null;
        IToken char_literal3 = null;
        IToken REAL4 = null;
        IToken INTEGER5 = null;
        IToken STRING6 = null;
        IToken IDENT8 = null;
        MathExprParser.term_return term2 = default(MathExprParser.term_return);

        MathExprParser.func_call_return func_call7 = default(MathExprParser.func_call_return);


        object char_literal1_tree=null;
        object char_literal3_tree=null;
        object REAL4_tree=null;
        object INTEGER5_tree=null;
        object STRING6_tree=null;
        object IDENT8_tree=null;
        RewriteRuleTokenStream stream_REAL = new RewriteRuleTokenStream(adaptor,"token REAL");

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 1) ) 
    	    {
    	    	return retval; 
    	    }
            // MathExpr.g:90:6: ( '(' term ')' | REAL -> REAL[double.Parse($REAL.text, NFI)] | INTEGER | STRING | func_call | IDENT )
            int alt1 = 6;
            switch ( input.LA(1) ) 
            {
            case 42:
            	{
                alt1 = 1;
                }
                break;
            case REAL:
            	{
                alt1 = 2;
                }
                break;
            case INTEGER:
            	{
                alt1 = 3;
                }
                break;
            case STRING:
            	{
                alt1 = 4;
                }
                break;
            case IDENT:
            	{
                int LA1_5 = input.LA(2);

                if ( (LA1_5 == EOF || (LA1_5 >= UNTIL && LA1_5 <= DO) || (LA1_5 >= THEN && LA1_5 <= OR) || LA1_5 == TTT || (LA1_5 >= ADD && LA1_5 <= DIV) || LA1_5 == COMPARE || (LA1_5 >= 43 && LA1_5 <= 44) || LA1_5 == 54) )
                {
                    alt1 = 6;
                }
                else if ( (LA1_5 == 42) )
                {
                    alt1 = 5;
                }
                else 
                {
                    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                    NoViableAltException nvae_d1s5 =
                        new NoViableAltException("", 1, 5, input);

                    throw nvae_d1s5;
                }
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            	    NoViableAltException nvae_d1s0 =
            	        new NoViableAltException("", 1, 0, input);

            	    throw nvae_d1s0;
            }

            switch (alt1) 
            {
                case 1 :
                    // MathExpr.g:91:3: '(' term ')'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal1=(IToken)Match(input,42,FOLLOW_42_in_group784); if (state.failed) return retval;
                    	PushFollow(FOLLOW_term_in_group787);
                    	term2 = term();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, term2.Tree);
                    	char_literal3=(IToken)Match(input,43,FOLLOW_43_in_group789); if (state.failed) return retval;

                    }
                    break;
                case 2 :
                    // MathExpr.g:92:3: REAL
                    {
                    	REAL4=(IToken)Match(input,REAL,FOLLOW_REAL_in_group794); if (state.failed) return retval; 
                    	if ( (state.backtracking==0) ) stream_REAL.Add(REAL4);



                    	// AST REWRITE
                    	// elements:          REAL
                    	// token labels:      
                    	// rule labels:       retval
                    	// token list labels: 
                    	// rule list labels:  
                    	// wildcard labels: 
                    	if ( (state.backtracking==0) ) {
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

                    	root_0 = (object)adaptor.GetNilNode();
                    	// 92:8: -> REAL[double.Parse($REAL.text, NFI)]
                    	{
                    	    adaptor.AddChild(root_0, new NumAstNode(REAL, double.Parse(((REAL4 != null) ? REAL4.Text : null), NFI)));

                    	}

                    	retval.Tree = root_0;retval.Tree = root_0;}
                    }
                    break;
                case 3 :
                    // MathExpr.g:93:3: INTEGER
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	INTEGER5=(IToken)Match(input,INTEGER,FOLLOW_INTEGER_in_group806); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{INTEGER5_tree = (object)adaptor.Create(INTEGER5);
                    		adaptor.AddChild(root_0, INTEGER5_tree);
                    	}

                    }
                    break;
                case 4 :
                    // MathExpr.g:94:3: STRING
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	STRING6=(IToken)Match(input,STRING,FOLLOW_STRING_in_group810); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{STRING6_tree = (object)adaptor.Create(STRING6);
                    		adaptor.AddChild(root_0, STRING6_tree);
                    	}

                    }
                    break;
                case 5 :
                    // MathExpr.g:95:3: func_call
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_func_call_in_group814);
                    	func_call7 = func_call();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, func_call7.Tree);

                    }
                    break;
                case 6 :
                    // MathExpr.g:96:3: IDENT
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	IDENT8=(IToken)Match(input,IDENT,FOLLOW_IDENT_in_group818); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{IDENT8_tree = (object)adaptor.Create(IDENT8);
                    		adaptor.AddChild(root_0, IDENT8_tree);
                    	}

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 1, group_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "group"

    public class mult_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "mult"
    // MathExpr.g:100:1: mult : group ( ( MUL | DIV | DIV_INT | MOD_INT | AND ) group )* ;
    public MathExprParser.mult_return mult() // throws RecognitionException [1]
    {   
        MathExprParser.mult_return retval = new MathExprParser.mult_return();
        retval.Start = input.LT(1);
        int mult_StartIndex = input.Index();
        object root_0 = null;

        IToken set10 = null;
        MathExprParser.group_return group9 = default(MathExprParser.group_return);

        MathExprParser.group_return group11 = default(MathExprParser.group_return);


        object set10_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 2) ) 
    	    {
    	    	return retval; 
    	    }
            // MathExpr.g:100:5: ( group ( ( MUL | DIV | DIV_INT | MOD_INT | AND ) group )* )
            // MathExpr.g:100:7: group ( ( MUL | DIV | DIV_INT | MOD_INT | AND ) group )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_group_in_mult827);
            	group9 = group();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, group9.Tree);
            	// MathExpr.g:100:13: ( ( MUL | DIV | DIV_INT | MOD_INT | AND ) group )*
            	do 
            	{
            	    int alt2 = 2;
            	    int LA2_0 = input.LA(1);

            	    if ( ((LA2_0 >= DIV_INT && LA2_0 <= AND) || (LA2_0 >= MUL && LA2_0 <= DIV)) )
            	    {
            	        alt2 = 1;
            	    }


            	    switch (alt2) 
            		{
            			case 1 :
            			    // MathExpr.g:100:15: ( MUL | DIV | DIV_INT | MOD_INT | AND ) group
            			    {
            			    	set10=(IToken)input.LT(1);
            			    	set10 = (IToken)input.LT(1);
            			    	if ( (input.LA(1) >= DIV_INT && input.LA(1) <= AND) || (input.LA(1) >= MUL && input.LA(1) <= DIV) ) 
            			    	{
            			    	    input.Consume();
            			    	    if ( state.backtracking == 0 ) root_0 = (object)adaptor.BecomeRoot((object)adaptor.Create(set10), root_0);
            			    	    state.errorRecovery = false;state.failed = false;
            			    	}
            			    	else 
            			    	{
            			    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	PushFollow(FOLLOW_group_in_mult854);
            			    	group11 = group();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, group11.Tree);

            			    }
            			    break;

            			default:
            			    goto loop2;
            	    }
            	} while (true);

            	loop2:
            		;	// Stops C# compiler whining that label 'loop2' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 2, mult_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "mult"

    public class add_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "add"
    // MathExpr.g:101:1: add : mult ( ( ADD | SUB | OR ) mult )* ;
    public MathExprParser.add_return add() // throws RecognitionException [1]
    {   
        MathExprParser.add_return retval = new MathExprParser.add_return();
        retval.Start = input.LT(1);
        int add_StartIndex = input.Index();
        object root_0 = null;

        IToken set13 = null;
        MathExprParser.mult_return mult12 = default(MathExprParser.mult_return);

        MathExprParser.mult_return mult14 = default(MathExprParser.mult_return);


        object set13_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 3) ) 
    	    {
    	    	return retval; 
    	    }
            // MathExpr.g:101:4: ( mult ( ( ADD | SUB | OR ) mult )* )
            // MathExpr.g:101:7: mult ( ( ADD | SUB | OR ) mult )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_mult_in_add866);
            	mult12 = mult();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, mult12.Tree);
            	// MathExpr.g:101:13: ( ( ADD | SUB | OR ) mult )*
            	do 
            	{
            	    int alt3 = 2;
            	    int LA3_0 = input.LA(1);

            	    if ( (LA3_0 == OR || (LA3_0 >= ADD && LA3_0 <= SUB)) )
            	    {
            	        alt3 = 1;
            	    }


            	    switch (alt3) 
            		{
            			case 1 :
            			    // MathExpr.g:101:15: ( ADD | SUB | OR ) mult
            			    {
            			    	set13=(IToken)input.LT(1);
            			    	set13 = (IToken)input.LT(1);
            			    	if ( input.LA(1) == OR || (input.LA(1) >= ADD && input.LA(1) <= SUB) ) 
            			    	{
            			    	    input.Consume();
            			    	    if ( state.backtracking == 0 ) root_0 = (object)adaptor.BecomeRoot((object)adaptor.Create(set13), root_0);
            			    	    state.errorRecovery = false;state.failed = false;
            			    	}
            			    	else 
            			    	{
            			    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	PushFollow(FOLLOW_mult_in_add886);
            			    	mult14 = mult();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, mult14.Tree);

            			    }
            			    break;

            			default:
            			    goto loop3;
            	    }
            	} while (true);

            	loop3:
            		;	// Stops C# compiler whining that label 'loop3' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 3, add_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "add"

    public class logic_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "logic"
    // MathExpr.g:102:1: logic : add ( COMPARE add )* ;
    public MathExprParser.logic_return logic() // throws RecognitionException [1]
    {   
        MathExprParser.logic_return retval = new MathExprParser.logic_return();
        retval.Start = input.LT(1);
        int logic_StartIndex = input.Index();
        object root_0 = null;

        IToken COMPARE16 = null;
        MathExprParser.add_return add15 = default(MathExprParser.add_return);

        MathExprParser.add_return add17 = default(MathExprParser.add_return);


        object COMPARE16_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 4) ) 
    	    {
    	    	return retval; 
    	    }
            // MathExpr.g:102:6: ( add ( COMPARE add )* )
            // MathExpr.g:102:8: add ( COMPARE add )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_add_in_logic898);
            	add15 = add();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, add15.Tree);
            	// MathExpr.g:102:12: ( COMPARE add )*
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);

            	    if ( (LA4_0 == COMPARE) )
            	    {
            	        alt4 = 1;
            	    }


            	    switch (alt4) 
            		{
            			case 1 :
            			    // MathExpr.g:102:14: COMPARE add
            			    {
            			    	COMPARE16=(IToken)Match(input,COMPARE,FOLLOW_COMPARE_in_logic902); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{COMPARE16_tree = (object)adaptor.Create(COMPARE16);
            			    		root_0 = (object)adaptor.BecomeRoot(COMPARE16_tree, root_0);
            			    	}
            			    	PushFollow(FOLLOW_add_in_logic905);
            			    	add17 = add();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, add17.Tree);

            			    }
            			    break;

            			default:
            			    goto loop4;
            	    }
            	} while (true);

            	loop4:
            		;	// Stops C# compiler whining that label 'loop4' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 4, logic_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "logic"

    public class term_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "term"
    // MathExpr.g:104:1: term : logic ;
    public MathExprParser.term_return term() // throws RecognitionException [1]
    {   
        MathExprParser.term_return retval = new MathExprParser.term_return();
        retval.Start = input.LT(1);
        int term_StartIndex = input.Index();
        object root_0 = null;

        MathExprParser.logic_return logic18 = default(MathExprParser.logic_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 5) ) 
    	    {
    	    	return retval; 
    	    }
            // MathExpr.g:104:5: ( logic )
            // MathExpr.g:104:7: logic
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_logic_in_term918);
            	logic18 = logic();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logic18.Tree);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 5, term_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "term"

    public class params__return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "params_"
    // MathExpr.g:106:1: params_ : ( term ( ',' term )* )? ;
    public MathExprParser.params__return params_() // throws RecognitionException [1]
    {   
        MathExprParser.params__return retval = new MathExprParser.params__return();
        retval.Start = input.LT(1);
        int params__StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal20 = null;
        MathExprParser.term_return term19 = default(MathExprParser.term_return);

        MathExprParser.term_return term21 = default(MathExprParser.term_return);


        object char_literal20_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 6) ) 
    	    {
    	    	return retval; 
    	    }
            // MathExpr.g:106:8: ( ( term ( ',' term )* )? )
            // MathExpr.g:106:10: ( term ( ',' term )* )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// MathExpr.g:106:10: ( term ( ',' term )* )?
            	int alt6 = 2;
            	int LA6_0 = input.LA(1);

            	if ( ((LA6_0 >= INTEGER && LA6_0 <= IDENT) || LA6_0 == 42) )
            	{
            	    alt6 = 1;
            	}
            	switch (alt6) 
            	{
            	    case 1 :
            	        // MathExpr.g:106:12: term ( ',' term )*
            	        {
            	        	PushFollow(FOLLOW_term_in_params_929);
            	        	term19 = term();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, term19.Tree);
            	        	// MathExpr.g:106:17: ( ',' term )*
            	        	do 
            	        	{
            	        	    int alt5 = 2;
            	        	    int LA5_0 = input.LA(1);

            	        	    if ( (LA5_0 == 44) )
            	        	    {
            	        	        alt5 = 1;
            	        	    }


            	        	    switch (alt5) 
            	        		{
            	        			case 1 :
            	        			    // MathExpr.g:106:18: ',' term
            	        			    {
            	        			    	char_literal20=(IToken)Match(input,44,FOLLOW_44_in_params_932); if (state.failed) return retval;
            	        			    	PushFollow(FOLLOW_term_in_params_935);
            	        			    	term21 = term();
            	        			    	state.followingStackPointer--;
            	        			    	if (state.failed) return retval;
            	        			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, term21.Tree);

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop5;
            	        	    }
            	        	} while (true);

            	        	loop5:
            	        		;	// Stops C# compiler whining that label 'loop5' has no statements


            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 6, params__StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "params_"

    public class func_call_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "func_call"
    // MathExpr.g:108:1: func_call : IDENT ( '(' params_ ')' ) -> ^( FUNC_CALL IDENT ^( PARAMS ( params_ )? ) ) ;
    public MathExprParser.func_call_return func_call() // throws RecognitionException [1]
    {   
        MathExprParser.func_call_return retval = new MathExprParser.func_call_return();
        retval.Start = input.LT(1);
        int func_call_StartIndex = input.Index();
        object root_0 = null;

        IToken IDENT22 = null;
        IToken char_literal23 = null;
        IToken char_literal25 = null;
        MathExprParser.params__return params_24 = default(MathExprParser.params__return);


        object IDENT22_tree=null;
        object char_literal23_tree=null;
        object char_literal25_tree=null;
        RewriteRuleTokenStream stream_IDENT = new RewriteRuleTokenStream(adaptor,"token IDENT");
        RewriteRuleTokenStream stream_43 = new RewriteRuleTokenStream(adaptor,"token 43");
        RewriteRuleTokenStream stream_42 = new RewriteRuleTokenStream(adaptor,"token 42");
        RewriteRuleSubtreeStream stream_params_ = new RewriteRuleSubtreeStream(adaptor,"rule params_");
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 7) ) 
    	    {
    	    	return retval; 
    	    }
            // MathExpr.g:108:10: ( IDENT ( '(' params_ ')' ) -> ^( FUNC_CALL IDENT ^( PARAMS ( params_ )? ) ) )
            // MathExpr.g:109:3: IDENT ( '(' params_ ')' )
            {
            	IDENT22=(IToken)Match(input,IDENT,FOLLOW_IDENT_in_func_call950); if (state.failed) return retval; 
            	if ( (state.backtracking==0) ) stream_IDENT.Add(IDENT22);

            	// MathExpr.g:109:9: ( '(' params_ ')' )
            	// MathExpr.g:109:11: '(' params_ ')'
            	{
            		char_literal23=(IToken)Match(input,42,FOLLOW_42_in_func_call954); if (state.failed) return retval; 
            		if ( (state.backtracking==0) ) stream_42.Add(char_literal23);

            		PushFollow(FOLLOW_params__in_func_call956);
            		params_24 = params_();
            		state.followingStackPointer--;
            		if (state.failed) return retval;
            		if ( (state.backtracking==0) ) stream_params_.Add(params_24.Tree);
            		char_literal25=(IToken)Match(input,43,FOLLOW_43_in_func_call958); if (state.failed) return retval; 
            		if ( (state.backtracking==0) ) stream_43.Add(char_literal25);


            	}



            	// AST REWRITE
            	// elements:          IDENT, params_
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	// wildcard labels: 
            	if ( (state.backtracking==0) ) {
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

            	root_0 = (object)adaptor.GetNilNode();
            	// 109:30: -> ^( FUNC_CALL IDENT ^( PARAMS ( params_ )? ) )
            	{
            	    // MathExpr.g:110:5: ^( FUNC_CALL IDENT ^( PARAMS ( params_ )? ) )
            	    {
            	    object root_1 = (object)adaptor.GetNilNode();
            	    root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(FUNC_CALL, "FUNC_CALL"), root_1);

            	    adaptor.AddChild(root_1, stream_IDENT.NextNode());
            	    // MathExpr.g:110:23: ^( PARAMS ( params_ )? )
            	    {
            	    object root_2 = (object)adaptor.GetNilNode();
            	    root_2 = (object)adaptor.BecomeRoot((object)adaptor.Create(PARAMS, "PARAMS"), root_2);

            	    // MathExpr.g:110:32: ( params_ )?
            	    if ( stream_params_.HasNext() )
            	    {
            	        adaptor.AddChild(root_2, stream_params_.NextTree());

            	    }
            	    stream_params_.Reset();

            	    adaptor.AddChild(root_1, root_2);
            	    }

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;}
            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 7, func_call_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "func_call"

    public class func_descr_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "func_descr"
    // MathExpr.g:114:1: func_descr : FUNCTION IDENT '(' ( var_list )? ')' ':' type ';' ( var )? expr -> ^( FUNCTION type IDENT ( ^( PARAMS var_list ) )? ( ^( var ) )? ^( expr ) ) ;
    public MathExprParser.func_descr_return func_descr() // throws RecognitionException [1]
    {   
        MathExprParser.func_descr_return retval = new MathExprParser.func_descr_return();
        retval.Start = input.LT(1);
        int func_descr_StartIndex = input.Index();
        object root_0 = null;

        IToken FUNCTION26 = null;
        IToken IDENT27 = null;
        IToken char_literal28 = null;
        IToken char_literal30 = null;
        IToken char_literal31 = null;
        IToken char_literal33 = null;
        MathExprParser.var_list_return var_list29 = default(MathExprParser.var_list_return);

        MathExprParser.type_return type32 = default(MathExprParser.type_return);

        MathExprParser.var_return var34 = default(MathExprParser.var_return);

        MathExprParser.expr_return expr35 = default(MathExprParser.expr_return);


        object FUNCTION26_tree=null;
        object IDENT27_tree=null;
        object char_literal28_tree=null;
        object char_literal30_tree=null;
        object char_literal31_tree=null;
        object char_literal33_tree=null;
        RewriteRuleTokenStream stream_FUNCTION = new RewriteRuleTokenStream(adaptor,"token FUNCTION");
        RewriteRuleTokenStream stream_IDENT = new RewriteRuleTokenStream(adaptor,"token IDENT");
        RewriteRuleTokenStream stream_43 = new RewriteRuleTokenStream(adaptor,"token 43");
        RewriteRuleTokenStream stream_42 = new RewriteRuleTokenStream(adaptor,"token 42");
        RewriteRuleTokenStream stream_DDD = new RewriteRuleTokenStream(adaptor,"token DDD");
        RewriteRuleTokenStream stream_TTT = new RewriteRuleTokenStream(adaptor,"token TTT");
        RewriteRuleSubtreeStream stream_var = new RewriteRuleSubtreeStream(adaptor,"rule var");
        RewriteRuleSubtreeStream stream_var_list = new RewriteRuleSubtreeStream(adaptor,"rule var_list");
        RewriteRuleSubtreeStream stream_expr = new RewriteRuleSubtreeStream(adaptor,"rule expr");
        RewriteRuleSubtreeStream stream_type = new RewriteRuleSubtreeStream(adaptor,"rule type");
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 8) ) 
    	    {
    	    	return retval; 
    	    }
            // MathExpr.g:114:11: ( FUNCTION IDENT '(' ( var_list )? ')' ':' type ';' ( var )? expr -> ^( FUNCTION type IDENT ( ^( PARAMS var_list ) )? ( ^( var ) )? ^( expr ) ) )
            // MathExpr.g:115:2: FUNCTION IDENT '(' ( var_list )? ')' ':' type ';' ( var )? expr
            {
            	FUNCTION26=(IToken)Match(input,FUNCTION,FOLLOW_FUNCTION_in_func_descr992); if (state.failed) return retval; 
            	if ( (state.backtracking==0) ) stream_FUNCTION.Add(FUNCTION26);

            	IDENT27=(IToken)Match(input,IDENT,FOLLOW_IDENT_in_func_descr994); if (state.failed) return retval; 
            	if ( (state.backtracking==0) ) stream_IDENT.Add(IDENT27);

            	char_literal28=(IToken)Match(input,42,FOLLOW_42_in_func_descr997); if (state.failed) return retval; 
            	if ( (state.backtracking==0) ) stream_42.Add(char_literal28);

            	// MathExpr.g:115:22: ( var_list )?
            	int alt7 = 2;
            	int LA7_0 = input.LA(1);

            	if ( (LA7_0 == IDENT) )
            	{
            	    alt7 = 1;
            	}
            	switch (alt7) 
            	{
            	    case 1 :
            	        // MathExpr.g:0:0: var_list
            	        {
            	        	PushFollow(FOLLOW_var_list_in_func_descr999);
            	        	var_list29 = var_list();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( (state.backtracking==0) ) stream_var_list.Add(var_list29.Tree);

            	        }
            	        break;

            	}

            	char_literal30=(IToken)Match(input,43,FOLLOW_43_in_func_descr1002); if (state.failed) return retval; 
            	if ( (state.backtracking==0) ) stream_43.Add(char_literal30);

            	char_literal31=(IToken)Match(input,DDD,FOLLOW_DDD_in_func_descr1004); if (state.failed) return retval; 
            	if ( (state.backtracking==0) ) stream_DDD.Add(char_literal31);

            	PushFollow(FOLLOW_type_in_func_descr1006);
            	type32 = type();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( (state.backtracking==0) ) stream_type.Add(type32.Tree);
            	char_literal33=(IToken)Match(input,TTT,FOLLOW_TTT_in_func_descr1008); if (state.failed) return retval; 
            	if ( (state.backtracking==0) ) stream_TTT.Add(char_literal33);

            	// MathExpr.g:115:49: ( var )?
            	int alt8 = 2;
            	int LA8_0 = input.LA(1);

            	if ( (LA8_0 == VAR) )
            	{
            	    alt8 = 1;
            	}
            	switch (alt8) 
            	{
            	    case 1 :
            	        // MathExpr.g:115:50: var
            	        {
            	        	PushFollow(FOLLOW_var_in_func_descr1011);
            	        	var34 = var();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( (state.backtracking==0) ) stream_var.Add(var34.Tree);

            	        }
            	        break;

            	}

            	PushFollow(FOLLOW_expr_in_func_descr1015);
            	expr35 = expr();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( (state.backtracking==0) ) stream_expr.Add(expr35.Tree);


            	// AST REWRITE
            	// elements:          FUNCTION, expr, IDENT, var, var_list, type
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	// wildcard labels: 
            	if ( (state.backtracking==0) ) {
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

            	root_0 = (object)adaptor.GetNilNode();
            	// 115:62: -> ^( FUNCTION type IDENT ( ^( PARAMS var_list ) )? ( ^( var ) )? ^( expr ) )
            	{
            	    // MathExpr.g:116:5: ^( FUNCTION type IDENT ( ^( PARAMS var_list ) )? ( ^( var ) )? ^( expr ) )
            	    {
            	    object root_1 = (object)adaptor.GetNilNode();
            	    root_1 = (object)adaptor.BecomeRoot(stream_FUNCTION.NextNode(), root_1);

            	    adaptor.AddChild(root_1, stream_type.NextTree());
            	    adaptor.AddChild(root_1, stream_IDENT.NextNode());
            	    // MathExpr.g:116:28: ( ^( PARAMS var_list ) )?
            	    if ( stream_var_list.HasNext() )
            	    {
            	        // MathExpr.g:116:28: ^( PARAMS var_list )
            	        {
            	        object root_2 = (object)adaptor.GetNilNode();
            	        root_2 = (object)adaptor.BecomeRoot((object)adaptor.Create(PARAMS, "PARAMS"), root_2);

            	        adaptor.AddChild(root_2, stream_var_list.NextTree());

            	        adaptor.AddChild(root_1, root_2);
            	        }

            	    }
            	    stream_var_list.Reset();
            	    // MathExpr.g:116:48: ( ^( var ) )?
            	    if ( stream_var.HasNext() )
            	    {
            	        // MathExpr.g:116:48: ^( var )
            	        {
            	        object root_2 = (object)adaptor.GetNilNode();
            	        root_2 = (object)adaptor.BecomeRoot(stream_var.NextNode(), root_2);

            	        adaptor.AddChild(root_1, root_2);
            	        }

            	    }
            	    stream_var.Reset();
            	    // MathExpr.g:116:56: ^( expr )
            	    {
            	    object root_2 = (object)adaptor.GetNilNode();
            	    root_2 = (object)adaptor.BecomeRoot(stream_expr.NextNode(), root_2);

            	    adaptor.AddChild(root_1, root_2);
            	    }

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;}
            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 8, func_descr_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "func_descr"

    public class proc_descr_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "proc_descr"
    // MathExpr.g:119:1: proc_descr : PROCEDURE IDENT '(' ( var_list )? ')' ';' ( var )? expr -> ^( PROCEDURE IDENT ( ^( PARAMS var_list ) )? ( ^( var ) )? ^( expr ) ) ;
    public MathExprParser.proc_descr_return proc_descr() // throws RecognitionException [1]
    {   
        MathExprParser.proc_descr_return retval = new MathExprParser.proc_descr_return();
        retval.Start = input.LT(1);
        int proc_descr_StartIndex = input.Index();
        object root_0 = null;

        IToken PROCEDURE36 = null;
        IToken IDENT37 = null;
        IToken char_literal38 = null;
        IToken char_literal40 = null;
        IToken char_literal41 = null;
        MathExprParser.var_list_return var_list39 = default(MathExprParser.var_list_return);

        MathExprParser.var_return var42 = default(MathExprParser.var_return);

        MathExprParser.expr_return expr43 = default(MathExprParser.expr_return);


        object PROCEDURE36_tree=null;
        object IDENT37_tree=null;
        object char_literal38_tree=null;
        object char_literal40_tree=null;
        object char_literal41_tree=null;
        RewriteRuleTokenStream stream_IDENT = new RewriteRuleTokenStream(adaptor,"token IDENT");
        RewriteRuleTokenStream stream_43 = new RewriteRuleTokenStream(adaptor,"token 43");
        RewriteRuleTokenStream stream_42 = new RewriteRuleTokenStream(adaptor,"token 42");
        RewriteRuleTokenStream stream_TTT = new RewriteRuleTokenStream(adaptor,"token TTT");
        RewriteRuleTokenStream stream_PROCEDURE = new RewriteRuleTokenStream(adaptor,"token PROCEDURE");
        RewriteRuleSubtreeStream stream_var = new RewriteRuleSubtreeStream(adaptor,"rule var");
        RewriteRuleSubtreeStream stream_var_list = new RewriteRuleSubtreeStream(adaptor,"rule var_list");
        RewriteRuleSubtreeStream stream_expr = new RewriteRuleSubtreeStream(adaptor,"rule expr");
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 9) ) 
    	    {
    	    	return retval; 
    	    }
            // MathExpr.g:119:11: ( PROCEDURE IDENT '(' ( var_list )? ')' ';' ( var )? expr -> ^( PROCEDURE IDENT ( ^( PARAMS var_list ) )? ( ^( var ) )? ^( expr ) ) )
            // MathExpr.g:120:2: PROCEDURE IDENT '(' ( var_list )? ')' ';' ( var )? expr
            {
            	PROCEDURE36=(IToken)Match(input,PROCEDURE,FOLLOW_PROCEDURE_in_proc_descr1057); if (state.failed) return retval; 
            	if ( (state.backtracking==0) ) stream_PROCEDURE.Add(PROCEDURE36);

            	IDENT37=(IToken)Match(input,IDENT,FOLLOW_IDENT_in_proc_descr1059); if (state.failed) return retval; 
            	if ( (state.backtracking==0) ) stream_IDENT.Add(IDENT37);

            	char_literal38=(IToken)Match(input,42,FOLLOW_42_in_proc_descr1062); if (state.failed) return retval; 
            	if ( (state.backtracking==0) ) stream_42.Add(char_literal38);

            	// MathExpr.g:120:23: ( var_list )?
            	int alt9 = 2;
            	int LA9_0 = input.LA(1);

            	if ( (LA9_0 == IDENT) )
            	{
            	    alt9 = 1;
            	}
            	switch (alt9) 
            	{
            	    case 1 :
            	        // MathExpr.g:0:0: var_list
            	        {
            	        	PushFollow(FOLLOW_var_list_in_proc_descr1064);
            	        	var_list39 = var_list();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( (state.backtracking==0) ) stream_var_list.Add(var_list39.Tree);

            	        }
            	        break;

            	}

            	char_literal40=(IToken)Match(input,43,FOLLOW_43_in_proc_descr1067); if (state.failed) return retval; 
            	if ( (state.backtracking==0) ) stream_43.Add(char_literal40);

            	char_literal41=(IToken)Match(input,TTT,FOLLOW_TTT_in_proc_descr1069); if (state.failed) return retval; 
            	if ( (state.backtracking==0) ) stream_TTT.Add(char_literal41);

            	// MathExpr.g:120:41: ( var )?
            	int alt10 = 2;
            	int LA10_0 = input.LA(1);

            	if ( (LA10_0 == VAR) )
            	{
            	    alt10 = 1;
            	}
            	switch (alt10) 
            	{
            	    case 1 :
            	        // MathExpr.g:120:42: var
            	        {
            	        	PushFollow(FOLLOW_var_in_proc_descr1072);
            	        	var42 = var();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( (state.backtracking==0) ) stream_var.Add(var42.Tree);

            	        }
            	        break;

            	}

            	PushFollow(FOLLOW_expr_in_proc_descr1076);
            	expr43 = expr();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( (state.backtracking==0) ) stream_expr.Add(expr43.Tree);


            	// AST REWRITE
            	// elements:          PROCEDURE, var, IDENT, expr, var_list
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	// wildcard labels: 
            	if ( (state.backtracking==0) ) {
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

            	root_0 = (object)adaptor.GetNilNode();
            	// 120:53: -> ^( PROCEDURE IDENT ( ^( PARAMS var_list ) )? ( ^( var ) )? ^( expr ) )
            	{
            	    // MathExpr.g:121:5: ^( PROCEDURE IDENT ( ^( PARAMS var_list ) )? ( ^( var ) )? ^( expr ) )
            	    {
            	    object root_1 = (object)adaptor.GetNilNode();
            	    root_1 = (object)adaptor.BecomeRoot(stream_PROCEDURE.NextNode(), root_1);

            	    adaptor.AddChild(root_1, stream_IDENT.NextNode());
            	    // MathExpr.g:121:25: ( ^( PARAMS var_list ) )?
            	    if ( stream_var_list.HasNext() )
            	    {
            	        // MathExpr.g:121:25: ^( PARAMS var_list )
            	        {
            	        object root_2 = (object)adaptor.GetNilNode();
            	        root_2 = (object)adaptor.BecomeRoot((object)adaptor.Create(PARAMS, "PARAMS"), root_2);

            	        adaptor.AddChild(root_2, stream_var_list.NextTree());

            	        adaptor.AddChild(root_1, root_2);
            	        }

            	    }
            	    stream_var_list.Reset();
            	    // MathExpr.g:121:45: ( ^( var ) )?
            	    if ( stream_var.HasNext() )
            	    {
            	        // MathExpr.g:121:45: ^( var )
            	        {
            	        object root_2 = (object)adaptor.GetNilNode();
            	        root_2 = (object)adaptor.BecomeRoot(stream_var.NextNode(), root_2);

            	        adaptor.AddChild(root_1, root_2);
            	        }

            	    }
            	    stream_var.Reset();
            	    // MathExpr.g:121:53: ^( expr )
            	    {
            	    object root_2 = (object)adaptor.GetNilNode();
            	    root_2 = (object)adaptor.BecomeRoot(stream_expr.NextNode(), root_2);

            	    adaptor.AddChild(root_1, root_2);
            	    }

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;}
            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 9, proc_descr_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "proc_descr"

    public class var_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "var"
    // MathExpr.g:124:1: var : 'var' var_list -> ^( VAR var_list ) ;
    public MathExprParser.var_return var() // throws RecognitionException [1]
    {   
        MathExprParser.var_return retval = new MathExprParser.var_return();
        retval.Start = input.LT(1);
        int var_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal44 = null;
        MathExprParser.var_list_return var_list45 = default(MathExprParser.var_list_return);


        object string_literal44_tree=null;
        RewriteRuleTokenStream stream_VAR = new RewriteRuleTokenStream(adaptor,"token VAR");
        RewriteRuleSubtreeStream stream_var_list = new RewriteRuleSubtreeStream(adaptor,"rule var_list");
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 10) ) 
    	    {
    	    	return retval; 
    	    }
            // MathExpr.g:124:4: ( 'var' var_list -> ^( VAR var_list ) )
            // MathExpr.g:125:2: 'var' var_list
            {
            	string_literal44=(IToken)Match(input,VAR,FOLLOW_VAR_in_var1116); if (state.failed) return retval; 
            	if ( (state.backtracking==0) ) stream_VAR.Add(string_literal44);

            	PushFollow(FOLLOW_var_list_in_var1118);
            	var_list45 = var_list();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( (state.backtracking==0) ) stream_var_list.Add(var_list45.Tree);


            	// AST REWRITE
            	// elements:          var_list
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	// wildcard labels: 
            	if ( (state.backtracking==0) ) {
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

            	root_0 = (object)adaptor.GetNilNode();
            	// 125:17: -> ^( VAR var_list )
            	{
            	    // MathExpr.g:125:20: ^( VAR var_list )
            	    {
            	    object root_1 = (object)adaptor.GetNilNode();
            	    root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(VAR, "VAR"), root_1);

            	    adaptor.AddChild(root_1, stream_var_list.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;}
            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 10, var_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "var"

    public class var_list_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "var_list"
    // MathExpr.g:128:1: var_list : ( exprvar ( ';' )+ ( exprvar ( ';' )+ )* | exprvar ( ';' )* ( exprvar ( ';' )* )* );
    public MathExprParser.var_list_return var_list() // throws RecognitionException [1]
    {   
        MathExprParser.var_list_return retval = new MathExprParser.var_list_return();
        retval.Start = input.LT(1);
        int var_list_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal47 = null;
        IToken char_literal49 = null;
        IToken char_literal51 = null;
        IToken char_literal53 = null;
        MathExprParser.exprvar_return exprvar46 = default(MathExprParser.exprvar_return);

        MathExprParser.exprvar_return exprvar48 = default(MathExprParser.exprvar_return);

        MathExprParser.exprvar_return exprvar50 = default(MathExprParser.exprvar_return);

        MathExprParser.exprvar_return exprvar52 = default(MathExprParser.exprvar_return);


        object char_literal47_tree=null;
        object char_literal49_tree=null;
        object char_literal51_tree=null;
        object char_literal53_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 11) ) 
    	    {
    	    	return retval; 
    	    }
            // MathExpr.g:128:9: ( exprvar ( ';' )+ ( exprvar ( ';' )+ )* | exprvar ( ';' )* ( exprvar ( ';' )* )* )
            int alt17 = 2;
            alt17 = dfa17.Predict(input);
            switch (alt17) 
            {
                case 1 :
                    // MathExpr.g:129:2: exprvar ( ';' )+ ( exprvar ( ';' )+ )*
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_exprvar_in_var_list1137);
                    	exprvar46 = exprvar();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, exprvar46.Tree);
                    	// MathExpr.g:129:10: ( ';' )+
                    	int cnt11 = 0;
                    	do 
                    	{
                    	    int alt11 = 2;
                    	    int LA11_0 = input.LA(1);

                    	    if ( (LA11_0 == TTT) )
                    	    {
                    	        alt11 = 1;
                    	    }


                    	    switch (alt11) 
                    		{
                    			case 1 :
                    			    // MathExpr.g:129:11: ';'
                    			    {
                    			    	char_literal47=(IToken)Match(input,TTT,FOLLOW_TTT_in_var_list1140); if (state.failed) return retval;

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt11 >= 1 ) goto loop11;
                    			    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                    		            EarlyExitException eee11 =
                    		                new EarlyExitException(11, input);
                    		            throw eee11;
                    	    }
                    	    cnt11++;
                    	} while (true);

                    	loop11:
                    		;	// Stops C# compiler whining that label 'loop11' has no statements

                    	// MathExpr.g:129:18: ( exprvar ( ';' )+ )*
                    	do 
                    	{
                    	    int alt13 = 2;
                    	    int LA13_0 = input.LA(1);

                    	    if ( (LA13_0 == IDENT) )
                    	    {
                    	        int LA13_2 = input.LA(2);

                    	        if ( (LA13_2 == DDD || LA13_2 == 44) )
                    	        {
                    	            alt13 = 1;
                    	        }


                    	    }


                    	    switch (alt13) 
                    		{
                    			case 1 :
                    			    // MathExpr.g:129:19: exprvar ( ';' )+
                    			    {
                    			    	PushFollow(FOLLOW_exprvar_in_var_list1146);
                    			    	exprvar48 = exprvar();
                    			    	state.followingStackPointer--;
                    			    	if (state.failed) return retval;
                    			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, exprvar48.Tree);
                    			    	// MathExpr.g:129:27: ( ';' )+
                    			    	int cnt12 = 0;
                    			    	do 
                    			    	{
                    			    	    int alt12 = 2;
                    			    	    int LA12_0 = input.LA(1);

                    			    	    if ( (LA12_0 == TTT) )
                    			    	    {
                    			    	        alt12 = 1;
                    			    	    }


                    			    	    switch (alt12) 
                    			    		{
                    			    			case 1 :
                    			    			    // MathExpr.g:129:28: ';'
                    			    			    {
                    			    			    	char_literal49=(IToken)Match(input,TTT,FOLLOW_TTT_in_var_list1149); if (state.failed) return retval;

                    			    			    }
                    			    			    break;

                    			    			default:
                    			    			    if ( cnt12 >= 1 ) goto loop12;
                    			    			    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                    			    		            EarlyExitException eee12 =
                    			    		                new EarlyExitException(12, input);
                    			    		            throw eee12;
                    			    	    }
                    			    	    cnt12++;
                    			    	} while (true);

                    			    	loop12:
                    			    		;	// Stops C# compiler whining that label 'loop12' has no statements


                    			    }
                    			    break;

                    			default:
                    			    goto loop13;
                    	    }
                    	} while (true);

                    	loop13:
                    		;	// Stops C# compiler whining that label 'loop13' has no statements


                    }
                    break;
                case 2 :
                    // MathExpr.g:130:4: exprvar ( ';' )* ( exprvar ( ';' )* )*
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_exprvar_in_var_list1160);
                    	exprvar50 = exprvar();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, exprvar50.Tree);
                    	// MathExpr.g:130:12: ( ';' )*
                    	do 
                    	{
                    	    int alt14 = 2;
                    	    int LA14_0 = input.LA(1);

                    	    if ( (LA14_0 == TTT) )
                    	    {
                    	        alt14 = 1;
                    	    }


                    	    switch (alt14) 
                    		{
                    			case 1 :
                    			    // MathExpr.g:130:13: ';'
                    			    {
                    			    	char_literal51=(IToken)Match(input,TTT,FOLLOW_TTT_in_var_list1163); if (state.failed) return retval;

                    			    }
                    			    break;

                    			default:
                    			    goto loop14;
                    	    }
                    	} while (true);

                    	loop14:
                    		;	// Stops C# compiler whining that label 'loop14' has no statements

                    	// MathExpr.g:130:20: ( exprvar ( ';' )* )*
                    	do 
                    	{
                    	    int alt16 = 2;
                    	    int LA16_0 = input.LA(1);

                    	    if ( (LA16_0 == IDENT) )
                    	    {
                    	        int LA16_2 = input.LA(2);

                    	        if ( (LA16_2 == DDD || LA16_2 == 44) )
                    	        {
                    	            alt16 = 1;
                    	        }


                    	    }


                    	    switch (alt16) 
                    		{
                    			case 1 :
                    			    // MathExpr.g:130:21: exprvar ( ';' )*
                    			    {
                    			    	PushFollow(FOLLOW_exprvar_in_var_list1169);
                    			    	exprvar52 = exprvar();
                    			    	state.followingStackPointer--;
                    			    	if (state.failed) return retval;
                    			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, exprvar52.Tree);
                    			    	// MathExpr.g:130:29: ( ';' )*
                    			    	do 
                    			    	{
                    			    	    int alt15 = 2;
                    			    	    int LA15_0 = input.LA(1);

                    			    	    if ( (LA15_0 == TTT) )
                    			    	    {
                    			    	        alt15 = 1;
                    			    	    }


                    			    	    switch (alt15) 
                    			    		{
                    			    			case 1 :
                    			    			    // MathExpr.g:130:30: ';'
                    			    			    {
                    			    			    	char_literal53=(IToken)Match(input,TTT,FOLLOW_TTT_in_var_list1172); if (state.failed) return retval;

                    			    			    }
                    			    			    break;

                    			    			default:
                    			    			    goto loop15;
                    			    	    }
                    			    	} while (true);

                    			    	loop15:
                    			    		;	// Stops C# compiler whining that label 'loop15' has no statements


                    			    }
                    			    break;

                    			default:
                    			    goto loop16;
                    	    }
                    	} while (true);

                    	loop16:
                    		;	// Stops C# compiler whining that label 'loop16' has no statements


                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 11, var_list_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "var_list"

    public class exprvar_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "exprvar"
    // MathExpr.g:133:1: exprvar : ( ident_list ( ':' type ) ( ';' )? -> ^( ':' type ident_list ) | IDENT ':' 'array' '[' INTEGER '..' INTEGER ']' 'of' type ( ';' )? -> ^( 'array' type IDENT INTEGER INTEGER ) );
    public MathExprParser.exprvar_return exprvar() // throws RecognitionException [1]
    {   
        MathExprParser.exprvar_return retval = new MathExprParser.exprvar_return();
        retval.Start = input.LT(1);
        int exprvar_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal55 = null;
        IToken char_literal57 = null;
        IToken IDENT58 = null;
        IToken char_literal59 = null;
        IToken string_literal60 = null;
        IToken char_literal61 = null;
        IToken INTEGER62 = null;
        IToken string_literal63 = null;
        IToken INTEGER64 = null;
        IToken char_literal65 = null;
        IToken string_literal66 = null;
        IToken char_literal68 = null;
        MathExprParser.ident_list_return ident_list54 = default(MathExprParser.ident_list_return);

        MathExprParser.type_return type56 = default(MathExprParser.type_return);

        MathExprParser.type_return type67 = default(MathExprParser.type_return);


        object char_literal55_tree=null;
        object char_literal57_tree=null;
        object IDENT58_tree=null;
        object char_literal59_tree=null;
        object string_literal60_tree=null;
        object char_literal61_tree=null;
        object INTEGER62_tree=null;
        object string_literal63_tree=null;
        object INTEGER64_tree=null;
        object char_literal65_tree=null;
        object string_literal66_tree=null;
        object char_literal68_tree=null;
        RewriteRuleTokenStream stream_49 = new RewriteRuleTokenStream(adaptor,"token 49");
        RewriteRuleTokenStream stream_INTEGER = new RewriteRuleTokenStream(adaptor,"token INTEGER");
        RewriteRuleTokenStream stream_48 = new RewriteRuleTokenStream(adaptor,"token 48");
        RewriteRuleTokenStream stream_IDENT = new RewriteRuleTokenStream(adaptor,"token IDENT");
        RewriteRuleTokenStream stream_45 = new RewriteRuleTokenStream(adaptor,"token 45");
        RewriteRuleTokenStream stream_47 = new RewriteRuleTokenStream(adaptor,"token 47");
        RewriteRuleTokenStream stream_DDD = new RewriteRuleTokenStream(adaptor,"token DDD");
        RewriteRuleTokenStream stream_46 = new RewriteRuleTokenStream(adaptor,"token 46");
        RewriteRuleTokenStream stream_TTT = new RewriteRuleTokenStream(adaptor,"token TTT");
        RewriteRuleSubtreeStream stream_ident_list = new RewriteRuleSubtreeStream(adaptor,"rule ident_list");
        RewriteRuleSubtreeStream stream_type = new RewriteRuleSubtreeStream(adaptor,"rule type");
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 12) ) 
    	    {
    	    	return retval; 
    	    }
            // MathExpr.g:133:8: ( ident_list ( ':' type ) ( ';' )? -> ^( ':' type ident_list ) | IDENT ':' 'array' '[' INTEGER '..' INTEGER ']' 'of' type ( ';' )? -> ^( 'array' type IDENT INTEGER INTEGER ) )
            int alt20 = 2;
            int LA20_0 = input.LA(1);

            if ( (LA20_0 == IDENT) )
            {
                int LA20_1 = input.LA(2);

                if ( (LA20_1 == DDD) )
                {
                    int LA20_2 = input.LA(3);

                    if ( (LA20_2 == 45) )
                    {
                        alt20 = 2;
                    }
                    else if ( ((LA20_2 >= 50 && LA20_2 <= 52)) )
                    {
                        alt20 = 1;
                    }
                    else 
                    {
                        if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                        NoViableAltException nvae_d20s2 =
                            new NoViableAltException("", 20, 2, input);

                        throw nvae_d20s2;
                    }
                }
                else if ( (LA20_1 == 44) )
                {
                    alt20 = 1;
                }
                else 
                {
                    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                    NoViableAltException nvae_d20s1 =
                        new NoViableAltException("", 20, 1, input);

                    throw nvae_d20s1;
                }
            }
            else 
            {
                if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                NoViableAltException nvae_d20s0 =
                    new NoViableAltException("", 20, 0, input);

                throw nvae_d20s0;
            }
            switch (alt20) 
            {
                case 1 :
                    // MathExpr.g:134:2: ident_list ( ':' type ) ( ';' )?
                    {
                    	PushFollow(FOLLOW_ident_list_in_exprvar1187);
                    	ident_list54 = ident_list();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( (state.backtracking==0) ) stream_ident_list.Add(ident_list54.Tree);
                    	// MathExpr.g:134:13: ( ':' type )
                    	// MathExpr.g:134:14: ':' type
                    	{
                    		char_literal55=(IToken)Match(input,DDD,FOLLOW_DDD_in_exprvar1190); if (state.failed) return retval; 
                    		if ( (state.backtracking==0) ) stream_DDD.Add(char_literal55);

                    		PushFollow(FOLLOW_type_in_exprvar1192);
                    		type56 = type();
                    		state.followingStackPointer--;
                    		if (state.failed) return retval;
                    		if ( (state.backtracking==0) ) stream_type.Add(type56.Tree);

                    	}

                    	// MathExpr.g:134:24: ( ';' )?
                    	int alt18 = 2;
                    	int LA18_0 = input.LA(1);

                    	if ( (LA18_0 == TTT) )
                    	{
                    	    int LA18_1 = input.LA(2);

                    	    if ( (synpred28_MathExpr()) )
                    	    {
                    	        alt18 = 1;
                    	    }
                    	}
                    	switch (alt18) 
                    	{
                    	    case 1 :
                    	        // MathExpr.g:134:25: ';'
                    	        {
                    	        	char_literal57=(IToken)Match(input,TTT,FOLLOW_TTT_in_exprvar1196); if (state.failed) return retval; 
                    	        	if ( (state.backtracking==0) ) stream_TTT.Add(char_literal57);


                    	        }
                    	        break;

                    	}



                    	// AST REWRITE
                    	// elements:          DDD, ident_list, type
                    	// token labels:      
                    	// rule labels:       retval
                    	// token list labels: 
                    	// rule list labels:  
                    	// wildcard labels: 
                    	if ( (state.backtracking==0) ) {
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

                    	root_0 = (object)adaptor.GetNilNode();
                    	// 134:31: -> ^( ':' type ident_list )
                    	{
                    	    // MathExpr.g:134:34: ^( ':' type ident_list )
                    	    {
                    	    object root_1 = (object)adaptor.GetNilNode();
                    	    root_1 = (object)adaptor.BecomeRoot(stream_DDD.NextNode(), root_1);

                    	    adaptor.AddChild(root_1, stream_type.NextTree());
                    	    adaptor.AddChild(root_1, stream_ident_list.NextTree());

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}

                    	retval.Tree = root_0;retval.Tree = root_0;}
                    }
                    break;
                case 2 :
                    // MathExpr.g:135:3: IDENT ':' 'array' '[' INTEGER '..' INTEGER ']' 'of' type ( ';' )?
                    {
                    	IDENT58=(IToken)Match(input,IDENT,FOLLOW_IDENT_in_exprvar1212); if (state.failed) return retval; 
                    	if ( (state.backtracking==0) ) stream_IDENT.Add(IDENT58);

                    	char_literal59=(IToken)Match(input,DDD,FOLLOW_DDD_in_exprvar1214); if (state.failed) return retval; 
                    	if ( (state.backtracking==0) ) stream_DDD.Add(char_literal59);

                    	string_literal60=(IToken)Match(input,45,FOLLOW_45_in_exprvar1216); if (state.failed) return retval; 
                    	if ( (state.backtracking==0) ) stream_45.Add(string_literal60);

                    	char_literal61=(IToken)Match(input,46,FOLLOW_46_in_exprvar1218); if (state.failed) return retval; 
                    	if ( (state.backtracking==0) ) stream_46.Add(char_literal61);

                    	INTEGER62=(IToken)Match(input,INTEGER,FOLLOW_INTEGER_in_exprvar1220); if (state.failed) return retval; 
                    	if ( (state.backtracking==0) ) stream_INTEGER.Add(INTEGER62);

                    	string_literal63=(IToken)Match(input,47,FOLLOW_47_in_exprvar1222); if (state.failed) return retval; 
                    	if ( (state.backtracking==0) ) stream_47.Add(string_literal63);

                    	INTEGER64=(IToken)Match(input,INTEGER,FOLLOW_INTEGER_in_exprvar1224); if (state.failed) return retval; 
                    	if ( (state.backtracking==0) ) stream_INTEGER.Add(INTEGER64);

                    	char_literal65=(IToken)Match(input,48,FOLLOW_48_in_exprvar1227); if (state.failed) return retval; 
                    	if ( (state.backtracking==0) ) stream_48.Add(char_literal65);

                    	string_literal66=(IToken)Match(input,49,FOLLOW_49_in_exprvar1229); if (state.failed) return retval; 
                    	if ( (state.backtracking==0) ) stream_49.Add(string_literal66);

                    	PushFollow(FOLLOW_type_in_exprvar1231);
                    	type67 = type();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( (state.backtracking==0) ) stream_type.Add(type67.Tree);
                    	// MathExpr.g:135:61: ( ';' )?
                    	int alt19 = 2;
                    	int LA19_0 = input.LA(1);

                    	if ( (LA19_0 == TTT) )
                    	{
                    	    int LA19_1 = input.LA(2);

                    	    if ( (synpred30_MathExpr()) )
                    	    {
                    	        alt19 = 1;
                    	    }
                    	}
                    	switch (alt19) 
                    	{
                    	    case 1 :
                    	        // MathExpr.g:135:62: ';'
                    	        {
                    	        	char_literal68=(IToken)Match(input,TTT,FOLLOW_TTT_in_exprvar1234); if (state.failed) return retval; 
                    	        	if ( (state.backtracking==0) ) stream_TTT.Add(char_literal68);


                    	        }
                    	        break;

                    	}



                    	// AST REWRITE
                    	// elements:          45, INTEGER, INTEGER, IDENT, type
                    	// token labels:      
                    	// rule labels:       retval
                    	// token list labels: 
                    	// rule list labels:  
                    	// wildcard labels: 
                    	if ( (state.backtracking==0) ) {
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

                    	root_0 = (object)adaptor.GetNilNode();
                    	// 135:68: -> ^( 'array' type IDENT INTEGER INTEGER )
                    	{
                    	    // MathExpr.g:135:71: ^( 'array' type IDENT INTEGER INTEGER )
                    	    {
                    	    object root_1 = (object)adaptor.GetNilNode();
                    	    root_1 = (object)adaptor.BecomeRoot(stream_45.NextNode(), root_1);

                    	    adaptor.AddChild(root_1, stream_type.NextTree());
                    	    adaptor.AddChild(root_1, stream_IDENT.NextNode());
                    	    adaptor.AddChild(root_1, stream_INTEGER.NextNode());
                    	    adaptor.AddChild(root_1, stream_INTEGER.NextNode());

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}

                    	retval.Tree = root_0;retval.Tree = root_0;}
                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 12, exprvar_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "exprvar"

    public class type_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "type"
    // MathExpr.g:139:1: type : ( 'real' -> REAL | 'integer' -> INTEGER | 'string' -> STRING );
    public MathExprParser.type_return type() // throws RecognitionException [1]
    {   
        MathExprParser.type_return retval = new MathExprParser.type_return();
        retval.Start = input.LT(1);
        int type_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal69 = null;
        IToken string_literal70 = null;
        IToken string_literal71 = null;

        object string_literal69_tree=null;
        object string_literal70_tree=null;
        object string_literal71_tree=null;
        RewriteRuleTokenStream stream_51 = new RewriteRuleTokenStream(adaptor,"token 51");
        RewriteRuleTokenStream stream_52 = new RewriteRuleTokenStream(adaptor,"token 52");
        RewriteRuleTokenStream stream_50 = new RewriteRuleTokenStream(adaptor,"token 50");

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 13) ) 
    	    {
    	    	return retval; 
    	    }
            // MathExpr.g:139:5: ( 'real' -> REAL | 'integer' -> INTEGER | 'string' -> STRING )
            int alt21 = 3;
            switch ( input.LA(1) ) 
            {
            case 50:
            	{
                alt21 = 1;
                }
                break;
            case 51:
            	{
                alt21 = 2;
                }
                break;
            case 52:
            	{
                alt21 = 3;
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            	    NoViableAltException nvae_d21s0 =
            	        new NoViableAltException("", 21, 0, input);

            	    throw nvae_d21s0;
            }

            switch (alt21) 
            {
                case 1 :
                    // MathExpr.g:140:2: 'real'
                    {
                    	string_literal69=(IToken)Match(input,50,FOLLOW_50_in_type1261); if (state.failed) return retval; 
                    	if ( (state.backtracking==0) ) stream_50.Add(string_literal69);



                    	// AST REWRITE
                    	// elements:          
                    	// token labels:      
                    	// rule labels:       retval
                    	// token list labels: 
                    	// rule list labels:  
                    	// wildcard labels: 
                    	if ( (state.backtracking==0) ) {
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

                    	root_0 = (object)adaptor.GetNilNode();
                    	// 140:9: -> REAL
                    	{
                    	    adaptor.AddChild(root_0, (object)adaptor.Create(REAL, "REAL"));

                    	}

                    	retval.Tree = root_0;retval.Tree = root_0;}
                    }
                    break;
                case 2 :
                    // MathExpr.g:141:4: 'integer'
                    {
                    	string_literal70=(IToken)Match(input,51,FOLLOW_51_in_type1270); if (state.failed) return retval; 
                    	if ( (state.backtracking==0) ) stream_51.Add(string_literal70);



                    	// AST REWRITE
                    	// elements:          
                    	// token labels:      
                    	// rule labels:       retval
                    	// token list labels: 
                    	// rule list labels:  
                    	// wildcard labels: 
                    	if ( (state.backtracking==0) ) {
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

                    	root_0 = (object)adaptor.GetNilNode();
                    	// 141:14: -> INTEGER
                    	{
                    	    adaptor.AddChild(root_0, (object)adaptor.Create(INTEGER, "INTEGER"));

                    	}

                    	retval.Tree = root_0;retval.Tree = root_0;}
                    }
                    break;
                case 3 :
                    // MathExpr.g:142:4: 'string'
                    {
                    	string_literal71=(IToken)Match(input,52,FOLLOW_52_in_type1279); if (state.failed) return retval; 
                    	if ( (state.backtracking==0) ) stream_52.Add(string_literal71);



                    	// AST REWRITE
                    	// elements:          
                    	// token labels:      
                    	// rule labels:       retval
                    	// token list labels: 
                    	// rule list labels:  
                    	// wildcard labels: 
                    	if ( (state.backtracking==0) ) {
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

                    	root_0 = (object)adaptor.GetNilNode();
                    	// 142:13: -> STRING
                    	{
                    	    adaptor.AddChild(root_0, (object)adaptor.Create(STRING, "STRING"));

                    	}

                    	retval.Tree = root_0;retval.Tree = root_0;}
                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 13, type_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "type"

    public class ident_list_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "ident_list"
    // MathExpr.g:145:1: ident_list : IDENT ( ',' IDENT )* ;
    public MathExprParser.ident_list_return ident_list() // throws RecognitionException [1]
    {   
        MathExprParser.ident_list_return retval = new MathExprParser.ident_list_return();
        retval.Start = input.LT(1);
        int ident_list_StartIndex = input.Index();
        object root_0 = null;

        IToken IDENT72 = null;
        IToken char_literal73 = null;
        IToken IDENT74 = null;

        object IDENT72_tree=null;
        object char_literal73_tree=null;
        object IDENT74_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 14) ) 
    	    {
    	    	return retval; 
    	    }
            // MathExpr.g:145:11: ( IDENT ( ',' IDENT )* )
            // MathExpr.g:146:2: IDENT ( ',' IDENT )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	IDENT72=(IToken)Match(input,IDENT,FOLLOW_IDENT_in_ident_list1293); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{IDENT72_tree = (object)adaptor.Create(IDENT72);
            		adaptor.AddChild(root_0, IDENT72_tree);
            	}
            	// MathExpr.g:146:8: ( ',' IDENT )*
            	do 
            	{
            	    int alt22 = 2;
            	    int LA22_0 = input.LA(1);

            	    if ( (LA22_0 == 44) )
            	    {
            	        alt22 = 1;
            	    }


            	    switch (alt22) 
            		{
            			case 1 :
            			    // MathExpr.g:146:9: ',' IDENT
            			    {
            			    	char_literal73=(IToken)Match(input,44,FOLLOW_44_in_ident_list1296); if (state.failed) return retval;
            			    	IDENT74=(IToken)Match(input,IDENT,FOLLOW_IDENT_in_ident_list1299); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{IDENT74_tree = (object)adaptor.Create(IDENT74);
            			    		adaptor.AddChild(root_0, IDENT74_tree);
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop22;
            	    }
            	} while (true);

            	loop22:
            		;	// Stops C# compiler whining that label 'loop22' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 14, ident_list_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "ident_list"

    public class expr_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "expr"
    // MathExpr.g:149:1: expr : ( IDENT ASSIGN term | IDENT -> ^( FUNC_CALL IDENT PARAMS ) | 'begin' expr_list 'end' -> ^( BLOCK expr_list ) | FOR IDENT ASSIGN term TO term DO expr | WHILE logic DO expr | REPEAT expr_list UNTIL logic | IF logic THEN expr ( ELSE expr )? | INC '(' IDENT ')' | DEC '(' IDENT ')' | func_call | func_descr | proc_descr );
    public MathExprParser.expr_return expr() // throws RecognitionException [1]
    {   
        MathExprParser.expr_return retval = new MathExprParser.expr_return();
        retval.Start = input.LT(1);
        int expr_StartIndex = input.Index();
        object root_0 = null;

        IToken IDENT75 = null;
        IToken ASSIGN76 = null;
        IToken IDENT78 = null;
        IToken string_literal79 = null;
        IToken string_literal81 = null;
        IToken FOR82 = null;
        IToken IDENT83 = null;
        IToken ASSIGN84 = null;
        IToken TO86 = null;
        IToken DO88 = null;
        IToken WHILE90 = null;
        IToken DO92 = null;
        IToken REPEAT94 = null;
        IToken UNTIL96 = null;
        IToken IF98 = null;
        IToken THEN100 = null;
        IToken ELSE102 = null;
        IToken INC104 = null;
        IToken char_literal105 = null;
        IToken IDENT106 = null;
        IToken char_literal107 = null;
        IToken DEC108 = null;
        IToken char_literal109 = null;
        IToken IDENT110 = null;
        IToken char_literal111 = null;
        MathExprParser.term_return term77 = default(MathExprParser.term_return);

        MathExprParser.expr_list_return expr_list80 = default(MathExprParser.expr_list_return);

        MathExprParser.term_return term85 = default(MathExprParser.term_return);

        MathExprParser.term_return term87 = default(MathExprParser.term_return);

        MathExprParser.expr_return expr89 = default(MathExprParser.expr_return);

        MathExprParser.logic_return logic91 = default(MathExprParser.logic_return);

        MathExprParser.expr_return expr93 = default(MathExprParser.expr_return);

        MathExprParser.expr_list_return expr_list95 = default(MathExprParser.expr_list_return);

        MathExprParser.logic_return logic97 = default(MathExprParser.logic_return);

        MathExprParser.logic_return logic99 = default(MathExprParser.logic_return);

        MathExprParser.expr_return expr101 = default(MathExprParser.expr_return);

        MathExprParser.expr_return expr103 = default(MathExprParser.expr_return);

        MathExprParser.func_call_return func_call112 = default(MathExprParser.func_call_return);

        MathExprParser.func_descr_return func_descr113 = default(MathExprParser.func_descr_return);

        MathExprParser.proc_descr_return proc_descr114 = default(MathExprParser.proc_descr_return);


        object IDENT75_tree=null;
        object ASSIGN76_tree=null;
        object IDENT78_tree=null;
        object string_literal79_tree=null;
        object string_literal81_tree=null;
        object FOR82_tree=null;
        object IDENT83_tree=null;
        object ASSIGN84_tree=null;
        object TO86_tree=null;
        object DO88_tree=null;
        object WHILE90_tree=null;
        object DO92_tree=null;
        object REPEAT94_tree=null;
        object UNTIL96_tree=null;
        object IF98_tree=null;
        object THEN100_tree=null;
        object ELSE102_tree=null;
        object INC104_tree=null;
        object char_literal105_tree=null;
        object IDENT106_tree=null;
        object char_literal107_tree=null;
        object DEC108_tree=null;
        object char_literal109_tree=null;
        object IDENT110_tree=null;
        object char_literal111_tree=null;
        RewriteRuleTokenStream stream_IDENT = new RewriteRuleTokenStream(adaptor,"token IDENT");
        RewriteRuleTokenStream stream_53 = new RewriteRuleTokenStream(adaptor,"token 53");
        RewriteRuleTokenStream stream_54 = new RewriteRuleTokenStream(adaptor,"token 54");
        RewriteRuleSubtreeStream stream_expr_list = new RewriteRuleSubtreeStream(adaptor,"rule expr_list");
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 15) ) 
    	    {
    	    	return retval; 
    	    }
            // MathExpr.g:149:5: ( IDENT ASSIGN term | IDENT -> ^( FUNC_CALL IDENT PARAMS ) | 'begin' expr_list 'end' -> ^( BLOCK expr_list ) | FOR IDENT ASSIGN term TO term DO expr | WHILE logic DO expr | REPEAT expr_list UNTIL logic | IF logic THEN expr ( ELSE expr )? | INC '(' IDENT ')' | DEC '(' IDENT ')' | func_call | func_descr | proc_descr )
            int alt24 = 12;
            alt24 = dfa24.Predict(input);
            switch (alt24) 
            {
                case 1 :
                    // MathExpr.g:150:3: IDENT ASSIGN term
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	IDENT75=(IToken)Match(input,IDENT,FOLLOW_IDENT_in_expr1312); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{IDENT75_tree = (object)adaptor.Create(IDENT75);
                    		adaptor.AddChild(root_0, IDENT75_tree);
                    	}
                    	ASSIGN76=(IToken)Match(input,ASSIGN,FOLLOW_ASSIGN_in_expr1314); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{ASSIGN76_tree = (object)adaptor.Create(ASSIGN76);
                    		root_0 = (object)adaptor.BecomeRoot(ASSIGN76_tree, root_0);
                    	}
                    	PushFollow(FOLLOW_term_in_expr1317);
                    	term77 = term();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, term77.Tree);

                    }
                    break;
                case 2 :
                    // MathExpr.g:151:4: IDENT
                    {
                    	IDENT78=(IToken)Match(input,IDENT,FOLLOW_IDENT_in_expr1322); if (state.failed) return retval; 
                    	if ( (state.backtracking==0) ) stream_IDENT.Add(IDENT78);



                    	// AST REWRITE
                    	// elements:          IDENT
                    	// token labels:      
                    	// rule labels:       retval
                    	// token list labels: 
                    	// rule list labels:  
                    	// wildcard labels: 
                    	if ( (state.backtracking==0) ) {
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

                    	root_0 = (object)adaptor.GetNilNode();
                    	// 151:10: -> ^( FUNC_CALL IDENT PARAMS )
                    	{
                    	    // MathExpr.g:151:13: ^( FUNC_CALL IDENT PARAMS )
                    	    {
                    	    object root_1 = (object)adaptor.GetNilNode();
                    	    root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(FUNC_CALL, "FUNC_CALL"), root_1);

                    	    adaptor.AddChild(root_1, stream_IDENT.NextNode());
                    	    adaptor.AddChild(root_1, (object)adaptor.Create(PARAMS, "PARAMS"));

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}

                    	retval.Tree = root_0;retval.Tree = root_0;}
                    }
                    break;
                case 3 :
                    // MathExpr.g:152:4: 'begin' expr_list 'end'
                    {
                    	string_literal79=(IToken)Match(input,53,FOLLOW_53_in_expr1337); if (state.failed) return retval; 
                    	if ( (state.backtracking==0) ) stream_53.Add(string_literal79);

                    	PushFollow(FOLLOW_expr_list_in_expr1339);
                    	expr_list80 = expr_list();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( (state.backtracking==0) ) stream_expr_list.Add(expr_list80.Tree);
                    	string_literal81=(IToken)Match(input,54,FOLLOW_54_in_expr1341); if (state.failed) return retval; 
                    	if ( (state.backtracking==0) ) stream_54.Add(string_literal81);



                    	// AST REWRITE
                    	// elements:          expr_list
                    	// token labels:      
                    	// rule labels:       retval
                    	// token list labels: 
                    	// rule list labels:  
                    	// wildcard labels: 
                    	if ( (state.backtracking==0) ) {
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

                    	root_0 = (object)adaptor.GetNilNode();
                    	// 152:28: -> ^( BLOCK expr_list )
                    	{
                    	    // MathExpr.g:152:31: ^( BLOCK expr_list )
                    	    {
                    	    object root_1 = (object)adaptor.GetNilNode();
                    	    root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(BLOCK, "BLOCK"), root_1);

                    	    adaptor.AddChild(root_1, stream_expr_list.NextTree());

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}

                    	retval.Tree = root_0;retval.Tree = root_0;}
                    }
                    break;
                case 4 :
                    // MathExpr.g:153:4: FOR IDENT ASSIGN term TO term DO expr
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	FOR82=(IToken)Match(input,FOR,FOLLOW_FOR_in_expr1354); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{FOR82_tree = (object)adaptor.Create(FOR82);
                    		root_0 = (object)adaptor.BecomeRoot(FOR82_tree, root_0);
                    	}
                    	IDENT83=(IToken)Match(input,IDENT,FOLLOW_IDENT_in_expr1357); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{IDENT83_tree = (object)adaptor.Create(IDENT83);
                    		adaptor.AddChild(root_0, IDENT83_tree);
                    	}
                    	ASSIGN84=(IToken)Match(input,ASSIGN,FOLLOW_ASSIGN_in_expr1359); if (state.failed) return retval;
                    	PushFollow(FOLLOW_term_in_expr1362);
                    	term85 = term();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, term85.Tree);
                    	TO86=(IToken)Match(input,TO,FOLLOW_TO_in_expr1364); if (state.failed) return retval;
                    	PushFollow(FOLLOW_term_in_expr1367);
                    	term87 = term();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, term87.Tree);
                    	DO88=(IToken)Match(input,DO,FOLLOW_DO_in_expr1369); if (state.failed) return retval;
                    	PushFollow(FOLLOW_expr_in_expr1372);
                    	expr89 = expr();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expr89.Tree);

                    }
                    break;
                case 5 :
                    // MathExpr.g:154:4: WHILE logic DO expr
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	WHILE90=(IToken)Match(input,WHILE,FOLLOW_WHILE_in_expr1377); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{WHILE90_tree = (object)adaptor.Create(WHILE90);
                    		root_0 = (object)adaptor.BecomeRoot(WHILE90_tree, root_0);
                    	}
                    	PushFollow(FOLLOW_logic_in_expr1380);
                    	logic91 = logic();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logic91.Tree);
                    	DO92=(IToken)Match(input,DO,FOLLOW_DO_in_expr1382); if (state.failed) return retval;
                    	PushFollow(FOLLOW_expr_in_expr1385);
                    	expr93 = expr();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expr93.Tree);

                    }
                    break;
                case 6 :
                    // MathExpr.g:155:4: REPEAT expr_list UNTIL logic
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	REPEAT94=(IToken)Match(input,REPEAT,FOLLOW_REPEAT_in_expr1390); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{REPEAT94_tree = (object)adaptor.Create(REPEAT94);
                    		root_0 = (object)adaptor.BecomeRoot(REPEAT94_tree, root_0);
                    	}
                    	PushFollow(FOLLOW_expr_list_in_expr1393);
                    	expr_list95 = expr_list();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expr_list95.Tree);
                    	UNTIL96=(IToken)Match(input,UNTIL,FOLLOW_UNTIL_in_expr1395); if (state.failed) return retval;
                    	PushFollow(FOLLOW_logic_in_expr1398);
                    	logic97 = logic();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logic97.Tree);

                    }
                    break;
                case 7 :
                    // MathExpr.g:156:4: IF logic THEN expr ( ELSE expr )?
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	IF98=(IToken)Match(input,IF,FOLLOW_IF_in_expr1405); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{IF98_tree = (object)adaptor.Create(IF98);
                    		root_0 = (object)adaptor.BecomeRoot(IF98_tree, root_0);
                    	}
                    	PushFollow(FOLLOW_logic_in_expr1408);
                    	logic99 = logic();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logic99.Tree);
                    	THEN100=(IToken)Match(input,THEN,FOLLOW_THEN_in_expr1410); if (state.failed) return retval;
                    	PushFollow(FOLLOW_expr_in_expr1413);
                    	expr101 = expr();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expr101.Tree);
                    	// MathExpr.g:156:25: ( ELSE expr )?
                    	int alt23 = 2;
                    	int LA23_0 = input.LA(1);

                    	if ( (LA23_0 == ELSE) )
                    	{
                    	    int LA23_1 = input.LA(2);

                    	    if ( (synpred40_MathExpr()) )
                    	    {
                    	        alt23 = 1;
                    	    }
                    	}
                    	switch (alt23) 
                    	{
                    	    case 1 :
                    	        // MathExpr.g:156:27: ELSE expr
                    	        {
                    	        	ELSE102=(IToken)Match(input,ELSE,FOLLOW_ELSE_in_expr1417); if (state.failed) return retval;
                    	        	PushFollow(FOLLOW_expr_in_expr1420);
                    	        	expr103 = expr();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return retval;
                    	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expr103.Tree);

                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 8 :
                    // MathExpr.g:157:4: INC '(' IDENT ')'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	INC104=(IToken)Match(input,INC,FOLLOW_INC_in_expr1427); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{INC104_tree = (object)adaptor.Create(INC104);
                    		root_0 = (object)adaptor.BecomeRoot(INC104_tree, root_0);
                    	}
                    	char_literal105=(IToken)Match(input,42,FOLLOW_42_in_expr1430); if (state.failed) return retval;
                    	IDENT106=(IToken)Match(input,IDENT,FOLLOW_IDENT_in_expr1433); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{IDENT106_tree = (object)adaptor.Create(IDENT106);
                    		adaptor.AddChild(root_0, IDENT106_tree);
                    	}
                    	char_literal107=(IToken)Match(input,43,FOLLOW_43_in_expr1435); if (state.failed) return retval;

                    }
                    break;
                case 9 :
                    // MathExpr.g:158:4: DEC '(' IDENT ')'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	DEC108=(IToken)Match(input,DEC,FOLLOW_DEC_in_expr1441); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{DEC108_tree = (object)adaptor.Create(DEC108);
                    		root_0 = (object)adaptor.BecomeRoot(DEC108_tree, root_0);
                    	}
                    	char_literal109=(IToken)Match(input,42,FOLLOW_42_in_expr1444); if (state.failed) return retval;
                    	IDENT110=(IToken)Match(input,IDENT,FOLLOW_IDENT_in_expr1447); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{IDENT110_tree = (object)adaptor.Create(IDENT110);
                    		adaptor.AddChild(root_0, IDENT110_tree);
                    	}
                    	char_literal111=(IToken)Match(input,43,FOLLOW_43_in_expr1449); if (state.failed) return retval;

                    }
                    break;
                case 10 :
                    // MathExpr.g:159:4: func_call
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_func_call_in_expr1455);
                    	func_call112 = func_call();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, func_call112.Tree);

                    }
                    break;
                case 11 :
                    // MathExpr.g:160:4: func_descr
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_func_descr_in_expr1461);
                    	func_descr113 = func_descr();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, func_descr113.Tree);

                    }
                    break;
                case 12 :
                    // MathExpr.g:161:4: proc_descr
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_proc_descr_in_expr1466);
                    	proc_descr114 = proc_descr();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, proc_descr114.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 15, expr_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "expr"

    public class expr_list_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "expr_list"
    // MathExpr.g:164:1: expr_list : ( ';' )* ( var )? expr ( ( ';' )+ expr )* ( ';' )* ;
    public MathExprParser.expr_list_return expr_list() // throws RecognitionException [1]
    {   
        MathExprParser.expr_list_return retval = new MathExprParser.expr_list_return();
        retval.Start = input.LT(1);
        int expr_list_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal115 = null;
        IToken char_literal118 = null;
        IToken char_literal120 = null;
        MathExprParser.var_return var116 = default(MathExprParser.var_return);

        MathExprParser.expr_return expr117 = default(MathExprParser.expr_return);

        MathExprParser.expr_return expr119 = default(MathExprParser.expr_return);


        object char_literal115_tree=null;
        object char_literal118_tree=null;
        object char_literal120_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 16) ) 
    	    {
    	    	return retval; 
    	    }
            // MathExpr.g:164:10: ( ( ';' )* ( var )? expr ( ( ';' )+ expr )* ( ';' )* )
            // MathExpr.g:165:3: ( ';' )* ( var )? expr ( ( ';' )+ expr )* ( ';' )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// MathExpr.g:165:3: ( ';' )*
            	do 
            	{
            	    int alt25 = 2;
            	    int LA25_0 = input.LA(1);

            	    if ( (LA25_0 == TTT) )
            	    {
            	        alt25 = 1;
            	    }


            	    switch (alt25) 
            		{
            			case 1 :
            			    // MathExpr.g:165:4: ';'
            			    {
            			    	char_literal115=(IToken)Match(input,TTT,FOLLOW_TTT_in_expr_list1478); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop25;
            	    }
            	} while (true);

            	loop25:
            		;	// Stops C# compiler whining that label 'loop25' has no statements

            	// MathExpr.g:165:11: ( var )?
            	int alt26 = 2;
            	int LA26_0 = input.LA(1);

            	if ( (LA26_0 == VAR) )
            	{
            	    alt26 = 1;
            	}
            	switch (alt26) 
            	{
            	    case 1 :
            	        // MathExpr.g:0:0: var
            	        {
            	        	PushFollow(FOLLOW_var_in_expr_list1483);
            	        	var116 = var();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, var116.Tree);

            	        }
            	        break;

            	}

            	PushFollow(FOLLOW_expr_in_expr_list1486);
            	expr117 = expr();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expr117.Tree);
            	// MathExpr.g:165:21: ( ( ';' )+ expr )*
            	do 
            	{
            	    int alt28 = 2;
            	    alt28 = dfa28.Predict(input);
            	    switch (alt28) 
            		{
            			case 1 :
            			    // MathExpr.g:165:22: ( ';' )+ expr
            			    {
            			    	// MathExpr.g:165:22: ( ';' )+
            			    	int cnt27 = 0;
            			    	do 
            			    	{
            			    	    int alt27 = 2;
            			    	    int LA27_0 = input.LA(1);

            			    	    if ( (LA27_0 == TTT) )
            			    	    {
            			    	        alt27 = 1;
            			    	    }


            			    	    switch (alt27) 
            			    		{
            			    			case 1 :
            			    			    // MathExpr.g:165:23: ';'
            			    			    {
            			    			    	char_literal118=(IToken)Match(input,TTT,FOLLOW_TTT_in_expr_list1490); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    if ( cnt27 >= 1 ) goto loop27;
            			    			    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            			    		            EarlyExitException eee27 =
            			    		                new EarlyExitException(27, input);
            			    		            throw eee27;
            			    	    }
            			    	    cnt27++;
            			    	} while (true);

            			    	loop27:
            			    		;	// Stops C# compiler whining that label 'loop27' has no statements

            			    	PushFollow(FOLLOW_expr_in_expr_list1495);
            			    	expr119 = expr();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expr119.Tree);

            			    }
            			    break;

            			default:
            			    goto loop28;
            	    }
            	} while (true);

            	loop28:
            		;	// Stops C# compiler whining that label 'loop28' has no statements

            	// MathExpr.g:165:37: ( ';' )*
            	do 
            	{
            	    int alt29 = 2;
            	    int LA29_0 = input.LA(1);

            	    if ( (LA29_0 == TTT) )
            	    {
            	        alt29 = 1;
            	    }


            	    switch (alt29) 
            		{
            			case 1 :
            			    // MathExpr.g:165:38: ';'
            			    {
            			    	char_literal120=(IToken)Match(input,TTT,FOLLOW_TTT_in_expr_list1500); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop29;
            	    }
            	} while (true);

            	loop29:
            		;	// Stops C# compiler whining that label 'loop29' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 16, expr_list_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "expr_list"

    public class program_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "program"
    // MathExpr.g:169:1: program : expr_list ;
    public MathExprParser.program_return program() // throws RecognitionException [1]
    {   
        MathExprParser.program_return retval = new MathExprParser.program_return();
        retval.Start = input.LT(1);
        int program_StartIndex = input.Index();
        object root_0 = null;

        MathExprParser.expr_list_return expr_list121 = default(MathExprParser.expr_list_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 17) ) 
    	    {
    	    	return retval; 
    	    }
            // MathExpr.g:169:8: ( expr_list )
            // MathExpr.g:170:2: expr_list
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_expr_list_in_program1516);
            	expr_list121 = expr_list();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expr_list121.Tree);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 17, program_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "program"

    public class result_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "result"
    // MathExpr.g:172:1: result : program -> ^( PROGRAM program ) ;
    public MathExprParser.result_return result() // throws RecognitionException [1]
    {   
        MathExprParser.result_return retval = new MathExprParser.result_return();
        retval.Start = input.LT(1);
        int result_StartIndex = input.Index();
        object root_0 = null;

        MathExprParser.program_return program122 = default(MathExprParser.program_return);


        RewriteRuleSubtreeStream stream_program = new RewriteRuleSubtreeStream(adaptor,"rule program");
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 18) ) 
    	    {
    	    	return retval; 
    	    }
            // MathExpr.g:172:7: ( program -> ^( PROGRAM program ) )
            // MathExpr.g:172:9: program
            {
            	PushFollow(FOLLOW_program_in_result1523);
            	program122 = program();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( (state.backtracking==0) ) stream_program.Add(program122.Tree);


            	// AST REWRITE
            	// elements:          program
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	// wildcard labels: 
            	if ( (state.backtracking==0) ) {
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

            	root_0 = (object)adaptor.GetNilNode();
            	// 172:17: -> ^( PROGRAM program )
            	{
            	    // MathExpr.g:172:20: ^( PROGRAM program )
            	    {
            	    object root_1 = (object)adaptor.GetNilNode();
            	    root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(PROGRAM, "PROGRAM"), root_1);

            	    adaptor.AddChild(root_1, stream_program.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;}
            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 18, result_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "result"

    public class execute_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "execute"
    // MathExpr.g:174:1: execute : result ;
    public MathExprParser.execute_return execute() // throws RecognitionException [1]
    {   
        MathExprParser.execute_return retval = new MathExprParser.execute_return();
        retval.Start = input.LT(1);
        int execute_StartIndex = input.Index();
        object root_0 = null;

        MathExprParser.result_return result123 = default(MathExprParser.result_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 19) ) 
    	    {
    	    	return retval; 
    	    }
            // MathExpr.g:174:8: ( result )
            // MathExpr.g:175:3: result
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_result_in_execute1540);
            	result123 = result();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, result123.Tree);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 19, execute_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "execute"

    // $ANTLR start "synpred24_MathExpr"
    public void synpred24_MathExpr_fragment() {
        // MathExpr.g:129:2: ( exprvar ( ';' )+ ( exprvar ( ';' )+ )* )
        // MathExpr.g:129:2: exprvar ( ';' )+ ( exprvar ( ';' )+ )*
        {
        	PushFollow(FOLLOW_exprvar_in_synpred24_MathExpr1137);
        	exprvar();
        	state.followingStackPointer--;
        	if (state.failed) return ;
        	// MathExpr.g:129:10: ( ';' )+
        	int cnt32 = 0;
        	do 
        	{
        	    int alt32 = 2;
        	    int LA32_0 = input.LA(1);

        	    if ( (LA32_0 == TTT) )
        	    {
        	        alt32 = 1;
        	    }


        	    switch (alt32) 
        		{
        			case 1 :
        			    // MathExpr.g:129:11: ';'
        			    {
        			    	Match(input,TTT,FOLLOW_TTT_in_synpred24_MathExpr1140); if (state.failed) return ;

        			    }
        			    break;

        			default:
        			    if ( cnt32 >= 1 ) goto loop32;
        			    if ( state.backtracking > 0 ) {state.failed = true; return ;}
        		            EarlyExitException eee32 =
        		                new EarlyExitException(32, input);
        		            throw eee32;
        	    }
        	    cnt32++;
        	} while (true);

        	loop32:
        		;	// Stops C# compiler whining that label 'loop32' has no statements

        	// MathExpr.g:129:18: ( exprvar ( ';' )+ )*
        	do 
        	{
        	    int alt34 = 2;
        	    int LA34_0 = input.LA(1);

        	    if ( (LA34_0 == IDENT) )
        	    {
        	        alt34 = 1;
        	    }


        	    switch (alt34) 
        		{
        			case 1 :
        			    // MathExpr.g:129:19: exprvar ( ';' )+
        			    {
        			    	PushFollow(FOLLOW_exprvar_in_synpred24_MathExpr1146);
        			    	exprvar();
        			    	state.followingStackPointer--;
        			    	if (state.failed) return ;
        			    	// MathExpr.g:129:27: ( ';' )+
        			    	int cnt33 = 0;
        			    	do 
        			    	{
        			    	    int alt33 = 2;
        			    	    int LA33_0 = input.LA(1);

        			    	    if ( (LA33_0 == TTT) )
        			    	    {
        			    	        alt33 = 1;
        			    	    }


        			    	    switch (alt33) 
        			    		{
        			    			case 1 :
        			    			    // MathExpr.g:129:28: ';'
        			    			    {
        			    			    	Match(input,TTT,FOLLOW_TTT_in_synpred24_MathExpr1149); if (state.failed) return ;

        			    			    }
        			    			    break;

        			    			default:
        			    			    if ( cnt33 >= 1 ) goto loop33;
        			    			    if ( state.backtracking > 0 ) {state.failed = true; return ;}
        			    		            EarlyExitException eee33 =
        			    		                new EarlyExitException(33, input);
        			    		            throw eee33;
        			    	    }
        			    	    cnt33++;
        			    	} while (true);

        			    	loop33:
        			    		;	// Stops C# compiler whining that label 'loop33' has no statements


        			    }
        			    break;

        			default:
        			    goto loop34;
        	    }
        	} while (true);

        	loop34:
        		;	// Stops C# compiler whining that label 'loop34' has no statements


        }
    }
    // $ANTLR end "synpred24_MathExpr"

    // $ANTLR start "synpred28_MathExpr"
    public void synpred28_MathExpr_fragment() {
        // MathExpr.g:134:25: ( ';' )
        // MathExpr.g:134:25: ';'
        {
        	Match(input,TTT,FOLLOW_TTT_in_synpred28_MathExpr1196); if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred28_MathExpr"

    // $ANTLR start "synpred30_MathExpr"
    public void synpred30_MathExpr_fragment() {
        // MathExpr.g:135:62: ( ';' )
        // MathExpr.g:135:62: ';'
        {
        	Match(input,TTT,FOLLOW_TTT_in_synpred30_MathExpr1234); if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred30_MathExpr"

    // $ANTLR start "synpred40_MathExpr"
    public void synpred40_MathExpr_fragment() {
        // MathExpr.g:156:27: ( ELSE expr )
        // MathExpr.g:156:27: ELSE expr
        {
        	Match(input,ELSE,FOLLOW_ELSE_in_synpred40_MathExpr1417); if (state.failed) return ;
        	PushFollow(FOLLOW_expr_in_synpred40_MathExpr1420);
        	expr();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred40_MathExpr"

    // Delegated rules

   	public bool synpred30_MathExpr() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred30_MathExpr_fragment(); // can never throw exception
   	    }
   	    catch (RecognitionException re) 
   	    {
   	        Console.Error.WriteLine("impossible: "+re);
   	    }
   	    bool success = !state.failed;
   	    input.Rewind(start);
   	    state.backtracking--;
   	    state.failed = false;
   	    return success;
   	}
   	public bool synpred40_MathExpr() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred40_MathExpr_fragment(); // can never throw exception
   	    }
   	    catch (RecognitionException re) 
   	    {
   	        Console.Error.WriteLine("impossible: "+re);
   	    }
   	    bool success = !state.failed;
   	    input.Rewind(start);
   	    state.backtracking--;
   	    state.failed = false;
   	    return success;
   	}
   	public bool synpred28_MathExpr() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred28_MathExpr_fragment(); // can never throw exception
   	    }
   	    catch (RecognitionException re) 
   	    {
   	        Console.Error.WriteLine("impossible: "+re);
   	    }
   	    bool success = !state.failed;
   	    input.Rewind(start);
   	    state.backtracking--;
   	    state.failed = false;
   	    return success;
   	}
   	public bool synpred24_MathExpr() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred24_MathExpr_fragment(); // can never throw exception
   	    }
   	    catch (RecognitionException re) 
   	    {
   	        Console.Error.WriteLine("impossible: "+re);
   	    }
   	    bool success = !state.failed;
   	    input.Rewind(start);
   	    state.backtracking--;
   	    state.failed = false;
   	    return success;
   	}


   	protected DFA17 dfa17;
   	protected DFA24 dfa24;
   	protected DFA28 dfa28;
	private void InitializeCyclicDFAs()
	{
    	this.dfa17 = new DFA17(this);
    	this.dfa24 = new DFA24(this);
    	this.dfa28 = new DFA28(this);
	    this.dfa17.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA17_SpecialStateTransition);
	}

    const string DFA17_eotS =
        "\x17\uffff";
    const string DFA17_eofS =
        "\x05\uffff\x03\x0b\x0b\uffff\x03\x0b\x01\uffff";
    const string DFA17_minS =
        "\x01\x23\x01\x1c\x01\x2d\x01\x23\x01\x2e\x03\x0a\x01\x1c\x01\x20"+
        "\x01\x00\x01\uffff\x01\x32\x01\x2f\x01\uffff\x01\x20\x01\x30\x01"+
        "\x31\x01\x32\x03\x0a\x01\x00";
    const string DFA17_maxS =
        "\x01\x23\x01\x2c\x01\x34\x01\x23\x01\x2e\x03\x35\x01\x2c\x01\x20"+
        "\x01\x00\x01\uffff\x01\x34\x01\x2f\x01\uffff\x01\x20\x01\x30\x01"+
        "\x31\x01\x34\x03\x35\x01\x00";
    const string DFA17_acceptS =
        "\x0b\uffff\x01\x02\x02\uffff\x01\x01\x08\uffff";
    const string DFA17_specialS =
        "\x0a\uffff\x01\x00\x0b\uffff\x01\x01}>";
    static readonly string[] DFA17_transitionS = {
            "\x01\x01",
            "\x01\x02\x0f\uffff\x01\x03",
            "\x01\x04\x04\uffff\x01\x05\x01\x06\x01\x07",
            "\x01\x08",
            "\x01\x09",
            "\x06\x0b\x03\uffff\x02\x0b\x08\uffff\x01\x0a\x05\uffff\x01"+
            "\x0b\x07\uffff\x01\x0b\x09\uffff\x01\x0b",
            "\x06\x0b\x03\uffff\x02\x0b\x08\uffff\x01\x0a\x05\uffff\x01"+
            "\x0b\x07\uffff\x01\x0b\x09\uffff\x01\x0b",
            "\x06\x0b\x03\uffff\x02\x0b\x08\uffff\x01\x0a\x05\uffff\x01"+
            "\x0b\x07\uffff\x01\x0b\x09\uffff\x01\x0b",
            "\x01\x0c\x0f\uffff\x01\x03",
            "\x01\x0d",
            "\x01\uffff",
            "",
            "\x01\x05\x01\x06\x01\x07",
            "\x01\x0f",
            "",
            "\x01\x10",
            "\x01\x11",
            "\x01\x12",
            "\x01\x13\x01\x14\x01\x15",
            "\x06\x0b\x03\uffff\x02\x0b\x08\uffff\x01\x16\x05\uffff\x01"+
            "\x0b\x07\uffff\x01\x0b\x09\uffff\x01\x0b",
            "\x06\x0b\x03\uffff\x02\x0b\x08\uffff\x01\x16\x05\uffff\x01"+
            "\x0b\x07\uffff\x01\x0b\x09\uffff\x01\x0b",
            "\x06\x0b\x03\uffff\x02\x0b\x08\uffff\x01\x16\x05\uffff\x01"+
            "\x0b\x07\uffff\x01\x0b\x09\uffff\x01\x0b",
            "\x01\uffff"
    };

    static readonly short[] DFA17_eot = DFA.UnpackEncodedString(DFA17_eotS);
    static readonly short[] DFA17_eof = DFA.UnpackEncodedString(DFA17_eofS);
    static readonly char[] DFA17_min = DFA.UnpackEncodedStringToUnsignedChars(DFA17_minS);
    static readonly char[] DFA17_max = DFA.UnpackEncodedStringToUnsignedChars(DFA17_maxS);
    static readonly short[] DFA17_accept = DFA.UnpackEncodedString(DFA17_acceptS);
    static readonly short[] DFA17_special = DFA.UnpackEncodedString(DFA17_specialS);
    static readonly short[][] DFA17_transition = DFA.UnpackEncodedStringArray(DFA17_transitionS);

    protected class DFA17 : DFA
    {
        public DFA17(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 17;
            this.eot = DFA17_eot;
            this.eof = DFA17_eof;
            this.min = DFA17_min;
            this.max = DFA17_max;
            this.accept = DFA17_accept;
            this.special = DFA17_special;
            this.transition = DFA17_transition;

        }

        override public string Description
        {
            get { return "128:1: var_list : ( exprvar ( ';' )+ ( exprvar ( ';' )+ )* | exprvar ( ';' )* ( exprvar ( ';' )* )* );"; }
        }

    }


    protected internal int DFA17_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA17_10 = input.LA(1);

                   	 
                   	int index17_10 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred24_MathExpr()) ) { s = 14; }

                   	else if ( (true) ) { s = 11; }

                   	 
                   	input.Seek(index17_10);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA17_22 = input.LA(1);

                   	 
                   	int index17_22 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred24_MathExpr()) ) { s = 14; }

                   	else if ( (true) ) { s = 11; }

                   	 
                   	input.Seek(index17_22);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae17 =
            new NoViableAltException(dfa.Description, 17, _s, input);
        dfa.Error(nvae17);
        throw nvae17;
    }
    const string DFA24_eotS =
        "\x0e\uffff";
    const string DFA24_eofS =
        "\x01\uffff\x01\x0d\x0c\uffff";
    const string DFA24_minS =
        "\x01\x0a\x01\x10\x0c\uffff";
    const string DFA24_maxS =
        "\x01\x35\x01\x36\x0c\uffff";
    const string DFA24_acceptS =
        "\x02\uffff\x01\x03\x01\x04\x01\x05\x01\x06\x01\x07\x01\x08\x01"+
        "\x09\x01\x0b\x01\x0c\x01\x01\x01\x0a\x01\x02";
    const string DFA24_specialS =
        "\x0e\uffff}>";
    static readonly string[] DFA24_transitionS = {
            "\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x03\x01\x05\x03\uffff"+
            "\x01\x04\x01\x06\x0e\uffff\x01\x01\x11\uffff\x01\x02",
            "\x01\x0d\x05\uffff\x01\x0d\x06\uffff\x01\x0d\x0a\uffff\x01"+
            "\x0b\x01\uffff\x01\x0c\x0b\uffff\x01\x0d",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA24_eot = DFA.UnpackEncodedString(DFA24_eotS);
    static readonly short[] DFA24_eof = DFA.UnpackEncodedString(DFA24_eofS);
    static readonly char[] DFA24_min = DFA.UnpackEncodedStringToUnsignedChars(DFA24_minS);
    static readonly char[] DFA24_max = DFA.UnpackEncodedStringToUnsignedChars(DFA24_maxS);
    static readonly short[] DFA24_accept = DFA.UnpackEncodedString(DFA24_acceptS);
    static readonly short[] DFA24_special = DFA.UnpackEncodedString(DFA24_specialS);
    static readonly short[][] DFA24_transition = DFA.UnpackEncodedStringArray(DFA24_transitionS);

    protected class DFA24 : DFA
    {
        public DFA24(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 24;
            this.eot = DFA24_eot;
            this.eof = DFA24_eof;
            this.min = DFA24_min;
            this.max = DFA24_max;
            this.accept = DFA24_accept;
            this.special = DFA24_special;
            this.transition = DFA24_transition;

        }

        override public string Description
        {
            get { return "149:1: expr : ( IDENT ASSIGN term | IDENT -> ^( FUNC_CALL IDENT PARAMS ) | 'begin' expr_list 'end' -> ^( BLOCK expr_list ) | FOR IDENT ASSIGN term TO term DO expr | WHILE logic DO expr | REPEAT expr_list UNTIL logic | IF logic THEN expr ( ELSE expr )? | INC '(' IDENT ')' | DEC '(' IDENT ')' | func_call | func_descr | proc_descr );"; }
        }

    }

    const string DFA28_eotS =
        "\x04\uffff";
    const string DFA28_eofS =
        "\x02\x02\x02\uffff";
    const string DFA28_minS =
        "\x01\x10\x01\x0a\x02\uffff";
    const string DFA28_maxS =
        "\x02\x36\x02\uffff";
    const string DFA28_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA28_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA28_transitionS = {
            "\x01\x02\x0c\uffff\x01\x01\x18\uffff\x01\x02",
            "\x06\x03\x01\x02\x02\uffff\x02\x03\x08\uffff\x01\x01\x05\uffff"+
            "\x01\x03\x11\uffff\x01\x03\x01\x02",
            "",
            ""
    };

    static readonly short[] DFA28_eot = DFA.UnpackEncodedString(DFA28_eotS);
    static readonly short[] DFA28_eof = DFA.UnpackEncodedString(DFA28_eofS);
    static readonly char[] DFA28_min = DFA.UnpackEncodedStringToUnsignedChars(DFA28_minS);
    static readonly char[] DFA28_max = DFA.UnpackEncodedStringToUnsignedChars(DFA28_maxS);
    static readonly short[] DFA28_accept = DFA.UnpackEncodedString(DFA28_acceptS);
    static readonly short[] DFA28_special = DFA.UnpackEncodedString(DFA28_specialS);
    static readonly short[][] DFA28_transition = DFA.UnpackEncodedStringArray(DFA28_transitionS);

    protected class DFA28 : DFA
    {
        public DFA28(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 28;
            this.eot = DFA28_eot;
            this.eof = DFA28_eof;
            this.min = DFA28_min;
            this.max = DFA28_max;
            this.accept = DFA28_accept;
            this.special = DFA28_special;
            this.transition = DFA28_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 165:21: ( ( ';' )+ expr )*"; }
        }

    }

 

    public static readonly BitSet FOLLOW_42_in_group784 = new BitSet(new ulong[]{0x0000040F00000000UL});
    public static readonly BitSet FOLLOW_term_in_group787 = new BitSet(new ulong[]{0x0000080000000000UL});
    public static readonly BitSet FOLLOW_43_in_group789 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_REAL_in_group794 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INTEGER_in_group806 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_STRING_in_group810 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_func_call_in_group814 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IDENT_in_group818 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_group_in_mult827 = new BitSet(new ulong[]{0x000000C003800002UL});
    public static readonly BitSet FOLLOW_set_in_mult831 = new BitSet(new ulong[]{0x0000040F00000000UL});
    public static readonly BitSet FOLLOW_group_in_mult854 = new BitSet(new ulong[]{0x000000C003800002UL});
    public static readonly BitSet FOLLOW_mult_in_add866 = new BitSet(new ulong[]{0x0000003004000002UL});
    public static readonly BitSet FOLLOW_set_in_add871 = new BitSet(new ulong[]{0x0000040F00000000UL});
    public static readonly BitSet FOLLOW_mult_in_add886 = new BitSet(new ulong[]{0x0000003004000002UL});
    public static readonly BitSet FOLLOW_add_in_logic898 = new BitSet(new ulong[]{0x0000020000000002UL});
    public static readonly BitSet FOLLOW_COMPARE_in_logic902 = new BitSet(new ulong[]{0x0000040F00000000UL});
    public static readonly BitSet FOLLOW_add_in_logic905 = new BitSet(new ulong[]{0x0000020000000002UL});
    public static readonly BitSet FOLLOW_logic_in_term918 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_term_in_params_929 = new BitSet(new ulong[]{0x0000100000000002UL});
    public static readonly BitSet FOLLOW_44_in_params_932 = new BitSet(new ulong[]{0x0000040F00000000UL});
    public static readonly BitSet FOLLOW_term_in_params_935 = new BitSet(new ulong[]{0x0000100000000002UL});
    public static readonly BitSet FOLLOW_IDENT_in_func_call950 = new BitSet(new ulong[]{0x0000040000000000UL});
    public static readonly BitSet FOLLOW_42_in_func_call954 = new BitSet(new ulong[]{0x00000C0F00000000UL});
    public static readonly BitSet FOLLOW_params__in_func_call956 = new BitSet(new ulong[]{0x0000080000000000UL});
    public static readonly BitSet FOLLOW_43_in_func_call958 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FUNCTION_in_func_descr992 = new BitSet(new ulong[]{0x0000000800000000UL});
    public static readonly BitSet FOLLOW_IDENT_in_func_descr994 = new BitSet(new ulong[]{0x0000040000000000UL});
    public static readonly BitSet FOLLOW_42_in_func_descr997 = new BitSet(new ulong[]{0x0000080800000000UL});
    public static readonly BitSet FOLLOW_var_list_in_func_descr999 = new BitSet(new ulong[]{0x0000080000000000UL});
    public static readonly BitSet FOLLOW_43_in_func_descr1002 = new BitSet(new ulong[]{0x0000000010000000UL});
    public static readonly BitSet FOLLOW_DDD_in_func_descr1004 = new BitSet(new ulong[]{0x001C000000000000UL});
    public static readonly BitSet FOLLOW_type_in_func_descr1006 = new BitSet(new ulong[]{0x0000000020000000UL});
    public static readonly BitSet FOLLOW_TTT_in_func_descr1008 = new BitSet(new ulong[]{0x002000080018FC20UL});
    public static readonly BitSet FOLLOW_var_in_func_descr1011 = new BitSet(new ulong[]{0x002000080018FC20UL});
    public static readonly BitSet FOLLOW_expr_in_func_descr1015 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_PROCEDURE_in_proc_descr1057 = new BitSet(new ulong[]{0x0000000800000000UL});
    public static readonly BitSet FOLLOW_IDENT_in_proc_descr1059 = new BitSet(new ulong[]{0x0000040000000000UL});
    public static readonly BitSet FOLLOW_42_in_proc_descr1062 = new BitSet(new ulong[]{0x0000080800000000UL});
    public static readonly BitSet FOLLOW_var_list_in_proc_descr1064 = new BitSet(new ulong[]{0x0000080000000000UL});
    public static readonly BitSet FOLLOW_43_in_proc_descr1067 = new BitSet(new ulong[]{0x0000000020000000UL});
    public static readonly BitSet FOLLOW_TTT_in_proc_descr1069 = new BitSet(new ulong[]{0x002000080018FC20UL});
    public static readonly BitSet FOLLOW_var_in_proc_descr1072 = new BitSet(new ulong[]{0x002000080018FC20UL});
    public static readonly BitSet FOLLOW_expr_in_proc_descr1076 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_VAR_in_var1116 = new BitSet(new ulong[]{0x0000000800000000UL});
    public static readonly BitSet FOLLOW_var_list_in_var1118 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_exprvar_in_var_list1137 = new BitSet(new ulong[]{0x0000000020000000UL});
    public static readonly BitSet FOLLOW_TTT_in_var_list1140 = new BitSet(new ulong[]{0x0000000820000002UL});
    public static readonly BitSet FOLLOW_exprvar_in_var_list1146 = new BitSet(new ulong[]{0x0000000020000000UL});
    public static readonly BitSet FOLLOW_TTT_in_var_list1149 = new BitSet(new ulong[]{0x0000000820000002UL});
    public static readonly BitSet FOLLOW_exprvar_in_var_list1160 = new BitSet(new ulong[]{0x0000000820000002UL});
    public static readonly BitSet FOLLOW_TTT_in_var_list1163 = new BitSet(new ulong[]{0x0000000820000002UL});
    public static readonly BitSet FOLLOW_exprvar_in_var_list1169 = new BitSet(new ulong[]{0x0000000820000002UL});
    public static readonly BitSet FOLLOW_TTT_in_var_list1172 = new BitSet(new ulong[]{0x0000000820000002UL});
    public static readonly BitSet FOLLOW_ident_list_in_exprvar1187 = new BitSet(new ulong[]{0x0000000010000000UL});
    public static readonly BitSet FOLLOW_DDD_in_exprvar1190 = new BitSet(new ulong[]{0x001C000000000000UL});
    public static readonly BitSet FOLLOW_type_in_exprvar1192 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_TTT_in_exprvar1196 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IDENT_in_exprvar1212 = new BitSet(new ulong[]{0x0000000010000000UL});
    public static readonly BitSet FOLLOW_DDD_in_exprvar1214 = new BitSet(new ulong[]{0x0000200000000000UL});
    public static readonly BitSet FOLLOW_45_in_exprvar1216 = new BitSet(new ulong[]{0x0000400000000000UL});
    public static readonly BitSet FOLLOW_46_in_exprvar1218 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_INTEGER_in_exprvar1220 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_47_in_exprvar1222 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_INTEGER_in_exprvar1224 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_48_in_exprvar1227 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_exprvar1229 = new BitSet(new ulong[]{0x001C000000000000UL});
    public static readonly BitSet FOLLOW_type_in_exprvar1231 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_TTT_in_exprvar1234 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_50_in_type1261 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_51_in_type1270 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_52_in_type1279 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IDENT_in_ident_list1293 = new BitSet(new ulong[]{0x0000100000000002UL});
    public static readonly BitSet FOLLOW_44_in_ident_list1296 = new BitSet(new ulong[]{0x0000000800000000UL});
    public static readonly BitSet FOLLOW_IDENT_in_ident_list1299 = new BitSet(new ulong[]{0x0000100000000002UL});
    public static readonly BitSet FOLLOW_IDENT_in_expr1312 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_ASSIGN_in_expr1314 = new BitSet(new ulong[]{0x0000040F00000000UL});
    public static readonly BitSet FOLLOW_term_in_expr1317 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IDENT_in_expr1322 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_53_in_expr1337 = new BitSet(new ulong[]{0x002000082018FC20UL});
    public static readonly BitSet FOLLOW_expr_list_in_expr1339 = new BitSet(new ulong[]{0x0040000000000000UL});
    public static readonly BitSet FOLLOW_54_in_expr1341 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FOR_in_expr1354 = new BitSet(new ulong[]{0x0000000800000000UL});
    public static readonly BitSet FOLLOW_IDENT_in_expr1357 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_ASSIGN_in_expr1359 = new BitSet(new ulong[]{0x0000040F00000000UL});
    public static readonly BitSet FOLLOW_term_in_expr1362 = new BitSet(new ulong[]{0x0000000000020000UL});
    public static readonly BitSet FOLLOW_TO_in_expr1364 = new BitSet(new ulong[]{0x0000040F00000000UL});
    public static readonly BitSet FOLLOW_term_in_expr1367 = new BitSet(new ulong[]{0x0000000000040000UL});
    public static readonly BitSet FOLLOW_DO_in_expr1369 = new BitSet(new ulong[]{0x002000080018FC20UL});
    public static readonly BitSet FOLLOW_expr_in_expr1372 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_WHILE_in_expr1377 = new BitSet(new ulong[]{0x0000040F00000000UL});
    public static readonly BitSet FOLLOW_logic_in_expr1380 = new BitSet(new ulong[]{0x0000000000040000UL});
    public static readonly BitSet FOLLOW_DO_in_expr1382 = new BitSet(new ulong[]{0x002000080018FC20UL});
    public static readonly BitSet FOLLOW_expr_in_expr1385 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_REPEAT_in_expr1390 = new BitSet(new ulong[]{0x002000082018FC20UL});
    public static readonly BitSet FOLLOW_expr_list_in_expr1393 = new BitSet(new ulong[]{0x0000000000010000UL});
    public static readonly BitSet FOLLOW_UNTIL_in_expr1395 = new BitSet(new ulong[]{0x0000040F00000000UL});
    public static readonly BitSet FOLLOW_logic_in_expr1398 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IF_in_expr1405 = new BitSet(new ulong[]{0x0000040F00000000UL});
    public static readonly BitSet FOLLOW_logic_in_expr1408 = new BitSet(new ulong[]{0x0000000000200000UL});
    public static readonly BitSet FOLLOW_THEN_in_expr1410 = new BitSet(new ulong[]{0x002000080018FC20UL});
    public static readonly BitSet FOLLOW_expr_in_expr1413 = new BitSet(new ulong[]{0x0000000000400002UL});
    public static readonly BitSet FOLLOW_ELSE_in_expr1417 = new BitSet(new ulong[]{0x002000080018FC20UL});
    public static readonly BitSet FOLLOW_expr_in_expr1420 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INC_in_expr1427 = new BitSet(new ulong[]{0x0000040000000000UL});
    public static readonly BitSet FOLLOW_42_in_expr1430 = new BitSet(new ulong[]{0x0000000800000000UL});
    public static readonly BitSet FOLLOW_IDENT_in_expr1433 = new BitSet(new ulong[]{0x0000080000000000UL});
    public static readonly BitSet FOLLOW_43_in_expr1435 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DEC_in_expr1441 = new BitSet(new ulong[]{0x0000040000000000UL});
    public static readonly BitSet FOLLOW_42_in_expr1444 = new BitSet(new ulong[]{0x0000000800000000UL});
    public static readonly BitSet FOLLOW_IDENT_in_expr1447 = new BitSet(new ulong[]{0x0000080000000000UL});
    public static readonly BitSet FOLLOW_43_in_expr1449 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_func_call_in_expr1455 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_func_descr_in_expr1461 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_proc_descr_in_expr1466 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TTT_in_expr_list1478 = new BitSet(new ulong[]{0x002000082018FC20UL});
    public static readonly BitSet FOLLOW_var_in_expr_list1483 = new BitSet(new ulong[]{0x002000080018FC20UL});
    public static readonly BitSet FOLLOW_expr_in_expr_list1486 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_TTT_in_expr_list1490 = new BitSet(new ulong[]{0x002000082018FC20UL});
    public static readonly BitSet FOLLOW_expr_in_expr_list1495 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_TTT_in_expr_list1500 = new BitSet(new ulong[]{0x0000000020000002UL});
    public static readonly BitSet FOLLOW_expr_list_in_program1516 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_program_in_result1523 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_result_in_execute1540 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_exprvar_in_synpred24_MathExpr1137 = new BitSet(new ulong[]{0x0000000020000000UL});
    public static readonly BitSet FOLLOW_TTT_in_synpred24_MathExpr1140 = new BitSet(new ulong[]{0x0000000820000002UL});
    public static readonly BitSet FOLLOW_exprvar_in_synpred24_MathExpr1146 = new BitSet(new ulong[]{0x0000000020000000UL});
    public static readonly BitSet FOLLOW_TTT_in_synpred24_MathExpr1149 = new BitSet(new ulong[]{0x0000000820000002UL});
    public static readonly BitSet FOLLOW_TTT_in_synpred28_MathExpr1196 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TTT_in_synpred30_MathExpr1234 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ELSE_in_synpred40_MathExpr1417 = new BitSet(new ulong[]{0x002000080018FC20UL});
    public static readonly BitSet FOLLOW_expr_in_synpred40_MathExpr1420 = new BitSet(new ulong[]{0x0000000000000002UL});

}
}