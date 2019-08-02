using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class BetweenFunction
    {
        public static GremlinQueryBuilder Between(this GremlinQueryBuilder builder, IGremlinParameter start, IGremlinParameter end)
        {
            if (start == null)
                throw new ArgumentNullException(nameof(start));
            if (end == null)
                throw new ArgumentNullException(nameof(end));
            if (!int.TryParse(start.Value, out _))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Between)} only supports integer parameters '{start.Value}' does not appear to conform to this");
            if (!int.TryParse(end.Value, out _))
                throw new GremlinQueryBuilderException(
                    $"{nameof(Between)} only supports integer parameters '{end.Value}' does not appear to conform to this");

            
            builder.AddArgument(start as GremlinArgument);
            builder.AddArgument(end as GremlinArgument);
            return builder.Add($"between({start.Value},{end.Value})");
        }
        
        // for implicit conversion operators
        public static GremlinQueryBuilder Between(this GremlinQueryBuilder builder, GremlinParameter start, GremlinParameter end)
        {
            return builder.Between((IGremlinParameter)start,(IGremlinParameter)end);
        }
    }
}