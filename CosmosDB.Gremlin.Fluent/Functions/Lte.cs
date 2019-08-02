using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class LteFunction
    {
        public static GremlinQueryBuilder Lte(this GremlinQueryBuilder builder, GremlinQueryBuilder inner)
        {
            if (inner == null)
                return builder;
            builder.AddArguments(inner.GremlinArguments);
            return builder.Add($"lte({inner.Query})");
        }

        public static GremlinQueryBuilder Lte(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (!long.TryParse(parameter.Value, out _))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Lte)} only supports numeric parameters and '{parameter.Value}' does not appear to conform to this");

            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"lte({parameter.Value})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder Lte(this GremlinQueryBuilder builder, GremlinParameter parameter)
        {
            return builder.Lte((IGremlinParameter)parameter);
        }
    }
}