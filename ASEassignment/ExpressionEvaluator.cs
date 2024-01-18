using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASEassignment
{
    public class ExpressionEvaluator
    {
        private Dictionary<string, int> variables;

        public ExpressionEvaluator(Dictionary<string, int> variables)
        {
            this.variables = variables;
        }

        public int Evaluate(string expression)
        {
            try
            {
                return EvaluateExpression(expression);
            }
            catch (Exception ex)
            {
                // Handle the case when expression evaluation fails
                MessageBox.Show($"Error: {ex.Message}", "Expression Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private int EvaluateExpression(string expression)
        {
            // Split the expression into terms separated by operators
            string[] terms = expression.Split('+', '-', '*', '/');

            // Initialize result with the first term
            int result = EvaluateTerm(terms[0]);

            // Process the remaining terms and operators
            for (int i = 1; i < terms.Length; i++)
            {
                char op = expression[terms[i - 1].Length];
                int termValue = EvaluateTerm(terms[i]);

                // Apply the operator
                switch (op)
                {
                    case '+':
                        result += termValue;
                        break;
                    case '-':
                        result -= termValue;
                        break;
                    case '*':
                        result *= termValue;
                        break;
                    case '/':
                        result /= termValue;
                        break;
                }
            }

            return result;
        }

        private int EvaluateTerm(string term)
        {
            // Check if the term is a variable
            if (variables.ContainsKey(term.ToLower()))
            {
                return variables[term.ToLower()];
            }

            // If not a variable, try parsing as an integer
            if (int.TryParse(term, out int value))
            {
                return value;
            }

            // If not a variable or integer, throw an exception
            throw new InvalidOperationException($"Invalid term: '{term}'");
        }
    }
}
