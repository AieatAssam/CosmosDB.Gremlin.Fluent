﻿using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class AggregateFunction
    {
        public static GremlinQueryBuilder Aggregate(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"aggregate({parameter.Value})");
        }
    }
}
