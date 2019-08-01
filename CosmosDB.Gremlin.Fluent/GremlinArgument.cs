using System;

namespace CosmosDB.Gremlin.Fluent
{
    public class GremlinArgument : IGremlinParameter
    {
        public virtual string Value => ArgumentName;

        public object ArgumentValue { get; }
        public string ArgumentName { get; }
        
        public GremlinArgument(string argumentName, object argumentValue)
        {
            if (argumentName == null)
                throw new ArgumentNullException(nameof(argumentName));
            if (argumentValue == null)
                throw new ArgumentNullException(nameof(argumentValue));
            if (string.IsNullOrWhiteSpace(argumentName))
                throw new GremlinParameterException("Argument name cannot be blank");

            ArgumentName = argumentName;
            ArgumentValue = argumentValue;
        }
    }
}