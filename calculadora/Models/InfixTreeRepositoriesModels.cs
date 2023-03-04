using System;
using System.Collections.Generic;
using System.Linq;

namespace calculadora.Models
{
	public class InfixTreeRepositoriesModels
	{
		public InfixTreeRepositoriesModels()
		{

		}
   

        public static List<char> operations = new List<char>()
        {
            '+',
            'x',
            '-',
            '÷',
            '^',
            's', //seno
            'c', //cosseno
            'l',
            'L',
            'm', //mod
            'f', // fatorial
            '%',
            'e'

        };

        public static int opCentral(String s)
        {
            s = s.Remove(0,1);
            s = s.Remove(s.Length - 1,1);
            
            int parentesesAbertos = 0;
            int p = 0;

            while (p < s.Length)
            {
                if (s[p] == '(') parentesesAbertos++;
                if (s[p] == ')') parentesesAbertos--;
                if (parentesesAbertos == 0 & InfixTreeRepositoriesModels.operations.Contains(s[p])) return p+1;

                p++;
            }

            return -1;
        }
        
        public static double factorial(double n){
            if (n <= 1.0) return 1;
            else return n*factorial(n-1);
        }

        private static int findExpressionSize(string s, int i)
        {
            int parentesesLiquidos = 0;
            int tamanhoExpressao = 0;
            do
            {
                if (s[i + tamanhoExpressao] == '(') parentesesLiquidos++;
                else if (s[i + tamanhoExpressao] == ')') parentesesLiquidos--;
                tamanhoExpressao++;

            } while (parentesesLiquidos != 0);
            return tamanhoExpressao;
        }

        public static void append(ref string formatted, string s,int expSize, ref int i, string codigoOperacao)
        {
            int size = findExpressionSize(s, i + expSize);
            string argumento = s.Substring(i + expSize, size);
            int numOuOp = opCentral(argumento);
            if (numOuOp == -1) formatted = formatted + '(' + codigoOperacao + s.Substring(i + 1 + expSize, size - 2) + ')';
            else formatted = formatted + '(' + codigoOperacao + s.Substring(i + expSize, size) + ')';

            i = i + expSize - 1 + size;
        }

        public static bool isFormatted(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {


                if (s[i] == 'c' && s[i + 1] == 'o' && s[i + 2] == 's') return false;
                else if (s[i] == 's' && s[i + 1] == 'e' && s[i + 2] == 'n') return false;
                else if (s[i] == 'l' && s[i + 1] == 'n') return false;
                else if (s[i] == 'l' && s[i + 1] == 'o' && s[i + 2] == 'g') return false;
                else if (s[i] == 'f' && s[i + 1] == 'a' && s[i + 2] == 'c' && s[i + 3] == 't') return false;
                else if (s[i] == 'p' && s[i + 1] == 'i') return false;
                else if (s[i] == 'm' && s[i + 1] == 'o' && s[i + 2] == 'd') return false;
                else if (s[i] == 'e' && s[i + 1] == 'x' && s[i + 2] == 'p') return false;
                else if (s[i] == ('(') && s[i + 1] == '-') return false;

            }

            return true;
            
        }
        public static string format(string s)
        {
            String formatted = "";

            for (int i = 0; i < s.Length; i++)
            {


                if (s[i] == 'c' && s[i+1] == 'o' && s[i+2] == 's')
                {
                    append(ref formatted, s, 3, ref i, "1c");
                }

                else if (s[i] == 's' && s[i + 1] == 'e' && s[i + 2] == 'n')
                {
                    append(ref formatted, s, 3, ref i, "1s");
                }
                else if (s[i] == 'l' && s[i + 1] == 'n')
                {
                    append(ref formatted, s, 2, ref i, "1l");
                }
                else if (s[i] == 'l' && s[i + 1] == 'o' && s[i + 2] == 'g')
                {
                    append(ref formatted, s, 3, ref i, "1L");
                }
                else if (s[i] == 'f' && s[i + 1] == 'a' && s[i + 2] == 'c' && s[i + 3] == 't')
                {
                    append(ref formatted, s, 4, ref i, "1f");
                }

                else if (s[i] == 'p' && s[i + 1] == 'i')
                {
                    formatted = formatted + "3.141592";
                    i = i + 1;
                }

                else if (s[i] == 'm' && s[i + 1] == 'o' && s[i + 2] == 'd')
                {
                    formatted = formatted + "m";
                    i = i + 2;
                }
                else if (s[i] == ('(') && s[i+1] == '-')
                {
                    formatted = formatted + "(0-";
                    i = i + 1;
                }
                else if (s[i] == 'e' && s[i + 1] == 'x' && s[i + 2] == 'p')
                {
                    append(ref formatted, s, 3, ref i, "1e");
                }
                else formatted += s[i];

            }


            int parentesesAbertos = 0;
            int p = 0;

            while (p < formatted.Length)
            {
                if (formatted[p] == '(') parentesesAbertos++;
                if (formatted[p] == ')') parentesesAbertos--;
                if (parentesesAbertos == 0 && p != formatted.Length -1)
                {
                    formatted = formatted + ')';
                    formatted = '(' + formatted;
                    break;
                }

                p++;
            }



            return formatted;
        }



      


    }
}

