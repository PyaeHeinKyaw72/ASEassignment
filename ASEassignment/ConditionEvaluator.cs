using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEassignment
{
    public class ConditionEvaluator
    {
        private Dictionary<string, int> assignedVariables;

        public ConditionEvaluator(Dictionary<string, int> variables)
        {
            assignedVariables = variables;
        }

        public bool EvaluateCondition(string[] command)
        {
            if (command.Length == 4)
            {
                int leftValue;
                int rightValue;

                // Try to parse left operand or get its value from assigned variables
                if (int.TryParse(command[1], out leftValue) || assignedVariables.TryGetValue(command[1].ToLower(), out leftValue))
                {
                    // Try to parse right operand or get its value from assigned variables
                    if (int.TryParse(command[3], out rightValue) || assignedVariables.TryGetValue(command[3].ToLower(), out rightValue))
                    {
                        // Compare based on the operator
                        switch (command[2])
                        {
                            case "==":
                                return leftValue == rightValue;

                            case "!=":
                                return leftValue != rightValue;

                            case "<":
                                return leftValue < rightValue;

                            case ">":
                                return leftValue > rightValue;

                            case "<=":
                                return leftValue <= rightValue;

                            case ">=":
                                return leftValue >= rightValue;

                            default:
                                throw new InvalidOperationException($"Unsupported operator: {command[2]}");
                        }
                    }
                }
            }

            // If the condition is not in the expected format, return false
            return false;
        }
    }
}
