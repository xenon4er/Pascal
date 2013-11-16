// $ANTLR 3.2 Sep 23, 2009 12:02:23 MathExpr.g 2013-11-05 17:58:41

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;


namespace  MathExpr 
{
public partial class MathExprLexer : Lexer {
    public const int FUNCTION = 12;
    public const int DEC = 11;
    public const int MOD_INT = 24;
    public const int WHILE = 19;
    public const int DO = 18;
    public const int FOR = 14;
    public const int SUB = 37;
    public const int TTT = 29;
    public const int AND = 25;
    public const int EOF = -1;
    public const int IF = 20;
    public const int FUNC_CALL = 8;
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

    public MathExprLexer() 
    {
		InitializeCyclicDFAs();
    }
    public MathExprLexer(ICharStream input)
		: this(input, null) {
    }
    public MathExprLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state) {
		InitializeCyclicDFAs(); 

    }
    
    override public string GrammarFileName
    {
    	get { return "MathExpr.g";} 
    }

    // $ANTLR start "VAR"
    public void mVAR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = VAR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:9:5: ( 'var' )
            // MathExpr.g:9:7: 'var'
            {
            	Match("var"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "VAR"

    // $ANTLR start "INC"
    public void mINC() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = INC;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:10:5: ( 'inc' )
            // MathExpr.g:10:7: 'inc'
            {
            	Match("inc"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "INC"

    // $ANTLR start "DEC"
    public void mDEC() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DEC;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:11:5: ( 'dec' )
            // MathExpr.g:11:7: 'dec'
            {
            	Match("dec"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DEC"

    // $ANTLR start "FUNCTION"
    public void mFUNCTION() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = FUNCTION;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:12:10: ( 'function' )
            // MathExpr.g:12:12: 'function'
            {
            	Match("function"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "FUNCTION"

    // $ANTLR start "PROCEDURE"
    public void mPROCEDURE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = PROCEDURE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:13:11: ( 'procedure' )
            // MathExpr.g:13:13: 'procedure'
            {
            	Match("procedure"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "PROCEDURE"

    // $ANTLR start "FOR"
    public void mFOR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = FOR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:14:5: ( 'for' )
            // MathExpr.g:14:7: 'for'
            {
            	Match("for"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "FOR"

    // $ANTLR start "REPEAT"
    public void mREPEAT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = REPEAT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:15:8: ( 'repeat' )
            // MathExpr.g:15:10: 'repeat'
            {
            	Match("repeat"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "REPEAT"

    // $ANTLR start "UNTIL"
    public void mUNTIL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = UNTIL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:16:7: ( 'until' )
            // MathExpr.g:16:9: 'until'
            {
            	Match("until"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "UNTIL"

    // $ANTLR start "TO"
    public void mTO() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TO;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:17:4: ( 'to' )
            // MathExpr.g:17:6: 'to'
            {
            	Match("to"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "TO"

    // $ANTLR start "DO"
    public void mDO() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DO;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:18:4: ( 'do' )
            // MathExpr.g:18:6: 'do'
            {
            	Match("do"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DO"

    // $ANTLR start "WHILE"
    public void mWHILE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WHILE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:19:7: ( 'while' )
            // MathExpr.g:19:9: 'while'
            {
            	Match("while"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "WHILE"

    // $ANTLR start "IF"
    public void mIF() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = IF;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:20:4: ( 'if' )
            // MathExpr.g:20:6: 'if'
            {
            	Match("if"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "IF"

    // $ANTLR start "THEN"
    public void mTHEN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = THEN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:21:6: ( 'then' )
            // MathExpr.g:21:8: 'then'
            {
            	Match("then"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "THEN"

    // $ANTLR start "ELSE"
    public void mELSE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ELSE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:22:6: ( 'else' )
            // MathExpr.g:22:8: 'else'
            {
            	Match("else"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ELSE"

    // $ANTLR start "DIV_INT"
    public void mDIV_INT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DIV_INT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:23:9: ( 'div' )
            // MathExpr.g:23:11: 'div'
            {
            	Match("div"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DIV_INT"

    // $ANTLR start "MOD_INT"
    public void mMOD_INT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MOD_INT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:24:9: ( 'mod' )
            // MathExpr.g:24:11: 'mod'
            {
            	Match("mod"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MOD_INT"

    // $ANTLR start "AND"
    public void mAND() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = AND;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:25:5: ( 'and' )
            // MathExpr.g:25:7: 'and'
            {
            	Match("and"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "AND"

    // $ANTLR start "OR"
    public void mOR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = OR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:26:4: ( 'or' )
            // MathExpr.g:26:6: 'or'
            {
            	Match("or"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "OR"

    // $ANTLR start "XOR"
    public void mXOR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = XOR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:27:5: ( 'xor' )
            // MathExpr.g:27:7: 'xor'
            {
            	Match("xor"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "XOR"

    // $ANTLR start "DDD"
    public void mDDD() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DDD;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:28:5: ( ':' )
            // MathExpr.g:28:7: ':'
            {
            	Match(':'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DDD"

    // $ANTLR start "TTT"
    public void mTTT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TTT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:29:5: ( ';' )
            // MathExpr.g:29:7: ';'
            {
            	Match(';'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "TTT"

    // $ANTLR start "T__42"
    public void mT__42() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__42;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:30:7: ( '(' )
            // MathExpr.g:30:9: '('
            {
            	Match('('); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__42"

    // $ANTLR start "T__43"
    public void mT__43() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__43;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:31:7: ( ')' )
            // MathExpr.g:31:9: ')'
            {
            	Match(')'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__43"

    // $ANTLR start "T__44"
    public void mT__44() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__44;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:32:7: ( ',' )
            // MathExpr.g:32:9: ','
            {
            	Match(','); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__44"

    // $ANTLR start "T__45"
    public void mT__45() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__45;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:33:7: ( 'array' )
            // MathExpr.g:33:9: 'array'
            {
            	Match("array"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__45"

    // $ANTLR start "T__46"
    public void mT__46() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__46;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:34:7: ( '[' )
            // MathExpr.g:34:9: '['
            {
            	Match('['); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__46"

    // $ANTLR start "T__47"
    public void mT__47() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__47;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:35:7: ( '..' )
            // MathExpr.g:35:9: '..'
            {
            	Match(".."); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__47"

    // $ANTLR start "T__48"
    public void mT__48() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__48;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:36:7: ( ']' )
            // MathExpr.g:36:9: ']'
            {
            	Match(']'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__48"

    // $ANTLR start "T__49"
    public void mT__49() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__49;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:37:7: ( 'of' )
            // MathExpr.g:37:9: 'of'
            {
            	Match("of"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__49"

    // $ANTLR start "T__50"
    public void mT__50() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__50;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:38:7: ( 'real' )
            // MathExpr.g:38:9: 'real'
            {
            	Match("real"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__50"

    // $ANTLR start "T__51"
    public void mT__51() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__51;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:39:7: ( 'integer' )
            // MathExpr.g:39:9: 'integer'
            {
            	Match("integer"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__51"

    // $ANTLR start "T__52"
    public void mT__52() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__52;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:40:7: ( 'string' )
            // MathExpr.g:40:9: 'string'
            {
            	Match("string"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__52"

    // $ANTLR start "T__53"
    public void mT__53() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__53;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:41:7: ( 'begin' )
            // MathExpr.g:41:9: 'begin'
            {
            	Match("begin"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__53"

    // $ANTLR start "T__54"
    public void mT__54() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__54;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:42:7: ( 'end' )
            // MathExpr.g:42:9: 'end'
            {
            	Match("end"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__54"

    // $ANTLR start "WS"
    public void mWS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:60:3: ( ( ' ' | '\\t' | '\\f' | '\\r' | '\\n' )+ )
            // MathExpr.g:61:3: ( ' ' | '\\t' | '\\f' | '\\r' | '\\n' )+
            {
            	// MathExpr.g:61:3: ( ' ' | '\\t' | '\\f' | '\\r' | '\\n' )+
            	int cnt1 = 0;
            	do 
            	{
            	    int alt1 = 2;
            	    int LA1_0 = input.LA(1);

            	    if ( ((LA1_0 >= '\t' && LA1_0 <= '\n') || (LA1_0 >= '\f' && LA1_0 <= '\r') || LA1_0 == ' ') )
            	    {
            	        alt1 = 1;
            	    }


            	    switch (alt1) 
            		{
            			case 1 :
            			    // MathExpr.g:
            			    {
            			    	if ( (input.LA(1) >= '\t' && input.LA(1) <= '\n') || (input.LA(1) >= '\f' && input.LA(1) <= '\r') || input.LA(1) == ' ' ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    if ( cnt1 >= 1 ) goto loop1;
            		            EarlyExitException eee1 =
            		                new EarlyExitException(1, input);
            		            throw eee1;
            	    }
            	    cnt1++;
            	} while (true);

            	loop1:
            		;	// Stops C# compiler whining that label 'loop1' has no statements


            	    _channel=HIDDEN;
            	  

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "WS"

    // $ANTLR start "ML_COMMENT"
    public void mML_COMMENT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ML_COMMENT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:66:11: ( '/*' ( options {greedy=false; } : . )* '*/' )
            // MathExpr.g:67:3: '/*' ( options {greedy=false; } : . )* '*/'
            {
            	Match("/*"); 

            	// MathExpr.g:67:8: ( options {greedy=false; } : . )*
            	do 
            	{
            	    int alt2 = 2;
            	    int LA2_0 = input.LA(1);

            	    if ( (LA2_0 == '*') )
            	    {
            	        int LA2_1 = input.LA(2);

            	        if ( (LA2_1 == '/') )
            	        {
            	            alt2 = 2;
            	        }
            	        else if ( ((LA2_1 >= '\u0000' && LA2_1 <= '.') || (LA2_1 >= '0' && LA2_1 <= '\uFFFF')) )
            	        {
            	            alt2 = 1;
            	        }


            	    }
            	    else if ( ((LA2_0 >= '\u0000' && LA2_0 <= ')') || (LA2_0 >= '+' && LA2_0 <= '\uFFFF')) )
            	    {
            	        alt2 = 1;
            	    }


            	    switch (alt2) 
            		{
            			case 1 :
            			    // MathExpr.g:67:38: .
            			    {
            			    	MatchAny(); 

            			    }
            			    break;

            			default:
            			    goto loop2;
            	    }
            	} while (true);

            	loop2:
            		;	// Stops C# compiler whining that label 'loop2' has no statements

            	Match("*/"); 


            	    _channel=HIDDEN;
            	  

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ML_COMMENT"

    // $ANTLR start "INTEGER"
    public void mINTEGER() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = INTEGER;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:72:8: ( ( ( '0' .. '9' )+ ) )
            // MathExpr.g:72:10: ( ( '0' .. '9' )+ )
            {
            	// MathExpr.g:72:10: ( ( '0' .. '9' )+ )
            	// MathExpr.g:72:11: ( '0' .. '9' )+
            	{
            		// MathExpr.g:72:11: ( '0' .. '9' )+
            		int cnt3 = 0;
            		do 
            		{
            		    int alt3 = 2;
            		    int LA3_0 = input.LA(1);

            		    if ( ((LA3_0 >= '0' && LA3_0 <= '9')) )
            		    {
            		        alt3 = 1;
            		    }


            		    switch (alt3) 
            			{
            				case 1 :
            				    // MathExpr.g:72:12: '0' .. '9'
            				    {
            				    	MatchRange('0','9'); 

            				    }
            				    break;

            				default:
            				    if ( cnt3 >= 1 ) goto loop3;
            			            EarlyExitException eee3 =
            			                new EarlyExitException(3, input);
            			            throw eee3;
            		    }
            		    cnt3++;
            		} while (true);

            		loop3:
            			;	// Stops C# compiler whining that label 'loop3' has no statements


            	}


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "INTEGER"

    // $ANTLR start "REAL"
    public void mREAL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = REAL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:74:5: ( ( '0' .. '9' )+ ( '.' ( '0' .. '9' )+ ) )
            // MathExpr.g:74:7: ( '0' .. '9' )+ ( '.' ( '0' .. '9' )+ )
            {
            	// MathExpr.g:74:7: ( '0' .. '9' )+
            	int cnt4 = 0;
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);

            	    if ( ((LA4_0 >= '0' && LA4_0 <= '9')) )
            	    {
            	        alt4 = 1;
            	    }


            	    switch (alt4) 
            		{
            			case 1 :
            			    // MathExpr.g:74:8: '0' .. '9'
            			    {
            			    	MatchRange('0','9'); 

            			    }
            			    break;

            			default:
            			    if ( cnt4 >= 1 ) goto loop4;
            		            EarlyExitException eee4 =
            		                new EarlyExitException(4, input);
            		            throw eee4;
            	    }
            	    cnt4++;
            	} while (true);

            	loop4:
            		;	// Stops C# compiler whining that label 'loop4' has no statements

            	// MathExpr.g:74:19: ( '.' ( '0' .. '9' )+ )
            	// MathExpr.g:74:20: '.' ( '0' .. '9' )+
            	{
            		Match('.'); 
            		// MathExpr.g:74:24: ( '0' .. '9' )+
            		int cnt5 = 0;
            		do 
            		{
            		    int alt5 = 2;
            		    int LA5_0 = input.LA(1);

            		    if ( ((LA5_0 >= '0' && LA5_0 <= '9')) )
            		    {
            		        alt5 = 1;
            		    }


            		    switch (alt5) 
            			{
            				case 1 :
            				    // MathExpr.g:74:25: '0' .. '9'
            				    {
            				    	MatchRange('0','9'); 

            				    }
            				    break;

            				default:
            				    if ( cnt5 >= 1 ) goto loop5;
            			            EarlyExitException eee5 =
            			                new EarlyExitException(5, input);
            			            throw eee5;
            		    }
            		    cnt5++;
            		} while (true);

            		loop5:
            			;	// Stops C# compiler whining that label 'loop5' has no statements


            	}


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "REAL"

    // $ANTLR start "STRING"
    public void mSTRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = STRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:76:8: ( '\"' ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )+ '\"' )
            // MathExpr.g:76:10: '\"' ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )+ '\"'
            {
            	Match('\"'); 
            	// MathExpr.g:76:14: ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )+
            	int cnt6 = 0;
            	do 
            	{
            	    int alt6 = 2;
            	    int LA6_0 = input.LA(1);

            	    if ( ((LA6_0 >= '0' && LA6_0 <= '9') || (LA6_0 >= 'A' && LA6_0 <= 'Z') || LA6_0 == '_' || (LA6_0 >= 'a' && LA6_0 <= 'z')) )
            	    {
            	        alt6 = 1;
            	    }


            	    switch (alt6) 
            		{
            			case 1 :
            			    // MathExpr.g:
            			    {
            			    	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || input.LA(1) == '_' || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    if ( cnt6 >= 1 ) goto loop6;
            		            EarlyExitException eee6 =
            		                new EarlyExitException(6, input);
            		            throw eee6;
            	    }
            	    cnt6++;
            	} while (true);

            	loop6:
            		;	// Stops C# compiler whining that label 'loop6' has no statements

            	Match('\"'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "STRING"

    // $ANTLR start "IDENT"
    public void mIDENT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = IDENT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:79:6: ( ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )* )
            // MathExpr.g:79:9: ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )*
            {
            	if ( (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || input.LA(1) == '_' || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}

            	// MathExpr.g:80:9: ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )*
            	do 
            	{
            	    int alt7 = 2;
            	    int LA7_0 = input.LA(1);

            	    if ( ((LA7_0 >= '0' && LA7_0 <= '9') || (LA7_0 >= 'A' && LA7_0 <= 'Z') || LA7_0 == '_' || (LA7_0 >= 'a' && LA7_0 <= 'z')) )
            	    {
            	        alt7 = 1;
            	    }


            	    switch (alt7) 
            		{
            			case 1 :
            			    // MathExpr.g:
            			    {
            			    	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || input.LA(1) == '_' || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    goto loop7;
            	    }
            	} while (true);

            	loop7:
            		;	// Stops C# compiler whining that label 'loop7' has no statements


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "IDENT"

    // $ANTLR start "ADD"
    public void mADD() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ADD;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:82:4: ( '+' )
            // MathExpr.g:82:9: '+'
            {
            	Match('+'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ADD"

    // $ANTLR start "SUB"
    public void mSUB() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SUB;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:83:4: ( '-' )
            // MathExpr.g:83:9: '-'
            {
            	Match('-'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "SUB"

    // $ANTLR start "MUL"
    public void mMUL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MUL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:84:4: ( '*' )
            // MathExpr.g:84:9: '*'
            {
            	Match('*'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MUL"

    // $ANTLR start "DIV"
    public void mDIV() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DIV;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:85:4: ( '/' )
            // MathExpr.g:85:9: '/'
            {
            	Match('/'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DIV"

    // $ANTLR start "ASSIGN"
    public void mASSIGN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ASSIGN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:86:7: ( ':=' )
            // MathExpr.g:86:9: ':='
            {
            	Match(":="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ASSIGN"

    // $ANTLR start "COMPARE"
    public void mCOMPARE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = COMPARE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // MathExpr.g:87:8: ( '>' | '>=' | '<' | '<=' | '=' | '<>' )
            int alt8 = 6;
            switch ( input.LA(1) ) 
            {
            case '>':
            	{
                int LA8_1 = input.LA(2);

                if ( (LA8_1 == '=') )
                {
                    alt8 = 2;
                }
                else 
                {
                    alt8 = 1;}
                }
                break;
            case '<':
            	{
                switch ( input.LA(2) ) 
                {
                case '=':
                	{
                    alt8 = 4;
                    }
                    break;
                case '>':
                	{
                    alt8 = 6;
                    }
                    break;
                	default:
                    	alt8 = 3;
                    	break;}

                }
                break;
            case '=':
            	{
                alt8 = 5;
                }
                break;
            	default:
            	    NoViableAltException nvae_d8s0 =
            	        new NoViableAltException("", 8, 0, input);

            	    throw nvae_d8s0;
            }

            switch (alt8) 
            {
                case 1 :
                    // MathExpr.g:87:10: '>'
                    {
                    	Match('>'); 

                    }
                    break;
                case 2 :
                    // MathExpr.g:87:16: '>='
                    {
                    	Match(">="); 


                    }
                    break;
                case 3 :
                    // MathExpr.g:87:23: '<'
                    {
                    	Match('<'); 

                    }
                    break;
                case 4 :
                    // MathExpr.g:87:29: '<='
                    {
                    	Match("<="); 


                    }
                    break;
                case 5 :
                    // MathExpr.g:87:36: '='
                    {
                    	Match('='); 

                    }
                    break;
                case 6 :
                    // MathExpr.g:87:42: '<>'
                    {
                    	Match("<>"); 


                    }
                    break;

            }
            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "COMPARE"

    override public void mTokens() // throws RecognitionException 
    {
        // MathExpr.g:1:8: ( VAR | INC | DEC | FUNCTION | PROCEDURE | FOR | REPEAT | UNTIL | TO | DO | WHILE | IF | THEN | ELSE | DIV_INT | MOD_INT | AND | OR | XOR | DDD | TTT | T__42 | T__43 | T__44 | T__45 | T__46 | T__47 | T__48 | T__49 | T__50 | T__51 | T__52 | T__53 | T__54 | WS | ML_COMMENT | INTEGER | REAL | STRING | IDENT | ADD | SUB | MUL | DIV | ASSIGN | COMPARE )
        int alt9 = 46;
        alt9 = dfa9.Predict(input);
        switch (alt9) 
        {
            case 1 :
                // MathExpr.g:1:10: VAR
                {
                	mVAR(); 

                }
                break;
            case 2 :
                // MathExpr.g:1:14: INC
                {
                	mINC(); 

                }
                break;
            case 3 :
                // MathExpr.g:1:18: DEC
                {
                	mDEC(); 

                }
                break;
            case 4 :
                // MathExpr.g:1:22: FUNCTION
                {
                	mFUNCTION(); 

                }
                break;
            case 5 :
                // MathExpr.g:1:31: PROCEDURE
                {
                	mPROCEDURE(); 

                }
                break;
            case 6 :
                // MathExpr.g:1:41: FOR
                {
                	mFOR(); 

                }
                break;
            case 7 :
                // MathExpr.g:1:45: REPEAT
                {
                	mREPEAT(); 

                }
                break;
            case 8 :
                // MathExpr.g:1:52: UNTIL
                {
                	mUNTIL(); 

                }
                break;
            case 9 :
                // MathExpr.g:1:58: TO
                {
                	mTO(); 

                }
                break;
            case 10 :
                // MathExpr.g:1:61: DO
                {
                	mDO(); 

                }
                break;
            case 11 :
                // MathExpr.g:1:64: WHILE
                {
                	mWHILE(); 

                }
                break;
            case 12 :
                // MathExpr.g:1:70: IF
                {
                	mIF(); 

                }
                break;
            case 13 :
                // MathExpr.g:1:73: THEN
                {
                	mTHEN(); 

                }
                break;
            case 14 :
                // MathExpr.g:1:78: ELSE
                {
                	mELSE(); 

                }
                break;
            case 15 :
                // MathExpr.g:1:83: DIV_INT
                {
                	mDIV_INT(); 

                }
                break;
            case 16 :
                // MathExpr.g:1:91: MOD_INT
                {
                	mMOD_INT(); 

                }
                break;
            case 17 :
                // MathExpr.g:1:99: AND
                {
                	mAND(); 

                }
                break;
            case 18 :
                // MathExpr.g:1:103: OR
                {
                	mOR(); 

                }
                break;
            case 19 :
                // MathExpr.g:1:106: XOR
                {
                	mXOR(); 

                }
                break;
            case 20 :
                // MathExpr.g:1:110: DDD
                {
                	mDDD(); 

                }
                break;
            case 21 :
                // MathExpr.g:1:114: TTT
                {
                	mTTT(); 

                }
                break;
            case 22 :
                // MathExpr.g:1:118: T__42
                {
                	mT__42(); 

                }
                break;
            case 23 :
                // MathExpr.g:1:124: T__43
                {
                	mT__43(); 

                }
                break;
            case 24 :
                // MathExpr.g:1:130: T__44
                {
                	mT__44(); 

                }
                break;
            case 25 :
                // MathExpr.g:1:136: T__45
                {
                	mT__45(); 

                }
                break;
            case 26 :
                // MathExpr.g:1:142: T__46
                {
                	mT__46(); 

                }
                break;
            case 27 :
                // MathExpr.g:1:148: T__47
                {
                	mT__47(); 

                }
                break;
            case 28 :
                // MathExpr.g:1:154: T__48
                {
                	mT__48(); 

                }
                break;
            case 29 :
                // MathExpr.g:1:160: T__49
                {
                	mT__49(); 

                }
                break;
            case 30 :
                // MathExpr.g:1:166: T__50
                {
                	mT__50(); 

                }
                break;
            case 31 :
                // MathExpr.g:1:172: T__51
                {
                	mT__51(); 

                }
                break;
            case 32 :
                // MathExpr.g:1:178: T__52
                {
                	mT__52(); 

                }
                break;
            case 33 :
                // MathExpr.g:1:184: T__53
                {
                	mT__53(); 

                }
                break;
            case 34 :
                // MathExpr.g:1:190: T__54
                {
                	mT__54(); 

                }
                break;
            case 35 :
                // MathExpr.g:1:196: WS
                {
                	mWS(); 

                }
                break;
            case 36 :
                // MathExpr.g:1:199: ML_COMMENT
                {
                	mML_COMMENT(); 

                }
                break;
            case 37 :
                // MathExpr.g:1:210: INTEGER
                {
                	mINTEGER(); 

                }
                break;
            case 38 :
                // MathExpr.g:1:218: REAL
                {
                	mREAL(); 

                }
                break;
            case 39 :
                // MathExpr.g:1:223: STRING
                {
                	mSTRING(); 

                }
                break;
            case 40 :
                // MathExpr.g:1:230: IDENT
                {
                	mIDENT(); 

                }
                break;
            case 41 :
                // MathExpr.g:1:236: ADD
                {
                	mADD(); 

                }
                break;
            case 42 :
                // MathExpr.g:1:240: SUB
                {
                	mSUB(); 

                }
                break;
            case 43 :
                // MathExpr.g:1:244: MUL
                {
                	mMUL(); 

                }
                break;
            case 44 :
                // MathExpr.g:1:248: DIV
                {
                	mDIV(); 

                }
                break;
            case 45 :
                // MathExpr.g:1:252: ASSIGN
                {
                	mASSIGN(); 

                }
                break;
            case 46 :
                // MathExpr.g:1:259: COMPARE
                {
                	mCOMPARE(); 

                }
                break;

        }

    }


    protected DFA9 dfa9;
	private void InitializeCyclicDFAs()
	{
	    this.dfa9 = new DFA9(this);
	}

    const string DFA9_eotS =
        "\x01\uffff\x0e\x1d\x01\x39\x07\uffff\x02\x1d\x01\uffff\x01\x3d"+
        "\x01\x3e\x06\uffff\x02\x1d\x01\x43\x01\x1d\x01\x45\x06\x1d\x01\x4d"+
        "\x07\x1d\x01\x55\x01\x56\x01\x1d\x02\uffff\x02\x1d\x04\uffff\x01"+
        "\x5a\x01\x5b\x01\x1d\x01\uffff\x01\x5d\x01\uffff\x01\x5e\x01\x1d"+
        "\x01\x60\x04\x1d\x01\uffff\x03\x1d\x01\x68\x01\x69\x01\x6a\x01\x1d"+
        "\x02\uffff\x01\x6c\x02\x1d\x02\uffff\x01\x1d\x02\uffff\x01\x1d\x01"+
        "\uffff\x02\x1d\x01\x73\x01\x1d\x01\x75\x01\x1d\x01\x77\x03\uffff"+
        "\x01\x1d\x01\uffff\x06\x1d\x01\uffff\x01\x7f\x01\uffff\x01\u0080"+
        "\x01\uffff\x01\u0081\x01\x1d\x01\u0083\x03\x1d\x01\u0087\x03\uffff"+
        "\x01\u0088\x01\uffff\x01\u0089\x02\x1d\x03\uffff\x01\u008c\x01\x1d"+
        "\x01\uffff\x01\u008e\x01\uffff";
    const string DFA9_eofS =
        "\u008f\uffff";
    const string DFA9_minS =
        "\x01\x09\x01\x61\x01\x66\x01\x65\x01\x6f\x01\x72\x01\x65\x01\x6e"+
        "\x02\x68\x01\x6c\x01\x6f\x01\x6e\x01\x66\x01\x6f\x01\x3d\x07\uffff"+
        "\x01\x74\x01\x65\x01\uffff\x01\x2a\x01\x2e\x06\uffff\x01\x72\x01"+
        "\x63\x01\x30\x01\x63\x01\x30\x01\x76\x01\x6e\x01\x72\x01\x6f\x01"+
        "\x61\x01\x74\x01\x30\x01\x65\x01\x69\x01\x73\x03\x64\x01\x72\x02"+
        "\x30\x01\x72\x02\uffff\x01\x72\x01\x67\x04\uffff\x02\x30\x01\x65"+
        "\x01\uffff\x01\x30\x01\uffff\x01\x30\x01\x63\x01\x30\x01\x63\x01"+
        "\x65\x01\x6c\x01\x69\x01\uffff\x01\x6e\x01\x6c\x01\x65\x03\x30\x01"+
        "\x61\x02\uffff\x01\x30\x02\x69\x02\uffff\x01\x67\x02\uffff\x01\x74"+
        "\x01\uffff\x01\x65\x01\x61\x01\x30\x01\x6c\x01\x30\x01\x65\x01\x30"+
        "\x03\uffff\x01\x79\x01\uffff\x02\x6e\x01\x65\x01\x69\x01\x64\x01"+
        "\x74\x01\uffff\x01\x30\x01\uffff\x01\x30\x01\uffff\x01\x30\x01\x67"+
        "\x01\x30\x01\x72\x01\x6f\x01\x75\x01\x30\x03\uffff\x01\x30\x01\uffff"+
        "\x01\x30\x01\x6e\x01\x72\x03\uffff\x01\x30\x01\x65\x01\uffff\x01"+
        "\x30\x01\uffff";
    const string DFA9_maxS =
        "\x01\x7a\x01\x61\x01\x6e\x01\x6f\x01\x75\x01\x72\x01\x65\x01\x6e"+
        "\x01\x6f\x01\x68\x01\x6e\x01\x6f\x02\x72\x01\x6f\x01\x3d\x07\uffff"+
        "\x01\x74\x01\x65\x01\uffff\x01\x2a\x01\x39\x06\uffff\x01\x72\x01"+
        "\x74\x01\x7a\x01\x63\x01\x7a\x01\x76\x01\x6e\x01\x72\x01\x6f\x01"+
        "\x70\x01\x74\x01\x7a\x01\x65\x01\x69\x01\x73\x03\x64\x01\x72\x02"+
        "\x7a\x01\x72\x02\uffff\x01\x72\x01\x67\x04\uffff\x02\x7a\x01\x65"+
        "\x01\uffff\x01\x7a\x01\uffff\x01\x7a\x01\x63\x01\x7a\x01\x63\x01"+
        "\x65\x01\x6c\x01\x69\x01\uffff\x01\x6e\x01\x6c\x01\x65\x03\x7a\x01"+
        "\x61\x02\uffff\x01\x7a\x02\x69\x02\uffff\x01\x67\x02\uffff\x01\x74"+
        "\x01\uffff\x01\x65\x01\x61\x01\x7a\x01\x6c\x01\x7a\x01\x65\x01\x7a"+
        "\x03\uffff\x01\x79\x01\uffff\x02\x6e\x01\x65\x01\x69\x01\x64\x01"+
        "\x74\x01\uffff\x01\x7a\x01\uffff\x01\x7a\x01\uffff\x01\x7a\x01\x67"+
        "\x01\x7a\x01\x72\x01\x6f\x01\x75\x01\x7a\x03\uffff\x01\x7a\x01\uffff"+
        "\x01\x7a\x01\x6e\x01\x72\x03\uffff\x01\x7a\x01\x65\x01\uffff\x01"+
        "\x7a\x01\uffff";
    const string DFA9_acceptS =
        "\x10\uffff\x01\x15\x01\x16\x01\x17\x01\x18\x01\x1a\x01\x1b\x01"+
        "\x1c\x02\uffff\x01\x23\x02\uffff\x01\x27\x01\x28\x01\x29\x01\x2a"+
        "\x01\x2b\x01\x2e\x16\uffff\x01\x2d\x01\x14\x02\uffff\x01\x24\x01"+
        "\x2c\x01\x25\x01\x26\x03\uffff\x01\x0c\x01\uffff\x01\x0a\x07\uffff"+
        "\x01\x09\x07\uffff\x01\x12\x01\x1d\x03\uffff\x01\x01\x01\x02\x01"+
        "\uffff\x01\x03\x01\x0f\x01\uffff\x01\x06\x07\uffff\x01\x22\x01\x10"+
        "\x01\x11\x01\uffff\x01\x13\x06\uffff\x01\x1e\x01\uffff\x01\x0d\x01"+
        "\uffff\x01\x0e\x07\uffff\x01\x08\x01\x0b\x01\x19\x01\uffff\x01\x21"+
        "\x03\uffff\x01\x07\x01\x20\x01\x1f\x02\uffff\x01\x04\x01\uffff\x01"+
        "\x05";
    const string DFA9_specialS =
        "\u008f\uffff}>";
    static readonly string[] DFA9_transitionS = {
            "\x02\x19\x01\uffff\x02\x19\x12\uffff\x01\x19\x01\uffff\x01"+
            "\x1c\x05\uffff\x01\x11\x01\x12\x01\x20\x01\x1e\x01\x13\x01\x1f"+
            "\x01\x15\x01\x1a\x0a\x1b\x01\x0f\x01\x10\x03\x21\x02\uffff\x1a"+
            "\x1d\x01\x14\x01\uffff\x01\x16\x01\uffff\x01\x1d\x01\uffff\x01"+
            "\x0c\x01\x18\x01\x1d\x01\x03\x01\x0a\x01\x04\x02\x1d\x01\x02"+
            "\x03\x1d\x01\x0b\x01\x1d\x01\x0d\x01\x05\x01\x1d\x01\x06\x01"+
            "\x17\x01\x08\x01\x07\x01\x01\x01\x09\x01\x0e\x02\x1d",
            "\x01\x22",
            "\x01\x24\x07\uffff\x01\x23",
            "\x01\x25\x03\uffff\x01\x27\x05\uffff\x01\x26",
            "\x01\x29\x05\uffff\x01\x28",
            "\x01\x2a",
            "\x01\x2b",
            "\x01\x2c",
            "\x01\x2e\x06\uffff\x01\x2d",
            "\x01\x2f",
            "\x01\x30\x01\uffff\x01\x31",
            "\x01\x32",
            "\x01\x33\x03\uffff\x01\x34",
            "\x01\x36\x0b\uffff\x01\x35",
            "\x01\x37",
            "\x01\x38",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x3a",
            "\x01\x3b",
            "",
            "\x01\x3c",
            "\x01\x3f\x01\uffff\x0a\x1b",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x40",
            "\x01\x41\x10\uffff\x01\x42",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "\x01\x44",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "\x01\x46",
            "\x01\x47",
            "\x01\x48",
            "\x01\x49",
            "\x01\x4b\x0e\uffff\x01\x4a",
            "\x01\x4c",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "\x01\x4e",
            "\x01\x4f",
            "\x01\x50",
            "\x01\x51",
            "\x01\x52",
            "\x01\x53",
            "\x01\x54",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "\x01\x57",
            "",
            "",
            "\x01\x58",
            "\x01\x59",
            "",
            "",
            "",
            "",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "\x01\x5c",
            "",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "\x01\x5f",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "\x01\x61",
            "\x01\x62",
            "\x01\x63",
            "\x01\x64",
            "",
            "\x01\x65",
            "\x01\x66",
            "\x01\x67",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "\x01\x6b",
            "",
            "",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "\x01\x6d",
            "\x01\x6e",
            "",
            "",
            "\x01\x6f",
            "",
            "",
            "\x01\x70",
            "",
            "\x01\x71",
            "\x01\x72",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "\x01\x74",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "\x01\x76",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "",
            "",
            "",
            "\x01\x78",
            "",
            "\x01\x79",
            "\x01\x7a",
            "\x01\x7b",
            "\x01\x7c",
            "\x01\x7d",
            "\x01\x7e",
            "",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "\x01\u0082",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "\x01\u0084",
            "\x01\u0085",
            "\x01\u0086",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "",
            "",
            "",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "\x01\u008a",
            "\x01\u008b",
            "",
            "",
            "",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            "\x01\u008d",
            "",
            "\x0a\x1d\x07\uffff\x1a\x1d\x04\uffff\x01\x1d\x01\uffff\x1a"+
            "\x1d",
            ""
    };

    static readonly short[] DFA9_eot = DFA.UnpackEncodedString(DFA9_eotS);
    static readonly short[] DFA9_eof = DFA.UnpackEncodedString(DFA9_eofS);
    static readonly char[] DFA9_min = DFA.UnpackEncodedStringToUnsignedChars(DFA9_minS);
    static readonly char[] DFA9_max = DFA.UnpackEncodedStringToUnsignedChars(DFA9_maxS);
    static readonly short[] DFA9_accept = DFA.UnpackEncodedString(DFA9_acceptS);
    static readonly short[] DFA9_special = DFA.UnpackEncodedString(DFA9_specialS);
    static readonly short[][] DFA9_transition = DFA.UnpackEncodedStringArray(DFA9_transitionS);

    protected class DFA9 : DFA
    {
        public DFA9(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 9;
            this.eot = DFA9_eot;
            this.eof = DFA9_eof;
            this.min = DFA9_min;
            this.max = DFA9_max;
            this.accept = DFA9_accept;
            this.special = DFA9_special;
            this.transition = DFA9_transition;

        }

        override public string Description
        {
            get { return "1:1: Tokens : ( VAR | INC | DEC | FUNCTION | PROCEDURE | FOR | REPEAT | UNTIL | TO | DO | WHILE | IF | THEN | ELSE | DIV_INT | MOD_INT | AND | OR | XOR | DDD | TTT | T__42 | T__43 | T__44 | T__45 | T__46 | T__47 | T__48 | T__49 | T__50 | T__51 | T__52 | T__53 | T__54 | WS | ML_COMMENT | INTEGER | REAL | STRING | IDENT | ADD | SUB | MUL | DIV | ASSIGN | COMPARE );"; }
        }

    }

 
    
}
}