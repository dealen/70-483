using HelpersLibrary;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ReflectionTests.ExpressionTrees
{
    public class CreatingHelloWorld : IRun
    {
        public void Run()
        {
            BuildingHelloWorldWithExpressionTree();
        }

        private void BuildingHelloWorldWithExpressionTree()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            BlockExpression blockExpr = Expression.Block(
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("Write", new Type[] { typeof(String) }),
                    Expression.Constant("Hello ")
                    ),
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                    Expression.Constant("World!")
                    ),
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                    Expression.Constant("He he")
                    )
                );

            var exp = Expression.Lambda<Action>(blockExpr).Compile();
            exp.Invoke();
        }
    }
}
