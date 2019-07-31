﻿using System;

namespace CosmosDB.Gremlin.Fluent.Functions
{
    public static class AddEFunction
    {
        public static GremlinQueryBuilder AddE(this GremlinQueryBuilder builder, IGremlinParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            
            builder.AddArgument(parameter as GremlinArgument);
            return builder.Add($"addE({parameter.Value})");
        }
    }
}
