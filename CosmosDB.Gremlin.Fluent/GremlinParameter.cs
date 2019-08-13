﻿namespace CosmosDB.Gremlin.Fluent
{
    public class GremlinParameter : IGremlinParameter
    {
        public virtual string QueryStringValue { get; }
        public virtual object TrueValue { get; }

        public GremlinParameter(string parameter)
        {
            QueryStringValue = $"'{Sanitize(parameter)}'";
            TrueValue = parameter;
        }

        public GremlinParameter(int parameter)
        {
            QueryStringValue = $"{parameter}";
            TrueValue = parameter;
        }
        
        public GremlinParameter(long parameter)
        {
            QueryStringValue = $"{parameter}";
            TrueValue = parameter;
        }
        
        public GremlinParameter(double parameter)
        {
            QueryStringValue = $"{parameter}";
            TrueValue = parameter;
        }

        public GremlinParameter(float parameter)
        {
            QueryStringValue = $"{parameter}";
            TrueValue = parameter;
        }

        public GremlinParameter(bool parameter)
        {
            QueryStringValue = $"{parameter}".ToLowerInvariant();
            TrueValue = parameter;
        }

        public GremlinParameter(byte parameter)
        {
            QueryStringValue = $"{parameter}";
            TrueValue = parameter;
        }

        public static implicit operator GremlinParameter(int parameter)
        {
            return new GremlinParameter(parameter);
        }
        
        public static implicit operator GremlinParameter(string parameter)
        {
            return new GremlinParameter(parameter);
        }
        
        public static implicit operator GremlinParameter(bool parameter)
        {
            return new GremlinParameter(parameter);
        }
        
        public static implicit operator GremlinParameter(long parameter)
        {
            return new GremlinParameter(parameter);
        }
        
        public static implicit operator GremlinParameter(double parameter)
        {
            return new GremlinParameter(parameter);
        }

        public static implicit operator GremlinParameter(float parameter)
        {
            return new GremlinParameter(parameter);
        }

        public static implicit operator GremlinParameter(byte parameter)
        {
            return new GremlinParameter(parameter);
        }

        protected virtual string Sanitize(string parameter)
        {
            if (string.IsNullOrEmpty(parameter))
                throw new GremlinParameterException($"{nameof(parameter)} cannot be null");

            return parameter.Replace("'", string.Empty);
        }
    }
}
